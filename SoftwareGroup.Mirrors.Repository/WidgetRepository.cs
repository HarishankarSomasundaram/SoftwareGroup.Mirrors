using SoftwareGroup.Mirrors.Core;
using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Repository
{
    public class WidgetRepository: IWidgetRepository
    {
        public int Create(DataEntity.Analysis.Widget widget)
        {
            var newWidget = new Widget
            {
                AnalysisID = widget.AnalysisID,
                WidgetTypeID = widget.WidgetTypeID,
                WidgetData = widget.WidgetData,
                WidgetUID = widget.UID,
                WidgetLayoutData = widget.WidgetLayoutData
            };

            using (var ctx = new MirrorsEntities())
            {
               
                var widgets = ctx.Widgets;
                widgets.Add(newWidget);
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
            return newWidget.WidgetID;
        }

        public DataEntity.Analysis.Widget Get(int widgetID)
        {
            DataEntity.Analysis.Widget widgetEO = null;
            using (var ctx = new MirrorsEntities())
            {
                var widgetEFO = ctx.Widgets.Where(w => w.WidgetID== widgetID).FirstOrDefault();
                widgetEO= new DataEntity.Analysis.Widget
                {
                   WidgetID = widgetEFO.WidgetID,
                   AnalysisID = widgetEFO.AnalysisID,
                   WidgetTypeID = widgetEFO.WidgetTypeID,
                   WidgetData = widgetEFO.WidgetData,
                   UID = widgetEFO.WidgetUID,
                   WidgetLayoutData = widgetEFO.WidgetLayoutData
                };
            }
            return widgetEO;
        }

        public DataEntity.Analysis.Widget Get(string widgetUID)
        {
            DataEntity.Analysis.Widget widgetEO = null;
            using (var ctx = new MirrorsEntities())
            {
                var widgetEFO = ctx.Widgets.Where(w => w.WidgetUID == widgetUID).FirstOrDefault();
                widgetEO = new DataEntity.Analysis.Widget
                {
                    WidgetID = widgetEFO.WidgetID,
                    AnalysisID = widgetEFO.AnalysisID,
                    WidgetTypeID = widgetEFO.WidgetTypeID,
                    WidgetData = widgetEFO.WidgetData,
                    UID = widgetEFO.WidgetUID
                };
            }
            return widgetEO;
        }

        public List<DataEntity.Analysis.Widget> GetAll()
        {
            List<DataEntity.Analysis.Widget> widgetsEO = new List<DataEntity.Analysis.Widget>();

            using (var ctx = new MirrorsEntities())
            {
                var widgetsEFO = ctx.Widgets.ToList();
                //TODO: foreach should be replaced
                foreach (var widgetEFO in widgetsEFO)
                {
                    DataEntity.Analysis.Widget widgetEO = new DataEntity.Analysis.Widget
                    {
                        WidgetID = widgetEFO.WidgetID,
                        AnalysisID = widgetEFO.AnalysisID,
                        WidgetTypeID = widgetEFO.WidgetTypeID,
                        WidgetData = widgetEFO.WidgetData,
                        UID = widgetEFO.WidgetUID,
                        WidgetLayoutData = widgetEFO.WidgetLayoutData
                    };
                    widgetsEO.Add(widgetEO);
                }
            }
            return widgetsEO;
        }

        public List<DataEntity.Analysis.Widget> GetWidgets(int analysisID)
        {
            List<DataEntity.Analysis.Widget> widgetsEO = new List<DataEntity.Analysis.Widget>();

            using (var ctx = new MirrorsEntities())
            {
                var widgetsEFO = ctx.Widgets.Where(w=>w.AnalysisID == analysisID).ToList();
                //TODO: foreach should be replaced
                foreach (var widgetEFO in widgetsEFO)
                {
                    DataEntity.Analysis.Widget widgetEO = new DataEntity.Analysis.Widget
                    {
                        WidgetID = widgetEFO.WidgetID,
                        AnalysisID = widgetEFO.AnalysisID,
                        WidgetTypeID = widgetEFO.WidgetTypeID,
                        WidgetData = widgetEFO.WidgetData,
                        UID = widgetEFO.WidgetUID,
                        WidgetLayoutData = widgetEFO.WidgetLayoutData
                    };
                    widgetsEO.Add(widgetEO);
                }
            }
            return widgetsEO;
        }

        public void Update(DataEntity.Analysis.Widget widget)
        {
            DataEntity.Analysis.Widget widgetEO = widget;
            using (var ctx = new MirrorsEntities())
            {
                var widgetEFO = ctx.Widgets.Where(w => w.WidgetID== widgetEO.WidgetID).FirstOrDefault();
                widgetEFO.AnalysisID = widgetEO.AnalysisID;
                widgetEFO.WidgetTypeID = widgetEO.WidgetTypeID;
                widgetEFO.WidgetData = widgetEO.WidgetData;
                widgetEFO.WidgetUID = widgetEO.UID;
                widgetEFO.WidgetLayoutData = widget.WidgetLayoutData;
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
        }

        public void Delete(string widgetUID)
        {
            using (var ctx = new MirrorsEntities())
            {
                var widgetEFO = ctx.Widgets.Where(w => w.WidgetUID == widgetUID).FirstOrDefault();
                ctx.Widgets.Remove(widgetEFO);
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
        }

        public void Delete(int widgetID)
        {            
            using (var ctx = new MirrorsEntities())
            {
                var widgetEFO = ctx.Widgets.Where(w => w.WidgetID== widgetID).FirstOrDefault();
                ctx.Widgets.Remove(widgetEFO);
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
        }
    }
}
