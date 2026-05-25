using FluentValidation;

namespace InveroryMangmentsAPI.Validators.ValidationExtensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> RequiredString<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty().WithMessage("Field is required.")
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Field cannot be empty or whitespace.");
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
                .WithMessage("Id must be greater than 0.");
        }
        public static IRuleBuilderOptions<T, short> ValidId<T>(
           this IRuleBuilder<T, short> rule)
        {
            return rule
                .GreaterThan((short)0)
                .WithMessage("Id must be greater than 0.");
        }

    }
}
