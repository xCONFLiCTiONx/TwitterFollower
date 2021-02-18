
namespace TwitterFollower
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.API_KEY_BOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BEARER_TOKEN_BOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ACCESS_TOKEN_BOX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.API_SECRET_KEY_BOX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ACCESS_TOKEN_SECRET_BOX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SCREEN_NAME_BOX = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.VERSION_LABEL = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // API_KEY_BOX
            // 
            this.API_KEY_BOX.Location = new System.Drawing.Point(155, 18);
            this.API_KEY_BOX.Name = "API_KEY_BOX";
            this.API_KEY_BOX.Size = new System.Drawing.Size(236, 20);
            this.API_KEY_BOX.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "API_KEY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "BEARER_TOKEN";
            // 
            // BEARER_TOKEN_BOX
            // 
            this.BEARER_TOKEN_BOX.Location = new System.Drawing.Point(155, 122);
            this.BEARER_TOKEN_BOX.Name = "BEARER_TOKEN_BOX";
            this.BEARER_TOKEN_BOX.Size = new System.Drawing.Size(236, 20);
            this.BEARER_TOKEN_BOX.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ACCESS_TOKEN";
            // 
            // ACCESS_TOKEN_BOX
            // 
            this.ACCESS_TOKEN_BOX.Location = new System.Drawing.Point(155, 44);
            this.ACCESS_TOKEN_BOX.Name = "ACCESS_TOKEN_BOX";
            this.ACCESS_TOKEN_BOX.Size = new System.Drawing.Size(236, 20);
            this.ACCESS_TOKEN_BOX.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "API_SECRET_KEY";
            // 
            // API_SECRET_KEY_BOX
            // 
            this.API_SECRET_KEY_BOX.Location = new System.Drawing.Point(155, 70);
            this.API_SECRET_KEY_BOX.Name = "API_SECRET_KEY_BOX";
            this.API_SECRET_KEY_BOX.Size = new System.Drawing.Size(236, 20);
            this.API_SECRET_KEY_BOX.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ACCESS_TOKEN_SECRET";
            // 
            // ACCESS_TOKEN_SECRET_BOX
            // 
            this.ACCESS_TOKEN_SECRET_BOX.Location = new System.Drawing.Point(155, 96);
            this.ACCESS_TOKEN_SECRET_BOX.Name = "ACCESS_TOKEN_SECRET_BOX";
            this.ACCESS_TOKEN_SECRET_BOX.Size = new System.Drawing.Size(236, 20);
            this.ACCESS_TOKEN_SECRET_BOX.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "SCREEN_NAME";
            this.toolTip1.SetToolTip(this.label2, "This is the Twitter profile name of the person you\'re wanting to scrape followers" +
        " and add to your own profile.");
            // 
            // SCREEN_NAME_BOX
            // 
            this.SCREEN_NAME_BOX.Location = new System.Drawing.Point(155, 148);
            this.SCREEN_NAME_BOX.Name = "SCREEN_NAME_BOX";
            this.SCREEN_NAME_BOX.Size = new System.Drawing.Size(236, 20);
            this.SCREEN_NAME_BOX.TabIndex = 5;
            this.toolTip1.SetToolTip(this.SCREEN_NAME_BOX, "This is the Twitter profile name of the person you\'re wanting to scrape followers" +
        " and add to your own profile.");
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(316, 174);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 23);
            this.GoButton.TabIndex = 6;
            this.GoButton.Text = "GO";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // VERSION_LABEL
            // 
            this.VERSION_LABEL.AutoSize = true;
            this.VERSION_LABEL.Location = new System.Drawing.Point(12, 186);
            this.VERSION_LABEL.Name = "VERSION_LABEL";
            this.VERSION_LABEL.Size = new System.Drawing.Size(48, 13);
            this.VERSION_LABEL.TabIndex = 15;
            this.VERSION_LABEL.Text = "Version: ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 206);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(406, 5);
            this.progressBar1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 211);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.VERSION_LABEL);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SCREEN_NAME_BOX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ACCESS_TOKEN_SECRET_BOX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.API_SECRET_KEY_BOX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ACCESS_TOKEN_BOX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BEARER_TOKEN_BOX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.API_KEY_BOX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(419, 250);
            this.MinimumSize = new System.Drawing.Size(419, 250);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitter Follow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox API_KEY_BOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BEARER_TOKEN_BOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ACCESS_TOKEN_BOX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox API_SECRET_KEY_BOX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ACCESS_TOKEN_SECRET_BOX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SCREEN_NAME_BOX;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label VERSION_LABEL;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

