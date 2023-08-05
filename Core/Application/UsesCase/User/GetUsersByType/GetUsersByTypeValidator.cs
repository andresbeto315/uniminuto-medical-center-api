using FluentValidation;

namespace Application.UsesCase.User.GetUsersByType
{
    public class GetUsersByTypeValidator : AbstractValidator<GetUsersByTypeRequest>
    {
        public GetUsersByTypeValidator()
        {
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("El tipo de usuario no puede estar vacío.");
        }
    }
}