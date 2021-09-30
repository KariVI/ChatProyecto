using ChatApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatApp.Client
{
    /// <summary>
    /// Lógica de interacción para Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private User user;
        public Chat(User user )
        {
            InitializeComponent();
            this.user = user;
    
        }

        public Label MessageTitle { get { return Title; } set { Title = value; } }
        public Button SendMessageButton { get { return SendButton; } set { SendButton = value; } }
        public ScrollViewer ScrollTextBox { get { return ContentScroller; } set { ContentScroller = value; } }       
        public TextBox MessageContainer { get { return MessageContent; } set { MessageContent = value; } }
        public ItemsControl MessageDisplay { get { return MessageTemplate; } set { MessageTemplate = value; } }


    }
}
