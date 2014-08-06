using SoftwareGroup.Mirrors.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.Analysis
{
    public class Widget
    {
        private string widgetLayoutData;
        private WidgetLayoutData layoutData;
        public int WidgetID;
        public int AnalysisID;
        public int WidgetTypeID;
        public string WidgetData;
        public string UID;
        public string WidgetLayoutData
        {
            get
            {
                if (widgetLayoutData == null)
                    widgetLayoutData = JsonHelper.JsonSerializer<WidgetLayoutData>(LayoutData);

                return widgetLayoutData;
            }
            set{
                widgetLayoutData = value;

                if (widgetLayoutData != null)
                {
                    LayoutData = JsonHelper.JsonDeserialize<WidgetLayoutData>(widgetLayoutData);
                }
             }
        }
        public WidgetLayoutData LayoutData
        {
            get
            { 
                if(layoutData==null)
                    layoutData = new WidgetLayoutData() { VisibleIndex = 0, OwnerZoneUID = "" };

                return layoutData;
            }
            set
            {
                layoutData = value;
            }
        }
    }    

    [Serializable()]
    public class WidgetLayoutData
    {
        public int VisibleIndex { get; set; }
        public string OwnerZoneUID{ get; set; }

        public byte[] ToByteArray()
        {
            byte[] bytes;
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, new WidgetLayoutData { VisibleIndex=this.VisibleIndex, OwnerZoneUID=this.OwnerZoneUID});
            bytes = stream.ToArray();
            stream.Close();

            return bytes;
        }
    }
}
