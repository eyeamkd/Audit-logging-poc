using Microsoft.EntityFrameworkCore;

namespace AuditLoggerPoc
{
    public class UserService : IUserService
    {
        private readonly UserDatabaseContext _databaseContext;

        public UserService(UserDatabaseContext userDatabaseContext) 
        {
            _databaseContext = userDatabaseContext;
        }


        public async Task<User> AddUser(User user)
        {
           await _databaseContext.Users.AddAsync(user);
           await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            User? user = await _databaseContext.Users.FindAsync(id);

            if (user != null)
            {
               _databaseContext.Users.Remove(user);
            }
           
            await _databaseContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();

            return user;

        }
    }
}
