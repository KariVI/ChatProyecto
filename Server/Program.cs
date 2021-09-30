using ChatApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    { 
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string address = "net.tcp://localhost:4345/ChatService";
            uris[0] = new Uri(address);
            IChatService chatService = new ChatService();
            ServiceHost host = new ServiceHost(chatService, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IChatService), binding, "");
            host.Opened += HostOnOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOnOpened(object sender, EventArgs e)
        {
            Console.WriteLine("TCP Service started");
        }
    }
}
