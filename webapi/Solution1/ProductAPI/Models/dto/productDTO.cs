using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.dto
{
    public class productDTO

    {
        public productDTO()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
      
        public double Price { get; set; }

        public DateTime CreationDate { get; set; }

        public double Rating { get; set; }
    }
}

