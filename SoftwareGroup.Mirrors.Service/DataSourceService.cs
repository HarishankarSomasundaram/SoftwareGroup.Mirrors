using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareGroup.Mirrors.Core.Service;
using SoftwareGroup.Mirrors.DataEntity.DataSource;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.Core.Repository;

namespace SoftwareGroup.Mirrors.Service
{
    public class DataSourceService:IDataSourceService
    {
        public DataConnection GetConnection(int connectionId)
        {
            throw new NotImplementedException();
        }


        public DataConnection GetConnection(string connectionName)
        {
            var repo = IoC.Resolve<IDataSourceRepository>();
            DataConnection connectionDetail = repo.GetConnection(connectionName);
            return connectionDetail;
        }
        public List<DataConnection> GetAllConnections()
        {
            var repository = IoC.Resolve<IDataSourceRepository>();
            List<DataConnection> connections = repository.GetAllConnections();
            return connections;
        }

        public void Save(DataConnection connectionDetail)
        {
            var repo = IoC.Resolve<IDataSourceRepository>();
     
            if (connectionDetail.ConnectionID > 0)
                repo.UpdateConnection(connectionDetail);
            else
            { 
                repo.CreateConnection(connectionDetail);
                
            }
           
        }
        public DataConnectionType GetConnectionType(int connectionTypeId)
        {
            throw new NotImplementedException();
        }
        public DataConnectionType GetConnectionType(string connectionTypeName)
        {
            throw new NotImplementedException();
        }
        public List<DataConnectionType> GetAllConnectionTypes()
        {
            var repository = IoC.Resolve<IDataSourceRepository>();
            List<DataConnectionType> connectionTypes = repository.GetAllConnectionTypes();
            return connectionTypes;
        }
        public DataSourceType GetSourceType(int sourceTypeId)
        {
            throw new NotImplementedException();
        }
        public DataSourceType GetSourceType(string sourceTypeName)
        {
            var repo = IoC.Resolve<IDataSourceRepository>();
            DataSourceType sourceTypeDetail = repo.GetSourceType(sourceTypeName);
            return sourceTypeDetail;
        }
        public List<DataSourceType> GetAllSourceTypes()
        {
            throw new NotImplementedException();
        }
        public DataSource GetSource(int sourceId)
        {
            throw new NotImplementedException();
        }
        public DataSource GetSource(string sourceName)
        {
            var repo = IoC.Resolve<IDataSourceRepository>();
            DataSource source = repo.GetSource(sourceName);
            return source;
        }
        public List<DataSource> GetAllSources()
        {
            throw new NotImplementedException();
        }
        public void Save(DataSource sourceDetail)
        {
            var repo = IoC.Resolve<IDataSourceRepository>();

            if (sourceDetail.SourceID > 0)
                repo.UpdateSource(sourceDetail);
            else
            {
                repo.CreateSource(sourceDetail);
            }
        }
        public DataSourceElement GetSourceElement(int elementId)
        {
            throw new NotImplementedException();
        }
        public DataSourceElement GetSourceElement(string sourceName)
        {
            throw new NotImplementedException();
        }
        public List<DataSourceElement> GetAllSourceElements(int sourceId)
        {
            throw new NotImplementedException();
        }
        public void Save(DataSourceElement sourceElementDetail)
        {
            throw new NotImplementedException();
        } 
    }
}
