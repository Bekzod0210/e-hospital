using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UserCases.Users.Commands
{
    public class UserRegisterCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;

        public UserRegisterCommandHandler(IApplicationDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<Unit> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(c => c.UserName == request.UserName, cancellationToken))
            {
                throw new RegisterException();
            }

            var user = new User()   
            {
                UserName = request.UserName,
                Name = request.UserName,
                PasswordHash = _hashService.GetHash(request.Password),
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
