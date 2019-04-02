using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MembraneThicknessGauge.Code
{
    public class ConnectionClient
    {
        private TcpClient TcpClient = new TcpClient();
        private List<string> MetaData = null;

        public void Connect(string adress)
        {
            TcpClient.Connect(adress, 55555);
            var networkStream = TcpClient.GetStream();
            var data = new byte[256];
            MetaData = new MetadataPacket(data.Take(networkStream.Read(data, 0, data.Length))
                                              .ToArray()).Data;

            


            //foreach(var metaData in MetaData)
            //{
            //    Console.WriteLine(metaData);
            //}
            //Thread t = new Thread(Read); 
            //t.Start();
        }

        public void Send()
        {

        }

        public void Read()
        {
            while (true)
            {
                Console.WriteLine($"Getting stream");
                NetworkStream ns = TcpClient.GetStream();
                Console.WriteLine($"{TcpClient.ReceiveBufferSize}");
                var data = new byte[256];
                do
                {
                    var packet = new Packet(data.Take(ns.Read(data, 0, data.Length))
                                                .ToArray());
                    Console.WriteLine(packet.Data);
                    Console.WriteLine(MetaData.ElementAt(packet.MetaDataID));
                    

                    //var message = new Packet(data);
                    //Console.WriteLine($"{message.DataSize} {message.MetaDataID} {message.Data}");
                    //foreach (var iterByte in data)
                    //{
                    //    Console.Write($"{iterByte} ");
                    //}
                    //Console.WriteLine();
                }
                while (ns.DataAvailable);




                //if (TcpClient.ReceiveBufferSize > 0)
                //{
                //    bytes = new byte[TcpClient.ReceiveBufferSize];
                //    ns.Read(bytes, 0, TcpClient.ReceiveBufferSize);
                //    foreach (var iterByte in bytes)
                //    {
                //        Console.Write($"{iterByte} ");
                //    }
                //    Console.WriteLine();
                //    ////var message = new Packet(bytes);
                //    //// string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                //    ////Console.WriteLine($"{message.DataSize} {message.MetaDataID} {message.Data}");

                //    }
                //}
            }
            
        }

        

        public void Close()
        {
            TcpClient.Close();
        }
    }
}
