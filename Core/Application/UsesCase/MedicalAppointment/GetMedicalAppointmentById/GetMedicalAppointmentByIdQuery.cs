using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetMedicalAppointmentById
{
    public class GetMedicalAppointmentByIdQuery : IRequestHandler<GetMedicalAppointmentByIdRequest, ResponseBase<GetMedicalAppointmentByIdResponse>>
    {
        private readonly IMedicalAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public GetMedicalAppointmentByIdQuery(IMedicalAppointmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetMedicalAppointmentByIdResponse>> Handle(GetMedicalAppointmentByIdRequest request, CancellationToken cancellationToken)
        {
            var medical = this._repository.GetById(request.Id);
            var newMedical = new MedicalAppointmentDto();
            var response = new ResponseBase<GetMedicalAppointmentByIdResponse>
            {
                Data = new GetMedicalAppointmentByIdResponse
                {
                    Medical = this._mapper.Map<MedicalAppointmentEntity, MedicalAppointmentDto>(medical, newMedical)
                },
                IDCodigo = 0,
                Message = "Búsqueda de cita medica satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}