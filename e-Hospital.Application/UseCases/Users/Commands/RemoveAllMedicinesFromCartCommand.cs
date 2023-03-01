using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class RemoveAllMedicinesFromCartCommand : ICommand<Unit>
    {

    }

    public class RemoveAllMedicinesFromCartCommandHandler : ICommandHandler<RemoveAllMedicinesFromCartCommand, Unit>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICurrentUserService _currentUser;

        public RemoveAllMedicinesFromCartCommandHandler(IDistributedCache distributedCache, ICurrentUserService currentUser)
        {
            _distributedCache = distributedCache;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(RemoveAllMedicinesFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartJson = await _distributedCache.GetStringAsync(_currentUser.UserId.ToString(), cancellationToken);

            if (string.IsNullOrEmpty(cartJson))
            {
                throw new MedicineNotFoundException();
            }

            await _distributedCache.RemoveAsync(_currentUser.UserId.ToString(), cancellationToken);

            return Unit.Value;
        }
    }
}
