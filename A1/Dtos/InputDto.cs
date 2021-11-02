using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace A1.Dtos
{
    public class StaffInputDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Research { get; set; }
    }

    public class ProductInputDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }

    }
    public class commentInputDto
    {
        

        
        
        public string Comment { get; set; }
        
        public string Name { get; set; }

        
    }


}
