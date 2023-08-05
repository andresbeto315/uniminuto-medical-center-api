using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetByDoctorId
{
    internal class GetByDoctorIdQuery : IRequestHandler<GetByDoctorIdRequest, ResponseBase<GetByDoctorIdResponse>>
    {
        private readonly IMedicalAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetByDoctorIdQuery(IMedicalAppointmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetByDoctorIdResponse>> Handle(GetByDoctorIdRequest request, CancellationToken cancellationToken)
        {
            var medicals = this._repository.GetByDoctorId(request.DoctorId);
            var response = new ResponseBase<GetByDoctorIdResponse>
            {
                Data = new GetByDoctorIdResponse
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