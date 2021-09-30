using ChatApp.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private IChatCallback callback = null;
        private Dictionary<User, IChatCallback> clients;
        private ObservableCollection<User> users;

        public ChatService(){
            clients = new Dictionary<User, IChatCallback>();
            users = new ObservableCollection<User>();
         }

        public void Connect(User user)
        {
            callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            if (callback != null) {
                clients.Add(user, callback);
                users.Add(user);
                clients?.ToList().ForEach(c => c.Value.UserConnected(users));
                Console.WriteLine($" {user.Name} just connected  ");
            }
        }

        public ObservableCollection<User> GetConnectedUsers()
        {
            return users;
        }

        public void SendMessage(Message message)
        {
            var sendto = clients?.First(c => c.Key.Equals(message.User));
           // sendto?.ForwardToClient(message);
            

        }
    }
}
