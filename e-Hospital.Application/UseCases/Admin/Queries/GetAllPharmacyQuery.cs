using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Queries
{
    public class GetAllPharmacyQuery : IQuery<List<PharmacyViewModel>>
    {
    }

    public class GetAllPharmacyQueryHandler : IQueryHandler<GetAllPharmacyQuery, List<PharmacyViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPharmacyQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PharmacyViewModel>> Handle(GetAllPharmacyQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pharmacies.
                Select(x => new PharmacyViewModel()
                {
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                }
                ).ToListAsync(cancellationToken);
        }
    }
}
