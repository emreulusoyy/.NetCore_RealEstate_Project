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
    public class PersonalManager : IPersonalService
    {
        IPersonalDal _PersonalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            _PersonalDal = personalDal;
        }

        public void TDelete(Personal t)
        {
            throw new NotImplementedException();
        }

        public Personal TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Personal> TGetList()
        {
            return _PersonalDal.GetList();
        }

        public void TInsert(Personal t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Personal t)
        {
            throw new NotImplementedException();
        }
    }
}
