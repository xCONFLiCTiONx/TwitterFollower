using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwitterFollower
{
    internal class Follow : IDisposable
    {
        private const string TwitterApiBaseUrl = "https://api.twitter.com/1.1/";
        private readonly HMACSHA1 sigHasher;
        private readonly DateTime epochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly string _API_KEY;
        private readonly string _ACCESS_TOKEN;
        private readonly string _BEARER_TOKEN;

        internal Follow(string API_KEY, string ACCESS_TOKEN, string API_SECRET_KEY, string ACCESS_TOKEN_SECRET, string BEARER_TOKEN)
        {
            _API_KEY = API_KEY;
            _ACCESS_TOKEN = ACCESS_TOKEN;
            sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", API_SECRET_KEY, ACCESS_TOKEN_SECRET)));
            _BEARER_TOKEN = BEARER_TOKEN;
        }

        internal async Task<string> FollowAsync(string _SCREEN_NAME)
        {
            try
            {
                string success = "No actions were taken...";
                string USER_ID = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("authorization", "Bearer " + _BEARER_TOKEN);
                    string response = await client.GetStringAsync("https://api.twitter.com/1.1/followers/ids.json?screen_name=" + _SCREEN_NAME);

                    JObject jdata = JObject.Parse(response);
                    JToken array = jdata["ids"];

                    foreach (JToken id in array)
                    {
                        USER_ID = id.ToString();

                        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.FollowersConnectionString))
                        {
                            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Follow where TwitterId = @TwitterId", connection))
                            {
                                connection.Open();
                                sqlCommand.Parameters.AddWithValue("@TwitterId", USER_ID);
                                int userCount = (int)sqlCommand.ExecuteScalar();

                                if (userCount == 0)
                                {
                                    success = await SendFollowRequest(USER_ID);

                                    if (success == "OK")
                                    {
                                        string values = "INSERT into Follow (TwitterId) VALUES (@TwitterId)";

                                        using (SqlCommand command = new SqlCommand(values))
                                        {
                                            command.Connection = connection;
                                            command.Parameters.AddWithValue("@TwitterId", USER_ID);

                                            command.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                EasyLogger.Error("GetToken - @RenewAccessToken(1): " + ex);

                return "ERROR: " + ex.Message;
            }
        }

        internal Task<string> SendFollowRequest(string USER_ID)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "user_id", USER_ID }
            };

            return SendRequest("friendships/create.json", data);
        }

        private Task<string> SendRequest(string url, Dictionary<string, string> data)
        {
            string fullUrl = TwitterApiBaseUrl + url;

            int timestamp = (int)(DateTime.UtcNow - epochUtc).TotalSeconds;

            data.Add("oauth_consumer_key", _API_KEY);
            data.Add("oauth_signature_method", "HMAC-SHA1");
            data.Add("oauth_timestamp", timestamp.ToString());
            data.Add("oauth_nonce", "a");
            data.Add("cursor", "-1");
            data.Add("count", "1000");// May need to decrease this to 500
            data.Add("oauth_token", _ACCESS_TOKEN);
            data.Add("oauth_version", "1.0");// This may need to be 2.0

            data.Add("oauth_signature", GenerateSignature(fullUrl, data));

            string oAuthHeader = GenerateOAuthHeader(data);

            FormUrlEncodedContent formData = new FormUrlEncodedContent(data.Where(kvp => !kvp.Key.StartsWith("oauth_")));

            return SendRequest(fullUrl, oAuthHeader, formData);
        }

        private string GenerateSignature(string url, Dictionary<string, string> data)
        {
            string sigString = string.Join(
                "&",
                data
                    .Union(data)
                    .Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );

            string fullSigData = string.Format(
                "{0}&{1}&{2}",
                "POST",
                Uri.EscapeDataString(url),
                Uri.EscapeDataString(sigString.ToString())
            );

            return Convert.ToBase64String(sigHasher.ComputeHash(new ASCIIEncoding().GetBytes(fullSigData.ToString())));
        }

        private string GenerateOAuthHeader(Dictionary<string, string> data)
        {
            return "OAuth " + string.Join(
                ", ",
                data
                    .Where(kvp => kvp.Key.StartsWith("oauth_"))
                    .Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );
        }

        private async Task<string> SendRequest(string fullUrl, string oAuthHeader, FormUrlEncodedContent formData)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", oAuthHeader);

                HttpResponseMessage httpResp = await http.PostAsync(fullUrl, formData);
                string respBody = await httpResp.Content.ReadAsStringAsync();

                if (respBody.ToLower().Contains("error"))
                {
                    return respBody;
                }

                return "OK";
            }
        }

        public void Dispose()
        {
            if (sigHasher != null)
            {
                sigHasher.Dispose();
            }
        }
    }
}
