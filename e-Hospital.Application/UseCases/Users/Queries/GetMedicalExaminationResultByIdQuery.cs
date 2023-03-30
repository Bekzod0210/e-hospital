using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetMedicalExaminationResultByIdQuery : IQuery<MedicalExaminationResultViewModel>
    {
        public int? Id { get; set; }
    }
    public class GetMedicalExaminationResultByIdQueryHandler : IQueryHandler<GetMedicalExaminationResultByIdQuery, MedicalExaminationResultViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetMedicalExaminationResultByIdQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<MedicalExaminationResultViewModel> Handle(GetMedicalExaminationResultByIdQuery request, CancellationToken cancellationToken)
        {
            var medicalExaminationResult = await _context.MedicalExaminationResults.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (medicalExaminationResult.PatientId != _currentUserService.UserId)
            {
                throw new Exception("You can get only your Results");
            }
            if (medicalExaminationResult == null)
            {
                throw new EntityNotFoundException(nameof(MedicalExaminationResult));
            }

            return new MedicalExaminationResultViewModel()
            {
                Id = medicalExaminationResult.Id,
                Diagnosis = medicalExaminationResult.Description
            };
        }
    }
}
