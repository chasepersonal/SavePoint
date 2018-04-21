using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavePoint.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;


namespace SavePoint.Authorization
{
    // Create Operations for Admin role
    // For use in View to ensure admin can see user name

    public static class GameOperations
    {
        public static OperationAuthorizationRequirement ViewUser = new OperationAuthorizationRequirement { Name = Constants.ViewUserOperationName };
    }

    public class Constants
    {
        public static readonly string ViewUserOperationName = "ViewUser";
        public static readonly string GamesAdministratorRole = "GameAdministrator";
        
    }
}
