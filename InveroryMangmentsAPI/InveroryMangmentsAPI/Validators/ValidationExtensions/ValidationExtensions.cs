using FluentValidation;
using Microsoft.CodeAnalysis;

namespace InveroryMangmentsAPI.Validators.ValidationExtensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> RequiredStringValidate<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .When(item => item != null)
                .WithMessage("Field is required  / not accept White Space.");
        }
        public static IRuleBuilderOptions<T, string?> OptionalStringValidate<T>(
           this IRuleBuilder<T, string?> rule)
        {
            return rule
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .When(item => item != null)
                .WithMessage("Field is required  / not accept White Space.");
        }
        public static IRuleBuilderOptions<T, string> MinLength<T>(
            this IRuleBuilder<T, string> rule, int min)
        {
            return rule
                .MinimumLength(min)
                .WithMessage($"Field must be at least {min} characters.");
        }

        public static IRuleBuilderOptions<T, string> MaxLength<T>(
            this IRuleBuilder<T, string> rule, int max)
        {
            return rule
                .MaximumLength(max)
                .WithMessage($"Field must not exceed {max} characters.");
        }

        public static IRuleBuilderOptions<T, int> ValidId<T>(
           this IRuleBuilder<T, int> rule)
        {
            return rule
                .GreaterThan(0)
                .WithMessage("Field must be greater than 0.");
        }
        public static IRuleBuilderOptions<T, int?> ValidId<T>(
           this IRuleBuilder<T, int?> rule)
        {
            return rule
                .GreaterThan(0)
                .When(item => item != null)
                .WithMessage("Field must be greater than 0.");
        }
        public static IRuleBuilderOptions<T, short> ValidId<T>(
           this IRuleBuilder<T, short> rule)
        {
            return rule
                .GreaterThan((short)0)
                .When(item => item != null)
                .WithMessage("Field must be greater than 0.");
        }
        public static IRuleBuilderOptions<T, short?> ValidId<T>(
           this IRuleBuilder<T, short?> rule)
        {
            return rule
                .GreaterThan((short)0)
                .When(item => item != null)
                .WithMessage("Field must be greater than 0.");
        }
        public static IRuleBuilderOptions<T, decimal?> decimalValidate<T>(
          this IRuleBuilder<T, decimal?> rule)
        {
            return
            rule.
            GreaterThan(0m).When(item => item != null)
            .WithMessage("Value must be greater than 0")
                .PrecisionScale(18,2,true).WithMessage("Field Value must not exceed 18 digits with 2 decimal places");
        }
        public static IRuleBuilderOptions<T, decimal> decimalValidate<T>(
          this IRuleBuilder<T, decimal> rule)
        {
            return
            rule.
            GreaterThan(0m)
            .WithMessage("Value must be greater than 0")
                .PrecisionScale(18, 2, true).WithMessage("Field Value must not exceed 18 digits with 2 decimal places");
        }


    }
}
