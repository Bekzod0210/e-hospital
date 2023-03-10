using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetEmployeeByIdQuery : IQuery<EmployeeViewModel>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            return new EmployeeViewModel { Name = employee.Name, PhoneNumber = employee.PhoneNumber, ProfessionId = employee.ProfessionId};

        }
    }
}
