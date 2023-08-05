using FluentValidation;

namespace Application.UsesCase.MedicalAppointment.RegisterMedicalAppointment
{
    public class RegisterMedicalAppointmentValidator : AbstractValidator<RegisterMedicalAppointmentRequest>
    {
        public RegisterMedicalAppointmentValidator()
        {
            RuleFor(x => x.UserDoctorId).NotEmpty().WithMessage("El Id del doctor no puede estar vacío.");
            RuleFor(x => x.UserDoctorId).NotEmpty().WithMessage("El Id del paciente no puede estar vacío.");
            RuleFor(x => x.StateId).NotEmpty().WithMessage("El Id del estado no puede estar vacío.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("La fecha no puede estar vacío.");
        }
    }
}