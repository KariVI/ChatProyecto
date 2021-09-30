using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatProyecto
{
    public class ChatService : IChatService
    {
        private Queue<Message> messages = new Queue<Message>();
        private Dictionary<string, IChatServiceCallback> loggedInUsers = new Dictionary<string, IChatServiceCallback>();

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
            int limitLength = 15;
            if (nickname.Length > limitLength)
            {

            }

            IChatServiceCallback callback = OperationContext.Current.GetCallbackChannel
           <IChatServiceCallback>();
            if (!loggedInUsers.ContainsKey(nickname))
            {
                loggedInUsers.Add(nickname, callback);
            }
            else { 
            
            }
        }

        public void Logoff(string nickname)
        {
            if (loggedInUsers.ContainsKey(nickname))
            {
                loggedInUsers.Remove(nickname);
            }
        }

        public void SendMessage(Message message)
        {
            AddMessage(message);
            SendMessageToUsers(message);
        }

        private void AddMessage(Message message)
        {         
          messages.Enqueue(message);
        }

        private void SendMessageToUsers(Message message)
        {
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();

            foreach (string key in callbackKeys)
            {
                IChatServiceCallback callback = loggedInUsers[key];
                callback.SendClientMessage(message);
            }
        }



    }
}
