using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftwareGroup.Mirrors.DataEntity.DataSource;
using SoftwareGroup.Mirrors.WebUI.Models;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.Core.Service;

namespace SoftwareGroup.Mirrors.WebUI.Common
{
    public class DataSourceHelper
    {

        public int CreateDataConnection(SourceDetailViewModel sourceDetail)
        {
            var service = IoC.Resolve<IDataSourceService>();
            DataConnection newConnection = new DataConnection();
            newConnection.AuthenticationType = sourceDetail.AuthenticationType;
            newConnection.ConnectionName = sourceDetail.ConnectionName;
            newConnection.ConnectionTypeID = sourceDetail.ConnectionTypeID;
            newConnection.HostName = sourceDetail.ServerName;
            newConnection.CatalogName = sourceDetail.InitialCatalog;
            newConnection.CreatedBy = 1;
            newConnection.UpdatedBy = null;
            newConnection.UpdatedOn = null;
            newConnection.CreatedOn = DateTime.Now;
            if(newConnection.AuthenticationType == "S")
            {
                newConnection.CatalogName = sourceDetail.ServerName;
                newConnection.Password = sourceDetail.Password;
            }
            service.Save(newConnection);

            return 0;
           
        }

        public int CreateDataConnection(ExcelConnectionViewModel excel)
        {
            var service = IoC.Resolve<IDataSourceService>();
            DataConnection newConnection = new DataConnection();
            newConnection.AuthenticationType = "X";
            newConnection.ConnectionName = excel.ConnectionName;
            newConnection.ConnectionTypeID = excel.ConnectionTypeID;
            newConnection.HostName = "X";
            newConnection.CatalogName = excel.Url;
            newConnection.CreatedBy = 1;
            newConnection.UpdatedBy = null;
            newConnection.UpdatedOn = null;
            newConnection.CreatedOn = DateTime.Now;
            //if (newConnection.AuthenticationType == "S")
            //{
            //    newConnection.CatalogName = dsWizard.ServerName;
            //    newConnection.Password = dsWizard.Password;
            //}
            service.Save(newConnection);

            return 0;

        }

        public int CreateDataConnectionAndSource(SourceDetailViewModel sourceDetail, DataSourceType sourceTypeDetail)
        {
            var service = IoC.Resolve<IDataSourceService>();
            DataConnection newConnection = new DataConnection();
            newConnection.AuthenticationType = sourceDetail.AuthenticationType;
            newConnection.ConnectionName = sourceDetail.ConnectionName;
            newConnection.ConnectionTypeID = sourceDetail.ConnectionTypeID;
            newConnection.HostName = sourceDetail.ServerName;
            newConnection.CatalogName = sourceDetail.InitialCatalog;
            newConnection.CreatedBy = 1;
            newConnection.UpdatedBy = null;
            newConnection.UpdatedOn = null;
            newConnection.CreatedOn = DateTime.Now;
            if (newConnection.AuthenticationType == "S")
            {
                newConnection.UserID = sourceDetail.UserName;
                newConnection.Password = sourceDetail.Password;
            }
            DataSource newSource = new DataSource();
            newSource.DataConnection = newConnection; 
            newSource.SourceName = sourceDetail.SourceName;
            newSource.SourceTypeID = sourceTypeDetail.SourceTypeID;
            newSource.ObjectName = sourceDetail.Object;
            newSource.CreatedBy = 1;
            newSource.CreatedOn = DateTime.Now;
            newSource.UpdatedBy = null;
            newSource.UpdatedOn = null;
            int sortOrder = 1;

            foreach (String s in sourceDetail.Elements)
            {
                DataSourceElement newSourceElement = new DataSourceElement();
                newSourceElement.ElementName = s;
                newSourceElement.ElementType = "DimensionField";
                newSourceElement.ElementDataType = "string";
                newSourceElement.ParentID = null;
                newSourceElement.SortOrder = sortOrder;
                sortOrder = sortOrder + 1;
                newSource.DataSourceElements.Add(newSourceElement);
            }

            foreach (String s in sourceDetail.Measures)
            {
                DataSourceElement newSourceElement = new DataSourceElement();
                newSourceElement.ElementName = s;
                newSourceElement.ElementType = "FactField";
                newSourceElement.ElementDataType = "string";
                newSourceElement.ParentID = null;
                newSourceElement.SortOrder = sortOrder;
                sortOrder = sortOrder + 1;
                newSource.DataSourceElements.Add(newSourceElement);
            }
            service.Save(newSource);

            return 0;


        }

        public int CreateSourceDetails(SourceDetailViewModel sourceDetail, DataConnection dataConnection, DataSourceType sourceTypeDetail)
        {
            var service = IoC.Resolve<IDataSourceService>();
            DataSource newSource = new DataSource();
            newSource.ConnectionID = dataConnection.ConnectionID;
            newSource.SourceName = sourceDetail.SourceName;
            newSource.SourceTypeID = sourceTypeDetail.SourceTypeID;
            newSource.ObjectName = sourceDetail.Object;
            newSource.CreatedBy = 1;
            newSource.CreatedOn = DateTime.Now;
            newSource.UpdatedBy = null;
            newSource.UpdatedOn = null;
            int sortOrder = 1;

            foreach (String s in sourceDetail.Elements)
            {
                DataSourceElement newSourceElement = new DataSourceElement();               
                newSourceElement.ElementName = s;
                newSourceElement.ElementType = "DimensionField";
                newSourceElement.ElementDataType = "string";
                newSourceElement.ParentID = null;
                newSourceElement.SortOrder = sortOrder;
                sortOrder = sortOrder + 1;
                newSource.DataSourceElements.Add(newSourceElement);
            }

            foreach (String s in sourceDetail.Measures)
            {
                DataSourceElement newSourceElement = new DataSourceElement();
                newSourceElement.ElementName = s;
                newSourceElement.ElementType = "FactField";
                newSourceElement.ElementDataType = "string";
                newSourceElement.ParentID = null;
                newSourceElement.SortOrder = sortOrder;
                sortOrder = sortOrder + 1;
                newSource.DataSourceElements.Add(newSourceElement);
            }
            service.Save(newSource);

            return 0;

        }
    }
}