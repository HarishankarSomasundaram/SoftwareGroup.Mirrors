using SoftwareGroup.Mirrors.DataEntity.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core.Repository
{
    public interface IAnalysisGroupRepository
    {
        int Create(AnalysisGroup analysisGroup);
        AnalysisGroup Get(int analysisGroupID);
        List<AnalysisGroup> GetAll();
        void Update(AnalysisGroup analysisGroup);
        void Delete(AnalysisGroup analysisGroup);        
    }
}
