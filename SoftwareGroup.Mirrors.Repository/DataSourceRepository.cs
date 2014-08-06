using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareGroup.Mirrors.DataEntity.DataSource;
using SoftwareGroup.Mirrors.Core.Repository;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.Core;

namespace SoftwareGroup.Mirrors.Repository
{
    public class DataSourceRepository:IDataSourceRepository
    {
        public DataEntity.DataSource.DataConnection GetConnection(int connectionId)
        {
            using (var ctx = new MirrorsEntities())
            {
                var connectionDetail = ctx.DataConnections.Where(m => m.ConnectionID == connectionId).FirstOrDefault();
                if (connectionDetail != null)
                {
                    var dataConnection = new DataEntity.DataSource.DataConnection()
                    {
                        ConnectionName = connectionDetail.ConnectionName,
                        ConnectionID = connectionDetail.ConnectionID,
                        ConnectionTypeID = connectionDetail.ConnectionTypeID,
                        HostName = connectionDetail.HostName,
                        AuthenticationType = connectionDetail.AuthenticationType,
                        UserID = connectionDetail.UserID,
                        Password = connectionDetail.Password,
                        CatalogName = connectionDetail.CatalogName,
                        CreatedBy = connectionDetail.CreatedBy,
                        CreatedOn = connectionDetail.CreatedOn,
                        UpdatedBy = connectionDetail.UpdatedBy,
                        UpdatedOn = connectionDetail.UpdatedOn
                    };
                    return dataConnection;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataEntity.DataSource.DataConnection GetConnection(string connectionName)
        {
            using (var ctx = new MirrorsEntities())
            {
                var connectionDetail = ctx.DataConnections.Where(m => m.ConnectionName == connectionName).FirstOrDefault();
                if (connectionDetail != null)
                {
                    var dataConnection = new DataEntity.DataSource.DataConnection()
                    {
                        ConnectionName = connectionDetail.ConnectionName,
                        ConnectionID = connectionDetail.ConnectionID,
                        ConnectionTypeID = connectionDetail.ConnectionTypeID,
                        HostName = connectionDetail.HostName,
                        AuthenticationType = connectionDetail.AuthenticationType,
                        UserID = connectionDetail.UserID,
                        Password = connectionDetail.Password,
                        CatalogName = connectionDetail.CatalogName,
                        CreatedBy = connectionDetail.CreatedBy,
                        CreatedOn = connectionDetail.CreatedOn,
                        UpdatedBy = connectionDetail.UpdatedBy,
                        UpdatedOn = connectionDetail.UpdatedOn
                    };
                    return dataConnection;
                }
                else
                {
                    return null;
                }

            }
        }
        public List<DataEntity.DataSource.DataConnection> GetAllConnections()
        {
            using (var ctx = new MirrorsEntities())
            {
                var results = ctx.DataConnections.ToList();
                var connections = new List<DataEntity.DataSource.DataConnection>();
                foreach (var item in results)
                {
                    DataEntity.DataSource.DataConnection connection = new DataEntity.DataSource.DataConnection();
                    connection.AuthenticationType = item.AuthenticationType;
                    connection.CatalogName = item.CatalogName;
                    connection.ConnectionID = item.ConnectionID;
                    connection.ConnectionName = item.ConnectionName;
                    connection.ConnectionTypeID = item.ConnectionTypeID; 
                    connections.Add(connection);
                }
                return connections;
            }
        }
        public int CreateConnection(DataEntity.DataSource.DataConnection connectionDetail)
        {
            using (var ctx = new MirrorsEntities())
            {
                var newConnection = new DataConnection()
                {
                    ConnectionName = connectionDetail.ConnectionName,
                    ConnectionTypeID = connectionDetail.ConnectionTypeID,
                    HostName = connectionDetail.HostName,
                    AuthenticationType = connectionDetail.AuthenticationType,
                    UserID = connectionDetail.UserID,
                    Password = connectionDetail.Password,
                    CatalogName = connectionDetail.CatalogName,
                    CreatedBy = connectionDetail.CreatedBy,
                    CreatedOn = connectionDetail.CreatedOn,
                    UpdatedBy = connectionDetail.UpdatedBy,
                    UpdatedOn = connectionDetail.UpdatedOn,
                    ConnectionID = connectionDetail.ConnectionID
                };
                var connections = ctx.DataConnections;
                connections.Add(newConnection);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    var logger = IoC.Resolve<ILogger>();

                    logger.LogFatal(sb.ToString(), ex);

                    throw new DbEntityValidationException(
                                "Entity Validation Failed - errors follow:\n" +
                                sb.ToString(), ex
                            ); // Add the original exception as the innerException

                }

                catch (DbUpdateException ex)
                {
                    var innerEx = ex.InnerException;

                    while (innerEx.InnerException != null)
                        innerEx = innerEx.InnerException;
                    var logger = IoC.Resolve<ILogger>();
                    logger.LogFatal(innerEx.Message, ex);
                    throw new DbUpdateException(innerEx.Message, ex);
                }


            }

            return 0;
        }
        public void UpdateConnection(DataEntity.DataSource.DataConnection connectionDetail)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataConnectionType GetConnectionType(int connectionTypeId)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataConnectionType GetConnectionType(string connectionTypeName)
        {
            throw new NotImplementedException();
        }
        public List<DataEntity.DataSource.DataConnectionType> GetAllConnectionTypes()
        {
            using (var ctx = new MirrorsEntities())
            {
                var results = ctx.DataConnectionTypes.ToList();
                var connectionTypes = new List<DataEntity.DataSource.DataConnectionType>();
                foreach (var item in results)
                {
                    DataEntity.DataSource.DataConnectionType connectionType = new DataEntity.DataSource.DataConnectionType();
                    connectionType.ConnectionTypeID = item.ConnectionTypeID;
                    connectionType.ConnectionTypeName = item.ConnectionTypeName;
                    connectionType.ProviderName = item.ProviderName;
                    connectionTypes.Add(connectionType);
                }
                return connectionTypes;
            }
        }
        public DataEntity.DataSource.DataSourceType GetSourceType(int sourceTypeId)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataSourceType GetSourceType(string sourceTypeName)
        {
            using (var ctx = new MirrorsEntities())
            {
                var sourceTypeDetail = ctx.DataSourceTypes.Where(m => m.SourceTypeName == sourceTypeName).FirstOrDefault();
                var sourceTypeDetail1 = new DataEntity.DataSource.DataSourceType()
                {
                    SourceTypeID = sourceTypeDetail.SourceTypeID,
                    SourceTypeName = sourceTypeDetail.SourceTypeName
                };
                return sourceTypeDetail1;

            }
        }
        public List<DataEntity.DataSource.DataSourceType> GetAllSourceTypes()
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataSource GetSource(int sourceId)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataSource GetSource(string sourceName)
        {
            using (var ctx = new MirrorsEntities())
            {
                var source = ctx.DataSources.Where(m => m.SourceName == sourceName).FirstOrDefault();
                if (source != null)
                {
                    var dataSource  = new DataEntity.DataSource.DataSource()
                    {
                        SourceID = source.SourceID,
                        SourceName = source.SourceName,
                        ConnectionID = source.ConnectionID,
                        SourceTypeID = source.SourceTypeID,
                        ObjectName = source.ObjectName,
                        CreatedBy = source.CreatedBy,
                        CreatedOn = source.CreatedOn,
                        UpdatedBy = source.UpdatedBy,
                        UpdatedOn = source.UpdatedOn

                    };
                    return dataSource;
                }
                else
                {
                    return null;
                }

            }
        }
        public List<DataEntity.DataSource.DataSource> GetAllSources()
        {
            using (var ctx = new MirrorsEntities())
            {
                var results = ctx.DataSources.ToList();
                var dataSources = new List<DataEntity.DataSource.DataSource>();
                foreach (var source in results)
                {
                    var dataSource = new DataEntity.DataSource.DataSource()
                    {
                        SourceID = source.SourceID,
                        SourceName = source.SourceName,
                        ConnectionID = source.ConnectionID,
                        SourceTypeID = source.SourceTypeID,
                        ObjectName = source.ObjectName,
                        CreatedBy = source.CreatedBy,
                        CreatedOn = source.CreatedOn,
                        UpdatedBy = source.UpdatedBy,
                        UpdatedOn = source.UpdatedOn

                    };

                    dataSources.Add(dataSource);
                }
                return dataSources;
            }            
        }
        public int CreateSource(DataEntity.DataSource.DataSource sourceDetail)
        {
            var dataSourceElements = new List<DataSourceElement>();
            
            foreach (DataEntity.DataSource.DataSourceElement dataSourceElement in sourceDetail.DataSourceElements)
            {
                DataSourceElement newSourceElement = new DataSourceElement()
                {
                    ElementName = dataSourceElement.ElementName,
                    ElementType = dataSourceElement.ElementType,
                    ElementDataType = dataSourceElement.ElementDataType,
                    ParentID = dataSourceElement.ParentID,
                    SortOrder = dataSourceElement.SortOrder
                };
                dataSourceElements.Add(newSourceElement);
            }
            using (var ctx = new MirrorsEntities())
            {
                var newDataSource = new DataSource()
                {
                    SourceName = sourceDetail.SourceName,
                    ConnectionID = sourceDetail.ConnectionID,
                    SourceTypeID = sourceDetail.SourceTypeID,
                    ObjectName = sourceDetail.ObjectName,
                    CreatedBy = sourceDetail.CreatedBy,
                    CreatedOn = sourceDetail.CreatedOn,
                    UpdatedBy = sourceDetail.UpdatedBy,
                    UpdatedOn = sourceDetail.UpdatedOn,
                    DataSourceElements = dataSourceElements,

                };
                if (sourceDetail.DataConnection != null)
                {
                    newDataSource.DataConnection = new DataConnection()
                    {
                        ConnectionName = sourceDetail.DataConnection.ConnectionName,
                        ConnectionTypeID = sourceDetail.DataConnection.ConnectionTypeID,
                        HostName = sourceDetail.DataConnection.HostName,
                        AuthenticationType = sourceDetail.DataConnection.AuthenticationType,
                        UserID = sourceDetail.DataConnection.UserID,
                        Password = sourceDetail.DataConnection.Password,
                        CatalogName = sourceDetail.DataConnection.CatalogName,
                        CreatedBy = sourceDetail.DataConnection.CreatedBy,
                        CreatedOn = sourceDetail.DataConnection.CreatedOn,
                        UpdatedBy = sourceDetail.DataConnection.UpdatedBy,
                        UpdatedOn = sourceDetail.DataConnection.UpdatedOn,
                        ConnectionID = sourceDetail.DataConnection.ConnectionID
                    };
                }
                var dataSources = ctx.DataSources;
                dataSources.Add(newDataSource);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    var logger = IoC.Resolve<ILogger>();

                    logger.LogFatal(sb.ToString(), ex);

                    throw new DbEntityValidationException(
                                "Entity Validation Failed - errors follow:\n" +
                                sb.ToString(), ex
                            ); // Add the original exception as the innerException

                }

                catch (DbUpdateException ex)
                {
                    var innerEx = ex.InnerException;

                    while (innerEx.InnerException != null)
                        innerEx = innerEx.InnerException;
                    var logger = IoC.Resolve<ILogger>();
                    logger.LogFatal(innerEx.Message, ex);
                    throw new DbUpdateException(innerEx.Message, ex);
                }


            }

            return 0;
        }
        public void UpdateSource(DataEntity.DataSource.DataSource sourceDetail)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataSourceElement GetSourceElement(int elementId)
        {
            throw new NotImplementedException();
        }
        public DataEntity.DataSource.DataSourceElement GetSourceElement(string sourceName)
        {
            throw new NotImplementedException();
        }
        public List<DataEntity.DataSource.DataSourceElement> GetAllSourceElements(int sourceId)
        {
            throw new NotImplementedException();
        }
        public int CreateSourceElement(DataEntity.DataSource.DataSourceElement sourceElementDetail)
        {
            throw new NotImplementedException();
        }
    }
}
