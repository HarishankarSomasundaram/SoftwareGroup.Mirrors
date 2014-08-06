using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.Core.Service.Analysis;
using SoftwareGroup.Mirrors.DataEntity.Analysis;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Service.Analysis
{
    public class WidgetTypeService : IWidgetTypeService
    {

        public List<DataEntity.Analysis.WidgetType> GetAll()
        {
            var repository = IoC.Resolve<IWidgetTypeRepository>();
            List<WidgetType> widgetTypes = repository.GetAll();
            return widgetTypes;
        }


        public WidgetType Get(int WidgetTypeID)
        {
            var repository = IoC.Resolve<IWidgetTypeRepository>();
            WidgetType widgetType = repository.Get(WidgetTypeID);
            return widgetType;
        }
    }
}
