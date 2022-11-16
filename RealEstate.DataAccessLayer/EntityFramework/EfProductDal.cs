using Microsoft.EntityFrameworkCore;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.DataAccessLayer.Repository;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        //Context c = new Context();
        public List<Product> GetProductByCategory()
        {
            using (var context = new Context())
            {
                return context.Products.Include(x => x.Category).ToList();
            }
        }
    }
}
