using ChatApp.Contracts;
using System.Collections.ObjectModel;

namespace ChatApp.Client
{
    public class ChatCallback : IChatCallback
    {
        public void ForwardToClient(Message message)
        {
            throw new System.NotImplementedException();
        }

        public void UserConnected(ObservableCollection<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}
