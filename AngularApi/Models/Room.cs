using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Room
    {
        [Key]
        public int room_id { get; set; }
        [Required]
        public int location_id { get; set; }
        [Required]
        public string room { get; set; }
        public ICollection<Set> sets { get; set; }
        public Room()
        {
            sets = new List<Set>();
        }
    }
}
