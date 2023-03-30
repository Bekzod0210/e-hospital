using System;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Queries
{
	public class GetAllMedicineQuery : IQuery<List<MedicineViewModel>>
	{
	}

    public class GetAllMedicineQueryHandler : IQueryHandler<GetAllMedicineQuery, List<MedicineViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMedicineQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicineViewModel>> Handle(GetAllMedicineQuery request, CancellationToken cancellationToken)
        {
            return await _context.Medicines.
                Select(x => new MedicineViewModel()
                {
                    Name = x.Name,
                    CreateDate = x.CreateDate,
                    EndDate = x.EndDate,
                }
                ).ToListAsync(cancellationToken);
        }
    }
}

