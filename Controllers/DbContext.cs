using Microsoft.EntityFrameworkCore;
using Historical__Facts_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    [Table("HistoricalFacts")]
    public partial class HistoricalFact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        
        public string Fact { get; set; }
    }
}
