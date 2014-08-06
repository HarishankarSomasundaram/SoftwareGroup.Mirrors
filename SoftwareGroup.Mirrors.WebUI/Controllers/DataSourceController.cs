//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using SoftwareGroup.Mirrors.WebUI.Models;
//using System.Data.SqlClient;
//using System.Data;
//using SoftwareGroup.Mirrors.Infra;
//using SoftwareGroup.Mirrors.Core.Service;
//using SoftwareGroup.Mirrors.DataEntity.DataSource;
//using SoftwareGroup.Mirrors.WebUI.Common;  
////using Microsoft.AnalysisServices.AdomdClient;

//namespace SoftwareGroup.Mirrors.WebUI.Controllers
//{
//    public class DataSourceController : Controller
//    {
//        //
//        // GET: /DataSource/

//        public ActionResult Index()
//        {
//            ViewBag.Title = "Administration";
//            ViewBag.SubTitle = "Datasource Manager";
//            ConnectionTypeViewModel connectionType = new ConnectionTypeViewModel();
//            var service = IoC.Resolve<IDataSourceService>();
//            connectionType.ConnectionTypes = service.GetAllConnectionTypes();
//            return View("Index", connectionType);
//        }



//        [HttpPost]
//        public ActionResult SourceType(ConnectionTypeViewModel connectionType)
//        {
//            if (ModelState.IsValid)
//            {
//                if (connectionType.ConnectionTypeID == 3)
//                {
//                    ExcelConnectionViewModel excel = new ExcelConnectionViewModel();
//                    excel.ConnectionTypeID = connectionType.ConnectionTypeID;
//                    excel.ConnectionTypeName = connectionType.ConnectionTypeName;
//                    excel.ProviderName = connectionType.ProviderName;
//                    return View("ExcelConnection", excel);
//                }
//                else
//                {
//                    ConnectionDetailViewModel connectionDetail = new ConnectionDetailViewModel();
//                    connectionDetail.ConnectionTypeID = connectionType.ConnectionTypeID;
//                    connectionDetail.ConnectionTypeName = connectionType.ConnectionTypeName;
//                    connectionDetail.ProviderName = connectionType.ProviderName;
//                    connectionDetail.NewOrExistingConnections = new List<SelectListItem>();
//                    connectionDetail.Databases = new List<SelectListItem>();
//                    var service = IoC.Resolve<IDataSourceService>();
//                    List<DataConnection> existingConnections = service.GetAllConnections();
//                    SelectListItem newItem = new SelectListItem() { Text = "(New Connection)", Value = "New Connection" };
//                    connectionDetail.NewOrExistingConnections.Add(newItem);
//                    foreach (DataConnection connection in existingConnections)
//                    {
//                        if(connection.ConnectionTypeID == connectionDetail.ConnectionTypeID)
//                        { 
//                            SelectListItem item = new SelectListItem() { Text = connection.ConnectionName, Value = connection.ConnectionName };
//                            connectionDetail.NewOrExistingConnections.Add(item);
//                        }
//                    }

//                    return View("ConnectionDetail", connectionDetail);
//                }
                
//            }

//            else
//            {
//                return View("Index", connectionType);
//            }
//        }

//        public JsonResult GetConnectionDetail(string NewOrExistingConnection)
//        {
//            var service = IoC.Resolve<IDataSourceService>();
//            var connection = service.GetConnection(NewOrExistingConnection);
//            var result = Json(connection);
//            return result;
//        }


//        [HttpPost]
//        public ActionResult ExcelConnection(ExcelConnectionViewModel excel)
//        {
//            if (ModelState.IsValid)
//            {
//                int successCode = new DataSourceHelper().CreateDataConnection(excel);
//                if (successCode == 0)
//                {
//                    ConnectionTypeViewModel connectionType = new ConnectionTypeViewModel();
//                    var service1 = IoC.Resolve<IDataSourceService>();
//                    connectionType.ConnectionTypes = service1.GetAllConnectionTypes();
//                    ViewBag.Message = "Data Source Information Saved Successfully";
//                    return View("Index", connectionType);
//                }
//                else
//                    return View("ExcelConnection", excel);
//            }
//            else
//            {
//                return View("ExcelConnection", excel);
//            }
//        }




