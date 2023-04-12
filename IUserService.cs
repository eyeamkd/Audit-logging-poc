namespace AuditLoggerPoc
{
    public interface IUserService
    {
        Task<User> AddUser(User user);

        Task<User> UpdateUser(User user);

        Task<bool> DeleteUser(Guid id);

        Task<IEnumerable<User>> GetUsers();
    }
}
