using FluentValidation;

namespace Application.UsesCase.MedicalAppointment.UpdateMedicalAppointment
{
    internal class UpdateMedicalAppointmentValidator : AbstractValidator<UpdateMedicalAppointmentRequest>
    {
        public UpdateMedicalAppointmentValidator()
        {
            RuleFor(x => x.UserDoctorId).NotEmpty().WithMessage("El Id del doctor no puede estar vacío.");
            RuleFor(x => x.UserDoctorId).NotEmpty().WithMessage("El Id del paciente no puede estar vacío.");
            RuleFor(x => x.StateId).NotEmpty().WithMessage("El Id del estado no puede estar vacío.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("La fecha no puede estar vacío.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("El id no puede estar vacío.");
        }
    }
}