//        [HttpPost]
//        public ActionResult ConnectionDetail(ConnectionDetailViewModel connectionDetail)
//        {
//            if (ModelState.IsValid)
//            {

//                SourceDetailViewModel sourceDetail = new SourceDetailViewModel();
//                sourceDetail.ConnectionTypeID = connectionDetail.ConnectionTypeID;
//                sourceDetail.ConnectionTypeName = connectionDetail.ConnectionTypeName;
//                sourceDetail.ProviderName = connectionDetail.ProviderName;
//                sourceDetail.ServerName = connectionDetail.ServerName;
//                sourceDetail.AuthenticationType = connectionDetail.AuthenticationType;
//                sourceDetail.UserName = connectionDetail.UserName;
//                sourceDetail.Password = connectionDetail.Password;
//                sourceDetail.InitialCatalog = connectionDetail.InitialCatalog;

//                sourceDetail.Objects = new List<SelectListItem>();
//                sourceDetail.Elements = new List<string>();
//                sourceDetail.Measures = new List<string>();
//                sourceDetail.ElementsList = new List<string>();
//                sourceDetail.MeasuresList = new List<string>();

//                string view=" ";
//                if (connectionDetail.ConnectionTypeID == 1)
//                {
//                    GetViewsSp(sourceDetail);
//                    if(sourceDetail.Objects.Count != 0)
//                    { 
//                    sourceDetail.Object = sourceDetail.Objects[0].Value; 
//                    GetColumns(sourceDetail);
//                    }
//                    view = "OLTPSourceDetail";
//                }
//                if (connectionDetail.ConnectionTypeID == 2)
//                {
//                    GetAnalysisCubes(sourceDetail);
//                    if (sourceDetail.Objects.Count != 0)
//                    {
//                        sourceDetail.Object = sourceDetail.Objects[0].Value;
//                        GetDimensions(sourceDetail);
//                        GetMeasures(sourceDetail);
//                    }
                
//                    view = "OLAPSourceDetail";
//                }
//                return View(view, sourceDetail);

//            }

//            else
//            {
//                return View("ConnectionDetail", connectionDetail);
//            }
//        }

//        public JsonResult GetDatabases(ConnectionDetailViewModel connectionDetail)
//        {
         
//            JsonResult result=null;
//            if (connectionDetail.ConnectionTypeID == 1)
//                result = GetSqlServerDatabases(connectionDetail);
//            if (connectionDetail.ConnectionTypeID == 2)
//                result = GetAnalysisDatabases(connectionDetail);
//            return result;
        
//        }

//        public JsonResult GetAnalysisDatabases(ConnectionDetailViewModel connectionDetail)
//        {          
//            List<SelectListItem> databases = new List<SelectListItem>();
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = connectionDetail.ServerName;
          
//            //using (AdomdConnection analysisServer = new AdomdConnection("Data Source=" + dsWizard.ServerName))
//            using (AdomdConnection analysisServer = new AdomdConnection(connString.ConnectionString))
//            {
               
//                analysisServer.Open();
//                AdomdRestrictionCollection restrictions= new AdomdRestrictionCollection();
//                DataTable tblDatabases = analysisServer.GetSchemaDataSet("DBSCHEMA_CATALOGS",restrictions).Tables[0];
//                analysisServer.Close();

//                foreach (DataRow row in tblDatabases.Rows)
//                {
//                    string r = (string)row["catalog_name"];
//                    SelectListItem item = new SelectListItem() { Text = r, Value = r };
//                    databases.Add(item);

//                }

//                JsonResult result = Json(databases);

//                return result;
//            }
    
//        }
//        public JsonResult GetSqlServerDatabases(ConnectionDetailViewModel connectionDetail)
//        {
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = connectionDetail.ServerName;
//            if (connectionDetail.AuthenticationType == "W")
//            {
//                connString.IntegratedSecurity = true;
//            }

//            if (connectionDetail.AuthenticationType == "S")
//            {
//                connString.UserID = connectionDetail.UserName;
//                connString.Password = connectionDetail.Password;
//            }

//            List<SelectListItem> databases = new List<SelectListItem>();

