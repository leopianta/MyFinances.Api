using MyFinances.Domain.Entities;
using MyFinances.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>>GetAll()
        {
            var result = _userRepository.GetAll();

            return result;
        }




        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       }
}
