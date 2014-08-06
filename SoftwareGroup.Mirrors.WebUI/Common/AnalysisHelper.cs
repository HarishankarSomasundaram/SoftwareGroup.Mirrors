using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Common
{
    public static class AnalysisHelper
    {
        public static void SaveAnalysisLayoutData(int analysisID, string layoutData)
        {
            var analysisRepository = IoC.Resolve<IAnalysisRepository>();
            analysisRepository.SaveAnalysisLayoutData(analysisID, layoutData);
        }
    }
}