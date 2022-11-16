using FluentValidation;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.ValidationRules
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.MemberName).NotEmpty().WithMessage("lütfen ad alanını boş geçmeyin!");
            RuleFor(x => x.MemberSurname).NotEmpty().WithMessage("lütfen soyad alanını boş geçmeyin!");
            RuleFor(x => x.MemberName).MinimumLength(3).WithMessage("lütfen en az 3 karakter veri girişi yapın!");
            RuleFor(x => x.MemberName).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter veri girişi yapın!");
        }
    }
}
