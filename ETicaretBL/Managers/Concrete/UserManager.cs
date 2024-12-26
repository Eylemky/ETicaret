using ETicaret.DAL.Repositories.Abstract;
using ETicaretBL.Managers.Abstract;
using ETicaretEntity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretBL.Managers.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();
        public async Task<User> GetByIdAsync(int id) => await _userRepository.GetByIdAsync(id);
        public async Task DeleteAsync(int id) => await _userRepository.DeleteAsync(id);
        public async Task AddAsync(User user)
        {
            // İş mantıkları, validasyonlar
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException("Username cannot be empty.");

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            // İş mantıkları, validasyonlar
            if (user.Id <= 0)
                throw new ArgumentException("User ID must be greater than zero.");

            await _userRepository.UpdateAsync(user);
        }
    
       
        
    }

}
