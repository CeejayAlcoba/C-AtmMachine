using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Models
{
    public class Money
    {
        [Key]
        public int moneyId { get; set; }
        public float money { get; set; }
    }
}
