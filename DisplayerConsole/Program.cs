using System.Net.Sockets;

namespace DisplayerConsole;

internal class Program
{
    static List<(string, string)> Options = new();
    static Thread TListener;
    static TcpClient Client;

    static void Main(string[] _Args)
    {
        Console.WriteLine("Options will show here");

        TListener = new Thread(ListenerThread);
        TListener.Start();
    }

    static void ListenerThread()
    {
        do
        {

        } while (Client.Connected);
    }

    /*
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            int port = Convert.ToInt32(textBox2.Text);
            client.Connect(ip, port);
            MessageBox.Show("Connected to: " + textBox1.Text);
            listenThread = new Thread(new ThreadStart(Listen));
            listenThread.Start();
        }

        private void Listen()
        {
            NetworkStream stream = client.GetStream();
            while (true)
            {
                //Buffer to receive Data
                byte[] buffer = new byte[256];
                //Received Byte count
                int byteNum = stream.Read(buffer, 0, buffer.Length);
                if (byteNum > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, byteNum);
                    AddMessage(message);
                }
            }
        }
     private void btn_Listen_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            int port = Convert.ToInt32(textBox2.Text);
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            client = listener.AcceptTcpClient();
            //IPEndPoint forms the connection to a Service
            IPEndPoint ipEnd = (IPEndPoint)client.Client.RemoteEndPoint;
            //It also contains the remote port information.
            //Therefore, the Ip Address alone can be extracted.
            IPAddress ipEndAddress = ipEnd.Address;
            MessageBox.Show("Connected to the Client: " + ipEndAddress.ToString());
            listenThread = new Thread(new ThreadStart(Listen));
            listenThread.Start();
        }
     
     private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtSend.Text;
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            AddMessage("Me: " + message);
        }
     
     */
}
