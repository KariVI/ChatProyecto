using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProyecto
{
    public class ChatService : IChatService
    {
        private Queue<Message> messages = new Queue<Message>();

        public Message GetMessage()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessageHistory()
        {
            return messages.ToList();
        }

        public void Login(string nickname)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message message)
        {
            throw new NotImplementedException();
        }

    }
}
