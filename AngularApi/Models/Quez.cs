using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Quez
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ownerid { get; set; }
      
    }
}
