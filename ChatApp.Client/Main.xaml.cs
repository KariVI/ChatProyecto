using ChatApp.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private MainWindow window;
        private ObservableCollection<Message> messages;
        //private readonly SolidColorBrush[] userBackground = new SolidColorBrush[4];
        private User user;


        public Main(MainWindow window, User _user)
        {
            InitializeComponent();
            this.window = window;
            user = _user;
            window.Height = 300;
            window.Width = 300;
        }

        private void FrameWorkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(obj => {
                window.mainView.Dispatcher.Invoke(() =>
                {
                });
            
            },null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }
    }
}
