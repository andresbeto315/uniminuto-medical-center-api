using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetByPatientId
{
    internal class GetByPatientIdQuery : IRequestHandler<GetByPatientIdRequest, ResponseBase<GetByPatientIdResponse>>
    {
        private readonly IMedicalAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetByPatientIdQuery(IMedicalAppointmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetByPatientIdResponse>> Handle(GetByPatientIdRequest request, CancellationToken cancellationToken)
        {
            var medicals = this._repository.GetByPatientId(request.PatientId);
            var response = new ResponseBase<GetByPatientIdResponse>
            {
                Data = new GetByPatientIdResponse
                {
                    Medicals = new List<MedicalAppointmentDto>()
                },
                IDCodigo = 0,
                Message = "Búsqueda de cita medica satisfactoria."
            };
            foreach (var medical in medicals)
            {
                var newMedical = new MedicalAppointmentDto();
                response.Data.Medicals.Add(this._mapper.Map<MedicalAppointmentEntity, MedicalAppointmentDto>(medical, newMedical));
            }
            return Task.FromResult(response);
        }
    }
}