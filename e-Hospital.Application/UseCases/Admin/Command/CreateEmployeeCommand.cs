using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Enums;
using MediatR;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class CreateEmployeeCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int ProfessionId { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class CreateEmployeeHandler : ICommandHandler<CreateEmployeeCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;
        public CreateEmployeeHandler(IApplicationDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }
        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(new Employee 
            {
                Name = request.Name,
                UserName = request.UserName,
                ProfessionId= request.ProfessionId,
                Gender=request.Gender,
                PhoneNumber=request.PhoneNumber,
                PasswordHash = _hashService.GetHash(request.Password)
            },cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