//            using (SqlConnection sqlConx = new SqlConnection(connString.ConnectionString))
//            {
//                sqlConx.Open();
//                DataTable tblDatabases = sqlConx.GetSchema("Databases");
//                sqlConx.Close();

//                foreach (DataRow row in tblDatabases.Rows)
//                {
//                    string r = (string)row["database_name"];
//                    SelectListItem item = new SelectListItem() { Text = r, Value = r };
//                    databases.Add(item);

//                }
//            }

//            JsonResult result = Json(databases);

//            return result;
//        }
//        public void GetViewsSp(SourceDetailViewModel sourceDetail)
//        {
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = sourceDetail.ServerName;
//            if (sourceDetail.AuthenticationType == "W")
//            {
//                connString.IntegratedSecurity = true;
//            }

//            if (sourceDetail.AuthenticationType == "S")
//            {
//                connString.UserID = sourceDetail.UserName;
//                connString.Password = sourceDetail.Password;
//            }
//            connString.InitialCatalog = sourceDetail.InitialCatalog;
     
//            using (SqlConnection sqlConx = new SqlConnection(connString.ConnectionString))
//            {
//                sqlConx.Open();
//                DataTable tblViews = sqlConx.GetSchema("Views");
//                sqlConx.Close();

//                foreach (DataRow row in tblViews.Rows)
//                {
//                    string r = (string)row["table_name"];
//                    SelectListItem item = new SelectListItem() { Text = r, Value = r };
//                    sourceDetail.Objects.Add(item);

//                }
//            }

//        }

//        public void GetAnalysisCubes(SourceDetailViewModel sourceDetail)
//        {

//            using (AdomdConnection analysisServer = new AdomdConnection("Data Source=" + sourceDetail.ServerName))
//            {
//                analysisServer.Open();
//                AdomdRestrictionCollection restrictions = new AdomdRestrictionCollection();
//                restrictions.Add("CATALOG_NAME", sourceDetail.InitialCatalog);
//                DataTable cubes = analysisServer.GetSchemaDataSet("MDSCHEMA_CUBES", restrictions).Tables[0];
//                analysisServer.Close();

//                foreach (DataRow row in cubes.Rows)
//                {
//                    string r = (string)row["cube_name"];
//                    SelectListItem item = new SelectListItem() { Text = r, Value = r };
//                    sourceDetail.Objects.Add(item);

//                }
//            }

//        }
//        public JsonResult GetColumns(SourceDetailViewModel sourceDetail)
//        {
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = sourceDetail.ServerName;
//            if (sourceDetail.AuthenticationType == "W")
//            {
//                connString.IntegratedSecurity = true;
//            }

//            if (sourceDetail.AuthenticationType == "S")
//            {
//                connString.UserID = sourceDetail.UserName;
//                connString.Password = sourceDetail.Password;
//            }
//            connString.InitialCatalog = sourceDetail.InitialCatalog;
//            string[] restrictions = new string[4] { null, null, sourceDetail.Object, null };
//            List<string> columnList;
//            using (SqlConnection sqlConx = new SqlConnection(connString.ConnectionString))
//            {
//                sqlConx.Open();
//                columnList = sqlConx.GetSchema("ViewColumns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToList();
//                sqlConx.Close();
//            }

//            sourceDetail.ElementsList.AddRange(columnList);

//            JsonResult result = Json(columnList);

//            return result;
           
//        }

//        public JsonResult GetDimensions(SourceDetailViewModel sourceDetail)
//        {
//            List<string> dimensionList = new List<string>();
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = sourceDetail.ServerName;

//            //using (AdomdConnection analysisServer = new AdomdConnection("Data Source=" + dsWizard.ServerName))
//            using (AdomdConnection analysisServer = new AdomdConnection(connString.ConnectionString))
//            {

//                analysisServer.Open();
//                AdomdRestrictionCollection restrictions = new AdomdRestrictionCollection();
//                restrictions.Add("CATALOG_NAME", sourceDetail.InitialCatalog);
//                restrictions.Add("CUBE_NAME", sourceDetail.Object);
//                DataTable tblDimensions = analysisServer.GetSchemaDataSet("MDSCHEMA_DIMENSIONS", restrictions).Tables[0];
//                analysisServer.Close();

