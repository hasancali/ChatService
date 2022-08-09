namespace ChatApp
{
    partial class FrmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnChatMessageSend = new DevExpress.XtraEditors.SimpleButton();
            this.txtChatMessage = new System.Windows.Forms.RichTextBox();
            this.txtChatMessagesView = new System.Windows.Forms.RichTextBox();
            this.lblLoggedIn = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lstConnectedUsers = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtConnectUsername = new DevExpress.XtraEditors.TextEdit();
            this.gboxLogin = new DevExpress.XtraEditors.GroupControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtLoginPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLoginUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstConnectedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gboxLogin)).BeginInit();
            this.gboxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginUsername.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.btnChatMessageSend);
            this.groupControl1.Controls.Add(this.txtChatMessage);
            this.groupControl1.Controls.Add(this.txtChatMessagesView);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(473, 475);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chat";
            // 
            // btnChatMessageSend
            // 
            this.btnChatMessageSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChatMessageSend.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnChatMessageSend.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChatMessageSend.ImageOptions.SvgImage")));
            this.btnChatMessageSend.Location = new System.Drawing.Point(392, 384);
            this.btnChatMessageSend.Name = "btnChatMessageSend";
            this.btnChatMessageSend.Size = new System.Drawing.Size(66, 86);
            this.btnChatMessageSend.TabIndex = 2;
            this.btnChatMessageSend.Click += new System.EventHandler(this.btnChatMessageSend_Click);
            // 
            // txtChatMessage
            // 
            this.txtChatMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatMessage.Location = new System.Drawing.Point(5, 384);
            this.txtChatMessage.Name = "txtChatMessage";
            this.txtChatMessage.Size = new System.Drawing.Size(372, 86);
            this.txtChatMessage.TabIndex = 1;
            this.txtChatMessage.Text = "";
            // 
            // txtChatMessagesView
            // 
            this.txtChatMessagesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatMessagesView.Enabled = false;
            this.txtChatMessagesView.Location = new System.Drawing.Point(5, 36);
            this.txtChatMessagesView.Name = "txtChatMessagesView";
            this.txtChatMessagesView.Size = new System.Drawing.Size(454, 342);
            this.txtChatMessagesView.TabIndex = 0;
            this.txtChatMessagesView.Text = "";
            // 
            // lblLoggedIn
            // 
            this.lblLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoggedIn.AutoSize = true;
            this.lblLoggedIn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoggedIn.Location = new System.Drawing.Point(496, 41);
            this.lblLoggedIn.Name = "lblLoggedIn";
            this.lblLoggedIn.Size = new System.Drawing.Size(141, 25);
            this.lblLoggedIn.TabIndex = 3;
            this.lblLoggedIn.Text = "Logged In as ";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl3.CaptionImageOptions.SvgImage")));
            this.groupControl3.Controls.Add(this.lstConnectedUsers);
            this.groupControl3.Location = new System.Drawing.Point(491, 156);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(226, 211);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Connected Users";
            // 
            // lstConnectedUsers
            // 
            this.lstConnectedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConnectedUsers.Location = new System.Drawing.Point(5, 36);
            this.lstConnectedUsers.Name = "lstConnectedUsers";
            this.lstConnectedUsers.Size = new System.Drawing.Size(216, 170);
            this.lstConnectedUsers.TabIndex = 0;
            this.lstConnectedUsers.SelectedIndexChanged += new System.EventHandler(this.lstConnectedUsers_SelectedIndexChanged);
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl4.CaptionImageOptions.SvgImage")));
            this.groupControl4.Controls.Add(this.simpleButton3);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.txtConnectUsername);
            this.groupControl4.Location = new System.Drawing.Point(491, 372);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(226, 115);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "Connect";
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(5, 63);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(216, 41);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Username";
            // 
            // txtConnectUsername
            // 
            this.txtConnectUsername.Location = new System.Drawing.Point(59, 37);
            this.txtConnectUsername.Name = "txtConnectUsername";
            this.txtConnectUsername.Size = new System.Drawing.Size(162, 20);
            this.txtConnectUsername.TabIndex = 5;
            // 
            // gboxLogin
            // 
            this.gboxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxLogin.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("gboxLogin.CaptionImageOptions.SvgImage")));
            this.gboxLogin.Controls.Add(this.btnLogin);
            this.gboxLogin.Controls.Add(this.txtLoginPassword);
            this.gboxLogin.Controls.Add(this.labelControl2);
            this.gboxLogin.Controls.Add(this.txtLoginUsername);
            this.gboxLogin.Controls.Add(this.labelControl1);
            this.gboxLogin.Location = new System.Drawing.Point(491, 12);
            this.gboxLogin.Name = "gboxLogin";
            this.gboxLogin.Size = new System.Drawing.Size(226, 138);
            this.gboxLogin.TabIndex = 4;
            this.gboxLogin.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogin.ImageOptions.SvgImage")));
            this.btnLogin.Location = new System.Drawing.Point(5, 90);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(216, 41);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(59, 64);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(162, 20);
            this.txtLoginPassword.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Password";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(59, 40);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(162, 20);
            this.txtLoginUsername.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Username";
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 500);
            this.Controls.Add(this.gboxLogin);
            this.Controls.Add(this.lblLoggedIn);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmChat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstConnectedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gboxLogin)).EndInit();
            this.gboxLogin.ResumeLayout(false);
            this.gboxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginUsername.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnChatMessageSend;
        private RichTextBox txtChatMessage;
        private RichTextBox txtChatMessagesView;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ListBoxControl lstConnectedUsers;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtConnectUsername;
        private Label lblLoggedIn;
        private DevExpress.XtraEditors.GroupControl gboxLogin;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtLoginPassword;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLoginUsername;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}