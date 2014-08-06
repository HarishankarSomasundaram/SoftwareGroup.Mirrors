using SoftwareGroup.Mirrors.DataEntity.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core.Repository
{
    public interface IWidgetRepository
    {
        int Create(Widget widget);
        Widget Get(int widgetID);
        Widget Get(string widgetUID);
        List<Widget> GetAll();
        List<Widget> GetWidgets(int analysisID);
        void Update(Widget widget);
        void Delete(int widgetID);
        void Delete(string widgetUID);   
    }
}
