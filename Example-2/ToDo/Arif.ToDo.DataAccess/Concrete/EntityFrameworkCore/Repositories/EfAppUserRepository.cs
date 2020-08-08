using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNonAdminUsers()
        {
            using var context = new TodoContext();

            return context.Users
                .Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                    (resultUser, resultUserRole) => new
                    {
                        user = resultUser,
                        userRole = resultUserRole
                    })
                .Join(context.Roles, userUserRole => userUserRole.userRole.RoleId, role => role.Id,
                    (resultUserUserRole, resultRole) => new
                    {
                        user = resultUserUserRole.user,
                        userRoles = resultUserUserRole.userRole,
                        roles = resultRole
                    })
                .Where(I => I.roles.Name != "Admin")
                .Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                }).ToList();
        }

        public List<AppUser> GetNonAdminUsers(string keyword, int activePage = 1)
        {
            using var context = new TodoContext();

            var result = context.Users
                .Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                    (resultUser, resultUserRole) => new
                    {
                        user = resultUser,
                        userRole = resultUserRole
                    })
                .Join(context.Roles, userUserRole => userUserRole.userRole.RoleId, role => role.Id,
                    (resultUserUserRole, resultRole) => new
                    {
                        user = resultUserUserRole.user,
                        userRoles = resultUserUserRole.userRole,
                        roles = resultRole
                    })
                .Where(I => I.roles.Name != "Admin")
                .Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                });

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(I => I.Name.ToLower().Contains(keyword.ToLower()) || I.SurName.ToLower().Contains(keyword.ToLower()));
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }
    }
}
