using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace e_Hospital.Application.Services
{
    public class WithdrawService : IWithdrawService
    {
        private readonly IApplicationDbContext _context;

        public WithdrawService(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task WithdrawExpired(Medicine expired)
        {
            var expiredMedicines = await _context.Medicines.Where(x => x.EndDate > DateTime.UtcNow).ToListAsync();
            if(expiredMedicines.Count > 0 ) 
            {
                foreach (var expiredMedicine in expiredMedicines)
                {
                    expiredMedicine.Status = Domain.Enums.Status.Expired;
                    _context.Medicines.Update(expiredMedicine);
                };
                await _context.SaveChangesAsync();
            }
        }
    }
}
