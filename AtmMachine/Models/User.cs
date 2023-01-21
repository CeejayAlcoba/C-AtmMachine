using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AtmMachine.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        [NotMapped]
        public string password { get; set; }
        [JsonIgnore]
        public byte[] salted { get; set; }
        [JsonIgnore]
        public string hashed { get; set; }
        [ForeignKey("money")]
        public int moneyId { get; set; }
        public Money money { get; set; }
    }
}
