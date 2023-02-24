using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UserCases.Users.Commands
{
    public class UserLoginCommand : ICommand<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public UserLoginCommandHandler(IApplicationDbContext context, IHashService hashService, ITokenService tokenService)
        {
            _context = context;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

            if (user == null)
            {
                throw new LoginException(new EntityNotFoundException(nameof(User)));
            }

            if (user.PasswordHash != _hashService.GetHash(request.Password))
            {
                throw new LoginException();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            return _tokenService.GetAccessToken(claims.ToArray());
        }
    }
}
