


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace MessagingToolkit.SmartGateway.Core.Data.Linq {
	
        /// <summary>
        /// Table: OutgoingCall
        /// Primary Key: Id
        /// </summary>

        public class OutgoingCallTable: DatabaseTable {
            
            public OutgoingCallTable(IDataProvider provider):base("OutgoingCall",provider){
                ClassName = "OutgoingCall";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CallDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CallerId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("GatewayId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn CallDate{
                get{
                    return this.GetColumn("CallDate");
                }
            }
            				
   			public static string CallDateColumn{
			      get{
        			return "CallDate";
      			}
		    }
           
            public IColumn CallerId{
                get{
                    return this.GetColumn("CallerId");
                }
            }
            				
   			public static string CallerIdColumn{
			      get{
        			return "CallerId";
      			}
		    }
           
            public IColumn GatewayId{
                get{
                    return this.GetColumn("GatewayId");
                }
            }
            				
   			public static string GatewayIdColumn{
			      get{
        			return "GatewayId";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: Privilege
        /// Primary Key: Id
        /// </summary>

        public class PrivilegeTable: DatabaseTable {
            
            public PrivilegeTable(IDataProvider provider):base("Privilege",provider){
                ClassName = "Privilege";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Desc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
            				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
           
            public IColumn Desc{
                get{
                    return this.GetColumn("Desc");
                }
            }
            				
   			public static string DescColumn{
			      get{
        			return "Desc";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: RolePrivilegeMap
        /// Primary Key: 
        /// </summary>

        public class RolePrivilegeMapTable: DatabaseTable {
            
            public RolePrivilegeMapTable(IDataProvider provider):base("RolePrivilegeMap",provider){
                ClassName = "RolePrivilegeMap";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("RoleId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("PrivilegeId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });
                    
                
                
            }
            
            public IColumn RoleId{
                get{
                    return this.GetColumn("RoleId");
                }
            }
            				
   			public static string RoleIdColumn{
			      get{
        			return "RoleId";
      			}
		    }
           
            public IColumn PrivilegeId{
                get{
                    return this.GetColumn("PrivilegeId");
                }
            }
            				
   			public static string PrivilegeIdColumn{
			      get{
        			return "PrivilegeId";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: UserRoleMap
        /// Primary Key: 
        /// </summary>

        public class UserRoleMapTable: DatabaseTable {
            
            public UserRoleMapTable(IDataProvider provider):base("UserRoleMap",provider){
                ClassName = "UserRoleMap";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("UserId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("RoleId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });
                    
                
                
            }
            
            public IColumn UserId{
                get{
                    return this.GetColumn("UserId");
                }
            }
            				
   			public static string UserIdColumn{
			      get{
        			return "UserId";
      			}
		    }
           
            public IColumn RoleId{
                get{
                    return this.GetColumn("RoleId");
                }
            }
            				
   			public static string RoleIdColumn{
			      get{
        			return "RoleId";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: IncomingCall
        /// Primary Key: Id
        /// </summary>

        public class IncomingCallTable: DatabaseTable {
            
            public IncomingCallTable(IDataProvider provider):base("IncomingCall",provider){
                ClassName = "IncomingCall";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CallDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CallerId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("GatewayId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn CallDate{
                get{
                    return this.GetColumn("CallDate");
                }
            }
            				
   			public static string CallDateColumn{
			      get{
        			return "CallDate";
      			}
		    }
           
            public IColumn CallerId{
                get{
                    return this.GetColumn("CallerId");
                }
            }
            				
   			public static string CallerIdColumn{
			      get{
        			return "CallerId";
      			}
		    }
           
            public IColumn GatewayId{
                get{
                    return this.GetColumn("GatewayId");
                }
            }
            				
   			public static string GatewayIdColumn{
			      get{
        			return "GatewayId";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: SQLITEADMIN_QUERIES
        /// Primary Key: ID
        /// </summary>

        public class SQLITEADMIN_QUERIESTable: DatabaseTable {
            
            public SQLITEADMIN_QUERIESTable(IDataProvider provider):base("SQLITEADMIN_QUERIES",provider){
                ClassName = "SQLITEADMIN_QUERY";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("SQL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
            				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
           
            public IColumn NAME{
                get{
                    return this.GetColumn("NAME");
                }
            }
            				
   			public static string NAMEColumn{
			      get{
        			return "NAME";
      			}
		    }
           
            public IColumn SQL{
                get{
                    return this.GetColumn("SQL");
                }
            }
            				
   			public static string SQLColumn{
			      get{
        			return "SQL";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: AppConfig
        /// Primary Key: Module
        /// </summary>

        public class AppConfigTable: DatabaseTable {
            
            public AppConfigTable(IDataProvider provider):base("AppConfig",provider){
                ClassName = "AppConfig";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Value", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Module", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Configurable", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });
                    
                
                
            }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
            				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
           
            public IColumn Value{
                get{
                    return this.GetColumn("Value");
                }
            }
            				
   			public static string ValueColumn{
			      get{
        			return "Value";
      			}
		    }
           
            public IColumn Module{
                get{
                    return this.GetColumn("Module");
                }
            }
            				
   			public static string ModuleColumn{
			      get{
        			return "Module";
      			}
		    }
           
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
            				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
           
            public IColumn Configurable{
                get{
                    return this.GetColumn("Configurable");
                }
            }
            				
   			public static string ConfigurableColumn{
			      get{
        			return "Configurable";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: TreeMenu
        /// Primary Key: Id
        /// </summary>

        public class TreeMenuTable: DatabaseTable {
            
            public TreeMenuTable(IDataProvider provider):base("TreeMenu",provider){
                ClassName = "TreeMenu";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Text", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("ImageIndex", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("SelectedImageIndex", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ParentId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ActionClass", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Module", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Enabled", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Text{
                get{
                    return this.GetColumn("Text");
                }
            }
            				
   			public static string TextColumn{
			      get{
        			return "Text";
      			}
		    }
           
            public IColumn ImageIndex{
                get{
                    return this.GetColumn("ImageIndex");
                }
            }
            				
   			public static string ImageIndexColumn{
			      get{
        			return "ImageIndex";
      			}
		    }
           
            public IColumn SelectedImageIndex{
                get{
                    return this.GetColumn("SelectedImageIndex");
                }
            }
            				
   			public static string SelectedImageIndexColumn{
			      get{
        			return "SelectedImageIndex";
      			}
		    }
           
            public IColumn ParentId{
                get{
                    return this.GetColumn("ParentId");
                }
            }
            				
   			public static string ParentIdColumn{
			      get{
        			return "ParentId";
      			}
		    }
           
            public IColumn ActionClass{
                get{
                    return this.GetColumn("ActionClass");
                }
            }
            				
   			public static string ActionClassColumn{
			      get{
        			return "ActionClass";
      			}
		    }
           
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
            				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
           
            public IColumn Module{
                get{
                    return this.GetColumn("Module");
                }
            }
            				
   			public static string ModuleColumn{
			      get{
        			return "Module";
      			}
		    }
           
            public IColumn Enabled{
                get{
                    return this.GetColumn("Enabled");
                }
            }
            				
   			public static string EnabledColumn{
			      get{
        			return "Enabled";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: EmailConfig
        /// Primary Key: 
        /// </summary>

        public class EmailConfigTable: DatabaseTable {
            
            public EmailConfigTable(IDataProvider provider):base("EmailConfig",provider){
                ClassName = "EmailConfig";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("SenderEmail", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MailSubject", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("SmtpServer", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Authentication", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("UserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("UserPassword", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn SenderEmail{
                get{
                    return this.GetColumn("SenderEmail");
                }
            }
            				
   			public static string SenderEmailColumn{
			      get{
        			return "SenderEmail";
      			}
		    }
           
            public IColumn MailSubject{
                get{
                    return this.GetColumn("MailSubject");
                }
            }
            				
   			public static string MailSubjectColumn{
			      get{
        			return "MailSubject";
      			}
		    }
           
            public IColumn SmtpServer{
                get{
                    return this.GetColumn("SmtpServer");
                }
            }
            				
   			public static string SmtpServerColumn{
			      get{
        			return "SmtpServer";
      			}
		    }
           
            public IColumn Authentication{
                get{
                    return this.GetColumn("Authentication");
                }
            }
            				
   			public static string AuthenticationColumn{
			      get{
        			return "Authentication";
      			}
		    }
           
            public IColumn UserName{
                get{
                    return this.GetColumn("UserName");
                }
            }
            				
   			public static string UserNameColumn{
			      get{
        			return "UserName";
      			}
		    }
           
            public IColumn UserPassword{
                get{
                    return this.GetColumn("UserPassword");
                }
            }
            				
   			public static string UserPasswordColumn{
			      get{
        			return "UserPassword";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: GatewayConfig
        /// Primary Key: Id
        /// </summary>

        public class GatewayConfigTable: DatabaseTable {
            
            public GatewayConfigTable(IDataProvider provider):base("GatewayConfig",provider){
                ClassName = "GatewayConfig";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("ComPort", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("BaudRate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("DataBits", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Parity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("StopBits", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Handshake", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("OwnNumber", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Smsc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("UseSimSmsc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Pin", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MessageValidity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("LongMessageOption", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MessageMemory", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Functions", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("LogSettings", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("ClearLogOnConnect", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("AutoConnect", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Initialize", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("CommandTimeout", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ReadTimeout", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CommandDelay", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("SendRetry", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("SendDelay", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("RequestStatusReport", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("SignalRefreshInterval", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("AutoResponseCall", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("AutoResponseCallText", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("AutoArchiveLog", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("AutoArchiveLogInterval", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ArchiveOldMessageInterval", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ForwardArchivedMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("ForwardEmail", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("DeleteArchivedMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("DeleteArchivedMessageInterval", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("DeleteAfterRetrieve", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn ComPort{
                get{
                    return this.GetColumn("ComPort");
                }
            }
            				
   			public static string ComPortColumn{
			      get{
        			return "ComPort";
      			}
		    }
           
            public IColumn BaudRate{
                get{
                    return this.GetColumn("BaudRate");
                }
            }
            				
   			public static string BaudRateColumn{
			      get{
        			return "BaudRate";
      			}
		    }
           
            public IColumn DataBits{
                get{
                    return this.GetColumn("DataBits");
                }
            }
            				
   			public static string DataBitsColumn{
			      get{
        			return "DataBits";
      			}
		    }
           
            public IColumn Parity{
                get{
                    return this.GetColumn("Parity");
                }
            }
            				
   			public static string ParityColumn{
			      get{
        			return "Parity";
      			}
		    }
           
            public IColumn StopBits{
                get{
                    return this.GetColumn("StopBits");
                }
            }
            				
   			public static string StopBitsColumn{
			      get{
        			return "StopBits";
      			}
		    }
           
            public IColumn Handshake{
                get{
                    return this.GetColumn("Handshake");
                }
            }
            				
   			public static string HandshakeColumn{
			      get{
        			return "Handshake";
      			}
		    }
           
            public IColumn OwnNumber{
                get{
                    return this.GetColumn("OwnNumber");
                }
            }
            				
   			public static string OwnNumberColumn{
			      get{
        			return "OwnNumber";
      			}
		    }
           
            public IColumn Smsc{
                get{
                    return this.GetColumn("Smsc");
                }
            }
            				
   			public static string SmscColumn{
			      get{
        			return "Smsc";
      			}
		    }
           
            public IColumn UseSimSmsc{
                get{
                    return this.GetColumn("UseSimSmsc");
                }
            }
            				
   			public static string UseSimSmscColumn{
			      get{
        			return "UseSimSmsc";
      			}
		    }
           
            public IColumn Pin{
                get{
                    return this.GetColumn("Pin");
                }
            }
            				
   			public static string PinColumn{
			      get{
        			return "Pin";
      			}
		    }
           
            public IColumn MessageValidity{
                get{
                    return this.GetColumn("MessageValidity");
                }
            }
            				
   			public static string MessageValidityColumn{
			      get{
        			return "MessageValidity";
      			}
		    }
           
            public IColumn LongMessageOption{
                get{
                    return this.GetColumn("LongMessageOption");
                }
            }
            				
   			public static string LongMessageOptionColumn{
			      get{
        			return "LongMessageOption";
      			}
		    }
           
            public IColumn MessageMemory{
                get{
                    return this.GetColumn("MessageMemory");
                }
            }
            				
   			public static string MessageMemoryColumn{
			      get{
        			return "MessageMemory";
      			}
		    }
           
            public IColumn Functions{
                get{
                    return this.GetColumn("Functions");
                }
            }
            				
   			public static string FunctionsColumn{
			      get{
        			return "Functions";
      			}
		    }
           
            public IColumn LogSettings{
                get{
                    return this.GetColumn("LogSettings");
                }
            }
            				
   			public static string LogSettingsColumn{
			      get{
        			return "LogSettings";
      			}
		    }
           
            public IColumn ClearLogOnConnect{
                get{
                    return this.GetColumn("ClearLogOnConnect");
                }
            }
            				
   			public static string ClearLogOnConnectColumn{
			      get{
        			return "ClearLogOnConnect";
      			}
		    }
           
            public IColumn AutoConnect{
                get{
                    return this.GetColumn("AutoConnect");
                }
            }
            				
   			public static string AutoConnectColumn{
			      get{
        			return "AutoConnect";
      			}
		    }
           
            public IColumn Initialize{
                get{
                    return this.GetColumn("Initialize");
                }
            }
            				
   			public static string InitializeColumn{
			      get{
        			return "Initialize";
      			}
		    }
           
            public IColumn CommandTimeout{
                get{
                    return this.GetColumn("CommandTimeout");
                }
            }
            				
   			public static string CommandTimeoutColumn{
			      get{
        			return "CommandTimeout";
      			}
		    }
           
            public IColumn ReadTimeout{
                get{
                    return this.GetColumn("ReadTimeout");
                }
            }
            				
   			public static string ReadTimeoutColumn{
			      get{
        			return "ReadTimeout";
      			}
		    }
           
            public IColumn CommandDelay{
                get{
                    return this.GetColumn("CommandDelay");
                }
            }
            				
   			public static string CommandDelayColumn{
			      get{
        			return "CommandDelay";
      			}
		    }
           
            public IColumn SendRetry{
                get{
                    return this.GetColumn("SendRetry");
                }
            }
            				
   			public static string SendRetryColumn{
			      get{
        			return "SendRetry";
      			}
		    }
           
            public IColumn SendDelay{
                get{
                    return this.GetColumn("SendDelay");
                }
            }
            				
   			public static string SendDelayColumn{
			      get{
        			return "SendDelay";
      			}
		    }
           
            public IColumn RequestStatusReport{
                get{
                    return this.GetColumn("RequestStatusReport");
                }
            }
            				
   			public static string RequestStatusReportColumn{
			      get{
        			return "RequestStatusReport";
      			}
		    }
           
            public IColumn SignalRefreshInterval{
                get{
                    return this.GetColumn("SignalRefreshInterval");
                }
            }
            				
   			public static string SignalRefreshIntervalColumn{
			      get{
        			return "SignalRefreshInterval";
      			}
		    }
           
            public IColumn AutoResponseCall{
                get{
                    return this.GetColumn("AutoResponseCall");
                }
            }
            				
   			public static string AutoResponseCallColumn{
			      get{
        			return "AutoResponseCall";
      			}
		    }
           
            public IColumn AutoResponseCallText{
                get{
                    return this.GetColumn("AutoResponseCallText");
                }
            }
            				
   			public static string AutoResponseCallTextColumn{
			      get{
        			return "AutoResponseCallText";
      			}
		    }
           
            public IColumn AutoArchiveLog{
                get{
                    return this.GetColumn("AutoArchiveLog");
                }
            }
            				
   			public static string AutoArchiveLogColumn{
			      get{
        			return "AutoArchiveLog";
      			}
		    }
           
            public IColumn AutoArchiveLogInterval{
                get{
                    return this.GetColumn("AutoArchiveLogInterval");
                }
            }
            				
   			public static string AutoArchiveLogIntervalColumn{
			      get{
        			return "AutoArchiveLogInterval";
      			}
		    }
           
            public IColumn ArchiveOldMessageInterval{
                get{
                    return this.GetColumn("ArchiveOldMessageInterval");
                }
            }
            				
   			public static string ArchiveOldMessageIntervalColumn{
			      get{
        			return "ArchiveOldMessageInterval";
      			}
		    }
           
            public IColumn ForwardArchivedMessage{
                get{
                    return this.GetColumn("ForwardArchivedMessage");
                }
            }
            				
   			public static string ForwardArchivedMessageColumn{
			      get{
        			return "ForwardArchivedMessage";
      			}
		    }
           
            public IColumn ForwardEmail{
                get{
                    return this.GetColumn("ForwardEmail");
                }
            }
            				
   			public static string ForwardEmailColumn{
			      get{
        			return "ForwardEmail";
      			}
		    }
           
            public IColumn DeleteArchivedMessage{
                get{
                    return this.GetColumn("DeleteArchivedMessage");
                }
            }
            				
   			public static string DeleteArchivedMessageColumn{
			      get{
        			return "DeleteArchivedMessage";
      			}
		    }
           
            public IColumn DeleteArchivedMessageInterval{
                get{
                    return this.GetColumn("DeleteArchivedMessageInterval");
                }
            }
            				
   			public static string DeleteArchivedMessageIntervalColumn{
			      get{
        			return "DeleteArchivedMessageInterval";
      			}
		    }
           
            public IColumn DeleteAfterRetrieve{
                get{
                    return this.GetColumn("DeleteAfterRetrieve");
                }
            }
            				
   			public static string DeleteAfterRetrieveColumn{
			      get{
        			return "DeleteAfterRetrieve";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: IncomingMessage
        /// Primary Key: Id
        /// </summary>

        public class IncomingMessageTable: DatabaseTable {
            
            public IncomingMessageTable(IDataProvider provider):base("IncomingMessage",provider){
                ClassName = "IncomingMessage";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Originator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("OriginatorReceivedDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Timezone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Message", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MessageType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("DeliveryStatus", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("ReceivedDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("ValidityTimeStamp", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("OriginatorRefNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("MessageStatusType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("SrcPort", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("DestPort", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("RawMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("GatewayId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("LastUpdate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Indexes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Originator{
                get{
                    return this.GetColumn("Originator");
                }
            }
            				
   			public static string OriginatorColumn{
			      get{
        			return "Originator";
      			}
		    }
           
            public IColumn OriginatorReceivedDate{
                get{
                    return this.GetColumn("OriginatorReceivedDate");
                }
            }
            				
   			public static string OriginatorReceivedDateColumn{
			      get{
        			return "OriginatorReceivedDate";
      			}
		    }
           
            public IColumn Timezone{
                get{
                    return this.GetColumn("Timezone");
                }
            }
            				
   			public static string TimezoneColumn{
			      get{
        			return "Timezone";
      			}
		    }
           
            public IColumn Message{
                get{
                    return this.GetColumn("Message");
                }
            }
            				
   			public static string MessageColumn{
			      get{
        			return "Message";
      			}
		    }
           
            public IColumn MessageType{
                get{
                    return this.GetColumn("MessageType");
                }
            }
            				
   			public static string MessageTypeColumn{
			      get{
        			return "MessageType";
      			}
		    }
           
            public IColumn DeliveryStatus{
                get{
                    return this.GetColumn("DeliveryStatus");
                }
            }
            				
   			public static string DeliveryStatusColumn{
			      get{
        			return "DeliveryStatus";
      			}
		    }
           
            public IColumn ReceivedDate{
                get{
                    return this.GetColumn("ReceivedDate");
                }
            }
            				
   			public static string ReceivedDateColumn{
			      get{
        			return "ReceivedDate";
      			}
		    }
           
            public IColumn ValidityTimeStamp{
                get{
                    return this.GetColumn("ValidityTimeStamp");
                }
            }
            				
   			public static string ValidityTimeStampColumn{
			      get{
        			return "ValidityTimeStamp";
      			}
		    }
           
            public IColumn OriginatorRefNo{
                get{
                    return this.GetColumn("OriginatorRefNo");
                }
            }
            				
   			public static string OriginatorRefNoColumn{
			      get{
        			return "OriginatorRefNo";
      			}
		    }
           
            public IColumn MessageStatusType{
                get{
                    return this.GetColumn("MessageStatusType");
                }
            }
            				
   			public static string MessageStatusTypeColumn{
			      get{
        			return "MessageStatusType";
      			}
		    }
           
            public IColumn SrcPort{
                get{
                    return this.GetColumn("SrcPort");
                }
            }
            				
   			public static string SrcPortColumn{
			      get{
        			return "SrcPort";
      			}
		    }
           
            public IColumn DestPort{
                get{
                    return this.GetColumn("DestPort");
                }
            }
            				
   			public static string DestPortColumn{
			      get{
        			return "DestPort";
      			}
		    }
           
            public IColumn Status{
                get{
                    return this.GetColumn("Status");
                }
            }
            				
   			public static string StatusColumn{
			      get{
        			return "Status";
      			}
		    }
           
            public IColumn RawMessage{
                get{
                    return this.GetColumn("RawMessage");
                }
            }
            				
   			public static string RawMessageColumn{
			      get{
        			return "RawMessage";
      			}
		    }
           
            public IColumn GatewayId{
                get{
                    return this.GetColumn("GatewayId");
                }
            }
            				
   			public static string GatewayIdColumn{
			      get{
        			return "GatewayId";
      			}
		    }
           
            public IColumn LastUpdate{
                get{
                    return this.GetColumn("LastUpdate");
                }
            }
            				
   			public static string LastUpdateColumn{
			      get{
        			return "LastUpdate";
      			}
		    }
           
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
            				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
           
            public IColumn Indexes{
                get{
                    return this.GetColumn("Indexes");
                }
            }
            				
   			public static string IndexesColumn{
			      get{
        			return "Indexes";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: OutgoingMessage
        /// Primary Key: Id
        /// </summary>

        public class OutgoingMessageTable: DatabaseTable {
            
            public OutgoingMessageTable(IDataProvider provider):base("OutgoingMessage",provider){
                ClassName = "OutgoingMessage";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Originator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Recipient", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MessageType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("MessageFormat", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Priority", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Message", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("ScheduledDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Quantity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("MessageClass", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("SrcPort", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("DestPort", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("StatusReport", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("WapUrl", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("WapExpiryDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("WapCreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("WapSignal", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("LastUpdate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("RefNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("SentDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("Errors", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("GatewayId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("GroupId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Originator{
                get{
                    return this.GetColumn("Originator");
                }
            }
            				
   			public static string OriginatorColumn{
			      get{
        			return "Originator";
      			}
		    }
           
            public IColumn Recipient{
                get{
                    return this.GetColumn("Recipient");
                }
            }
            				
   			public static string RecipientColumn{
			      get{
        			return "Recipient";
      			}
		    }
           
            public IColumn MessageType{
                get{
                    return this.GetColumn("MessageType");
                }
            }
            				
   			public static string MessageTypeColumn{
			      get{
        			return "MessageType";
      			}
		    }
           
            public IColumn MessageFormat{
                get{
                    return this.GetColumn("MessageFormat");
                }
            }
            				
   			public static string MessageFormatColumn{
			      get{
        			return "MessageFormat";
      			}
		    }
           
            public IColumn Priority{
                get{
                    return this.GetColumn("Priority");
                }
            }
            				
   			public static string PriorityColumn{
			      get{
        			return "Priority";
      			}
		    }
           
            public IColumn Message{
                get{
                    return this.GetColumn("Message");
                }
            }
            				
   			public static string MessageColumn{
			      get{
        			return "Message";
      			}
		    }
           
            public IColumn ScheduledDate{
                get{
                    return this.GetColumn("ScheduledDate");
                }
            }
            				
   			public static string ScheduledDateColumn{
			      get{
        			return "ScheduledDate";
      			}
		    }
           
            public IColumn Quantity{
                get{
                    return this.GetColumn("Quantity");
                }
            }
            				
   			public static string QuantityColumn{
			      get{
        			return "Quantity";
      			}
		    }
           
            public IColumn MessageClass{
                get{
                    return this.GetColumn("MessageClass");
                }
            }
            				
   			public static string MessageClassColumn{
			      get{
        			return "MessageClass";
      			}
		    }
           
            public IColumn SrcPort{
                get{
                    return this.GetColumn("SrcPort");
                }
            }
            				
   			public static string SrcPortColumn{
			      get{
        			return "SrcPort";
      			}
		    }
           
            public IColumn DestPort{
                get{
                    return this.GetColumn("DestPort");
                }
            }
            				
   			public static string DestPortColumn{
			      get{
        			return "DestPort";
      			}
		    }
           
            public IColumn StatusReport{
                get{
                    return this.GetColumn("StatusReport");
                }
            }
            				
   			public static string StatusReportColumn{
			      get{
        			return "StatusReport";
      			}
		    }
           
            public IColumn WapUrl{
                get{
                    return this.GetColumn("WapUrl");
                }
            }
            				
   			public static string WapUrlColumn{
			      get{
        			return "WapUrl";
      			}
		    }
           
            public IColumn WapExpiryDate{
                get{
                    return this.GetColumn("WapExpiryDate");
                }
            }
            				
   			public static string WapExpiryDateColumn{
			      get{
        			return "WapExpiryDate";
      			}
		    }
           
            public IColumn WapCreateDate{
                get{
                    return this.GetColumn("WapCreateDate");
                }
            }
            				
   			public static string WapCreateDateColumn{
			      get{
        			return "WapCreateDate";
      			}
		    }
           
            public IColumn WapSignal{
                get{
                    return this.GetColumn("WapSignal");
                }
            }
            				
   			public static string WapSignalColumn{
			      get{
        			return "WapSignal";
      			}
		    }
           
            public IColumn LastUpdate{
                get{
                    return this.GetColumn("LastUpdate");
                }
            }
            				
   			public static string LastUpdateColumn{
			      get{
        			return "LastUpdate";
      			}
		    }
           
            public IColumn RefNo{
                get{
                    return this.GetColumn("RefNo");
                }
            }
            				
   			public static string RefNoColumn{
			      get{
        			return "RefNo";
      			}
		    }
           
            public IColumn SentDate{
                get{
                    return this.GetColumn("SentDate");
                }
            }
            				
   			public static string SentDateColumn{
			      get{
        			return "SentDate";
      			}
		    }
           
            public IColumn Status{
                get{
                    return this.GetColumn("Status");
                }
            }
            				
   			public static string StatusColumn{
			      get{
        			return "Status";
      			}
		    }
           
            public IColumn Errors{
                get{
                    return this.GetColumn("Errors");
                }
            }
            				
   			public static string ErrorsColumn{
			      get{
        			return "Errors";
      			}
		    }
           
            public IColumn GatewayId{
                get{
                    return this.GetColumn("GatewayId");
                }
            }
            				
   			public static string GatewayIdColumn{
			      get{
        			return "GatewayId";
      			}
		    }
           
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
            				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
           
            public IColumn GroupId{
                get{
                    return this.GetColumn("GroupId");
                }
            }
            				
   			public static string GroupIdColumn{
			      get{
        			return "GroupId";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: Role
        /// Primary Key: Id
        /// </summary>

        public class RoleTable: DatabaseTable {
            
            public RoleTable(IDataProvider provider):base("Role",provider){
                ClassName = "Role";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Desc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("CanBeDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
            				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
           
            public IColumn Desc{
                get{
                    return this.GetColumn("Desc");
                }
            }
            				
   			public static string DescColumn{
			      get{
        			return "Desc";
      			}
		    }
           
            public IColumn CanBeDeleted{
                get{
                    return this.GetColumn("CanBeDeleted");
                }
            }
            				
   			public static string CanBeDeletedColumn{
			      get{
        			return "CanBeDeleted";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: User
        /// Primary Key: Id
        /// </summary>

        public class UserTable: DatabaseTable {
            
            public UserTable(IDataProvider provider):base("User",provider){
                ClassName = "User";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("CommonName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Mobtel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LoginName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Password", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("CanBeDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn CommonName{
                get{
                    return this.GetColumn("CommonName");
                }
            }
            				
   			public static string CommonNameColumn{
			      get{
        			return "CommonName";
      			}
		    }
           
            public IColumn Mobtel{
                get{
                    return this.GetColumn("Mobtel");
                }
            }
            				
   			public static string MobtelColumn{
			      get{
        			return "Mobtel";
      			}
		    }
           
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
            				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
           
            public IColumn LoginName{
                get{
                    return this.GetColumn("LoginName");
                }
            }
            				
   			public static string LoginNameColumn{
			      get{
        			return "LoginName";
      			}
		    }
           
            public IColumn Password{
                get{
                    return this.GetColumn("Password");
                }
            }
            				
   			public static string PasswordColumn{
			      get{
        			return "Password";
      			}
		    }
           
            public IColumn CanBeDeleted{
                get{
                    return this.GetColumn("CanBeDeleted");
                }
            }
            				
   			public static string CanBeDeletedColumn{
			      get{
        			return "CanBeDeleted";
      			}
		    }
           
                    
        }
        
}