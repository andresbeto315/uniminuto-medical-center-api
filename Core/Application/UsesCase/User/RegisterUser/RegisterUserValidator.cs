using FluentValidation;

namespace Application.UsesCase.User.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre no puede estar vacío.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("La fecha de nacimiento no puede estar vacía.");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("El tipo no puede estar vacío.");
        }
    }
}