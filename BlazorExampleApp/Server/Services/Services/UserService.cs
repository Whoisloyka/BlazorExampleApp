using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorExampleApp.Server.Data.Context;
using BlazorExampleApp.Server.Services.Infrastruce;
using MealOrdering.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleApp.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly BlazorExampleDbContext context;

        public UserService(IMapper Mapper, BlazorExampleDbContext Context)
        {
            mapper = Mapper;
            context = Context;
        }
        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser != null)
                throw new Exception("Kullanıcı zaten mevcut");

            dbUser = mapper.Map<Data.Modal.Users>(User);

            context.Users.Add(dbUser);
            int result = await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(dbUser);
        }

        public async Task<bool> DeleteUserById(Guid Id)
        {
            var dbUser = await context.Users.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");

            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            return await context.Users
             .Where(i => i.Id == id)
             .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
             .FirstOrDefaultAsync();
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.Users
                         .Where(i => i.IsActive)
                         .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                         .ToListAsync();
        }
        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("İlgili kayıt bulunamadı.");


            /*
             *             dbUser = mapper.Map<Data.Modal.Users>(User);
             *             
             *             Update işleminde mapping işlemini bu şekilde yaparsak yeni bir instance oluşturacak,
             *             ve sql sorgusunu hazırlarken  değişen veya değişmeyen User'a ait tüm alanlar için update sorgusu oluşturcak.
             *             Yalnızca basit bir isim update'i için bile user'ın tüm verilerini update etmek isteyecek. Ancak aşağıdaki şekilde mapping yaparsak,
             *             yalnızca değişiklik yapılan alanları bulacak ve onları update edecek.
             */
            mapper.Map(User, dbUser);


            context.Users.Add(dbUser);
            int result = await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(dbUser);
        }
    }
}
