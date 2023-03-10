using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetAllHospitalQuery : IQuery<List<HospitalViewModel>>
    {
    }

    public class GetAllHospitalQueryHandler : IQueryHandler<GetAllHospitalQuery, List<HospitalViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHospitalQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HospitalViewModel>> Handle(GetAllHospitalQuery request, CancellationToken cancellationToken)
        {
            return await _context.Hospitals.
                Select(x => new HospitalViewModel()
                {
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                }
                ).ToListAsync(cancellationToken);
        }
    }
}
