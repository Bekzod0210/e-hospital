using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetAllProfessionQuery : IQuery<List<ProfessionViewModel>>
    {
    }

    public class GetAllProfessionQueryHandler : IQueryHandler<GetAllProfessionQuery, List<ProfessionViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProfessionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfessionViewModel>> Handle(GetAllProfessionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Professions
                .Select(x => new ProfessionViewModel()
                {
                    Name = x.Name,
                }
                ).ToListAsync(cancellationToken);
        }
    }
}
