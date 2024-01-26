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
    public class YemekValidator : AbstractValidator<Yemek>
    {
        public YemekValidator()
        {
            RuleFor(x => x.YemekName).NotEmpty().WithMessage("User name Boş Olamaz");



        }

    }
}
