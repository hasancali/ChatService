using ChatClient;
using ChatService;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChatApp
{
    public partial class FrmChat : DevExpress.XtraEditors.XtraForm
    {
        ChatClients client;

        private string selectedUser;

        public FrmChat()
        {
            InitializeComponent();


            lstConnectedUsers.SelectedIndexChanged += (obj, e) => selectedUser = lstConnectedUsers.SelectedItem?.ToString();

            lstConnectedUsers.SelectedIndexChanged += lstConnectedUsers_SelectedIndexChanged;

            txtChatMessage.TextChanged += (obj, e) => btnChatMessageSend.Enabled = !string.IsNullOrWhiteSpace(txtChatMessage.Text) && lstConnectedUsers.Items.Count > 0;

            CreateChatClient();

            client.ConnectToServer(IPAddress.Parse("192.168.1.35"), 5000);
        }

        private void btnChatMessageSend_Click(object sender, EventArgs e)
        {
            if (client.ConnectedClients.Count > 0)
            {
                var message = this.txtChatMessage.Text;

                var selectedClient = client.ConnectedClients.FirstOrDefault(u => u.Username == selectedUser);

                client.SendToClient(message, selectedClient);

                this.txtChatMessage.Clear();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = this.txtLoginUsername.Text;
            var password = this.txtLoginPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username required", "Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password required", "Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            client.Login(username, password);


            gboxLogin.Hide();
            lblLoggedIn.Text += username;
            lblLoggedIn.Visible = true;

            client.Listen();
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
            Application.Exit();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var username = this.txtConnectUsername.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username required");
                return;
            }

            client.ConnectToClient(username);

            this.txtConnectUsername.Text = "";
        }

        private void lstConnectedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtChatMessagesView.Clear();

            var selectedUserChat = client.Chats.FirstOrDefault(c => c.User == selectedUser);

            if (selectedUserChat != null)
            {
                foreach (var message in selectedUserChat.Messages)
                {
                    this.txtChatMessagesView.AppendText($"{message.Content.TrimEnd()} (from {message.Sender}) at {message.Date.ToString()}\n");
                }
            }
        }

        private void Client_ClientConnected(object sender, ConnectionEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                lstConnectedUsers.Items.Add(e.Client.Username);

                if (lstConnectedUsers.Items.Count == 1)
                    lstConnectedUsers.SelectedIndex = 0;
            }));
        }

        private void CreateChatClient()
        {
            client = new ChatClients();

            client.ClientConnected += Client_ClientConnected;

            client.ClientDisconnected += (obj, ev) => Invoke(new MethodInvoker(() => lstConnectedUsers.Items.Remove(ev.Client.Username)));

            client.MessageReceived += (obj, ev) =>
            {
                if (selectedUser == ev.Client.Username)
                    Invoke(new MethodInvoker(() => txtChatMessagesView.AppendText($"{ev.Message.Content} (from {ev.Client.Username}) at {ev.Message.Date.ToString()}\n")));
            };

            client.MessageSent += (obj, ev) =>
                Invoke(new MethodInvoker(() => txtChatMessagesView.AppendText($"{ev.Message.Content} (from {client.Username}) at {ev.Message.Date.ToString()}\n")));
        }
    }
}