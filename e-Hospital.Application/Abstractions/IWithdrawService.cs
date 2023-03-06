using e_Hospital.Domain.Entities;

namespace e_Hospital.Application.Abstractions
{
    public interface IWithdrawService
    {
        Task WithdrawExpired(Medicine expired);
    }
}
