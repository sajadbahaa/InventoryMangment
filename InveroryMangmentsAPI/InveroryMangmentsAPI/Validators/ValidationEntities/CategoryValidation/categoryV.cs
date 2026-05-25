using DTOsLayer.Categories.Read;
using DTOsLayer.Categories.Write;
using FluentValidation;
using InveroryMangmentsAPI.Validators.ValidationExtensions;

namespace InveroryMangmentsAPI.Validators.ValidationEntities.CategoryValidation
{
    public class categoryV : AbstractValidator<AddCategoryDto>
    {
        public categoryV()
        {
                 RuleFor(item => item.Name)
                .RequiredString()
                .MaxLength(70)
                .MinLength(6);  
        }
    }

    public class CategoryUpdate:AbstractValidator<UpdateCategoryDto>
    {
        public CategoryUpdate()
        {
            RuleFor(item => item.Id).ValidId();
            RuleFor(item => item.Name)
                            .RequiredString()
                            .MaxLength(70)
                            .MinLength(6);

        }
    }

    }

