using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Validators;

namespace BusinessLayer.ValidationRulers_fluentValidation
{
    public class TatliValidator : AbstractValidator<Tatli>
    {
        public TatliValidator()
        {
            RuleFor(x => x.TatliName).NotEmpty().WithMessage("User name Boş Olamaz");



        }

    }
}
