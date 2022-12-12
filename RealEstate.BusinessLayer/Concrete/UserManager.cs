using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TDelete(AppUser t)
        {
           _userDal.Delete(t);  
        }

        public AppUser TGetByID(int id)
        {
            return _userDal.GetByID(id);    
        }

        public List<AppUser> TGetList()
        {
            return _userDal.GetList();  
        }

        public void TInsert(AppUser t)
        {
            _userDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t); 
        }
    }
}
