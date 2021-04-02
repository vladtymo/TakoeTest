using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        //Exists
        [OperationContract]
        bool IsExistNickname(string nickname);
        [OperationContract]
        bool IsExistEmail(string email);

        //Checks
        [OperationContract]
        bool IsRightPassword(string pass, out string mess);
        [OperationContract]
        bool IsRightPasswordInUser(User user, string password);

        //Get user
        [OperationContract]
        User GetUserByNickAndPass(string nick, string pass);
        [OperationContract]
        User GetUserByNick(string nick);
        [OperationContract]
        User GetUserByEmail(string email);

        //Add
        [OperationContract]
        void AddNewUser(User user);
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
