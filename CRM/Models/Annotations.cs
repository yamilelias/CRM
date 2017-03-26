using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class Annotations
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }
    
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Contact Owner")]
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]

        public Contact Contact { get; set; }
    }
}
