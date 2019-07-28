using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Set
    {
        [Key]
        public int set_id { get; set; }
        public int room_id { get; set; }
        [ForeignKey("room_id")]
        public virtual Room rom { get; set; }
        public string usagetype { get; set; }
        public string username { get; set; }
    }
}
