using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Annotations
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public string Date { get; set; }
        public string Description { get; set; }

        [Required]
        public Contact Contact { get; set; }
    }
}
