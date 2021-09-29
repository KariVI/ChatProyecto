using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatProyecto
{
   [ServiceContract]
    public interface IChatService
    {
      
        
        [OperationContract]
        Message GetMessage();
        


    }

    [DataContract]
    public class Message {
        private String userName;
        private String text;

        [DataMember]
        public String UserName { get { return userName; } set { userName = value; } }
        [DataMember]
        public String Text { get { return text; } set { text = value; } }
    
    }
}
