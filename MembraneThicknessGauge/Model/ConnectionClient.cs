using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MembraneThicknessGauge.Model
{
    public class ConnectionClient
    {
        private TcpClient TcpClient = new TcpClient();
        private MetadataPacket metadata = null;
        private List<string> MetaDataList = null;
        private Queue<Packet> packetsQuene = new Queue<Packet>();


        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        private ManualResetEvent connectDone = new ManualResetEvent(false);


        public void Connect(int port,string iPString)
        {
            byte[] bytes = new byte[1024];

            var iPAddress = IPAddress.Parse(iPString);
            var myRIOEndPoint= new IPEndPoint(iPAddress, port);
            var client = new Socket(myRIOEndPoint.AddressFamily, SocketType.Stream,ProtocolType.Tcp);

            try
            {
                client.BeginConnect(myRIOEndPoint, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();


                Console.WriteLine("Начинаю приём");
                Receive(client);
                receiveDone.WaitOne();
                foreach(var met in metadata.Data)
                {
                    Console.WriteLine(met);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //var socket = new Socket(SocketType.);
            //TcpClient.Connect(adress, 55555);
            //var networkStream = TcpClient.GetStream();
            //var data = new byte[256];
            //MetaDataList = new MetadataPacket(data.Take(networkStream.Read(data, 0, data.Length))
            //                                  .ToArray()).Data;

            //foreach(var metaDataString in MetaDataList)
            //{
            //    Console.WriteLine(metaDataString);
            //}
            //Thread t = new Thread(Read);
            //t.Start();

            //Send(1, "oh, hello");

        }




        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                var client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                Console.WriteLine("Создаю объедку");
                var state = new StateObject
                {
                    workSocket = client
                };

                // Begin receiving the data from the remote device.
                Console.WriteLine("Бегиню приём");
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine("Так-с, что тут к нас...");
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    Console.WriteLine("ЧТо-то есть");
                    foreach (var sym in state.buffer.Take(bytesRead))
                    {
                        Console.Write($"{sym} ");
                    }
                    Console.WriteLine();


                    
                    if (metadata == null)
                    {
                        Console.WriteLine("оп, вот и метаданные");
                        metadata = new MetadataPacket(state.buffer.Take(bytesRead).ToArray());
                        Console.WriteLine("Обработал метаданные");
                    }
                    else
                    {
                        Console.WriteLine("Пакетик, ты будешь " + packetsQuene.Count);
                        packetsQuene.Enqueue(new Packet(state.buffer.Take(bytesRead).ToArray()));
                        Console.WriteLine("Обработал пакетик");
                    }

                    // There might be more data, so store the data received so far.  
                    //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    //  Get the rest of the data.
                    Console.WriteLine("Может ещё есть");
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                    Console.WriteLine("Хз, как ты сюда попал");
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    //if (state.sb.Length > 1)
                    //{
                    //    response = state.sb.ToString();
                    //}
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                    Console.WriteLine("Я сделаль");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }




        //public void Send(int metadataID, string messageText)
        //{
        //    var metadata = BitConverter.GetBytes(metadataID);
        //    Array.Reverse(metadata);

        //    var message = metadata.Concat(Encoding.ASCII.GetBytes(messageText));

        //    var messageSize = BitConverter.GetBytes(Convert.ToInt16(message.Count()));
        //    Array.Reverse(messageSize);


        //    var fullMessage = messageSize.Concat(message);
        //    foreach(var someChar in fullMessage)
        //    {
        //        Console.Write($"{someChar} ");
        //    }
        //    Console.WriteLine();

        //    NetworkStream ns = TcpClient.GetStream();
        //    ns.Write(fullMessage.ToArray(), 0, fullMessage.Count());

        //}

        //public void Read()
        //{
        //    while (true)
        //    {
        //        NetworkStream ns = TcpClient.GetStream();
        //        var data = new byte[256];
        //        do
        //        {
        //            var packet = new Packet(data.Take(ns.Read(data, 0, data.Length))
        //                                        .ToArray());
        //        }
        //        while (ns.DataAvailable);




        //        //if (TcpClient.ReceiveBufferSize > 0)
        //        //{
        //        //    bytes = new byte[TcpClient.ReceiveBufferSize];
        //        //    ns.Read(bytes, 0, TcpClient.ReceiveBufferSize);
        //        //    foreach (var iterByte in bytes)
        //        //    {
        //        //        Console.Write($"{iterByte} ");
        //        //    }
        //        //    Console.WriteLine();
        //        //    ////var message = new Packet(bytes);
        //        //    //// string msg = Encoding.ASCII.GetString(bytes); //the message incoming
        //        //    ////Console.WriteLine($"{message.DataSize} {message.MetaDataID} {message.Data}");

        //        //    }
        //        //}
        //    }

        //}



        //public static void Close()
        //{
        //    TcpClient.Close();
        //}
    }

    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
