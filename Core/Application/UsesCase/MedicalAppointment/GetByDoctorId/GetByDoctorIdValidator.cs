using FluentValidation;

namespace Application.UsesCase.MedicalAppointment.GetByDoctorId
{
    internal class GetByDoctorIdValidator : AbstractValidator<GetByDoctorIdRequest>
    {
        public GetByDoctorIdValidator()
        {
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("El Id del doctor no puede estar vacío.");
        }
    }
}