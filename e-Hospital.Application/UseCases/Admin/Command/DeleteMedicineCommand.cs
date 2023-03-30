using System;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
	public class DeleteMedicineCommand : ICommand<Unit>
	{
		public int Id { get; set; }
	}

    public class DeleteMedicineCommandHandler : ICommandHandler<DeleteMedicineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMedicineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (medicine == null)
            {
                throw new MedicineNotFoundException();
            }

            _context.Medicines.Remove(medicine);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

