using System;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Queries
{
	public class GetMedicineByIdQuery : IQuery<MedicineViewModel>
	{
		public int Id { get; set; }
	}

    public class GetMedicineByIdQueryHandler : IQueryHandler<GetMedicineByIdQuery, MedicineViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetMedicineByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MedicineViewModel> Handle(GetMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (medicine == null)
            {
                throw new MedicineNotFoundException();
            }

            return new MedicineViewModel { Name = medicine.Name, CreateDate = medicine.CreateDate, EndDate = medicine.EndDate };
        }
    }
}

