using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class CreateMedicalExaminationResultCommand : ICommand<Unit>
    {
        public int PatientId { get; set; }
        public string Diagnosis { get; set; }
    }
    public class CreateMedicalExaminationResultCommandHandler : ICommandHandler<CreateMedicalExaminationResultCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public CreateMedicalExaminationResultCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateMedicalExaminationResultCommand request, CancellationToken cancellationToken)
        {
            await _context.MedicalExaminationResults.AddAsync(new MedicalExaminationResult()
            {
            PatientId = request.PatientId,
            Description = request.Diagnosis
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var mex = await _context.MedicalExaminationResults.FirstOrDefaultAsync(x => x.PatientId == request.PatientId, cancellationToken);

            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == request.PatientId);

            patient.MedicalExaminationId = mex.Id;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
