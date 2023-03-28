using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Queries
{
    public class GetPharmacyByIdQuery : IQuery<PharmacyViewModel>
    {
        public int Id { get; set; }
    }

    public class GetPharmacyByIdQueryHandler : IQueryHandler<GetPharmacyByIdQuery, PharmacyViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetPharmacyByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<PharmacyViewModel> Handle(GetPharmacyByIdQuery request, CancellationToken cancellationToken)
        {
            var pharmacy = await _context.Pharmacies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (pharmacy == null)
            {
                throw new PharmacyNotFoundExeption();
            }

            return new PharmacyViewModel { Name = pharmacy.Name, PhoneNumber = pharmacy.PhoneNumber, Address = pharmacy.Address };

        }
    }
}
