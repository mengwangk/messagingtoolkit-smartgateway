


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace MessagingToolkit.SmartGateway.Core.Data.ActiveRecord
{
    public partial class SmartGatewayDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public static IDataProvider DefaultDataProvider { get; set; }

        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public SmartGatewayDB() 
        {
            if (DefaultDataProvider == null) {
                DataProvider = ProviderFactory.GetProvider("SmartGateway");
            }
            else {
                DataProvider = DefaultDataProvider;
            }
            Init();
        }

        public SmartGatewayDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public SmartGatewayDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<OutgoingCall> OutgoingCalls { get; set; }
        public Query<Privilege> Privileges { get; set; }
        public Query<RolePrivilegeMap> RolePrivilegeMaps { get; set; }
        public Query<UserRoleMap> UserRoleMaps { get; set; }
        public Query<IncomingCall> IncomingCalls { get; set; }
        public Query<SQLITEADMIN_QUERY> SQLITEADMIN_QUERIES { get; set; }
        public Query<AppConfig> AppConfigs { get; set; }
        public Query<TreeMenu> TreeMenus { get; set; }
        public Query<EmailConfig> EmailConfigs { get; set; }
        public Query<GatewayConfig> GatewayConfigs { get; set; }
        public Query<IncomingMessage> IncomingMessages { get; set; }
        public Query<OutgoingMessage> OutgoingMessages { get; set; }
        public Query<Role> Roles { get; set; }
        public Query<User> Users { get; set; }
        public Query<DbMessenger> DbMessengers { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            OutgoingCalls = new Query<OutgoingCall>(provider);
            Privileges = new Query<Privilege>(provider);
            RolePrivilegeMaps = new Query<RolePrivilegeMap>(provider);
            UserRoleMaps = new Query<UserRoleMap>(provider);
            IncomingCalls = new Query<IncomingCall>(provider);
            SQLITEADMIN_QUERIES = new Query<SQLITEADMIN_QUERY>(provider);
            AppConfigs = new Query<AppConfig>(provider);
            TreeMenus = new Query<TreeMenu>(provider);
            EmailConfigs = new Query<EmailConfig>(provider);
            GatewayConfigs = new Query<GatewayConfig>(provider);
            IncomingMessages = new Query<IncomingMessage>(provider);
            OutgoingMessages = new Query<OutgoingMessage>(provider);
            Roles = new Query<Role>(provider);
            Users = new Query<User>(provider);
            DbMessengers = new Query<DbMessenger>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new OutgoingCallTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PrivilegeTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new RolePrivilegeMapTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new UserRoleMapTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new IncomingCallTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new SQLITEADMIN_QUERIESTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new AppConfigTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new TreeMenuTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new EmailConfigTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new GatewayConfigTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new IncomingMessageTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new OutgoingMessageTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new RoleTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new UserTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new DbMessengerTable(DataProvider));
            }
            #endregion
        }
        

        #region ' Helpers '
            
        internal static DateTime DateTimeNowTruncatedDownToSecond() {
            var now = DateTime.Now;
            return now.AddTicks(-now.Ticks % TimeSpan.TicksPerSecond);
        }

        #endregion

    }
}