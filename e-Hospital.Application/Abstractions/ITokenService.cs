using System.Security.Claims;

namespace e_Hospital.Application.Abstractions
{
    public interface ITokenService
    {
        string GetAccessToken(Claim[] claims);
    }
}
