using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.DTO;

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
        bool IsRightPasswordInUser(UserDTO user, string password);

        //Get user
        [OperationContract]
        UserDTO GetUserByNickAndPass(string nick, string pass);
        [OperationContract]
        UserDTO GetUserByNick(string nick);
        [OperationContract]
        UserDTO GetUserByEmail(string email);

        //Add
        [OperationContract]
        void AddNewUser(UserDTO user);
    }
}
