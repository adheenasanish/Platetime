using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Repositories
{
    public class UserRoleAccountRepo
    {
        private readonly PlateTimeContext _context;
        private readonly IServiceProvider _serviceProvider;
        

        public UserRoleAccountRepo(PlateTimeContext context,
                                    IServiceProvider serviceProvider
                                    )
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> AddUserRole(string email, string roleName)
        {
            var UserManager = _serviceProvider
                                .GetRequiredService<UserManager<IdentityUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                await UserManager.AddToRoleAsync(user, roleName);
            }
            return true;
        }

        // Get current AspUser's ID to match with find corresponding Restaurants ID
        public async Task<int> GetCurrentRestrauntId(IdentityUser usr)
        {
            var res = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.UserId == usr.Id);
            int resId = 0;
            try {
                resId = res.Id;
            } catch { }
            return resId;
        }

        // Get current AspUser's ID to match with find corresponding Restaurant goers ID
        public async Task<int> GetCurrentRestrauntGoerId(IdentityUser usr)
        {
            var res = await _context.RestaurantGoer
                .FirstOrDefaultAsync(m => m.UserId == usr.Id);
            int resGoerId = 0;
            try {
                resGoerId = res.Id;
            }
            catch { }
            return resGoerId;
        }
    }
}
