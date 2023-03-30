using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class UpdateEmployeeCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand,Unit> 
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;
        public UpdateEmployeeCommandHandler(IApplicationDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=> x.Id == request.Id);
            if (employee == null)
            {
                throw new Exception(nameof(EmployeeNotFoundException));
            }
            _context.Employees.Update(new Domain.Entities.Employee()
            {
                Gender = request.Gender,
                Name = request.Name,
                ProfessionId= request.ProfessionId,
                UserName= request.UserName,
                PasswordHash = _hashService.GetHash(request.Password),
            });

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
