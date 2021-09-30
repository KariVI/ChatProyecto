using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Contracts
{
    public class User
    {
        

        public string Name { get; set; }

        public User()
        {
            Name = "";
        }
        public ObservableCollection <Message> UserMessager { get; set; }


    }
    public class Message
    {
        private string text;
        public string User { get { return text; } set { text = value; } }
        public string Text { get { return text; } set { text = value; } }
    }
}
