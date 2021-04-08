﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfService.DTO")]
    [System.SerializableAttribute()]
    public partial class UserDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BirthDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BirthDate {
            get {
                return this.BirthDateField;
            }
            set {
                if ((this.BirthDateField.Equals(value) != true)) {
                    this.BirthDateField = value;
                    this.RaisePropertyChanged("BirthDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Fullname {
            get {
                return this.FullnameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullnameField, value) != true)) {
                    this.FullnameField = value;
                    this.RaisePropertyChanged("Fullname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((this.GenderField.Equals(value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsExistNickname", ReplyAction="http://tempuri.org/IUserService/IsExistNicknameResponse")]
        bool IsExistNickname(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsExistNickname", ReplyAction="http://tempuri.org/IUserService/IsExistNicknameResponse")]
        System.Threading.Tasks.Task<bool> IsExistNicknameAsync(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsExistEmail", ReplyAction="http://tempuri.org/IUserService/IsExistEmailResponse")]
        bool IsExistEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsExistEmail", ReplyAction="http://tempuri.org/IUserService/IsExistEmailResponse")]
        System.Threading.Tasks.Task<bool> IsExistEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsRightPassword", ReplyAction="http://tempuri.org/IUserService/IsRightPasswordResponse")]
        Client.UserServiceReference.IsRightPasswordResponse IsRightPassword(Client.UserServiceReference.IsRightPasswordRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsRightPassword", ReplyAction="http://tempuri.org/IUserService/IsRightPasswordResponse")]
        System.Threading.Tasks.Task<Client.UserServiceReference.IsRightPasswordResponse> IsRightPasswordAsync(Client.UserServiceReference.IsRightPasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsRightPasswordInUser", ReplyAction="http://tempuri.org/IUserService/IsRightPasswordInUserResponse")]
        bool IsRightPasswordInUser(Client.UserServiceReference.UserDTO user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsRightPasswordInUser", ReplyAction="http://tempuri.org/IUserService/IsRightPasswordInUserResponse")]
        System.Threading.Tasks.Task<bool> IsRightPasswordInUserAsync(Client.UserServiceReference.UserDTO user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByNickAndPass", ReplyAction="http://tempuri.org/IUserService/GetUserByNickAndPassResponse")]
        Client.UserServiceReference.UserDTO GetUserByNickAndPass(string nick, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByNickAndPass", ReplyAction="http://tempuri.org/IUserService/GetUserByNickAndPassResponse")]
        System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByNickAndPassAsync(string nick, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByNick", ReplyAction="http://tempuri.org/IUserService/GetUserByNickResponse")]
        Client.UserServiceReference.UserDTO GetUserByNick(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByNick", ReplyAction="http://tempuri.org/IUserService/GetUserByNickResponse")]
        System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByNickAsync(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByEmail", ReplyAction="http://tempuri.org/IUserService/GetUserByEmailResponse")]
        Client.UserServiceReference.UserDTO GetUserByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByEmail", ReplyAction="http://tempuri.org/IUserService/GetUserByEmailResponse")]
        System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddNewUser", ReplyAction="http://tempuri.org/IUserService/AddNewUserResponse")]
        void AddNewUser(Client.UserServiceReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddNewUser", ReplyAction="http://tempuri.org/IUserService/AddNewUserResponse")]
        System.Threading.Tasks.Task AddNewUserAsync(Client.UserServiceReference.UserDTO user);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="IsRightPassword", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class IsRightPasswordRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pass;
        
        public IsRightPasswordRequest() {
        }
        
        public IsRightPasswordRequest(string pass) {
            this.pass = pass;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="IsRightPasswordResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class IsRightPasswordResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool IsRightPasswordResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string mess;
        
        public IsRightPasswordResponse() {
        }
        
        public IsRightPasswordResponse(bool IsRightPasswordResult, string mess) {
            this.IsRightPasswordResult = IsRightPasswordResult;
            this.mess = mess;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Client.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Client.UserServiceReference.IUserService>, Client.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsExistNickname(string nickname) {
            return base.Channel.IsExistNickname(nickname);
        }
        
        public System.Threading.Tasks.Task<bool> IsExistNicknameAsync(string nickname) {
            return base.Channel.IsExistNicknameAsync(nickname);
        }
        
        public bool IsExistEmail(string email) {
            return base.Channel.IsExistEmail(email);
        }
        
        public System.Threading.Tasks.Task<bool> IsExistEmailAsync(string email) {
            return base.Channel.IsExistEmailAsync(email);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Client.UserServiceReference.IsRightPasswordResponse Client.UserServiceReference.IUserService.IsRightPassword(Client.UserServiceReference.IsRightPasswordRequest request) {
            return base.Channel.IsRightPassword(request);
        }
        
        public bool IsRightPassword(string pass, out string mess) {
            Client.UserServiceReference.IsRightPasswordRequest inValue = new Client.UserServiceReference.IsRightPasswordRequest();
            inValue.pass = pass;
            Client.UserServiceReference.IsRightPasswordResponse retVal = ((Client.UserServiceReference.IUserService)(this)).IsRightPassword(inValue);
            mess = retVal.mess;
            return retVal.IsRightPasswordResult;
        }
        
        public System.Threading.Tasks.Task<Client.UserServiceReference.IsRightPasswordResponse> IsRightPasswordAsync(Client.UserServiceReference.IsRightPasswordRequest request) {
            return base.Channel.IsRightPasswordAsync(request);
        }
        
        public bool IsRightPasswordInUser(Client.UserServiceReference.UserDTO user, string password) {
            return base.Channel.IsRightPasswordInUser(user, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsRightPasswordInUserAsync(Client.UserServiceReference.UserDTO user, string password) {
            return base.Channel.IsRightPasswordInUserAsync(user, password);
        }
        
        public Client.UserServiceReference.UserDTO GetUserByNickAndPass(string nick, string pass) {
            return base.Channel.GetUserByNickAndPass(nick, pass);
        }
        
        public System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByNickAndPassAsync(string nick, string pass) {
            return base.Channel.GetUserByNickAndPassAsync(nick, pass);
        }
        
        public Client.UserServiceReference.UserDTO GetUserByNick(string nick) {
            return base.Channel.GetUserByNick(nick);
        }
        
        public System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByNickAsync(string nick) {
            return base.Channel.GetUserByNickAsync(nick);
        }
        
        public Client.UserServiceReference.UserDTO GetUserByEmail(string email) {
            return base.Channel.GetUserByEmail(email);
        }
        
        public System.Threading.Tasks.Task<Client.UserServiceReference.UserDTO> GetUserByEmailAsync(string email) {
            return base.Channel.GetUserByEmailAsync(email);
        }
        
        public void AddNewUser(Client.UserServiceReference.UserDTO user) {
            base.Channel.AddNewUser(user);
        }
        
        public System.Threading.Tasks.Task AddNewUserAsync(Client.UserServiceReference.UserDTO user) {
            return base.Channel.AddNewUserAsync(user);
        }
    }
}
