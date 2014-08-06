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
    public class AnalysisGroupRepository: IAnalysisGroupRepository
    {
        public int Create(DataEntity.Analysis.AnalysisGroup analysisGroup)
        {
            if (!IsInserterd(analysisGroup))
            {
                var newAnalysisGroup = new AnalysisGroup
                {
                    AnalysisGroupName = analysisGroup.AnalysisGroupName
                };
                using (var ctx = new MirrorsEntities())
                {

                    var analysisGroups = ctx.AnalysisGroups;
                    analysisGroups.Add(newAnalysisGroup);
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
                return newAnalysisGroup.AnalysisGroupID;
            }
            else
            {
                return 0;
            }
          
        }

        public DataEntity.Analysis.AnalysisGroup Get(int analysisGroupID)
        {
            DataEntity.Analysis.AnalysisGroup analysisGroupEO = null;
            using (var ctx = new MirrorsEntities())
            {
                var analysisGroupEFO = ctx.AnalysisGroups.Where(ag => ag.AnalysisGroupID == analysisGroupID).FirstOrDefault();
                analysisGroupEO = new DataEntity.Analysis.AnalysisGroup {
                    AnalysisGroupID = analysisGroupEFO.AnalysisGroupID,
                    AnalysisGroupName = analysisGroupEFO.AnalysisGroupName
                };
            }
            return analysisGroupEO;
        }

        public List<DataEntity.Analysis.AnalysisGroup> GetAll()
        {
            List<DataEntity.Analysis.AnalysisGroup> analysisGroupsEO = new List<DataEntity.Analysis.AnalysisGroup>();

            using (var ctx = new MirrorsEntities())
            {
                var analysisGroupsEFO = ctx.AnalysisGroups.ToList();
                //TODO: foreach should be replaced
                foreach (var analysisGroupEFO in analysisGroupsEFO)
                {
                    DataEntity.Analysis.AnalysisGroup analysisGroupEO = new DataEntity.Analysis.AnalysisGroup { 
                        AnalysisGroupID = analysisGroupEFO.AnalysisGroupID,
                        AnalysisGroupName = analysisGroupEFO.AnalysisGroupName
                    };
                    analysisGroupsEO.Add(analysisGroupEO);
                }
            }
            return analysisGroupsEO;
        }

        public void Update(DataEntity.Analysis.AnalysisGroup analysisGroup)
        {
            DataEntity.Analysis.AnalysisGroup analysisGroupEO = analysisGroup;
            using (var ctx = new MirrorsEntities())
            {
                var analysisGroupEFO = ctx.AnalysisGroups.Where(ag => ag.AnalysisGroupID == analysisGroupEO.AnalysisGroupID).FirstOrDefault();
                analysisGroupEFO.AnalysisGroupName = analysisGroupEO.AnalysisGroupName;
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

        public void Delete(DataEntity.Analysis.AnalysisGroup analysisGroup)
        {
            DataEntity.Analysis.AnalysisGroup analysisGroupEO = analysisGroup;
            using (var ctx = new MirrorsEntities())
            {
                var analysisGroupEFO = ctx.AnalysisGroups.Where(ag => ag.AnalysisGroupID == analysisGroupEO.AnalysisGroupID).FirstOrDefault();
                ctx.AnalysisGroups.Remove(analysisGroupEFO);

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

        public bool IsInserterd(DataEntity.Analysis.AnalysisGroup analysisGroup)
        {
            using (var ctx = new MirrorsEntities())
            {

                try
                {
                    return ctx.AnalysisGroups.Where(a => (a.AnalysisGroupName.ToLower() == analysisGroup.AnalysisGroupName.ToLower())).Any();
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
