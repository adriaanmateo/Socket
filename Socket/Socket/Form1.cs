using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket
{
    public partial class Form1 : Form
    {
        SocketServer mServer;

        public Form1()
        {
            InitializeComponent();

            mServer = new SocketServer();

            mServer.RaiseClientConnectedEvent += HandleClientConnected;
            mServer.RaiseTextReceivedEvent += HandleTextReceived;
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(txtMessage.Text.Trim());
            txtMessage.ResetText();
        }

        public void HandleClientConnected(object sender, ClientConnectedEventArgs cl)
        {
            LstClients.Items.Add($"{DateTime.Now} - New Client connected {cl.NewClient} {Environment.NewLine}");
        }

        public void HandleTextReceived(object sender, TextReceivedEventArgs tr)
        {
            LstClients.Items.Add($"{DateTime.Now} - Received from {tr.ClientSender}: " +
                $"{tr.TextReceived} {Environment.NewLine}");
        }
    }
}
