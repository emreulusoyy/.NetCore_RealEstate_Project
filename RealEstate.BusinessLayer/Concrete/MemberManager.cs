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
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void TDelete(Member t)
        {
            _memberDal.Delete(t);
        }

        public Member TGetByID(int id)
        {
            return _memberDal.GetByID(id);
        }

        public List<Member> TGetList()
        {
            return _memberDal.GetList();
        }

        public void TInsert(Member t)
        {
            _memberDal.Insert(t);
        }

        public void TUpdate(Member t)
        {
            _memberDal.Update(t);
        }
    }
}
