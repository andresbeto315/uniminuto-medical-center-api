using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.UpdateMedicalAppointment
{
    public class UpdateMedicalAppointmentCommand : IRequestHandler<UpdateMedicalAppointmentRequest, ResponseBase<UpdateMedicalAppointmentResponse>>
    {
        private readonly IMedicalAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateMedicalAppointmentCommand(IMedicalAppointmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<UpdateMedicalAppointmentResponse>> Handle(UpdateMedicalAppointmentRequest request, CancellationToken cancellationToken)
        {
            var newMedical = new MedicalAppointmentEntity();
            this._mapper.Map<UpdateMedicalAppointmentRequest, MedicalAppointmentEntity>(request, newMedical);
            var id = this._repository.Update(newMedical);

            var response = new ResponseBase<UpdateMedicalAppointmentResponse>
            {
                Data = new UpdateMedicalAppointmentResponse
                {
                    Id = id
                },
                IDCodigo = 0,
                Message = "Actualizada cita medica satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}