using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class RecipeModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description")]
        public string Description { get; set; }

        [Required]
        public List<string> Ingredients { get; set; }

        [Required]
        public List<string> Steps { get; set; }
    }
}
