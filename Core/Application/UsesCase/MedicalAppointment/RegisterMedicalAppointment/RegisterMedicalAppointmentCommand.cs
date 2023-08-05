using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.RegisterMedicalAppointment
{
    internal class RegisterMedicalAppointmentCommand : IRequestHandler<RegisterMedicalAppointmentRequest, ResponseBase<RegisterMedicalAppointmentResponse>>
    {
        private readonly IMedicalAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public RegisterMedicalAppointmentCommand(IMedicalAppointmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<RegisterMedicalAppointmentResponse>> Handle(RegisterMedicalAppointmentRequest request, CancellationToken cancellationToken)
        {
            var newMedical = new MedicalAppointmentEntity();
            this._mapper.Map<RegisterMedicalAppointmentRequest, MedicalAppointmentEntity>(request, newMedical);
            var id = this._repository.Register(newMedical);

            var response = new ResponseBase<RegisterMedicalAppointmentResponse>
            {
                Data = new RegisterMedicalAppointmentResponse
                {
                    Id = id
                },
                IDCodigo = 0,
                Message = "Creada cita medica satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}