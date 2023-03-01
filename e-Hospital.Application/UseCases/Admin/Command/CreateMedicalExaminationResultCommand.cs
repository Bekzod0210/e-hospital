using e_Hospital.Application.Abstractions;
using MediatR;

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
            await _context.MedicalExaminationResults.AddAsync(new Domain.Entities.MedicalExaminationResult()
            {
                PatientId = request.PatientId,
                Description = request.Diagnosis
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
