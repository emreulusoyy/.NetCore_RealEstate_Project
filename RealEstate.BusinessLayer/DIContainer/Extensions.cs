using Microsoft.Extensions.DependencyInjection;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.Concrete;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services) //this kesinlikle eklenmeli, startup görmez yoksa
        {

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IMemberService, MemberManager>();
            services.AddScoped<IMemberDal, EfMemberDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();


        }
    }
}
