


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace MessagingToolkit.SmartGateway.Core.Data.ActiveRecord
{
    
    
    /// <summary>
    /// A class which represents the OutgoingCall table in the SmartGateway Database.
    /// </summary>
    public partial class OutgoingCall: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<OutgoingCall> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<OutgoingCall>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<OutgoingCall> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(OutgoingCall item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                OutgoingCall item=new OutgoingCall();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<OutgoingCall> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public OutgoingCall(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                OutgoingCall.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutgoingCall>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public OutgoingCall(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public OutgoingCall(Expression<Func<OutgoingCall, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<OutgoingCall> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<OutgoingCall> _repo;
            
            if(db.TestMode){
                OutgoingCall.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutgoingCall>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<OutgoingCall> GetRepo(){
            return GetRepo("","");
        }
        
        public static OutgoingCall SingleOrDefault(Expression<Func<OutgoingCall, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            OutgoingCall single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static OutgoingCall SingleOrDefault(Expression<Func<OutgoingCall, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            OutgoingCall single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<OutgoingCall, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<OutgoingCall, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<OutgoingCall> Find(Expression<Func<OutgoingCall, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<OutgoingCall> Find(Expression<Func<OutgoingCall, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<OutgoingCall> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<OutgoingCall> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<OutgoingCall> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<OutgoingCall> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<OutgoingCall> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<OutgoingCall> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CallerId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(OutgoingCall)){
                OutgoingCall compare=(OutgoingCall)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.CallerId.ToString();
                    }

        public string DescriptorColumn() {
            return "CallerId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "CallerId";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CallDate;
        public DateTime CallDate
        {
            get { return _CallDate; }
            set
            {
                if(_CallDate!=value){
                    _CallDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CallDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CallerId;
        public string CallerId
        {
            get { return _CallerId; }
            set
            {
                if(_CallerId!=value){
                    _CallerId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CallerId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GatewayId;
        public string GatewayId
        {
            get { return _GatewayId; }
            set
            {
                if(_GatewayId!=value){
                    _GatewayId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GatewayId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<OutgoingCall, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Privilege table in the SmartGateway Database.
    /// </summary>
    public partial class Privilege: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Privilege> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Privilege>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Privilege> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Privilege item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Privilege item=new Privilege();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Privilege> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public Privilege(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Privilege.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Privilege>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Privilege(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Privilege(Expression<Func<Privilege, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Privilege> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<Privilege> _repo;
            
            if(db.TestMode){
                Privilege.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Privilege>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Privilege> GetRepo(){
            return GetRepo("","");
        }
        
        public static Privilege SingleOrDefault(Expression<Func<Privilege, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Privilege single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Privilege SingleOrDefault(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Privilege single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Privilege, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Privilege> Find(Expression<Func<Privilege, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Privilege> Find(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Privilege> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Privilege> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Privilege> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Privilege> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Privilege> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Privilege> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Privilege)){
                Privilege compare=(Privilege)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Desc;
        public string Desc
        {
            get { return _Desc; }
            set
            {
                if(_Desc!=value){
                    _Desc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Desc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Privilege, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the RolePrivilegeMap table in the SmartGateway Database.
    /// </summary>
    public partial class RolePrivilegeMap: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RolePrivilegeMap> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RolePrivilegeMap>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RolePrivilegeMap> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(RolePrivilegeMap item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RolePrivilegeMap item=new RolePrivilegeMap();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RolePrivilegeMap> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public RolePrivilegeMap(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RolePrivilegeMap.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RolePrivilegeMap>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RolePrivilegeMap(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public RolePrivilegeMap(Expression<Func<RolePrivilegeMap, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RolePrivilegeMap> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<RolePrivilegeMap> _repo;
            
            if(db.TestMode){
                RolePrivilegeMap.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RolePrivilegeMap>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RolePrivilegeMap> GetRepo(){
            return GetRepo("","");
        }
        
        public static RolePrivilegeMap SingleOrDefault(Expression<Func<RolePrivilegeMap, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RolePrivilegeMap single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RolePrivilegeMap SingleOrDefault(Expression<Func<RolePrivilegeMap, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RolePrivilegeMap single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RolePrivilegeMap, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RolePrivilegeMap, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RolePrivilegeMap> Find(Expression<Func<RolePrivilegeMap, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RolePrivilegeMap> Find(Expression<Func<RolePrivilegeMap, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RolePrivilegeMap> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RolePrivilegeMap> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RolePrivilegeMap> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RolePrivilegeMap> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RolePrivilegeMap> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RolePrivilegeMap> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "RoleId";
        }

        public object KeyValue()
        {
            return this.RoleId;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PrivilegeId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RolePrivilegeMap)){
                RolePrivilegeMap compare=(RolePrivilegeMap)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.RoleId;
        }
        
        public string DescriptorValue()
        {
                            return this.PrivilegeId.ToString();
                    }

        public string DescriptorColumn() {
            return "PrivilegeId";
        }
        public static string GetKeyColumn()
        {
            return "RoleId";
        }        
        public static string GetDescriptorColumn()
        {
            return "PrivilegeId";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _RoleId;
        public int RoleId
        {
            get { return _RoleId; }
            set
            {
                if(_RoleId!=value){
                    _RoleId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PrivilegeId;
        public int PrivilegeId
        {
            get { return _PrivilegeId; }
            set
            {
                if(_PrivilegeId!=value){
                    _PrivilegeId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<RolePrivilegeMap, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the UserRoleMap table in the SmartGateway Database.
    /// </summary>
    public partial class UserRoleMap: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<UserRoleMap> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<UserRoleMap>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<UserRoleMap> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(UserRoleMap item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                UserRoleMap item=new UserRoleMap();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<UserRoleMap> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public UserRoleMap(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                UserRoleMap.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserRoleMap>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public UserRoleMap(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public UserRoleMap(Expression<Func<UserRoleMap, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<UserRoleMap> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<UserRoleMap> _repo;
            
            if(db.TestMode){
                UserRoleMap.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserRoleMap>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<UserRoleMap> GetRepo(){
            return GetRepo("","");
        }
        
        public static UserRoleMap SingleOrDefault(Expression<Func<UserRoleMap, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            UserRoleMap single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static UserRoleMap SingleOrDefault(Expression<Func<UserRoleMap, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            UserRoleMap single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<UserRoleMap, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<UserRoleMap, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<UserRoleMap> Find(Expression<Func<UserRoleMap, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<UserRoleMap> Find(Expression<Func<UserRoleMap, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<UserRoleMap> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<UserRoleMap> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<UserRoleMap> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<UserRoleMap> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<UserRoleMap> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<UserRoleMap> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "UserId";
        }

        public object KeyValue()
        {
            return this.UserId;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.RoleId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(UserRoleMap)){
                UserRoleMap compare=(UserRoleMap)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.UserId;
        }
        
        public string DescriptorValue()
        {
                            return this.RoleId.ToString();
                    }

        public string DescriptorColumn() {
            return "RoleId";
        }
        public static string GetKeyColumn()
        {
            return "UserId";
        }        
        public static string GetDescriptorColumn()
        {
            return "RoleId";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _UserId;
        public int UserId
        {
            get { return _UserId; }
            set
            {
                if(_UserId!=value){
                    _UserId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _RoleId;
        public int RoleId
        {
            get { return _RoleId; }
            set
            {
                if(_RoleId!=value){
                    _RoleId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<UserRoleMap, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the IncomingCall table in the SmartGateway Database.
    /// </summary>
    public partial class IncomingCall: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<IncomingCall> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<IncomingCall>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<IncomingCall> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(IncomingCall item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                IncomingCall item=new IncomingCall();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<IncomingCall> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public IncomingCall(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                IncomingCall.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IncomingCall>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public IncomingCall(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public IncomingCall(Expression<Func<IncomingCall, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<IncomingCall> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<IncomingCall> _repo;
            
            if(db.TestMode){
                IncomingCall.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IncomingCall>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<IncomingCall> GetRepo(){
            return GetRepo("","");
        }
        
        public static IncomingCall SingleOrDefault(Expression<Func<IncomingCall, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            IncomingCall single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static IncomingCall SingleOrDefault(Expression<Func<IncomingCall, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            IncomingCall single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<IncomingCall, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<IncomingCall, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<IncomingCall> Find(Expression<Func<IncomingCall, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<IncomingCall> Find(Expression<Func<IncomingCall, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<IncomingCall> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<IncomingCall> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<IncomingCall> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<IncomingCall> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<IncomingCall> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<IncomingCall> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CallerId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(IncomingCall)){
                IncomingCall compare=(IncomingCall)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.CallerId.ToString();
                    }

        public string DescriptorColumn() {
            return "CallerId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "CallerId";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CallDate;
        public DateTime CallDate
        {
            get { return _CallDate; }
            set
            {
                if(_CallDate!=value){
                    _CallDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CallDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CallerId;
        public string CallerId
        {
            get { return _CallerId; }
            set
            {
                if(_CallerId!=value){
                    _CallerId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CallerId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GatewayId;
        public string GatewayId
        {
            get { return _GatewayId; }
            set
            {
                if(_GatewayId!=value){
                    _GatewayId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GatewayId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<IncomingCall, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the SQLITEADMIN_QUERIES table in the SmartGateway Database.
    /// </summary>
    public partial class SQLITEADMIN_QUERY: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SQLITEADMIN_QUERY> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SQLITEADMIN_QUERY>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SQLITEADMIN_QUERY> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(SQLITEADMIN_QUERY item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SQLITEADMIN_QUERY item=new SQLITEADMIN_QUERY();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SQLITEADMIN_QUERY> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public SQLITEADMIN_QUERY(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SQLITEADMIN_QUERY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SQLITEADMIN_QUERY>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SQLITEADMIN_QUERY(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public SQLITEADMIN_QUERY(Expression<Func<SQLITEADMIN_QUERY, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SQLITEADMIN_QUERY> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<SQLITEADMIN_QUERY> _repo;
            
            if(db.TestMode){
                SQLITEADMIN_QUERY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SQLITEADMIN_QUERY>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SQLITEADMIN_QUERY> GetRepo(){
            return GetRepo("","");
        }
        
        public static SQLITEADMIN_QUERY SingleOrDefault(Expression<Func<SQLITEADMIN_QUERY, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SQLITEADMIN_QUERY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SQLITEADMIN_QUERY SingleOrDefault(Expression<Func<SQLITEADMIN_QUERY, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SQLITEADMIN_QUERY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SQLITEADMIN_QUERY, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SQLITEADMIN_QUERY, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SQLITEADMIN_QUERY> Find(Expression<Func<SQLITEADMIN_QUERY, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SQLITEADMIN_QUERY> Find(Expression<Func<SQLITEADMIN_QUERY, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SQLITEADMIN_QUERY> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SQLITEADMIN_QUERY> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SQLITEADMIN_QUERY> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SQLITEADMIN_QUERY> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SQLITEADMIN_QUERY> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SQLITEADMIN_QUERY> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.NAME.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SQLITEADMIN_QUERY)){
                SQLITEADMIN_QUERY compare=(SQLITEADMIN_QUERY)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.NAME.ToString();
                    }

        public string DescriptorColumn() {
            return "NAME";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "NAME";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NAME;
        public string NAME
        {
            get { return _NAME; }
            set
            {
                if(_NAME!=value){
                    _NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SQL;
        public string SQL
        {
            get { return _SQL; }
            set
            {
                if(_SQL!=value){
                    _SQL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SQL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<SQLITEADMIN_QUERY, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the AppConfig table in the SmartGateway Database.
    /// </summary>
    public partial class AppConfig: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<AppConfig> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<AppConfig>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<AppConfig> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(AppConfig item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                AppConfig item=new AppConfig();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<AppConfig> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public AppConfig(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                AppConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<AppConfig>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public AppConfig(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public AppConfig(Expression<Func<AppConfig, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<AppConfig> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<AppConfig> _repo;
            
            if(db.TestMode){
                AppConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<AppConfig>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<AppConfig> GetRepo(){
            return GetRepo("","");
        }
        
        public static AppConfig SingleOrDefault(Expression<Func<AppConfig, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            AppConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static AppConfig SingleOrDefault(Expression<Func<AppConfig, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            AppConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<AppConfig, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<AppConfig, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<AppConfig> Find(Expression<Func<AppConfig, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<AppConfig> Find(Expression<Func<AppConfig, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<AppConfig> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<AppConfig> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<AppConfig> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<AppConfig> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<AppConfig> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<AppConfig> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Name";
        }

        public object KeyValue()
        {
            return this.Name;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(AppConfig)){
                AppConfig compare=(AppConfig)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Name";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                if(_Value!=value){
                    _Value=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Value");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Module;
        public string Module
        {
            get { return _Module; }
            set
            {
                if(_Module!=value){
                    _Module=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Module");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _Configurable;
        public bool? Configurable
        {
            get { return _Configurable; }
            set
            {
                if(_Configurable!=value){
                    _Configurable=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Configurable");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<AppConfig, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the TreeMenu table in the SmartGateway Database.
    /// </summary>
    public partial class TreeMenu: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<TreeMenu> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<TreeMenu>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<TreeMenu> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(TreeMenu item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                TreeMenu item=new TreeMenu();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<TreeMenu> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public TreeMenu(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                TreeMenu.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TreeMenu>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public TreeMenu(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public TreeMenu(Expression<Func<TreeMenu, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<TreeMenu> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<TreeMenu> _repo;
            
            if(db.TestMode){
                TreeMenu.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TreeMenu>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<TreeMenu> GetRepo(){
            return GetRepo("","");
        }
        
        public static TreeMenu SingleOrDefault(Expression<Func<TreeMenu, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            TreeMenu single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static TreeMenu SingleOrDefault(Expression<Func<TreeMenu, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            TreeMenu single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<TreeMenu, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<TreeMenu, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<TreeMenu> Find(Expression<Func<TreeMenu, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<TreeMenu> Find(Expression<Func<TreeMenu, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<TreeMenu> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<TreeMenu> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<TreeMenu> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<TreeMenu> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<TreeMenu> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<TreeMenu> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Text.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(TreeMenu)){
                TreeMenu compare=(TreeMenu)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Text.ToString();
                    }

        public string DescriptorColumn() {
            return "Text";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Text";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Text;
        public string Text
        {
            get { return _Text; }
            set
            {
                if(_Text!=value){
                    _Text=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Text");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ImageIndex;
        public int? ImageIndex
        {
            get { return _ImageIndex; }
            set
            {
                if(_ImageIndex!=value){
                    _ImageIndex=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ImageIndex");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _SelectedImageIndex;
        public int? SelectedImageIndex
        {
            get { return _SelectedImageIndex; }
            set
            {
                if(_SelectedImageIndex!=value){
                    _SelectedImageIndex=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SelectedImageIndex");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ParentId;
        public int? ParentId
        {
            get { return _ParentId; }
            set
            {
                if(_ParentId!=value){
                    _ParentId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParentId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ActionClass;
        public string ActionClass
        {
            get { return _ActionClass; }
            set
            {
                if(_ActionClass!=value){
                    _ActionClass=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ActionClass");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Sequence;
        public int? Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Module;
        public string Module
        {
            get { return _Module; }
            set
            {
                if(_Module!=value){
                    _Module=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Module");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _Enabled;
        public bool? Enabled
        {
            get { return _Enabled; }
            set
            {
                if(_Enabled!=value){
                    _Enabled=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Enabled");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<TreeMenu, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the EmailConfig table in the SmartGateway Database.
    /// </summary>
    public partial class EmailConfig: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<EmailConfig> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<EmailConfig>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<EmailConfig> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(EmailConfig item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                EmailConfig item=new EmailConfig();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<EmailConfig> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public EmailConfig(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                EmailConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<EmailConfig>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public EmailConfig(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public EmailConfig(Expression<Func<EmailConfig, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<EmailConfig> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<EmailConfig> _repo;
            
            if(db.TestMode){
                EmailConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<EmailConfig>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<EmailConfig> GetRepo(){
            return GetRepo("","");
        }
        
        public static EmailConfig SingleOrDefault(Expression<Func<EmailConfig, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            EmailConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static EmailConfig SingleOrDefault(Expression<Func<EmailConfig, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            EmailConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<EmailConfig, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<EmailConfig, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<EmailConfig> Find(Expression<Func<EmailConfig, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<EmailConfig> Find(Expression<Func<EmailConfig, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<EmailConfig> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<EmailConfig> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<EmailConfig> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<EmailConfig> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<EmailConfig> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<EmailConfig> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "SenderEmail";
        }

        public object KeyValue()
        {
            return this.SenderEmail;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.SenderEmail.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(EmailConfig)){
                EmailConfig compare=(EmailConfig)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.SenderEmail.ToString();
                    }

        public string DescriptorColumn() {
            return "SenderEmail";
        }
        public static string GetKeyColumn()
        {
            return "SenderEmail";
        }        
        public static string GetDescriptorColumn()
        {
            return "SenderEmail";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _SenderEmail;
        public string SenderEmail
        {
            get { return _SenderEmail; }
            set
            {
                if(_SenderEmail!=value){
                    _SenderEmail=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SenderEmail");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MailSubject;
        public string MailSubject
        {
            get { return _MailSubject; }
            set
            {
                if(_MailSubject!=value){
                    _MailSubject=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MailSubject");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SmtpServer;
        public string SmtpServer
        {
            get { return _SmtpServer; }
            set
            {
                if(_SmtpServer!=value){
                    _SmtpServer=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SmtpServer");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _Authentication;
        public bool? Authentication
        {
            get { return _Authentication; }
            set
            {
                if(_Authentication!=value){
                    _Authentication=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Authentication");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if(_UserName!=value){
                    _UserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UserPassword;
        public string UserPassword
        {
            get { return _UserPassword; }
            set
            {
                if(_UserPassword!=value){
                    _UserPassword=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserPassword");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<EmailConfig, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the GatewayConfig table in the SmartGateway Database.
    /// </summary>
    public partial class GatewayConfig: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<GatewayConfig> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<GatewayConfig>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<GatewayConfig> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(GatewayConfig item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                GatewayConfig item=new GatewayConfig();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<GatewayConfig> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public GatewayConfig(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                GatewayConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<GatewayConfig>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public GatewayConfig(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public GatewayConfig(Expression<Func<GatewayConfig, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<GatewayConfig> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<GatewayConfig> _repo;
            
            if(db.TestMode){
                GatewayConfig.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<GatewayConfig>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<GatewayConfig> GetRepo(){
            return GetRepo("","");
        }
        
        public static GatewayConfig SingleOrDefault(Expression<Func<GatewayConfig, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            GatewayConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static GatewayConfig SingleOrDefault(Expression<Func<GatewayConfig, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            GatewayConfig single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<GatewayConfig, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<GatewayConfig, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<GatewayConfig> Find(Expression<Func<GatewayConfig, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<GatewayConfig> Find(Expression<Func<GatewayConfig, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<GatewayConfig> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<GatewayConfig> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<GatewayConfig> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<GatewayConfig> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<GatewayConfig> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<GatewayConfig> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Id.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(GatewayConfig)){
                GatewayConfig compare=(GatewayConfig)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Id.ToString();
                    }

        public string DescriptorColumn() {
            return "Id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ComPort;
        public string ComPort
        {
            get { return _ComPort; }
            set
            {
                if(_ComPort!=value){
                    _ComPort=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ComPort");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _BaudRate;
        public string BaudRate
        {
            get { return _BaudRate; }
            set
            {
                if(_BaudRate!=value){
                    _BaudRate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BaudRate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DataBits;
        public string DataBits
        {
            get { return _DataBits; }
            set
            {
                if(_DataBits!=value){
                    _DataBits=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DataBits");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Parity;
        public string Parity
        {
            get { return _Parity; }
            set
            {
                if(_Parity!=value){
                    _Parity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Parity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StopBits;
        public string StopBits
        {
            get { return _StopBits; }
            set
            {
                if(_StopBits!=value){
                    _StopBits=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StopBits");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Handshake;
        public string Handshake
        {
            get { return _Handshake; }
            set
            {
                if(_Handshake!=value){
                    _Handshake=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Handshake");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OwnNumber;
        public string OwnNumber
        {
            get { return _OwnNumber; }
            set
            {
                if(_OwnNumber!=value){
                    _OwnNumber=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OwnNumber");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Smsc;
        public string Smsc
        {
            get { return _Smsc; }
            set
            {
                if(_Smsc!=value){
                    _Smsc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Smsc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _UseSimSmsc;
        public bool? UseSimSmsc
        {
            get { return _UseSimSmsc; }
            set
            {
                if(_UseSimSmsc!=value){
                    _UseSimSmsc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UseSimSmsc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Pin;
        public string Pin
        {
            get { return _Pin; }
            set
            {
                if(_Pin!=value){
                    _Pin=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Pin");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageValidity;
        public string MessageValidity
        {
            get { return _MessageValidity; }
            set
            {
                if(_MessageValidity!=value){
                    _MessageValidity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageValidity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LongMessageOption;
        public string LongMessageOption
        {
            get { return _LongMessageOption; }
            set
            {
                if(_LongMessageOption!=value){
                    _LongMessageOption=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LongMessageOption");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageMemory;
        public string MessageMemory
        {
            get { return _MessageMemory; }
            set
            {
                if(_MessageMemory!=value){
                    _MessageMemory=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageMemory");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Functions;
        public int? Functions
        {
            get { return _Functions; }
            set
            {
                if(_Functions!=value){
                    _Functions=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Functions");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LogSettings;
        public string LogSettings
        {
            get { return _LogSettings; }
            set
            {
                if(_LogSettings!=value){
                    _LogSettings=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LogSettings");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _ClearLogOnConnect;
        public bool? ClearLogOnConnect
        {
            get { return _ClearLogOnConnect; }
            set
            {
                if(_ClearLogOnConnect!=value){
                    _ClearLogOnConnect=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ClearLogOnConnect");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _AutoConnect;
        public bool? AutoConnect
        {
            get { return _AutoConnect; }
            set
            {
                if(_AutoConnect!=value){
                    _AutoConnect=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoConnect");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _Initialize;
        public bool? Initialize
        {
            get { return _Initialize; }
            set
            {
                if(_Initialize!=value){
                    _Initialize=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Initialize");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CommandTimeout;
        public int? CommandTimeout
        {
            get { return _CommandTimeout; }
            set
            {
                if(_CommandTimeout!=value){
                    _CommandTimeout=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CommandTimeout");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ReadTimeout;
        public int? ReadTimeout
        {
            get { return _ReadTimeout; }
            set
            {
                if(_ReadTimeout!=value){
                    _ReadTimeout=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ReadTimeout");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CommandDelay;
        public int? CommandDelay
        {
            get { return _CommandDelay; }
            set
            {
                if(_CommandDelay!=value){
                    _CommandDelay=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CommandDelay");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _SendRetry;
        public int? SendRetry
        {
            get { return _SendRetry; }
            set
            {
                if(_SendRetry!=value){
                    _SendRetry=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SendRetry");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _SendDelay;
        public int? SendDelay
        {
            get { return _SendDelay; }
            set
            {
                if(_SendDelay!=value){
                    _SendDelay=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SendDelay");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _RequestStatusReport;
        public bool? RequestStatusReport
        {
            get { return _RequestStatusReport; }
            set
            {
                if(_RequestStatusReport!=value){
                    _RequestStatusReport=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RequestStatusReport");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _SignalRefreshInterval;
        public int? SignalRefreshInterval
        {
            get { return _SignalRefreshInterval; }
            set
            {
                if(_SignalRefreshInterval!=value){
                    _SignalRefreshInterval=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SignalRefreshInterval");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _AutoResponseCall;
        public bool? AutoResponseCall
        {
            get { return _AutoResponseCall; }
            set
            {
                if(_AutoResponseCall!=value){
                    _AutoResponseCall=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoResponseCall");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AutoResponseCallText;
        public string AutoResponseCallText
        {
            get { return _AutoResponseCallText; }
            set
            {
                if(_AutoResponseCallText!=value){
                    _AutoResponseCallText=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoResponseCallText");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _AutoArchiveLog;
        public bool? AutoArchiveLog
        {
            get { return _AutoArchiveLog; }
            set
            {
                if(_AutoArchiveLog!=value){
                    _AutoArchiveLog=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoArchiveLog");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AutoArchiveLogInterval;
        public int? AutoArchiveLogInterval
        {
            get { return _AutoArchiveLogInterval; }
            set
            {
                if(_AutoArchiveLogInterval!=value){
                    _AutoArchiveLogInterval=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoArchiveLogInterval");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ArchiveOldMessageInterval;
        public int? ArchiveOldMessageInterval
        {
            get { return _ArchiveOldMessageInterval; }
            set
            {
                if(_ArchiveOldMessageInterval!=value){
                    _ArchiveOldMessageInterval=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ArchiveOldMessageInterval");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _ForwardArchivedMessage;
        public bool? ForwardArchivedMessage
        {
            get { return _ForwardArchivedMessage; }
            set
            {
                if(_ForwardArchivedMessage!=value){
                    _ForwardArchivedMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ForwardArchivedMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ForwardEmail;
        public string ForwardEmail
        {
            get { return _ForwardEmail; }
            set
            {
                if(_ForwardEmail!=value){
                    _ForwardEmail=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ForwardEmail");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _DeleteArchivedMessage;
        public bool? DeleteArchivedMessage
        {
            get { return _DeleteArchivedMessage; }
            set
            {
                if(_DeleteArchivedMessage!=value){
                    _DeleteArchivedMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeleteArchivedMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DeleteArchivedMessageInterval;
        public int? DeleteArchivedMessageInterval
        {
            get { return _DeleteArchivedMessageInterval; }
            set
            {
                if(_DeleteArchivedMessageInterval!=value){
                    _DeleteArchivedMessageInterval=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeleteArchivedMessageInterval");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _DeleteAfterRetrieve;
        public bool? DeleteAfterRetrieve
        {
            get { return _DeleteAfterRetrieve; }
            set
            {
                if(_DeleteAfterRetrieve!=value){
                    _DeleteAfterRetrieve=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeleteAfterRetrieve");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<GatewayConfig, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the IncomingMessage table in the SmartGateway Database.
    /// </summary>
    public partial class IncomingMessage: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<IncomingMessage> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<IncomingMessage>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<IncomingMessage> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(IncomingMessage item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                IncomingMessage item=new IncomingMessage();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<IncomingMessage> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public IncomingMessage(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                IncomingMessage.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IncomingMessage>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public IncomingMessage(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public IncomingMessage(Expression<Func<IncomingMessage, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<IncomingMessage> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<IncomingMessage> _repo;
            
            if(db.TestMode){
                IncomingMessage.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IncomingMessage>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<IncomingMessage> GetRepo(){
            return GetRepo("","");
        }
        
        public static IncomingMessage SingleOrDefault(Expression<Func<IncomingMessage, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            IncomingMessage single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static IncomingMessage SingleOrDefault(Expression<Func<IncomingMessage, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            IncomingMessage single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<IncomingMessage, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<IncomingMessage, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<IncomingMessage> Find(Expression<Func<IncomingMessage, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<IncomingMessage> Find(Expression<Func<IncomingMessage, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<IncomingMessage> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<IncomingMessage> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<IncomingMessage> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<IncomingMessage> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<IncomingMessage> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<IncomingMessage> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Id.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(IncomingMessage)){
                IncomingMessage compare=(IncomingMessage)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Id.ToString();
                    }

        public string DescriptorColumn() {
            return "Id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Originator;
        public string Originator
        {
            get { return _Originator; }
            set
            {
                if(_Originator!=value){
                    _Originator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Originator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OriginatorReceivedDate;
        public DateTime? OriginatorReceivedDate
        {
            get { return _OriginatorReceivedDate; }
            set
            {
                if(_OriginatorReceivedDate!=value){
                    _OriginatorReceivedDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OriginatorReceivedDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Timezone;
        public string Timezone
        {
            get { return _Timezone; }
            set
            {
                if(_Timezone!=value){
                    _Timezone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Timezone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if(_Message!=value){
                    _Message=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Message");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageType;
        public string MessageType
        {
            get { return _MessageType; }
            set
            {
                if(_MessageType!=value){
                    _MessageType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DeliveryStatus;
        public string DeliveryStatus
        {
            get { return _DeliveryStatus; }
            set
            {
                if(_DeliveryStatus!=value){
                    _DeliveryStatus=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeliveryStatus");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _ReceivedDate;
        public DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set
            {
                if(_ReceivedDate!=value){
                    _ReceivedDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ReceivedDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _ValidityTimeStamp;
        public DateTime ValidityTimeStamp
        {
            get { return _ValidityTimeStamp; }
            set
            {
                if(_ValidityTimeStamp!=value){
                    _ValidityTimeStamp=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ValidityTimeStamp");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _OriginatorRefNo;
        public int OriginatorRefNo
        {
            get { return _OriginatorRefNo; }
            set
            {
                if(_OriginatorRefNo!=value){
                    _OriginatorRefNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OriginatorRefNo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageStatusType;
        public string MessageStatusType
        {
            get { return _MessageStatusType; }
            set
            {
                if(_MessageStatusType!=value){
                    _MessageStatusType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageStatusType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SrcPort;
        public int SrcPort
        {
            get { return _SrcPort; }
            set
            {
                if(_SrcPort!=value){
                    _SrcPort=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SrcPort");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DestPort;
        public int? DestPort
        {
            get { return _DestPort; }
            set
            {
                if(_DestPort!=value){
                    _DestPort=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DestPort");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if(_Status!=value){
                    _Status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RawMessage;
        public string RawMessage
        {
            get { return _RawMessage; }
            set
            {
                if(_RawMessage!=value){
                    _RawMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RawMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GatewayId;
        public string GatewayId
        {
            get { return _GatewayId; }
            set
            {
                if(_GatewayId!=value){
                    _GatewayId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GatewayId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdate;
        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set
            {
                if(_LastUpdate!=value){
                    _LastUpdate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CreateDate;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Indexes;
        public string Indexes
        {
            get { return _Indexes; }
            set
            {
                if(_Indexes!=value){
                    _Indexes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Indexes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<IncomingMessage, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the OutgoingMessage table in the SmartGateway Database.
    /// </summary>
    public partial class OutgoingMessage: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<OutgoingMessage> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<OutgoingMessage>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<OutgoingMessage> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(OutgoingMessage item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                OutgoingMessage item=new OutgoingMessage();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<OutgoingMessage> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public OutgoingMessage(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                OutgoingMessage.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutgoingMessage>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public OutgoingMessage(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public OutgoingMessage(Expression<Func<OutgoingMessage, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<OutgoingMessage> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<OutgoingMessage> _repo;
            
            if(db.TestMode){
                OutgoingMessage.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutgoingMessage>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<OutgoingMessage> GetRepo(){
            return GetRepo("","");
        }
        
        public static OutgoingMessage SingleOrDefault(Expression<Func<OutgoingMessage, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            OutgoingMessage single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static OutgoingMessage SingleOrDefault(Expression<Func<OutgoingMessage, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            OutgoingMessage single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<OutgoingMessage, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<OutgoingMessage, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<OutgoingMessage> Find(Expression<Func<OutgoingMessage, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<OutgoingMessage> Find(Expression<Func<OutgoingMessage, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<OutgoingMessage> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<OutgoingMessage> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<OutgoingMessage> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<OutgoingMessage> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<OutgoingMessage> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<OutgoingMessage> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Id.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(OutgoingMessage)){
                OutgoingMessage compare=(OutgoingMessage)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Id.ToString();
                    }

        public string DescriptorColumn() {
            return "Id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Originator;
        public string Originator
        {
            get { return _Originator; }
            set
            {
                if(_Originator!=value){
                    _Originator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Originator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Recipient;
        public string Recipient
        {
            get { return _Recipient; }
            set
            {
                if(_Recipient!=value){
                    _Recipient=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Recipient");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageType;
        public string MessageType
        {
            get { return _MessageType; }
            set
            {
                if(_MessageType!=value){
                    _MessageType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageFormat;
        public string MessageFormat
        {
            get { return _MessageFormat; }
            set
            {
                if(_MessageFormat!=value){
                    _MessageFormat=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageFormat");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Priority;
        public string Priority
        {
            get { return _Priority; }
            set
            {
                if(_Priority!=value){
                    _Priority=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Priority");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if(_Message!=value){
                    _Message=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Message");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ScheduledDate;
        public DateTime? ScheduledDate
        {
            get { return _ScheduledDate; }
            set
            {
                if(_ScheduledDate!=value){
                    _ScheduledDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ScheduledDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if(_Quantity!=value){
                    _Quantity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Quantity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MessageClass;
        public string MessageClass
        {
            get { return _MessageClass; }
            set
            {
                if(_MessageClass!=value){
                    _MessageClass=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MessageClass");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SrcPort;
        public int SrcPort
        {
            get { return _SrcPort; }
            set
            {
                if(_SrcPort!=value){
                    _SrcPort=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SrcPort");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _DestPort;
        public int DestPort
        {
            get { return _DestPort; }
            set
            {
                if(_DestPort!=value){
                    _DestPort=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DestPort");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusReport;
        public string StatusReport
        {
            get { return _StatusReport; }
            set
            {
                if(_StatusReport!=value){
                    _StatusReport=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusReport");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _WapUrl;
        public string WapUrl
        {
            get { return _WapUrl; }
            set
            {
                if(_WapUrl!=value){
                    _WapUrl=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WapUrl");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _WapExpiryDate;
        public DateTime? WapExpiryDate
        {
            get { return _WapExpiryDate; }
            set
            {
                if(_WapExpiryDate!=value){
                    _WapExpiryDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WapExpiryDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _WapCreateDate;
        public DateTime? WapCreateDate
        {
            get { return _WapCreateDate; }
            set
            {
                if(_WapCreateDate!=value){
                    _WapCreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WapCreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _WapSignal;
        public string WapSignal
        {
            get { return _WapSignal; }
            set
            {
                if(_WapSignal!=value){
                    _WapSignal=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WapSignal");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdate;
        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set
            {
                if(_LastUpdate!=value){
                    _LastUpdate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RefNo;
        public string RefNo
        {
            get { return _RefNo; }
            set
            {
                if(_RefNo!=value){
                    _RefNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RefNo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _SentDate;
        public DateTime? SentDate
        {
            get { return _SentDate; }
            set
            {
                if(_SentDate!=value){
                    _SentDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SentDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if(_Status!=value){
                    _Status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Errors;
        public string Errors
        {
            get { return _Errors; }
            set
            {
                if(_Errors!=value){
                    _Errors=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Errors");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GatewayId;
        public string GatewayId
        {
            get { return _GatewayId; }
            set
            {
                if(_GatewayId!=value){
                    _GatewayId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GatewayId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CreateDate;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GroupId;
        public string GroupId
        {
            get { return _GroupId; }
            set
            {
                if(_GroupId!=value){
                    _GroupId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GroupId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<OutgoingMessage, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Role table in the SmartGateway Database.
    /// </summary>
    public partial class Role: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Role> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Role>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Role> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Role item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Role item=new Role();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Role> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public Role(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Role.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Role>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Role(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Role(Expression<Func<Role, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Role> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<Role> _repo;
            
            if(db.TestMode){
                Role.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Role>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Role> GetRepo(){
            return GetRepo("","");
        }
        
        public static Role SingleOrDefault(Expression<Func<Role, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Role single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Role SingleOrDefault(Expression<Func<Role, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Role single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Role, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Role, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Role> Find(Expression<Func<Role, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Role> Find(Expression<Func<Role, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Role> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Role> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Role> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Role> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Role> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Role> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Role)){
                Role compare=(Role)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Desc;
        public string Desc
        {
            get { return _Desc; }
            set
            {
                if(_Desc!=value){
                    _Desc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Desc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _CanBeDeleted;
        public bool CanBeDeleted
        {
            get { return _CanBeDeleted; }
            set
            {
                if(_CanBeDeleted!=value){
                    _CanBeDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CanBeDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Role, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the User table in the SmartGateway Database.
    /// </summary>
    public partial class User: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<User> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<User>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<User> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(User item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                User item=new User();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<User> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public User(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                User.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<User>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public User(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public User(Expression<Func<User, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<User> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<User> _repo;
            
            if(db.TestMode){
                User.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<User>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<User> GetRepo(){
            return GetRepo("","");
        }
        
        public static User SingleOrDefault(Expression<Func<User, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            User single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static User SingleOrDefault(Expression<Func<User, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            User single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<User, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<User, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<User> Find(Expression<Func<User, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<User> Find(Expression<Func<User, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<User> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<User> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<User> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<User> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<User> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<User> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CommonName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(User)){
                User compare=(User)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.CommonName.ToString();
                    }

        public string DescriptorColumn() {
            return "CommonName";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "CommonName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CommonName;
        public string CommonName
        {
            get { return _CommonName; }
            set
            {
                if(_CommonName!=value){
                    _CommonName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CommonName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Mobtel;
        public string Mobtel
        {
            get { return _Mobtel; }
            set
            {
                if(_Mobtel!=value){
                    _Mobtel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Mobtel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if(_Email!=value){
                    _Email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LoginName;
        public string LoginName
        {
            get { return _LoginName; }
            set
            {
                if(_LoginName!=value){
                    _LoginName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LoginName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if(_Password!=value){
                    _Password=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Password");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _CanBeDeleted;
        public bool CanBeDeleted
        {
            get { return _CanBeDeleted; }
            set
            {
                if(_CanBeDeleted!=value){
                    _CanBeDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CanBeDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<User, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the DbMessenger table in the SmartGateway Database.
    /// </summary>
    public partial class DbMessenger: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<DbMessenger> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<DbMessenger>(new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<DbMessenger> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(DbMessenger item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                DbMessenger item=new DbMessenger();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<DbMessenger> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB _db;
        public DbMessenger(string connectionString, string providerName) {

            _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                DbMessenger.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DbMessenger>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public DbMessenger(){
             _db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public DbMessenger(Expression<Func<DbMessenger, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<DbMessenger> GetRepo(string connectionString, string providerName){
            MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB();
            }else{
                db=new MessagingToolkit.SmartGateway.Core.Data.ActiveRecord.SmartGatewayDB(connectionString, providerName);
            }
            IRepository<DbMessenger> _repo;
            
            if(db.TestMode){
                DbMessenger.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DbMessenger>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<DbMessenger> GetRepo(){
            return GetRepo("","");
        }
        
        public static DbMessenger SingleOrDefault(Expression<Func<DbMessenger, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            DbMessenger single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static DbMessenger SingleOrDefault(Expression<Func<DbMessenger, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            DbMessenger single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<DbMessenger, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<DbMessenger, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<DbMessenger> Find(Expression<Func<DbMessenger, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<DbMessenger> Find(Expression<Func<DbMessenger, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<DbMessenger> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<DbMessenger> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<DbMessenger> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<DbMessenger> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<DbMessenger> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<DbMessenger> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Name";
        }

        public object KeyValue()
        {
            return this.Name;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(DbMessenger)){
                DbMessenger compare=(DbMessenger)obj;
                return compare.KeyValue().Equals(this.KeyValue());
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Name";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Dsn;
        public string Dsn
        {
            get { return _Dsn; }
            set
            {
                if(_Dsn!=value){
                    _Dsn=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Dsn");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DbTable;
        public string DbTable
        {
            get { return _DbTable; }
            set
            {
                if(_DbTable!=value){
                    _DbTable=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DbTable");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PollingInterval;
        public int PollingInterval
        {
            get { return _PollingInterval; }
            set
            {
                if(_PollingInterval!=value){
                    _PollingInterval=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PollingInterval");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _RequiredAuth;
        public bool RequiredAuth
        {
            get { return _RequiredAuth; }
            set
            {
                if(_RequiredAuth!=value){
                    _RequiredAuth=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RequiredAuth");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DbUserName;
        public string DbUserName
        {
            get { return _DbUserName; }
            set
            {
                if(_DbUserName!=value){
                    _DbUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DbUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DbUserPassword;
        public string DbUserPassword
        {
            get { return _DbUserPassword; }
            set
            {
                if(_DbUserPassword!=value){
                    _DbUserPassword=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DbUserPassword");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UniqMsgIdColName;
        public string UniqMsgIdColName
        {
            get { return _UniqMsgIdColName; }
            set
            {
                if(_UniqMsgIdColName!=value){
                    _UniqMsgIdColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UniqMsgIdColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UniqMsgIdColDataType;
        public string UniqMsgIdColDataType
        {
            get { return _UniqMsgIdColDataType; }
            set
            {
                if(_UniqMsgIdColDataType!=value){
                    _UniqMsgIdColDataType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UniqMsgIdColDataType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MsgColName;
        public string MsgColName
        {
            get { return _MsgColName; }
            set
            {
                if(_MsgColName!=value){
                    _MsgColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MsgColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DestNoColName;
        public string DestNoColName
        {
            get { return _DestNoColName; }
            set
            {
                if(_DestNoColName!=value){
                    _DestNoColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DestNoColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MsgPriorityColName;
        public string MsgPriorityColName
        {
            get { return _MsgPriorityColName; }
            set
            {
                if(_MsgPriorityColName!=value){
                    _MsgPriorityColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MsgPriorityColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MsgAlertColName;
        public string MsgAlertColName
        {
            get { return _MsgAlertColName; }
            set
            {
                if(_MsgAlertColName!=value){
                    _MsgAlertColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MsgAlertColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DefaultMsgPriority;
        public string DefaultMsgPriority
        {
            get { return _DefaultMsgPriority; }
            set
            {
                if(_DefaultMsgPriority!=value){
                    _DefaultMsgPriority=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DefaultMsgPriority");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DefaultTextMsg;
        public string DefaultTextMsg
        {
            get { return _DefaultTextMsg; }
            set
            {
                if(_DefaultTextMsg!=value){
                    _DefaultTextMsg=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DefaultTextMsg");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _DeleteAfterSending;
        public bool DeleteAfterSending
        {
            get { return _DeleteAfterSending; }
            set
            {
                if(_DeleteAfterSending!=value){
                    _DeleteAfterSending=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeleteAfterSending");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusColName;
        public string StatusColName
        {
            get { return _StatusColName; }
            set
            {
                if(_StatusColName!=value){
                    _StatusColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusTimestampColName;
        public string StatusTimestampColName
        {
            get { return _StatusTimestampColName; }
            set
            {
                if(_StatusTimestampColName!=value){
                    _StatusTimestampColName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusTimestampColName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusColNewValue;
        public string StatusColNewValue
        {
            get { return _StatusColNewValue; }
            set
            {
                if(_StatusColNewValue!=value){
                    _StatusColNewValue=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusColNewValue");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusColUpdateSuccessVal;
        public string StatusColUpdateSuccessVal
        {
            get { return _StatusColUpdateSuccessVal; }
            set
            {
                if(_StatusColUpdateSuccessVal!=value){
                    _StatusColUpdateSuccessVal=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusColUpdateSuccessVal");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusColUpdateFailedValue;
        public string StatusColUpdateFailedValue
        {
            get { return _StatusColUpdateFailedValue; }
            set
            {
                if(_StatusColUpdateFailedValue!=value){
                    _StatusColUpdateFailedValue=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusColUpdateFailedValue");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StatusColUpdateSendingValue;
        public string StatusColUpdateSendingValue
        {
            get { return _StatusColUpdateSendingValue; }
            set
            {
                if(_StatusColUpdateSendingValue!=value){
                    _StatusColUpdateSendingValue=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusColUpdateSendingValue");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _AutoStart;
        public bool AutoStart
        {
            get { return _AutoStart; }
            set
            {
                if(_AutoStart!=value){
                    _AutoStart=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AutoStart");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if(_Status!=value){
                    _Status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<DbMessenger, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
