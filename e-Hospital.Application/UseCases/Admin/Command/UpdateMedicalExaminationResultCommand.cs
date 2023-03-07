using e_Hospital.Application.Abstractions;
using MediatR;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class UpdateMedicalExaminationResultCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMedicalExaminationResultCommandHandler : ICommandHandler<UpdateMedicalExaminationResultCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMedicalExaminationResultCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateMedicalExaminationResultCommand command, CancellationToken cancellationToken)
        {
            var medicalExaminationResult = _context.MedicalExaminationResults.FirstOrDefault(x => x.Id == command.Id);

            if (medicalExaminationResult == null)
            {
                throw new Exception("MedicalExaminationResult's Id is not valid");
            }
            medicalExaminationResult.PatientId = command.PatientId;
            medicalExaminationResult.Description = command.Description;

            _context.MedicalExaminationResults.Update(medicalExaminationResult);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
