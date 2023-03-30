using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class DeleteEmployeeCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            _context.Hospitals.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
