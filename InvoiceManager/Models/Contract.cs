using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(Order = 3)]
        public string Description { get; set; }

        [Column(Order = 4)]
        public double Price { get; set; }

        [Column(Order = 5)]
        public bool Hide { get; set; }
    }
}
