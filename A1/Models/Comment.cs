using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A1.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Time { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public string Name { get; set; }

        public int IP { get; set; }


    }
}
