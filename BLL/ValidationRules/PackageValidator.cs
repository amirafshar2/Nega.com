using BE;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
    public class PackageValidator : AbstractValidator<Package>
    {
        public PackageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا نام پاکت را وارد کنید");
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا سرتیتر پاکت را وارد کنید ");
            RuleFor(x => x.Price).NotEmpty().WithMessage("لطفا قیمت پاکت را وارد کنید");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("لطفا عکس پاکت را وارد کنید");
            RuleFor(x => x.Content).NotEmpty().WithMessage("لطفا توضیحات پاکت را وارد کنید");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("کمترین تعداد حرف مورد قبول 20حرف می باشد");

        }
    }
}
