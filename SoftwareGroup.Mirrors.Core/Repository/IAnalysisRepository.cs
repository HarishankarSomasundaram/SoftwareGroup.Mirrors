using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoftwareGroup.Mirrors.DataEntity.Analysis;

namespace SoftwareGroup.Mirrors.Core.Repository
{
    public interface IAnalysisRepository
    {
        int Create(Analysis analysis);
        Analysis Get(int analysisID);
        List<Analysis> GetAll();
        void Update(Analysis analysis);
        void Delete(Analysis analysis);
        void SaveAnalysisLayoutData(int analysisID, string layoutData);
    }
}
