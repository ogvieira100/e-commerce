using E_Commerce.Core.Validation;
using FluentValidation;

namespace E_Commerce.ProductsApi.Application.CreateProducts
{
    public class CreateProductsValidator : AbstractValidator<CreateProductsCommand>
    {

        public CreateProductsValidator()
        {

            RuleFor(pr => pr.Price).SetValidator(new PriceValidation(1, null));

            RuleFor(pr => pr.Description)
                .NotEmpty()
                .Length(3, 2000)
                .WithMessage("Atenção a descrição deve ter entre 3 e 200 caracteres");

            RuleFor(pr => pr.Name)
                 .NotEmpty()
                 .Length(3, 200)
                 .WithMessage("Atenção o titulo deve conter entre 3 e 200 caracteres");

            RuleFor(pr => pr.Image)
                .Must(x => x == null || (x.Length >= 3 && x.Length <= 200))
                .WithMessage("Atenção a imagem deve ter entre 3 e 200 caracteres")  
                ;
              
        }
    }
}
