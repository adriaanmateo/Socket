using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    class SocketServer
    {
        public IPAddress ServerIP { get; protected set; }
        public int ServerPort { get; protected set; }
        public bool KeepRunning { get; set; }
        public EventHandler<ClientConnectedEventArgs> RaiseClientConnectedEvent;
        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;

        TcpListener mTCPListener;
        List<Client> mClients;


        public SocketServer(IPAddress ipaddr, int port)
        {
            mClients = new List<Client>();
            (ServerIP, ServerPort) = (ipaddr, port);
        }

        public SocketServer()
        {
            mClients = new List<Client>();
            (ServerIP, ServerPort) = (IPAddress.Any, 23000);
        }

        protected virtual void OnRaiseClientConnectedEvent(ClientConnectedEventArgs e)
        {
            RaiseClientConnectedEvent?.Invoke(this, e);
        }

        protected virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            RaiseTextReceivedEvent?.Invoke(this, trea);
        }

        public async void StartListeningForIncomingConnection()
        {

            Debug.WriteLine($"IP Address: {ServerIP} - Port: {ServerPort}");

            mTCPListener = new TcpListener(ServerIP, ServerPort);

            try
            {
                mTCPListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();
                    var newClient = new Client(mClients.Count + 1, returnedByAccept);
                    mClients.Add(newClient);

                    Debug.WriteLine(
                        string.Format("Client connected successfully, ID: {0} - {1}",
                        newClient.ID, newClient.Connection.Client.RemoteEndPoint)
                        );

                    TakeCareOfTCPClient(newClient);

                    var eaClientConnected = new ClientConnectedEventArgs(returnedByAccept.Client.RemoteEndPoint.ToString());
                    OnRaiseClientConnectedEvent(eaClientConnected);
                }

            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp);
            }
        }

        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                }

                foreach (Client c in mClients)
                {
                    c.Connection.Close();
                }

                mClients.Clear();
            }
            catch (Exception excp)
            {

                Debug.WriteLine(excp);
            }
        }

        private async void TakeCareOfTCPClient(Client clientToServe)
        {
            var paramClient = clientToServe.Connection;
            KillAfter1hour(paramClient);
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read");

                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);

                    Debug.WriteLine("Returned: " + nRet);

                    if (nRet == 0)
                    {
                        RemoveClient(clientToServe);

                        Debug.WriteLine("Socket disconnected");
                        break;
                    }

                    string receivedText = new string(buff, 0, nRet);
                    Debug.WriteLine("*** RECEIVED: " + receivedText);
                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(
                        paramClient.Client.RemoteEndPoint.ToString(),
                        receivedText
                        ));
                    //SendToAll($"Client {clientToServe.ID} sends {receivedText} ");

                    Array.Clear(buff, 0, buff.Length);

                }

            }
            catch (Exception excp)
            {
                RemoveClient(clientToServe);
                Debug.WriteLine(excp);
            }

        }

        private async Task KillAfter1hour(TcpClient paramClient)
        {
            await Task.Delay(TimeSpan.FromHours(1));
            paramClient.Client.Close();
        }

        private void RemoveClient(Client clientToRemove)
        {
            mClients.Remove(clientToRemove);
            Debug.WriteLine(String.Format("Client removed, count: {0}", mClients.Count));

        }

        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(leMessage);

                foreach (Client c in mClients)
                {
                    await c.Connection.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }

        }
    }

    public class Client
    {
        public int ID { get; set; }
        public TcpClient Connection { get; set; }
        public Client(int id, TcpClient connection) => (ID, Connection) = (id, connection);
    }
}
