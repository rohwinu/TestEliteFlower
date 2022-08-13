using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace EliteFlower.Web.Models
{
    public class ManufactureOverview
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Name length can't be more than 1000.", MinimumLength = 10)]
        public string Name { get; set; }

        public StringBuilder Validations { get; set; }
    }
}
