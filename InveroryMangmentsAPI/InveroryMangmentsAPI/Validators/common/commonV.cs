using DTOsLayer.Common.Request;
using FluentValidation;
using InveroryMangmentsAPI.Validators.ValidationExtensions;

namespace InveroryMangmentsAPI.Validators.common
{
    public class commonVID:AbstractValidator<ApiRequestID>
    {
        public commonVID()
        {
            RuleFor(item => item.Id).ValidId();
        }
    }

    public class commonVString : AbstractValidator<ApiRequestString>
    {
        public commonVString()
        {
            RuleFor(item => item.Value).RequiredStringValidate().MinLength(3).MaxLength(70);
        }
    }
}
