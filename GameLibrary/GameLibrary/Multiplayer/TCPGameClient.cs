using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace GameLibrary.Multiplayer
{
    public class TCPGameClient
    {
        TcpClient client = new TcpClient();
        IPEndPoint serverEndPoint;
        NetworkStream clientStream;
        ASCIIEncoding encoder = new ASCIIEncoding();

        public TCPGameClient(string ipAddress, int portNumber)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), portNumber);
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();            
        }

        public TcpClient Client
        {
            get
            {
                return client;
            }
        }

        public void CloseConnection()
        {
            client.Close();
            clientStream.Close();
        }


        public void SendInformation(string data)
        {
            byte[] buffer = encoder.GetBytes(data);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }


        public String RecieveInformation()
        {
            byte[] message = new byte[4096];
            int bytesRead = 0;

            try
            {
                if (clientStream.DataAvailable)
                {
                    bytesRead = clientStream.Read(message, 0, 4096);

                    if (bytesRead == 0)
                    {
                        return "";
                    }
                    String a = encoder.GetString(message, 0, bytesRead);
                 //   clientStream.Flush();
                 //   String b = encoder.GetString(message, 0, bytesRead);
                    return a;
                }
                return "";
            }
            catch
            {
                return null;
            }
        }
    }
}
