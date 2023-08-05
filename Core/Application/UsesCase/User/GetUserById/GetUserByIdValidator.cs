using FluentValidation;

namespace Application.UsesCase.User.GetUserById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id del usuario no puede estar vacío.");
        }
    }
}