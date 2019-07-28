using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Locatio
    {
        [Key]
        public int Location_id { get; set; }
        [Required]
        public string location { get; set; }



    }
}
