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
            RuleFor(x => x.Name).NotEmpty().WithMessage("yazar adı boş geçinemez");
            RuleFor()
        }
    }
}
