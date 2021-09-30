using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Contracts
{
    [ServiceContract (CallbackContract = typeof(IChatCallback), SessionMode = SessionMode.Required)]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(User user);
        [OperationContract(IsOneWay = true)]
        void SendMessage(Message message);
        [OperationContract]
        ObservableCollection<User> GetConnectedUsers();

    }
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void ForwardToClient(Message message);

        [OperationContract(IsOneWay = true)]
        void UserConnected(ObservableCollection<User> users);

    }
}
