using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetAllEmployeesQuery : IQuery<List<EmployeeViewModel>>
    {
    }

    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, List<EmployeeViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllEmployeesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Select(x => new EmployeeViewModel()
                {
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    ProfessionId = x.ProfessionId
                }
                ).ToListAsync(cancellationToken);
        }
    }
}
