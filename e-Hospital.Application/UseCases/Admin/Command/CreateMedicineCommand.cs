using System;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
	public class CreateMedicineCommand : ICommand<int>
	{
		public string? Name { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime EndDate { get; set; }
	}

    public class CreateMedicineCommandHandler : ICommandHandler<CreateMedicineCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMedicineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Medicines.AnyAsync(x => x.Name == request.Name && x.CreateDate == request.CreateDate && x.EndDate == request.EndDate,
                cancellationToken))
            {
                throw new MedicineExistsException();
            }

            var medicine = new Medicine
            {
                Name = request.Name,
                CreateDate = request.CreateDate,
                EndDate = request.EndDate
            };

            if (medicine.EndDate <= DateTime.UtcNow)
            {
                medicine.Status = Status.Expired;
            }

            await _context.Medicines.AddAsync(medicine);

            await _context.SaveChangesAsync(cancellationToken);

            return medicine.Id;
        }
    }
}

