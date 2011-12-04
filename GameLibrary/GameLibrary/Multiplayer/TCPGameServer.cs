using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace GameLibrary.Multiplayer
{
    /// <summary>
    /// http://www.switchonthecode.com/tutorials/csharp-tutorial-simple-threaded-tcp-server
    /// </summary>
    public class TCPGameServer
    {
        public List<TcpClient> clientList = new List<TcpClient>();
        private int port;
        private TcpListener tcpListener;
        private Thread listenThread;
        public delegate void RecieveInformation(string message);
        public RecieveInformation recieveInformation;
        public String info = "No and  Yes";

        public int PortNumber
        {
            get
            {
                return port;
               
            }
        }


        public void CloseConnections()
        {
            listenThread.Abort();
            tcpListener.Stop();
        }


        public TCPGameServer(int portNumber)
        {
            port = portNumber;
            this.tcpListener = new TcpListener(IPAddress.Any, portNumber);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }


        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                clientList.Add(client);
                ClientConnected();
                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }


        public virtual void ClientConnected()
        {

        }
        public static string LocalIP
        {
            get
            {
                IPHostEntry host;
                string localIP = "?";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                return localIP;
            }
        }


        /// <summary>
        /// This function is responsible for reading data from the client. Let's have a look at it.
        /// </summary>
        /// <param name="client"></param>
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                        bytesRead = clientStream.Read(message, 0, 4096);

                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                //System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));

                recieveInformation(encoder.GetString(message, 0, bytesRead));
            }
            tcpClient.Close();
        }       


        private void SendInformation(TcpClient client, String data)
        {
            try
            {
                NetworkStream clientStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(data);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch
            {
                clientList.Remove(client);
            }
        }


        public void SendToClients(String data)
        {
            info = data;
            for (int i = 0; i < clientList.Count; i++)
            {
                SendInformation(clientList[i], data);
            }
        } 
    }
}
