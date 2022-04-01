using MealOrdering.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleApp.Server.Services.Infrastruce
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(Guid id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<bool> DeleteUserById(Guid Id);

    }
}
