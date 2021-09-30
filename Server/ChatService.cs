using ChatApp.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private IChatCallback callback = null;
        private Dictionary<User, IChatCallback> clients;

        public ChatService(){
            clients = new Dictionary<User, IChatCallback>();
         }

        public void Connect(User user)
        {
            callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            if (callback != null) {
                clients.Add(user, callback);
            }
        }

        public void SendMessage(Message message)
        {
            var sendto = clients?.First(c => c.Key.Equals(message.User));
            sendto?.ForwardToClient(message);
            

        }
    }
}
