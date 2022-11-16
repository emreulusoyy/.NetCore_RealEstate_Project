using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductMail { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