//                foreach (DataRow row in tblDimensions.Rows)
//                {
//                    string r = (string)row["dimension_name"];      
//                    dimensionList.Add(r);

//                }

//                sourceDetail.ElementsList.AddRange(dimensionList);
//                JsonResult result = Json(dimensionList);

//                return result;
//            }

//        }

//        public JsonResult GetMeasures(SourceDetailViewModel sourceDetail)
//        {
//            List<string> measuresList = new List<string>();
//            SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder();
//            connString.DataSource = sourceDetail.ServerName;

//            //using (AdomdConnection analysisServer = new AdomdConnection("Data Source=" + dsWizard.ServerName))
//            using (AdomdConnection analysisServer = new AdomdConnection(connString.ConnectionString))
//            {

//                analysisServer.Open();
//                AdomdRestrictionCollection restrictions = new AdomdRestrictionCollection();
//                restrictions.Add("CATALOG_NAME", sourceDetail.InitialCatalog);
//                restrictions.Add("CUBE_NAME", sourceDetail.Object);
//                DataTable tblMeasures = analysisServer.GetSchemaDataSet("MDSCHEMA_MEASURES", restrictions).Tables[0];
//                analysisServer.Close();

//                foreach (DataRow row in tblMeasures.Rows)
//                {
//                    string r = (string)row["measure_name"];
//                    measuresList.Add(r);

//                }
//                sourceDetail.MeasuresList.AddRange(measuresList);
//                JsonResult result = Json(measuresList);

//                return result;
//            }

//        }

//        [HttpPost]
//        public ActionResult OLAPSourceDetail(SourceDetailViewModel sourceDetail )
//        {
//            if (ModelState.IsValid)
//            {

//                sourceDetail.AuthenticationType = "X";
//                int successCode = 0;
//                if (sourceDetail.NewOrExistingConnection == "New Connection")
//                {
//                    var service = IoC.Resolve<IDataSourceService>();
//                    var sourceType = service.GetSourceType("Cube");
//                    successCode = new DataSourceHelper().CreateDataConnectionAndSource(sourceDetail, sourceType);
//                }
//                else
//                {

//                        var service = IoC.Resolve<IDataSourceService>();
//                        var existingConnection = service.GetConnection(sourceDetail.ConnectionName);
//                        var sourceType = service.GetSourceType("Cube");
//                        successCode = new DataSourceHelper().CreateSourceDetails(sourceDetail, existingConnection, sourceType);
                    
//                }

//                ConnectionTypeViewModel connectionType = new ConnectionTypeViewModel();
//                var service1 = IoC.Resolve<IDataSourceService>();
//                connectionType.ConnectionTypes = service1.GetAllConnectionTypes();
//                ViewBag.Message = "Data Source Information Saved Successfully";
//                return View("Index", connectionType);
//            }
//            else
//            {
//                return View("OLAPSourceDetail", sourceDetail);
//            }

//        }
//        [HttpPost]
//        public ActionResult OLTPSourceDetail(SourceDetailViewModel sourceDetail)
//        {
//            if (ModelState.IsValid)
//            {


//                int successCode = 0;
//                if (sourceDetail.NewOrExistingConnection == "New Connection")
//                {
//                    var service = IoC.Resolve<IDataSourceService>();
//                    var sourceType = service.GetSourceType("View");
//                    successCode = new DataSourceHelper().CreateDataConnectionAndSource(sourceDetail, sourceType);
//                }
//                else
//                {

//                    var service = IoC.Resolve<IDataSourceService>();
//                    var newOrExistingConnection = service.GetConnection(sourceDetail.ConnectionName);
//                    var sourceType = service.GetSourceType("View");
//                    successCode = new DataSourceHelper().CreateSourceDetails(sourceDetail, newOrExistingConnection, sourceType);

//                }

//                ConnectionTypeViewModel connectionType = new ConnectionTypeViewModel();
//                var service1 = IoC.Resolve<IDataSourceService>();
//                connectionType.ConnectionTypes = service1.GetAllConnectionTypes();
//                ViewBag.Message = "Data Source Information Saved Successfully";
//                return View("Index", connectionType);
//            }
//            else
//            {
//                return View("OLTPSourceDetail", sourceDetail);
//            }
//        }

//    }
//}
