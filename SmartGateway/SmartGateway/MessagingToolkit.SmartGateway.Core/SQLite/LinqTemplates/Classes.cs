


using System;
using System.ComponentModel;
using System.Linq;

namespace MessagingToolkit.SmartGateway.Core.Data.Linq
{
    
    
    
    
    /// <summary>
    /// A class which represents the XP_PROC table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.XP_PROC 
    /// </summary>

	public partial class XP_PROC: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public XP_PROC(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void Onview_nameChanging(string value);
        partial void Onview_nameChanged();
		
		private string _view_name;
		public string view_name { 
		    get{
		        return _view_name;
		    } 
		    set{
		        this.Onview_nameChanging(value);
                this.SendPropertyChanging();
                this._view_name = value;
                this.SendPropertyChanged("view_name");
                this.Onview_nameChanged();
		    }
		}
		
        partial void Onparam_listChanging(string value);
        partial void Onparam_listChanged();
		
		private string _param_list;
		public string param_list { 
		    get{
		        return _param_list;
		    } 
		    set{
		        this.Onparam_listChanging(value);
                this.SendPropertyChanging();
                this._param_list = value;
                this.SendPropertyChanged("param_list");
                this.Onparam_listChanged();
		    }
		}
		
        partial void OnxSQLChanging(string value);
        partial void OnxSQLChanged();
		
		private string _xSQL;
		public string xSQL { 
		    get{
		        return _xSQL;
		    } 
		    set{
		        this.OnxSQLChanging(value);
                this.SendPropertyChanging();
                this._xSQL = value;
                this.SendPropertyChanged("xSQL");
                this.OnxSQLChanged();
		    }
		}
		
        partial void Ondef_paramChanging(string value);
        partial void Ondef_paramChanged();
		
		private string _def_param;
		public string def_param { 
		    get{
		        return _def_param;
		    } 
		    set{
		        this.Ondef_paramChanging(value);
                this.SendPropertyChanging();
                this._def_param = value;
                this.SendPropertyChanged("def_param");
                this.Ondef_paramChanged();
		    }
		}
		
        partial void Onopt_paramChanging(string value);
        partial void Onopt_paramChanged();
		
		private string _opt_param;
		public string opt_param { 
		    get{
		        return _opt_param;
		    } 
		    set{
		        this.Onopt_paramChanging(value);
                this.SendPropertyChanging();
                this._opt_param = value;
                this.SendPropertyChanged("opt_param");
                this.Onopt_paramChanged();
		    }
		}
		
        partial void OncommentChanging(string value);
        partial void OncommentChanged();
		
		private string _comment;
		public string comment { 
		    get{
		        return _comment;
		    } 
		    set{
		        this.OncommentChanging(value);
                this.SendPropertyChanging();
                this._comment = value;
                this.SendPropertyChanged("comment");
                this.OncommentChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the sqlite_sequence table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.sqlite_sequence 
    /// </summary>

	public partial class sqlite_sequence: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public sqlite_sequence(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
		
		private string _name;
		public string name { 
		    get{
		        return _name;
		    } 
		    set{
		        this.OnnameChanging(value);
                this.SendPropertyChanging();
                this._name = value;
                this.SendPropertyChanged("name");
                this.OnnameChanged();
		    }
		}
		
        partial void OnseqChanging(long? value);
        partial void OnseqChanged();
		
		private long? _seq;
		public long? seq { 
		    get{
		        return _seq;
		    } 
		    set{
		        this.OnseqChanging(value);
                this.SendPropertyChanging();
                this._seq = value;
                this.SendPropertyChanged("seq");
                this.OnseqChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the OutgoingCall table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.OutgoingCall 
    /// </summary>

	public partial class OutgoingCall: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public OutgoingCall(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnCallDateChanging(DateTime value);
        partial void OnCallDateChanged();
		
		private DateTime _CallDate;
		public DateTime CallDate { 
		    get{
		        return _CallDate;
		    } 
		    set{
		        this.OnCallDateChanging(value);
                this.SendPropertyChanging();
                this._CallDate = value;
                this.SendPropertyChanged("CallDate");
                this.OnCallDateChanged();
		    }
		}
		
        partial void OnCallerIdChanging(string value);
        partial void OnCallerIdChanged();
		
		private string _CallerId;
		public string CallerId { 
		    get{
		        return _CallerId;
		    } 
		    set{
		        this.OnCallerIdChanging(value);
                this.SendPropertyChanging();
                this._CallerId = value;
                this.SendPropertyChanged("CallerId");
                this.OnCallerIdChanged();
		    }
		}
		
        partial void OnGatewayIdChanging(string value);
        partial void OnGatewayIdChanged();
		
		private string _GatewayId;
		public string GatewayId { 
		    get{
		        return _GatewayId;
		    } 
		    set{
		        this.OnGatewayIdChanging(value);
                this.SendPropertyChanging();
                this._GatewayId = value;
                this.SendPropertyChanged("GatewayId");
                this.OnGatewayIdChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Privilege table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.Privilege 
    /// </summary>

	public partial class Privilege: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Privilege(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
		
		private string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		
        partial void OnDescChanging(string value);
        partial void OnDescChanged();
		
		private string _Desc;
		public string Desc { 
		    get{
		        return _Desc;
		    } 
		    set{
		        this.OnDescChanging(value);
                this.SendPropertyChanging();
                this._Desc = value;
                this.SendPropertyChanged("Desc");
                this.OnDescChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the RolePrivilegeMap table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.RolePrivilegeMap 
    /// </summary>

	public partial class RolePrivilegeMap: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public RolePrivilegeMap(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnRoleIdChanging(long value);
        partial void OnRoleIdChanged();
		
		private long _RoleId;
		public long RoleId { 
		    get{
		        return _RoleId;
		    } 
		    set{
		        this.OnRoleIdChanging(value);
                this.SendPropertyChanging();
                this._RoleId = value;
                this.SendPropertyChanged("RoleId");
                this.OnRoleIdChanged();
		    }
		}
		
        partial void OnPrivilegeIdChanging(long value);
        partial void OnPrivilegeIdChanged();
		
		private long _PrivilegeId;
		public long PrivilegeId { 
		    get{
		        return _PrivilegeId;
		    } 
		    set{
		        this.OnPrivilegeIdChanging(value);
                this.SendPropertyChanging();
                this._PrivilegeId = value;
                this.SendPropertyChanged("PrivilegeId");
                this.OnPrivilegeIdChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the UserRoleMap table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.UserRoleMap 
    /// </summary>

	public partial class UserRoleMap: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public UserRoleMap(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnUserIdChanging(long value);
        partial void OnUserIdChanged();
		
		private long _UserId;
		public long UserId { 
		    get{
		        return _UserId;
		    } 
		    set{
		        this.OnUserIdChanging(value);
                this.SendPropertyChanging();
                this._UserId = value;
                this.SendPropertyChanged("UserId");
                this.OnUserIdChanged();
		    }
		}
		
        partial void OnRoleIdChanging(long value);
        partial void OnRoleIdChanged();
		
		private long _RoleId;
		public long RoleId { 
		    get{
		        return _RoleId;
		    } 
		    set{
		        this.OnRoleIdChanging(value);
                this.SendPropertyChanging();
                this._RoleId = value;
                this.SendPropertyChanged("RoleId");
                this.OnRoleIdChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the IncomingCall table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.IncomingCall 
    /// </summary>

	public partial class IncomingCall: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public IncomingCall(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnCallDateChanging(DateTime value);
        partial void OnCallDateChanged();
		
		private DateTime _CallDate;
		public DateTime CallDate { 
		    get{
		        return _CallDate;
		    } 
		    set{
		        this.OnCallDateChanging(value);
                this.SendPropertyChanging();
                this._CallDate = value;
                this.SendPropertyChanged("CallDate");
                this.OnCallDateChanged();
		    }
		}
		
        partial void OnCallerIdChanging(string value);
        partial void OnCallerIdChanged();
		
		private string _CallerId;
		public string CallerId { 
		    get{
		        return _CallerId;
		    } 
		    set{
		        this.OnCallerIdChanging(value);
                this.SendPropertyChanging();
                this._CallerId = value;
                this.SendPropertyChanged("CallerId");
                this.OnCallerIdChanged();
		    }
		}
		
        partial void OnGatewayIdChanging(string value);
        partial void OnGatewayIdChanged();
		
		private string _GatewayId;
		public string GatewayId { 
		    get{
		        return _GatewayId;
		    } 
		    set{
		        this.OnGatewayIdChanging(value);
                this.SendPropertyChanging();
                this._GatewayId = value;
                this.SendPropertyChanged("GatewayId");
                this.OnGatewayIdChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the SQLITEADMIN_QUERIES table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.SQLITEADMIN_QUERY 
    /// </summary>

	public partial class SQLITEADMIN_QUERY: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public SQLITEADMIN_QUERY(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIDChanging(long value);
        partial void OnIDChanged();
		
		private long _ID;
		public long ID { 
		    get{
		        return _ID;
		    } 
		    set{
		        this.OnIDChanging(value);
                this.SendPropertyChanging();
                this._ID = value;
                this.SendPropertyChanged("ID");
                this.OnIDChanged();
		    }
		}
		
        partial void OnNAMEChanging(string value);
        partial void OnNAMEChanged();
		
		private string _NAME;
		public string NAME { 
		    get{
		        return _NAME;
		    } 
		    set{
		        this.OnNAMEChanging(value);
                this.SendPropertyChanging();
                this._NAME = value;
                this.SendPropertyChanged("NAME");
                this.OnNAMEChanged();
		    }
		}
		
        partial void OnSQLChanging(string value);
        partial void OnSQLChanged();
		
		private string _SQL;
		public string SQL { 
		    get{
		        return _SQL;
		    } 
		    set{
		        this.OnSQLChanging(value);
                this.SendPropertyChanging();
                this._SQL = value;
                this.SendPropertyChanged("SQL");
                this.OnSQLChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the AppConfig table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.AppConfig 
    /// </summary>

	public partial class AppConfig: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public AppConfig(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
		
		private string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		
        partial void OnValueChanging(string value);
        partial void OnValueChanged();
		
		private string _Value;
		public string Value { 
		    get{
		        return _Value;
		    } 
		    set{
		        this.OnValueChanging(value);
                this.SendPropertyChanging();
                this._Value = value;
                this.SendPropertyChanged("Value");
                this.OnValueChanged();
		    }
		}
		
        partial void OnModuleChanging(string value);
        partial void OnModuleChanged();
		
		private string _Module;
		public string Module { 
		    get{
		        return _Module;
		    } 
		    set{
		        this.OnModuleChanging(value);
                this.SendPropertyChanging();
                this._Module = value;
                this.SendPropertyChanged("Module");
                this.OnModuleChanged();
		    }
		}
		
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
		
		private string _Description;
		public string Description { 
		    get{
		        return _Description;
		    } 
		    set{
		        this.OnDescriptionChanging(value);
                this.SendPropertyChanging();
                this._Description = value;
                this.SendPropertyChanged("Description");
                this.OnDescriptionChanged();
		    }
		}
		
        partial void OnConfigurableChanging(bool? value);
        partial void OnConfigurableChanged();
		
		private bool? _Configurable;
		public bool? Configurable { 
		    get{
		        return _Configurable;
		    } 
		    set{
		        this.OnConfigurableChanging(value);
                this.SendPropertyChanging();
                this._Configurable = value;
                this.SendPropertyChanged("Configurable");
                this.OnConfigurableChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the TreeMenu table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.TreeMenu 
    /// </summary>

	public partial class TreeMenu: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public TreeMenu(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
		
		private string _Text;
		public string Text { 
		    get{
		        return _Text;
		    } 
		    set{
		        this.OnTextChanging(value);
                this.SendPropertyChanging();
                this._Text = value;
                this.SendPropertyChanged("Text");
                this.OnTextChanged();
		    }
		}
		
        partial void OnImageIndexChanging(long? value);
        partial void OnImageIndexChanged();
		
		private long? _ImageIndex;
		public long? ImageIndex { 
		    get{
		        return _ImageIndex;
		    } 
		    set{
		        this.OnImageIndexChanging(value);
                this.SendPropertyChanging();
                this._ImageIndex = value;
                this.SendPropertyChanged("ImageIndex");
                this.OnImageIndexChanged();
		    }
		}
		
        partial void OnSelectedImageIndexChanging(long? value);
        partial void OnSelectedImageIndexChanged();
		
		private long? _SelectedImageIndex;
		public long? SelectedImageIndex { 
		    get{
		        return _SelectedImageIndex;
		    } 
		    set{
		        this.OnSelectedImageIndexChanging(value);
                this.SendPropertyChanging();
                this._SelectedImageIndex = value;
                this.SendPropertyChanged("SelectedImageIndex");
                this.OnSelectedImageIndexChanged();
		    }
		}
		
        partial void OnParentIdChanging(long? value);
        partial void OnParentIdChanged();
		
		private long? _ParentId;
		public long? ParentId { 
		    get{
		        return _ParentId;
		    } 
		    set{
		        this.OnParentIdChanging(value);
                this.SendPropertyChanging();
                this._ParentId = value;
                this.SendPropertyChanged("ParentId");
                this.OnParentIdChanged();
		    }
		}
		
        partial void OnActionClassChanging(string value);
        partial void OnActionClassChanged();
		
		private string _ActionClass;
		public string ActionClass { 
		    get{
		        return _ActionClass;
		    } 
		    set{
		        this.OnActionClassChanging(value);
                this.SendPropertyChanging();
                this._ActionClass = value;
                this.SendPropertyChanged("ActionClass");
                this.OnActionClassChanged();
		    }
		}
		
        partial void OnSequenceChanging(long? value);
        partial void OnSequenceChanged();
		
		private long? _Sequence;
		public long? Sequence { 
		    get{
		        return _Sequence;
		    } 
		    set{
		        this.OnSequenceChanging(value);
                this.SendPropertyChanging();
                this._Sequence = value;
                this.SendPropertyChanged("Sequence");
                this.OnSequenceChanged();
		    }
		}
		
        partial void OnModuleChanging(string value);
        partial void OnModuleChanged();
		
		private string _Module;
		public string Module { 
		    get{
		        return _Module;
		    } 
		    set{
		        this.OnModuleChanging(value);
                this.SendPropertyChanging();
                this._Module = value;
                this.SendPropertyChanged("Module");
                this.OnModuleChanged();
		    }
		}
		
        partial void OnEnabledChanging(bool? value);
        partial void OnEnabledChanged();
		
		private bool? _Enabled;
		public bool? Enabled { 
		    get{
		        return _Enabled;
		    } 
		    set{
		        this.OnEnabledChanging(value);
                this.SendPropertyChanging();
                this._Enabled = value;
                this.SendPropertyChanged("Enabled");
                this.OnEnabledChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the EmailConfig table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.EmailConfig 
    /// </summary>

	public partial class EmailConfig: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public EmailConfig(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnSenderEmailChanging(string value);
        partial void OnSenderEmailChanged();
		
		private string _SenderEmail;
		public string SenderEmail { 
		    get{
		        return _SenderEmail;
		    } 
		    set{
		        this.OnSenderEmailChanging(value);
                this.SendPropertyChanging();
                this._SenderEmail = value;
                this.SendPropertyChanged("SenderEmail");
                this.OnSenderEmailChanged();
		    }
		}
		
        partial void OnMailSubjectChanging(string value);
        partial void OnMailSubjectChanged();
		
		private string _MailSubject;
		public string MailSubject { 
		    get{
		        return _MailSubject;
		    } 
		    set{
		        this.OnMailSubjectChanging(value);
                this.SendPropertyChanging();
                this._MailSubject = value;
                this.SendPropertyChanged("MailSubject");
                this.OnMailSubjectChanged();
		    }
		}
		
        partial void OnSmtpServerChanging(string value);
        partial void OnSmtpServerChanged();
		
		private string _SmtpServer;
		public string SmtpServer { 
		    get{
		        return _SmtpServer;
		    } 
		    set{
		        this.OnSmtpServerChanging(value);
                this.SendPropertyChanging();
                this._SmtpServer = value;
                this.SendPropertyChanged("SmtpServer");
                this.OnSmtpServerChanged();
		    }
		}
		
        partial void OnAuthenticationChanging(bool? value);
        partial void OnAuthenticationChanged();
		
		private bool? _Authentication;
		public bool? Authentication { 
		    get{
		        return _Authentication;
		    } 
		    set{
		        this.OnAuthenticationChanging(value);
                this.SendPropertyChanging();
                this._Authentication = value;
                this.SendPropertyChanged("Authentication");
                this.OnAuthenticationChanged();
		    }
		}
		
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
		
		private string _UserName;
		public string UserName { 
		    get{
		        return _UserName;
		    } 
		    set{
		        this.OnUserNameChanging(value);
                this.SendPropertyChanging();
                this._UserName = value;
                this.SendPropertyChanged("UserName");
                this.OnUserNameChanged();
		    }
		}
		
        partial void OnUserPasswordChanging(string value);
        partial void OnUserPasswordChanged();
		
		private string _UserPassword;
		public string UserPassword { 
		    get{
		        return _UserPassword;
		    } 
		    set{
		        this.OnUserPasswordChanging(value);
                this.SendPropertyChanging();
                this._UserPassword = value;
                this.SendPropertyChanged("UserPassword");
                this.OnUserPasswordChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the GatewayConfig table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.GatewayConfig 
    /// </summary>

	public partial class GatewayConfig: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public GatewayConfig(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
		
		private string _Id;
		public string Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnComPortChanging(string value);
        partial void OnComPortChanged();
		
		private string _ComPort;
		public string ComPort { 
		    get{
		        return _ComPort;
		    } 
		    set{
		        this.OnComPortChanging(value);
                this.SendPropertyChanging();
                this._ComPort = value;
                this.SendPropertyChanged("ComPort");
                this.OnComPortChanged();
		    }
		}
		
        partial void OnBaudRateChanging(string value);
        partial void OnBaudRateChanged();
		
		private string _BaudRate;
		public string BaudRate { 
		    get{
		        return _BaudRate;
		    } 
		    set{
		        this.OnBaudRateChanging(value);
                this.SendPropertyChanging();
                this._BaudRate = value;
                this.SendPropertyChanged("BaudRate");
                this.OnBaudRateChanged();
		    }
		}
		
        partial void OnDataBitsChanging(string value);
        partial void OnDataBitsChanged();
		
		private string _DataBits;
		public string DataBits { 
		    get{
		        return _DataBits;
		    } 
		    set{
		        this.OnDataBitsChanging(value);
                this.SendPropertyChanging();
                this._DataBits = value;
                this.SendPropertyChanged("DataBits");
                this.OnDataBitsChanged();
		    }
		}
		
        partial void OnParityChanging(string value);
        partial void OnParityChanged();
		
		private string _Parity;
		public string Parity { 
		    get{
		        return _Parity;
		    } 
		    set{
		        this.OnParityChanging(value);
                this.SendPropertyChanging();
                this._Parity = value;
                this.SendPropertyChanged("Parity");
                this.OnParityChanged();
		    }
		}
		
        partial void OnStopBitsChanging(string value);
        partial void OnStopBitsChanged();
		
		private string _StopBits;
		public string StopBits { 
		    get{
		        return _StopBits;
		    } 
		    set{
		        this.OnStopBitsChanging(value);
                this.SendPropertyChanging();
                this._StopBits = value;
                this.SendPropertyChanged("StopBits");
                this.OnStopBitsChanged();
		    }
		}
		
        partial void OnHandshakeChanging(string value);
        partial void OnHandshakeChanged();
		
		private string _Handshake;
		public string Handshake { 
		    get{
		        return _Handshake;
		    } 
		    set{
		        this.OnHandshakeChanging(value);
                this.SendPropertyChanging();
                this._Handshake = value;
                this.SendPropertyChanged("Handshake");
                this.OnHandshakeChanged();
		    }
		}
		
        partial void OnOwnNumberChanging(string value);
        partial void OnOwnNumberChanged();
		
		private string _OwnNumber;
		public string OwnNumber { 
		    get{
		        return _OwnNumber;
		    } 
		    set{
		        this.OnOwnNumberChanging(value);
                this.SendPropertyChanging();
                this._OwnNumber = value;
                this.SendPropertyChanged("OwnNumber");
                this.OnOwnNumberChanged();
		    }
		}
		
        partial void OnSmscChanging(string value);
        partial void OnSmscChanged();
		
		private string _Smsc;
		public string Smsc { 
		    get{
		        return _Smsc;
		    } 
		    set{
		        this.OnSmscChanging(value);
                this.SendPropertyChanging();
                this._Smsc = value;
                this.SendPropertyChanged("Smsc");
                this.OnSmscChanged();
		    }
		}
		
        partial void OnUseSimSmscChanging(bool? value);
        partial void OnUseSimSmscChanged();
		
		private bool? _UseSimSmsc;
		public bool? UseSimSmsc { 
		    get{
		        return _UseSimSmsc;
		    } 
		    set{
		        this.OnUseSimSmscChanging(value);
                this.SendPropertyChanging();
                this._UseSimSmsc = value;
                this.SendPropertyChanged("UseSimSmsc");
                this.OnUseSimSmscChanged();
		    }
		}
		
        partial void OnPinChanging(string value);
        partial void OnPinChanged();
		
		private string _Pin;
		public string Pin { 
		    get{
		        return _Pin;
		    } 
		    set{
		        this.OnPinChanging(value);
                this.SendPropertyChanging();
                this._Pin = value;
                this.SendPropertyChanged("Pin");
                this.OnPinChanged();
		    }
		}
		
        partial void OnMessageValidityChanging(string value);
        partial void OnMessageValidityChanged();
		
		private string _MessageValidity;
		public string MessageValidity { 
		    get{
		        return _MessageValidity;
		    } 
		    set{
		        this.OnMessageValidityChanging(value);
                this.SendPropertyChanging();
                this._MessageValidity = value;
                this.SendPropertyChanged("MessageValidity");
                this.OnMessageValidityChanged();
		    }
		}
		
        partial void OnLongMessageOptionChanging(string value);
        partial void OnLongMessageOptionChanged();
		
		private string _LongMessageOption;
		public string LongMessageOption { 
		    get{
		        return _LongMessageOption;
		    } 
		    set{
		        this.OnLongMessageOptionChanging(value);
                this.SendPropertyChanging();
                this._LongMessageOption = value;
                this.SendPropertyChanged("LongMessageOption");
                this.OnLongMessageOptionChanged();
		    }
		}
		
        partial void OnMessageMemoryChanging(string value);
        partial void OnMessageMemoryChanged();
		
		private string _MessageMemory;
		public string MessageMemory { 
		    get{
		        return _MessageMemory;
		    } 
		    set{
		        this.OnMessageMemoryChanging(value);
                this.SendPropertyChanging();
                this._MessageMemory = value;
                this.SendPropertyChanged("MessageMemory");
                this.OnMessageMemoryChanged();
		    }
		}
		
        partial void OnFunctionsChanging(long? value);
        partial void OnFunctionsChanged();
		
		private long? _Functions;
		public long? Functions { 
		    get{
		        return _Functions;
		    } 
		    set{
		        this.OnFunctionsChanging(value);
                this.SendPropertyChanging();
                this._Functions = value;
                this.SendPropertyChanged("Functions");
                this.OnFunctionsChanged();
		    }
		}
		
        partial void OnLogSettingsChanging(string value);
        partial void OnLogSettingsChanged();
		
		private string _LogSettings;
		public string LogSettings { 
		    get{
		        return _LogSettings;
		    } 
		    set{
		        this.OnLogSettingsChanging(value);
                this.SendPropertyChanging();
                this._LogSettings = value;
                this.SendPropertyChanged("LogSettings");
                this.OnLogSettingsChanged();
		    }
		}
		
        partial void OnClearLogOnConnectChanging(bool? value);
        partial void OnClearLogOnConnectChanged();
		
		private bool? _ClearLogOnConnect;
		public bool? ClearLogOnConnect { 
		    get{
		        return _ClearLogOnConnect;
		    } 
		    set{
		        this.OnClearLogOnConnectChanging(value);
                this.SendPropertyChanging();
                this._ClearLogOnConnect = value;
                this.SendPropertyChanged("ClearLogOnConnect");
                this.OnClearLogOnConnectChanged();
		    }
		}
		
        partial void OnAutoConnectChanging(bool? value);
        partial void OnAutoConnectChanged();
		
		private bool? _AutoConnect;
		public bool? AutoConnect { 
		    get{
		        return _AutoConnect;
		    } 
		    set{
		        this.OnAutoConnectChanging(value);
                this.SendPropertyChanging();
                this._AutoConnect = value;
                this.SendPropertyChanged("AutoConnect");
                this.OnAutoConnectChanged();
		    }
		}
		
        partial void OnInitializeChanging(bool? value);
        partial void OnInitializeChanged();
		
		private bool? _Initialize;
		public bool? Initialize { 
		    get{
		        return _Initialize;
		    } 
		    set{
		        this.OnInitializeChanging(value);
                this.SendPropertyChanging();
                this._Initialize = value;
                this.SendPropertyChanged("Initialize");
                this.OnInitializeChanged();
		    }
		}
		
        partial void OnCommandTimeoutChanging(long? value);
        partial void OnCommandTimeoutChanged();
		
		private long? _CommandTimeout;
		public long? CommandTimeout { 
		    get{
		        return _CommandTimeout;
		    } 
		    set{
		        this.OnCommandTimeoutChanging(value);
                this.SendPropertyChanging();
                this._CommandTimeout = value;
                this.SendPropertyChanged("CommandTimeout");
                this.OnCommandTimeoutChanged();
		    }
		}
		
        partial void OnReadTimeoutChanging(long? value);
        partial void OnReadTimeoutChanged();
		
		private long? _ReadTimeout;
		public long? ReadTimeout { 
		    get{
		        return _ReadTimeout;
		    } 
		    set{
		        this.OnReadTimeoutChanging(value);
                this.SendPropertyChanging();
                this._ReadTimeout = value;
                this.SendPropertyChanged("ReadTimeout");
                this.OnReadTimeoutChanged();
		    }
		}
		
        partial void OnCommandDelayChanging(long? value);
        partial void OnCommandDelayChanged();
		
		private long? _CommandDelay;
		public long? CommandDelay { 
		    get{
		        return _CommandDelay;
		    } 
		    set{
		        this.OnCommandDelayChanging(value);
                this.SendPropertyChanging();
                this._CommandDelay = value;
                this.SendPropertyChanged("CommandDelay");
                this.OnCommandDelayChanged();
		    }
		}
		
        partial void OnSendRetryChanging(long? value);
        partial void OnSendRetryChanged();
		
		private long? _SendRetry;
		public long? SendRetry { 
		    get{
		        return _SendRetry;
		    } 
		    set{
		        this.OnSendRetryChanging(value);
                this.SendPropertyChanging();
                this._SendRetry = value;
                this.SendPropertyChanged("SendRetry");
                this.OnSendRetryChanged();
		    }
		}
		
        partial void OnSendDelayChanging(long? value);
        partial void OnSendDelayChanged();
		
		private long? _SendDelay;
		public long? SendDelay { 
		    get{
		        return _SendDelay;
		    } 
		    set{
		        this.OnSendDelayChanging(value);
                this.SendPropertyChanging();
                this._SendDelay = value;
                this.SendPropertyChanged("SendDelay");
                this.OnSendDelayChanged();
		    }
		}
		
        partial void OnRequestStatusReportChanging(bool? value);
        partial void OnRequestStatusReportChanged();
		
		private bool? _RequestStatusReport;
		public bool? RequestStatusReport { 
		    get{
		        return _RequestStatusReport;
		    } 
		    set{
		        this.OnRequestStatusReportChanging(value);
                this.SendPropertyChanging();
                this._RequestStatusReport = value;
                this.SendPropertyChanged("RequestStatusReport");
                this.OnRequestStatusReportChanged();
		    }
		}
		
        partial void OnSignalRefreshIntervalChanging(long? value);
        partial void OnSignalRefreshIntervalChanged();
		
		private long? _SignalRefreshInterval;
		public long? SignalRefreshInterval { 
		    get{
		        return _SignalRefreshInterval;
		    } 
		    set{
		        this.OnSignalRefreshIntervalChanging(value);
                this.SendPropertyChanging();
                this._SignalRefreshInterval = value;
                this.SendPropertyChanged("SignalRefreshInterval");
                this.OnSignalRefreshIntervalChanged();
		    }
		}
		
        partial void OnAutoResponseCallChanging(bool? value);
        partial void OnAutoResponseCallChanged();
		
		private bool? _AutoResponseCall;
		public bool? AutoResponseCall { 
		    get{
		        return _AutoResponseCall;
		    } 
		    set{
		        this.OnAutoResponseCallChanging(value);
                this.SendPropertyChanging();
                this._AutoResponseCall = value;
                this.SendPropertyChanged("AutoResponseCall");
                this.OnAutoResponseCallChanged();
		    }
		}
		
        partial void OnAutoResponseCallTextChanging(string value);
        partial void OnAutoResponseCallTextChanged();
		
		private string _AutoResponseCallText;
		public string AutoResponseCallText { 
		    get{
		        return _AutoResponseCallText;
		    } 
		    set{
		        this.OnAutoResponseCallTextChanging(value);
                this.SendPropertyChanging();
                this._AutoResponseCallText = value;
                this.SendPropertyChanged("AutoResponseCallText");
                this.OnAutoResponseCallTextChanged();
		    }
		}
		
        partial void OnAutoArchiveLogChanging(bool? value);
        partial void OnAutoArchiveLogChanged();
		
		private bool? _AutoArchiveLog;
		public bool? AutoArchiveLog { 
		    get{
		        return _AutoArchiveLog;
		    } 
		    set{
		        this.OnAutoArchiveLogChanging(value);
                this.SendPropertyChanging();
                this._AutoArchiveLog = value;
                this.SendPropertyChanged("AutoArchiveLog");
                this.OnAutoArchiveLogChanged();
		    }
		}
		
        partial void OnAutoArchiveLogIntervalChanging(long? value);
        partial void OnAutoArchiveLogIntervalChanged();
		
		private long? _AutoArchiveLogInterval;
		public long? AutoArchiveLogInterval { 
		    get{
		        return _AutoArchiveLogInterval;
		    } 
		    set{
		        this.OnAutoArchiveLogIntervalChanging(value);
                this.SendPropertyChanging();
                this._AutoArchiveLogInterval = value;
                this.SendPropertyChanged("AutoArchiveLogInterval");
                this.OnAutoArchiveLogIntervalChanged();
		    }
		}
		
        partial void OnArchiveOldMessageIntervalChanging(long? value);
        partial void OnArchiveOldMessageIntervalChanged();
		
		private long? _ArchiveOldMessageInterval;
		public long? ArchiveOldMessageInterval { 
		    get{
		        return _ArchiveOldMessageInterval;
		    } 
		    set{
		        this.OnArchiveOldMessageIntervalChanging(value);
                this.SendPropertyChanging();
                this._ArchiveOldMessageInterval = value;
                this.SendPropertyChanged("ArchiveOldMessageInterval");
                this.OnArchiveOldMessageIntervalChanged();
		    }
		}
		
        partial void OnForwardArchivedMessageChanging(bool? value);
        partial void OnForwardArchivedMessageChanged();
		
		private bool? _ForwardArchivedMessage;
		public bool? ForwardArchivedMessage { 
		    get{
		        return _ForwardArchivedMessage;
		    } 
		    set{
		        this.OnForwardArchivedMessageChanging(value);
                this.SendPropertyChanging();
                this._ForwardArchivedMessage = value;
                this.SendPropertyChanged("ForwardArchivedMessage");
                this.OnForwardArchivedMessageChanged();
		    }
		}
		
        partial void OnForwardEmailChanging(string value);
        partial void OnForwardEmailChanged();
		
		private string _ForwardEmail;
		public string ForwardEmail { 
		    get{
		        return _ForwardEmail;
		    } 
		    set{
		        this.OnForwardEmailChanging(value);
                this.SendPropertyChanging();
                this._ForwardEmail = value;
                this.SendPropertyChanged("ForwardEmail");
                this.OnForwardEmailChanged();
		    }
		}
		
        partial void OnDeleteArchivedMessageChanging(bool? value);
        partial void OnDeleteArchivedMessageChanged();
		
		private bool? _DeleteArchivedMessage;
		public bool? DeleteArchivedMessage { 
		    get{
		        return _DeleteArchivedMessage;
		    } 
		    set{
		        this.OnDeleteArchivedMessageChanging(value);
                this.SendPropertyChanging();
                this._DeleteArchivedMessage = value;
                this.SendPropertyChanged("DeleteArchivedMessage");
                this.OnDeleteArchivedMessageChanged();
		    }
		}
		
        partial void OnDeleteArchivedMessageIntervalChanging(long? value);
        partial void OnDeleteArchivedMessageIntervalChanged();
		
		private long? _DeleteArchivedMessageInterval;
		public long? DeleteArchivedMessageInterval { 
		    get{
		        return _DeleteArchivedMessageInterval;
		    } 
		    set{
		        this.OnDeleteArchivedMessageIntervalChanging(value);
                this.SendPropertyChanging();
                this._DeleteArchivedMessageInterval = value;
                this.SendPropertyChanged("DeleteArchivedMessageInterval");
                this.OnDeleteArchivedMessageIntervalChanged();
		    }
		}
		
        partial void OnDeleteAfterRetrieveChanging(bool? value);
        partial void OnDeleteAfterRetrieveChanged();
		
		private bool? _DeleteAfterRetrieve;
		public bool? DeleteAfterRetrieve { 
		    get{
		        return _DeleteAfterRetrieve;
		    } 
		    set{
		        this.OnDeleteAfterRetrieveChanging(value);
                this.SendPropertyChanging();
                this._DeleteAfterRetrieve = value;
                this.SendPropertyChanged("DeleteAfterRetrieve");
                this.OnDeleteAfterRetrieveChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the IncomingMessage table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.IncomingMessage 
    /// </summary>

	public partial class IncomingMessage: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public IncomingMessage(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
		
		private string _Id;
		public string Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnOriginatorChanging(string value);
        partial void OnOriginatorChanged();
		
		private string _Originator;
		public string Originator { 
		    get{
		        return _Originator;
		    } 
		    set{
		        this.OnOriginatorChanging(value);
                this.SendPropertyChanging();
                this._Originator = value;
                this.SendPropertyChanged("Originator");
                this.OnOriginatorChanged();
		    }
		}
		
        partial void OnOriginatorReceivedDateChanging(DateTime? value);
        partial void OnOriginatorReceivedDateChanged();
		
		private DateTime? _OriginatorReceivedDate;
		public DateTime? OriginatorReceivedDate { 
		    get{
		        return _OriginatorReceivedDate;
		    } 
		    set{
		        this.OnOriginatorReceivedDateChanging(value);
                this.SendPropertyChanging();
                this._OriginatorReceivedDate = value;
                this.SendPropertyChanged("OriginatorReceivedDate");
                this.OnOriginatorReceivedDateChanged();
		    }
		}
		
        partial void OnTimezoneChanging(string value);
        partial void OnTimezoneChanged();
		
		private string _Timezone;
		public string Timezone { 
		    get{
		        return _Timezone;
		    } 
		    set{
		        this.OnTimezoneChanging(value);
                this.SendPropertyChanging();
                this._Timezone = value;
                this.SendPropertyChanged("Timezone");
                this.OnTimezoneChanged();
		    }
		}
		
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
		
		private string _Message;
		public string Message { 
		    get{
		        return _Message;
		    } 
		    set{
		        this.OnMessageChanging(value);
                this.SendPropertyChanging();
                this._Message = value;
                this.SendPropertyChanged("Message");
                this.OnMessageChanged();
		    }
		}
		
        partial void OnMessageTypeChanging(string value);
        partial void OnMessageTypeChanged();
		
		private string _MessageType;
		public string MessageType { 
		    get{
		        return _MessageType;
		    } 
		    set{
		        this.OnMessageTypeChanging(value);
                this.SendPropertyChanging();
                this._MessageType = value;
                this.SendPropertyChanged("MessageType");
                this.OnMessageTypeChanged();
		    }
		}
		
        partial void OnDeliveryStatusChanging(string value);
        partial void OnDeliveryStatusChanged();
		
		private string _DeliveryStatus;
		public string DeliveryStatus { 
		    get{
		        return _DeliveryStatus;
		    } 
		    set{
		        this.OnDeliveryStatusChanging(value);
                this.SendPropertyChanging();
                this._DeliveryStatus = value;
                this.SendPropertyChanged("DeliveryStatus");
                this.OnDeliveryStatusChanged();
		    }
		}
		
        partial void OnReceivedDateChanging(DateTime value);
        partial void OnReceivedDateChanged();
		
		private DateTime _ReceivedDate;
		public DateTime ReceivedDate { 
		    get{
		        return _ReceivedDate;
		    } 
		    set{
		        this.OnReceivedDateChanging(value);
                this.SendPropertyChanging();
                this._ReceivedDate = value;
                this.SendPropertyChanged("ReceivedDate");
                this.OnReceivedDateChanged();
		    }
		}
		
        partial void OnValidityTimeStampChanging(DateTime value);
        partial void OnValidityTimeStampChanged();
		
		private DateTime _ValidityTimeStamp;
		public DateTime ValidityTimeStamp { 
		    get{
		        return _ValidityTimeStamp;
		    } 
		    set{
		        this.OnValidityTimeStampChanging(value);
                this.SendPropertyChanging();
                this._ValidityTimeStamp = value;
                this.SendPropertyChanged("ValidityTimeStamp");
                this.OnValidityTimeStampChanged();
		    }
		}
		
        partial void OnOriginatorRefNoChanging(long value);
        partial void OnOriginatorRefNoChanged();
		
		private long _OriginatorRefNo;
		public long OriginatorRefNo { 
		    get{
		        return _OriginatorRefNo;
		    } 
		    set{
		        this.OnOriginatorRefNoChanging(value);
                this.SendPropertyChanging();
                this._OriginatorRefNo = value;
                this.SendPropertyChanged("OriginatorRefNo");
                this.OnOriginatorRefNoChanged();
		    }
		}
		
        partial void OnMessageStatusTypeChanging(string value);
        partial void OnMessageStatusTypeChanged();
		
		private string _MessageStatusType;
		public string MessageStatusType { 
		    get{
		        return _MessageStatusType;
		    } 
		    set{
		        this.OnMessageStatusTypeChanging(value);
                this.SendPropertyChanging();
                this._MessageStatusType = value;
                this.SendPropertyChanged("MessageStatusType");
                this.OnMessageStatusTypeChanged();
		    }
		}
		
        partial void OnSrcPortChanging(long value);
        partial void OnSrcPortChanged();
		
		private long _SrcPort;
		public long SrcPort { 
		    get{
		        return _SrcPort;
		    } 
		    set{
		        this.OnSrcPortChanging(value);
                this.SendPropertyChanging();
                this._SrcPort = value;
                this.SendPropertyChanged("SrcPort");
                this.OnSrcPortChanged();
		    }
		}
		
        partial void OnDestPortChanging(long? value);
        partial void OnDestPortChanged();
		
		private long? _DestPort;
		public long? DestPort { 
		    get{
		        return _DestPort;
		    } 
		    set{
		        this.OnDestPortChanging(value);
                this.SendPropertyChanging();
                this._DestPort = value;
                this.SendPropertyChanged("DestPort");
                this.OnDestPortChanged();
		    }
		}
		
        partial void OnStatusChanging(string value);
        partial void OnStatusChanged();
		
		private string _Status;
		public string Status { 
		    get{
		        return _Status;
		    } 
		    set{
		        this.OnStatusChanging(value);
                this.SendPropertyChanging();
                this._Status = value;
                this.SendPropertyChanged("Status");
                this.OnStatusChanged();
		    }
		}
		
        partial void OnRawMessageChanging(string value);
        partial void OnRawMessageChanged();
		
		private string _RawMessage;
		public string RawMessage { 
		    get{
		        return _RawMessage;
		    } 
		    set{
		        this.OnRawMessageChanging(value);
                this.SendPropertyChanging();
                this._RawMessage = value;
                this.SendPropertyChanged("RawMessage");
                this.OnRawMessageChanged();
		    }
		}
		
        partial void OnGatewayIdChanging(string value);
        partial void OnGatewayIdChanged();
		
		private string _GatewayId;
		public string GatewayId { 
		    get{
		        return _GatewayId;
		    } 
		    set{
		        this.OnGatewayIdChanging(value);
                this.SendPropertyChanging();
                this._GatewayId = value;
                this.SendPropertyChanged("GatewayId");
                this.OnGatewayIdChanged();
		    }
		}
		
        partial void OnLastUpdateChanging(DateTime value);
        partial void OnLastUpdateChanged();
		
		private DateTime _LastUpdate;
		public DateTime LastUpdate { 
		    get{
		        return _LastUpdate;
		    } 
		    set{
		        this.OnLastUpdateChanging(value);
                this.SendPropertyChanging();
                this._LastUpdate = value;
                this.SendPropertyChanged("LastUpdate");
                this.OnLastUpdateChanged();
		    }
		}
		
        partial void OnCreateDateChanging(DateTime value);
        partial void OnCreateDateChanged();
		
		private DateTime _CreateDate;
		public DateTime CreateDate { 
		    get{
		        return _CreateDate;
		    } 
		    set{
		        this.OnCreateDateChanging(value);
                this.SendPropertyChanging();
                this._CreateDate = value;
                this.SendPropertyChanged("CreateDate");
                this.OnCreateDateChanged();
		    }
		}
		
        partial void OnIndexesChanging(string value);
        partial void OnIndexesChanged();
		
		private string _Indexes;
		public string Indexes { 
		    get{
		        return _Indexes;
		    } 
		    set{
		        this.OnIndexesChanging(value);
                this.SendPropertyChanging();
                this._Indexes = value;
                this.SendPropertyChanged("Indexes");
                this.OnIndexesChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the OutgoingMessage table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.OutgoingMessage 
    /// </summary>

	public partial class OutgoingMessage: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public OutgoingMessage(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
		
		private string _Id;
		public string Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnOriginatorChanging(string value);
        partial void OnOriginatorChanged();
		
		private string _Originator;
		public string Originator { 
		    get{
		        return _Originator;
		    } 
		    set{
		        this.OnOriginatorChanging(value);
                this.SendPropertyChanging();
                this._Originator = value;
                this.SendPropertyChanged("Originator");
                this.OnOriginatorChanged();
		    }
		}
		
        partial void OnRecipientChanging(string value);
        partial void OnRecipientChanged();
		
		private string _Recipient;
		public string Recipient { 
		    get{
		        return _Recipient;
		    } 
		    set{
		        this.OnRecipientChanging(value);
                this.SendPropertyChanging();
                this._Recipient = value;
                this.SendPropertyChanged("Recipient");
                this.OnRecipientChanged();
		    }
		}
		
        partial void OnMessageTypeChanging(string value);
        partial void OnMessageTypeChanged();
		
		private string _MessageType;
		public string MessageType { 
		    get{
		        return _MessageType;
		    } 
		    set{
		        this.OnMessageTypeChanging(value);
                this.SendPropertyChanging();
                this._MessageType = value;
                this.SendPropertyChanged("MessageType");
                this.OnMessageTypeChanged();
		    }
		}
		
        partial void OnMessageFormatChanging(string value);
        partial void OnMessageFormatChanged();
		
		private string _MessageFormat;
		public string MessageFormat { 
		    get{
		        return _MessageFormat;
		    } 
		    set{
		        this.OnMessageFormatChanging(value);
                this.SendPropertyChanging();
                this._MessageFormat = value;
                this.SendPropertyChanged("MessageFormat");
                this.OnMessageFormatChanged();
		    }
		}
		
        partial void OnPriorityChanging(string value);
        partial void OnPriorityChanged();
		
		private string _Priority;
		public string Priority { 
		    get{
		        return _Priority;
		    } 
		    set{
		        this.OnPriorityChanging(value);
                this.SendPropertyChanging();
                this._Priority = value;
                this.SendPropertyChanged("Priority");
                this.OnPriorityChanged();
		    }
		}
		
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
		
		private string _Message;
		public string Message { 
		    get{
		        return _Message;
		    } 
		    set{
		        this.OnMessageChanging(value);
                this.SendPropertyChanging();
                this._Message = value;
                this.SendPropertyChanged("Message");
                this.OnMessageChanged();
		    }
		}
		
        partial void OnScheduledDateChanging(DateTime? value);
        partial void OnScheduledDateChanged();
		
		private DateTime? _ScheduledDate;
		public DateTime? ScheduledDate { 
		    get{
		        return _ScheduledDate;
		    } 
		    set{
		        this.OnScheduledDateChanging(value);
                this.SendPropertyChanging();
                this._ScheduledDate = value;
                this.SendPropertyChanged("ScheduledDate");
                this.OnScheduledDateChanged();
		    }
		}
		
        partial void OnQuantityChanging(long value);
        partial void OnQuantityChanged();
		
		private long _Quantity;
		public long Quantity { 
		    get{
		        return _Quantity;
		    } 
		    set{
		        this.OnQuantityChanging(value);
                this.SendPropertyChanging();
                this._Quantity = value;
                this.SendPropertyChanged("Quantity");
                this.OnQuantityChanged();
		    }
		}
		
        partial void OnMessageClassChanging(string value);
        partial void OnMessageClassChanged();
		
		private string _MessageClass;
		public string MessageClass { 
		    get{
		        return _MessageClass;
		    } 
		    set{
		        this.OnMessageClassChanging(value);
                this.SendPropertyChanging();
                this._MessageClass = value;
                this.SendPropertyChanged("MessageClass");
                this.OnMessageClassChanged();
		    }
		}
		
        partial void OnSrcPortChanging(long value);
        partial void OnSrcPortChanged();
		
		private long _SrcPort;
		public long SrcPort { 
		    get{
		        return _SrcPort;
		    } 
		    set{
		        this.OnSrcPortChanging(value);
                this.SendPropertyChanging();
                this._SrcPort = value;
                this.SendPropertyChanged("SrcPort");
                this.OnSrcPortChanged();
		    }
		}
		
        partial void OnDestPortChanging(long value);
        partial void OnDestPortChanged();
		
		private long _DestPort;
		public long DestPort { 
		    get{
		        return _DestPort;
		    } 
		    set{
		        this.OnDestPortChanging(value);
                this.SendPropertyChanging();
                this._DestPort = value;
                this.SendPropertyChanged("DestPort");
                this.OnDestPortChanged();
		    }
		}
		
        partial void OnStatusReportChanging(string value);
        partial void OnStatusReportChanged();
		
		private string _StatusReport;
		public string StatusReport { 
		    get{
		        return _StatusReport;
		    } 
		    set{
		        this.OnStatusReportChanging(value);
                this.SendPropertyChanging();
                this._StatusReport = value;
                this.SendPropertyChanged("StatusReport");
                this.OnStatusReportChanged();
		    }
		}
		
        partial void OnWapUrlChanging(string value);
        partial void OnWapUrlChanged();
		
		private string _WapUrl;
		public string WapUrl { 
		    get{
		        return _WapUrl;
		    } 
		    set{
		        this.OnWapUrlChanging(value);
                this.SendPropertyChanging();
                this._WapUrl = value;
                this.SendPropertyChanged("WapUrl");
                this.OnWapUrlChanged();
		    }
		}
		
        partial void OnWapExpiryDateChanging(DateTime? value);
        partial void OnWapExpiryDateChanged();
		
		private DateTime? _WapExpiryDate;
		public DateTime? WapExpiryDate { 
		    get{
		        return _WapExpiryDate;
		    } 
		    set{
		        this.OnWapExpiryDateChanging(value);
                this.SendPropertyChanging();
                this._WapExpiryDate = value;
                this.SendPropertyChanged("WapExpiryDate");
                this.OnWapExpiryDateChanged();
		    }
		}
		
        partial void OnWapCreateDateChanging(DateTime? value);
        partial void OnWapCreateDateChanged();
		
		private DateTime? _WapCreateDate;
		public DateTime? WapCreateDate { 
		    get{
		        return _WapCreateDate;
		    } 
		    set{
		        this.OnWapCreateDateChanging(value);
                this.SendPropertyChanging();
                this._WapCreateDate = value;
                this.SendPropertyChanged("WapCreateDate");
                this.OnWapCreateDateChanged();
		    }
		}
		
        partial void OnWapSignalChanging(string value);
        partial void OnWapSignalChanged();
		
		private string _WapSignal;
		public string WapSignal { 
		    get{
		        return _WapSignal;
		    } 
		    set{
		        this.OnWapSignalChanging(value);
                this.SendPropertyChanging();
                this._WapSignal = value;
                this.SendPropertyChanged("WapSignal");
                this.OnWapSignalChanged();
		    }
		}
		
        partial void OnLastUpdateChanging(DateTime value);
        partial void OnLastUpdateChanged();
		
		private DateTime _LastUpdate;
		public DateTime LastUpdate { 
		    get{
		        return _LastUpdate;
		    } 
		    set{
		        this.OnLastUpdateChanging(value);
                this.SendPropertyChanging();
                this._LastUpdate = value;
                this.SendPropertyChanged("LastUpdate");
                this.OnLastUpdateChanged();
		    }
		}
		
        partial void OnRefNoChanging(string value);
        partial void OnRefNoChanged();
		
		private string _RefNo;
		public string RefNo { 
		    get{
		        return _RefNo;
		    } 
		    set{
		        this.OnRefNoChanging(value);
                this.SendPropertyChanging();
                this._RefNo = value;
                this.SendPropertyChanged("RefNo");
                this.OnRefNoChanged();
		    }
		}
		
        partial void OnSentDateChanging(DateTime? value);
        partial void OnSentDateChanged();
		
		private DateTime? _SentDate;
		public DateTime? SentDate { 
		    get{
		        return _SentDate;
		    } 
		    set{
		        this.OnSentDateChanging(value);
                this.SendPropertyChanging();
                this._SentDate = value;
                this.SendPropertyChanged("SentDate");
                this.OnSentDateChanged();
		    }
		}
		
        partial void OnStatusChanging(string value);
        partial void OnStatusChanged();
		
		private string _Status;
		public string Status { 
		    get{
		        return _Status;
		    } 
		    set{
		        this.OnStatusChanging(value);
                this.SendPropertyChanging();
                this._Status = value;
                this.SendPropertyChanged("Status");
                this.OnStatusChanged();
		    }
		}
		
        partial void OnErrorsChanging(string value);
        partial void OnErrorsChanged();
		
		private string _Errors;
		public string Errors { 
		    get{
		        return _Errors;
		    } 
		    set{
		        this.OnErrorsChanging(value);
                this.SendPropertyChanging();
                this._Errors = value;
                this.SendPropertyChanged("Errors");
                this.OnErrorsChanged();
		    }
		}
		
        partial void OnGatewayIdChanging(string value);
        partial void OnGatewayIdChanged();
		
		private string _GatewayId;
		public string GatewayId { 
		    get{
		        return _GatewayId;
		    } 
		    set{
		        this.OnGatewayIdChanging(value);
                this.SendPropertyChanging();
                this._GatewayId = value;
                this.SendPropertyChanged("GatewayId");
                this.OnGatewayIdChanged();
		    }
		}
		
        partial void OnCreateDateChanging(DateTime value);
        partial void OnCreateDateChanged();
		
		private DateTime _CreateDate;
		public DateTime CreateDate { 
		    get{
		        return _CreateDate;
		    } 
		    set{
		        this.OnCreateDateChanging(value);
                this.SendPropertyChanging();
                this._CreateDate = value;
                this.SendPropertyChanged("CreateDate");
                this.OnCreateDateChanged();
		    }
		}
		
        partial void OnGroupIdChanging(string value);
        partial void OnGroupIdChanged();
		
		private string _GroupId;
		public string GroupId { 
		    get{
		        return _GroupId;
		    } 
		    set{
		        this.OnGroupIdChanging(value);
                this.SendPropertyChanging();
                this._GroupId = value;
                this.SendPropertyChanged("GroupId");
                this.OnGroupIdChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Role table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.Role 
    /// </summary>

	public partial class Role: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Role(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
		
		private string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		
        partial void OnDescChanging(string value);
        partial void OnDescChanged();
		
		private string _Desc;
		public string Desc { 
		    get{
		        return _Desc;
		    } 
		    set{
		        this.OnDescChanging(value);
                this.SendPropertyChanging();
                this._Desc = value;
                this.SendPropertyChanged("Desc");
                this.OnDescChanged();
		    }
		}
		
        partial void OnCanBeDeletedChanging(bool value);
        partial void OnCanBeDeletedChanged();
		
		private bool _CanBeDeleted;
		public bool CanBeDeleted { 
		    get{
		        return _CanBeDeleted;
		    } 
		    set{
		        this.OnCanBeDeletedChanging(value);
                this.SendPropertyChanging();
                this._CanBeDeleted = value;
                this.SendPropertyChanged("CanBeDeleted");
                this.OnCanBeDeletedChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the User table in the SmartGateway Database.
    /// This class is queryable through SmartGatewayDB.User 
    /// </summary>

	public partial class User: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public User(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
		
		private long _Id;
		public long Id { 
		    get{
		        return _Id;
		    } 
		    set{
		        this.OnIdChanging(value);
                this.SendPropertyChanging();
                this._Id = value;
                this.SendPropertyChanged("Id");
                this.OnIdChanged();
		    }
		}
		
        partial void OnCommonNameChanging(string value);
        partial void OnCommonNameChanged();
		
		private string _CommonName;
		public string CommonName { 
		    get{
		        return _CommonName;
		    } 
		    set{
		        this.OnCommonNameChanging(value);
                this.SendPropertyChanging();
                this._CommonName = value;
                this.SendPropertyChanged("CommonName");
                this.OnCommonNameChanged();
		    }
		}
		
        partial void OnMobtelChanging(string value);
        partial void OnMobtelChanged();
		
		private string _Mobtel;
		public string Mobtel { 
		    get{
		        return _Mobtel;
		    } 
		    set{
		        this.OnMobtelChanging(value);
                this.SendPropertyChanging();
                this._Mobtel = value;
                this.SendPropertyChanged("Mobtel");
                this.OnMobtelChanged();
		    }
		}
		
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
		
		private string _Email;
		public string Email { 
		    get{
		        return _Email;
		    } 
		    set{
		        this.OnEmailChanging(value);
                this.SendPropertyChanging();
                this._Email = value;
                this.SendPropertyChanged("Email");
                this.OnEmailChanged();
		    }
		}
		
        partial void OnLoginNameChanging(string value);
        partial void OnLoginNameChanged();
		
		private string _LoginName;
		public string LoginName { 
		    get{
		        return _LoginName;
		    } 
		    set{
		        this.OnLoginNameChanging(value);
                this.SendPropertyChanging();
                this._LoginName = value;
                this.SendPropertyChanged("LoginName");
                this.OnLoginNameChanged();
		    }
		}
		
        partial void OnPasswordChanging(string value);
        partial void OnPasswordChanged();
		
		private string _Password;
		public string Password { 
		    get{
		        return _Password;
		    } 
		    set{
		        this.OnPasswordChanging(value);
                this.SendPropertyChanging();
                this._Password = value;
                this.SendPropertyChanged("Password");
                this.OnPasswordChanged();
		    }
		}
		
        partial void OnCanBeDeletedChanging(bool value);
        partial void OnCanBeDeletedChanged();
		
		private bool _CanBeDeleted;
		public bool CanBeDeleted { 
		    get{
		        return _CanBeDeleted;
		    } 
		    set{
		        this.OnCanBeDeletedChanging(value);
                this.SendPropertyChanging();
                this._CanBeDeleted = value;
                this.SendPropertyChanged("CanBeDeleted");
                this.OnCanBeDeletedChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
}