using System.Collections.Generic;

namespace AspNetCore.NetCore.WebApp.Areas.Administration.ViewModels
{
    public class SeedDataModel
    {
        public string Password { get; set; }
        public bool IsErrorCondition { get; set; }
        public List<SeedDataResult> Results { get; set; }
    }
}
