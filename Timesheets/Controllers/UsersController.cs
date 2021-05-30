using Timesheets.Domain.Interfaces;

namespace Timesheets.Controllers
{
    public class UsersController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
    }
}