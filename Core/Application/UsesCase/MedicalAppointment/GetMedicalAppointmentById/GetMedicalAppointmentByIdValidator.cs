using FluentValidation;

namespace Application.UsesCase.MedicalAppointment.GetMedicalAppointmentById
{
    public class GetMedicalAppointmentByIdValidator : AbstractValidator<GetMedicalAppointmentByIdRequest>
    {
        public GetMedicalAppointmentByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id de la cita medica no puede estar vacío.");
        }
    }
}