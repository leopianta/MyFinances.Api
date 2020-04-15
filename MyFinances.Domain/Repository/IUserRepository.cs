using MyFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistsUserByName(User user);
        bool DeleteUser(int Id);
        
    }
}
