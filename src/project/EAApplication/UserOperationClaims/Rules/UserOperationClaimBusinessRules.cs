using EASecurity.Authorization;
using EAService.OperationClaims;
using EAService.UserOperationClaims;
using EAService.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;

        public UserOperationClaimBusinessRules(IUserOperationClaimService userOperationClaimService, IUserService userService, IOperationClaimService operationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
            _operationClaimService = operationClaimService;
        }

        public async Task OperationClaimAndUserControl(UserOperationClaim userOperationClaim)
        {
            var isExist =await _userOperationClaimService.Get(x=>x.UserId==userOperationClaim.UserId && x.OperationClaimId==userOperationClaim.OperationClaimId);

            if (isExist is not null)
                throw new Exception("UserOperationClaim is already exist");

            var userControl = await _userService.GetById(userOperationClaim.UserId);
            if (userControl is null)
                throw new Exception("User not exist");

            var operationClaimControl = await _operationClaimService.GetById(userOperationClaim.OperationClaimId);
            if (operationClaimControl is null)
                throw new Exception("Operation Claim not exist");

        }
    }
}
