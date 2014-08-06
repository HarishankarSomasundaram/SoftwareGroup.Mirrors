using SoftwareGroup.Mirrors.DataEntity.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core.Service.Analysis
{
    public interface IWidgetTypeService
    {
        List<WidgetType> GetAll();
        WidgetType Get(int WidgetTypeID);
    }
}
