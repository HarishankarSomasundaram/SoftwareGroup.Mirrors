using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareGroup.Mirrors.DataEntity.DataSource;

namespace SoftwareGroup.Mirrors.Core.Repository
{
    public interface IDataSourceRepository
    {
        DataConnection GetConnection(int connectionId);

        DataConnection GetConnection(string connectionName);

        List<DataConnection> GetAllConnections();

        int CreateConnection(DataConnection connectionDetail);

        void UpdateConnection(DataConnection connectionDetail);

        DataConnectionType GetConnectionType(int connectionTypeId);

        DataConnectionType GetConnectionType(string connectionTypeName);

        List<DataConnectionType> GetAllConnectionTypes();

        DataSourceType GetSourceType(int sourceTypeId);

        DataSourceType GetSourceType(string sourceTypeName);

        List<DataSourceType> GetAllSourceTypes();

        DataSource GetSource(int sourceId);

        DataSource GetSource(string sourceName);

        List<DataSource> GetAllSources();

        int  CreateSource(DataSource sourceDetail);

        void UpdateSource(DataSource sourceDetail);

        DataSourceElement GetSourceElement(int elementId);

        DataSourceElement GetSourceElement(string sourceName);

        List<DataSourceElement> GetAllSourceElements(int sourceId);

        int CreateSourceElement(DataSourceElement sourceElementDetail);
    }
}
