using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareGroup.Mirrors.DataEntity.DataSource;

namespace SoftwareGroup.Mirrors.Core.Service
{
    public interface IDataSourceService
    {
        DataConnection GetConnection(int connectionId);

        DataConnection GetConnection(string connectionName);

        List<DataConnection> GetAllConnections();

        void Save(DataConnection connectionDetail);

        DataConnectionType GetConnectionType(int connectionTypeId);

        DataConnectionType GetConnectionType(string connectionTypeName);

        List<DataConnectionType> GetAllConnectionTypes();

        DataSourceType GetSourceType(int sourceTypeId);

        DataSourceType GetSourceType(string sourceTypeName);

        List<DataSourceType> GetAllSourceTypes();

        DataSource GetSource(int sourceId);

        DataSource GetSource(string sourceName);

        List<DataSource> GetAllSources();

        void Save(DataSource sourceDetail);

        DataSourceElement GetSourceElement(int elementId);

        DataSourceElement GetSourceElement(string sourceName);

        List<DataSourceElement> GetAllSourceElements(int sourceId);

        void Save(DataSourceElement sourceElementDetail);

    }
}
