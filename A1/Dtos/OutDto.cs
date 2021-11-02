using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;

namespace A1.Dtos
{
    public class StaffOutDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Title { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public string Url { get; set; }

        public string Research { get; set; }
    }

    public class ProductOutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public string Price { get; set; }
    }
    public class commentOutDto
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public string Comments { get; set; }

        public string Name { get; set; }

        public string  IP { get; set; }
    }
    public class commentOutDto1
    {
       
        public string Comments { get; set; }

        public string Name { get; set; }

        
    }
    public class StaffCardOut
    {
        public string Name { get; set; }
        public int Uid { get; set; }
        public string Photo { get; set; }
        public string Categories { get; set; }
        public string PhotoType { get; set; }
    }

}
