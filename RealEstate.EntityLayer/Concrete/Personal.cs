using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.EntityLayer.Concrete
{
    public class Personal
{
        [Key]
        public int ID { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int Progress { get; set; }
        public string Amount { get; set; }

        public string Dates { get; set; }   
    
    }
}
