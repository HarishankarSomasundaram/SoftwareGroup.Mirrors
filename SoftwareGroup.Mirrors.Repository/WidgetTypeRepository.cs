using SoftwareGroup.Mirrors.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Repository
{
    public class WidgetTypeRepository :IWidgetTypeRepository
    {
        public List<DataEntity.Analysis.WidgetType> GetAll()
        {
            using (var ctx = new MirrorsEntities())
            {
                var results = ctx.WidgetTypes.ToList();
                var widgetTypes = new List<DataEntity.Analysis.WidgetType>();
                foreach (var item in results)
                {
                    DataEntity.Analysis.WidgetType widgetType = new DataEntity.Analysis.WidgetType();
                    widgetType.WidgetTypeID = item.WidgetTypeID;
                    widgetType.WidgetTypeName = item.WidgetTypeName;
                    widgetType.WidgetTypeData = item.WidgetTypeData;
                    widgetTypes.Add(widgetType);
                }
                return widgetTypes;
            }
        }



        public DataEntity.Analysis.WidgetType Get(int WidgetTypeID)
        {
            DataEntity.Analysis.WidgetType widgetTypeEO = null;
            using (var ctx = new MirrorsEntities())
            {
                var widgetTypeEFO = ctx.WidgetTypes.Where(wt => wt.WidgetTypeID == WidgetTypeID).FirstOrDefault();
                widgetTypeEO = new DataEntity.Analysis.WidgetType
                {
                    WidgetTypeData = widgetTypeEFO.WidgetTypeData,
                    WidgetTypeName = widgetTypeEFO.WidgetTypeName
                };

            }
            return widgetTypeEO;
        }
    }
}
