using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Queries
{
    public class GetAllMyQueusQuery : IQuery<List<QueueViewModel>>
    {
    }
    public class GetAllMyQueusQueryHandler : IQueryHandler<GetAllMyQueusQuery, List<QueueViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetAllMyQueusQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<QueueViewModel>> Handle(GetAllMyQueusQuery request, CancellationToken cancellationToken)
        {
            return await _context.Queues
                .Where(x => x.PatientId == _currentUserService.UserId)
                .Select(x => new QueueViewModel()
                {
                    DateTime = x.Date,
                    ProfessionId= x.ProfessionId,
                    HospitalId = x.HospitalId,
                }
                ).ToListAsync(cancellationToken);
        }
    }
}
