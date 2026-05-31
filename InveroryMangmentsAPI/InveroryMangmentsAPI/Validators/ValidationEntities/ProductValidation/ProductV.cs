using DTOsLayer.Products.Write;
using FluentValidation;
using InveroryMangmentsAPI.Validators.ValidationExtensions;

namespace InveroryMangmentsAPI.Validators.ValidationEntities.ProductValidation
{
    public class AddProductV : AbstractValidator<AddProductDto>
    {
        public AddProductV()
        {
            RuleFor(item => item.ProductName).RequiredStringValidate().MaxLength(70).MinLength(3);
            RuleFor(item => item.PurchasePrice).decimalValidate();
            RuleFor(item => item.SalePrice).decimalValidate();
            RuleFor(item=>item).Must(item=>item.SalePrice>item.PurchasePrice)
            .WithMessage("Sale price must be greater than purchase price.");
            RuleFor(item => item.CategoryId).ValidId();
        }
    }
    public class UpdateProductV : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductV()
        {
            RuleFor(item => item.ProductId).ValidId();
            RuleFor(item => item.ProductName).RequiredStringValidate().MaxLength(70).MinLength(3);
            RuleFor(item => item.PurchasePrice).decimalValidate();
            RuleFor(item => item.SalePrice).decimalValidate();
            RuleFor(item => item).Must(item =>item.SalePrice > item.PurchasePrice)
            .WithMessage("Sale price must be greater than purchase p rice.");
            RuleFor(item => item.CategoryId).ValidId();
        }
    }
}
