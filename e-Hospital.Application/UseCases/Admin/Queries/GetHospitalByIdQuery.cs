using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Queries
{
    public class GetHospitalByIdQuery : IQuery<HospitalViewModel>
    {
        public int Id { get; set; }
    }

    public class GetHospitalByIdQueryHandler : IQueryHandler<GetHospitalByIdQuery, HospitalViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetHospitalByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HospitalViewModel> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (hospital == null)
            {
                throw new HospitalNotFoundException();
            }

            return new HospitalViewModel { Name = hospital.Name, PhoneNumber = hospital.PhoneNumber, Address = hospital.Address };
        }
    }
}
