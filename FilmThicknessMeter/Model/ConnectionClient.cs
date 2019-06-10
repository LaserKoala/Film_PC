using FilmThicknessMeter.Utilites;
using FilmThicknessMeter.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Model
{
    public class ConnectionClient
    {
        public IPEndPoint IPEndPoint { get; set; }
        public Socket Socket { get; set; }
        public IPAddress Address
        {
            get => ((IPEndPoint)Socket.RemoteEndPoint).Address;
        }
        public int Port
        {
            get => ((IPEndPoint)Socket.RemoteEndPoint).Port;
        }

        private MetadataPacket _metadataPacket;
        private byte[] buffer = new byte[1024];
         



        public ConnectionClient SetSocket(int port, string iPString)
        {
            if (Socket != null)
            {
                if (Socket.Connected)
                {
                    Socket.Disconnect(false);
                    Socket.Dispose();
                }
            }

            IPEndPoint = new IPEndPoint(IPAddress.Parse(iPString), port);

            Socket = new Socket(IPEndPoint.AddressFamily,
                                SocketType.Stream,
                                ProtocolType.Tcp);
            Socket.ReceiveTimeout = 1000;

            return this;
        }

        public void Connect()
        {
            Socket.Connect(IPEndPoint);
            _metadataPacket = new MetadataPacket(buffer.Take(Socket.Receive(buffer)).ToArray());
        }

        public void Disconnect()
        {
            Socket.Disconnect(false);
        }

        public void Send(byte[] message)
        {
            var stateObject = new StateObject(Socket)
            {
                Buffer = message
            };
            stateObject.Socket.BeginSend(stateObject.Buffer,
                                        0,
                                        message.Length,
                                        SocketFlags.None,
                                        new AsyncCallback(SendDataCallback),
                                        stateObject);
            
        }

        public void WaitForData(MainViewModel viewModel)
        {


            var stateObject = new StateObject(Socket, viewModel);

            try
            {

                stateObject.Socket.Receive(stateObject.Buffer, SocketFlags.None);
                var recievedPacket = new Packet(stateObject.Buffer);

                Task.Run(() =>
                {
                    PacketAnalyzer.ParseMessage(recievedPacket, stateObject.ViewModel);
                });
                WaitForData(stateObject.ViewModel);
            }
            catch (SocketException)
            {

            }

            //stateObject.Socket.BeginReceive(stateObject.buffer,
            //                                0,
            //                                stateObject.Socket.Available,
            //                                SocketFlags.None,
            //                                new AsyncCallback(RecieveDataCallback),
            //                                stateObject);
        }

        public void RecieveDataCallback(IAsyncResult ar)
        {
            var stateObject = (StateObject)ar.AsyncState;
            var recievedPacket = new Packet(stateObject.Buffer);

            PacketAnalyzer.ParseMessage(recievedPacket, stateObject.ViewModel);

            WaitForData(stateObject.ViewModel);
        }

        public void SendDataCallback(IAsyncResult ar)
        {
            var stateObject = (StateObject)ar.AsyncState;
        }
    }

    public class StateObject
    {
        public MainViewModel ViewModel;
        public Socket Socket;
        public const int BufferSize = 512; 
        public byte[] Buffer = new byte[BufferSize];

        public StateObject(Socket socket)
        {
            Socket = socket;
        }

        public StateObject(Socket socket, MainViewModel viewModel)
        {
            Socket = socket;
            ViewModel = viewModel;
        }
    }
}
