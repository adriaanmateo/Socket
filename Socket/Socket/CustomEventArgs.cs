using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class ClientConnectedEventArgs : EventArgs
    {
        public string NewClient { get; set; }

        public ClientConnectedEventArgs(string _newClient)
        {
            NewClient = _newClient;
        }
    }

    public class TextReceivedEventArgs : EventArgs
    {
        public string ClientSender { get; set; }
        public string TextReceived { get; set; }

        public TextReceivedEventArgs(string _clientSender, string _textReceived)
        {
            ClientSender = _clientSender;
            TextReceived = _textReceived;
        }
    }
}
