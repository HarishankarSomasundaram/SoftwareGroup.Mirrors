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
    public class AnalysisRepository:IAnalysisRepository
    {
        public int Create(DataEntity.Analysis.Analysis analysis)
        { 
            var newAnalysis = new Analysis
            {
                AnalysisName = analysis.AnalysisName,
                AnalysisDescription = analysis.AnalysisDescription,
                AnalysisGroupID = analysis.AnalysisGroupID,
                AnalysisLayoutData = analysis.AnalysisLayoutData
            };
            using (var ctx = new MirrorsEntities())
            {          
                var analyses = ctx.Analyses;
                analyses.Add(newAnalysis);
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
            return newAnalysis.AnalysisID;
        }

     
        public DataEntity.Analysis.Analysis Get(int analysisID) 
        {
            DataEntity.Analysis.Analysis analysisEO = null;
            using (var ctx = new MirrorsEntities())
            {
                var analysisEFO = ctx.Analyses.Where(ag => ag.AnalysisID == analysisID).FirstOrDefault();
                analysisEO = new DataEntity.Analysis.Analysis { 
                    AnalysisID = analysisEFO.AnalysisID,
                    AnalysisName = analysisEFO.AnalysisName,
                    AnalysisDescription = analysisEFO.AnalysisDescription,
                    AnalysisLayoutData = analysisEFO.AnalysisLayoutData,
                    AnalysisGroupID = analysisEFO.AnalysisGroupID
                };
               
            }
            return analysisEO;
        }

        public List<DataEntity.Analysis.Analysis> GetAll()
        {
            List<DataEntity.Analysis.Analysis> analysesEO = new List<DataEntity.Analysis.Analysis>();

            using (var ctx = new MirrorsEntities())
            {
                var analysesEFO = ctx.Analyses.ToList();
                //TODO: foreach should be replaced
                foreach (var analysisEFO in analysesEFO)
                {
                    DataEntity.Analysis.Analysis analysisEO = new DataEntity.Analysis.Analysis
                    {
                        AnalysisID = analysisEFO.AnalysisID,
                        AnalysisName = analysisEFO.AnalysisName,
                        AnalysisDescription = analysisEFO.AnalysisDescription,
                        AnalysisLayoutData = analysisEFO.AnalysisLayoutData,
                        AnalysisGroupID = analysisEFO.AnalysisGroupID
                    };
                    analysesEO.Add(analysisEO);
                }
            }
            return analysesEO;
        }

        public void Update(DataEntity.Analysis.Analysis analysis)
        {
            DataEntity.Analysis.Analysis analysisEO = analysis;
            using (var ctx = new MirrorsEntities())
            {
                var analysisEFO = ctx.Analyses.Where(ag => ag.AnalysisID == analysisEO.AnalysisID).FirstOrDefault();
                analysisEFO.AnalysisName = analysisEO.AnalysisName;
                analysisEFO.AnalysisDescription = analysisEO.AnalysisDescription;
                analysisEFO.AnalysisGroupID = analysisEO.AnalysisGroupID;
                analysisEFO.AnalysisLayoutData = analysisEO.AnalysisLayoutData;

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

        public void Delete(DataEntity.Analysis.Analysis analysis)
        {
            DataEntity.Analysis.Analysis analysisEO = analysis;
            using (var ctx = new MirrorsEntities())
            {
                var analysisEFO = ctx.Analyses.Where(ag => ag.AnalysisID == analysisEO.AnalysisID).FirstOrDefault();
                ctx.Analyses.Remove(analysisEFO);
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

        public void SaveAnalysisLayoutData(int analysisID, string layoutData)
        {            
            using (var ctx = new MirrorsEntities())
            {
                var analysisEFO = ctx.Analyses.Where(ag => ag.AnalysisID == analysisID).FirstOrDefault();
                analysisEFO.AnalysisLayoutData = layoutData;

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
