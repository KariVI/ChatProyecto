using ChatApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatApp.Client
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindow window;
        public Login()
        {
            InitializeComponent();
            window = (MainWindow)Application.Current.MainWindow;
            if( window != null)
            {
                window.Width = 540;
                window.Height = 420;
                window.MinWidth = 540;
                window.MinHeight = 420;
                window.MaxWidth = 540;
                window.MaxHeight = 420;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(Username.Text))
            {
                User user = new User();
                user.Name = Username.Text;
                window.mainView = new Main(window, user);
                var uri = "net.tcp://localhost:4345/ChatService";
                var callback = new InstanceContext(new ChatCallback());
                var binding = new NetTcpBinding(SecurityMode.None);
                var channel = new DuplexChannelFactory<IChatService>(callback, binding) ;
                var endPoint = new EndpointAddress(uri);
                var proxy = channel.CreateChannel(endPoint);

                proxy?.Connect(user);
                Chat chat = new Chat(user);
                chat.Show();
                


                
            }


        }
    }
}
