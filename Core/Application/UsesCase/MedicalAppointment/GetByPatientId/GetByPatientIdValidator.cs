using FluentValidation;

namespace Application.UsesCase.MedicalAppointment.GetByPatientId
{
    internal class GetByPatientIdValidator : AbstractValidator<GetByPatientIdRequest>
    {
        public GetByPatientIdValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty().WithMessage("El Id del paciente no puede estar vacío.");
        }
    }
}