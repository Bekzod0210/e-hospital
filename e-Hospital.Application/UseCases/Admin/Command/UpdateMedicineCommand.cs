using System;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
	public class UpdateMedicineCommand : ICommand<Unit>
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public DateTime? CreateDate { get; set; }

		public DateTime? EndDate { get; set; }
	}

    public class UpdateMedicineCommandHandler : ICommandHandler<UpdateMedicineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMedicineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (medicine == null)
            {
                throw new MedicineNotFoundException();
            }

            medicine.Name = request.Name ?? medicine.Name;
            medicine.CreateDate = request.CreateDate ?? medicine.CreateDate;
            medicine.EndDate = request.EndDate ?? medicine.EndDate;

            _context.Medicines.Update(medicine);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

