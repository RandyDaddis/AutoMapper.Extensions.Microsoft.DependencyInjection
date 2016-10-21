using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.NetCore.WebApp.Areas.Administration.ViewModels
{
    public class SeedDataModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsErrorCondition { get; set; }
        public List<SeedDataResult> Results { get; set; }
    }
}
