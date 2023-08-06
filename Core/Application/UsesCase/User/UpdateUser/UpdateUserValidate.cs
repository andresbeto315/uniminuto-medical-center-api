using FluentValidation;

namespace Application.UsesCase.User.UpdateUser
{
    public class UpdateUserValidate : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidate()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id no puede estar vacío.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre no puede estar vacío.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("La fecha de nacimiento no puede estar vacía.");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("El tipo no puede estar vacío.");
        }
    }
}