


namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);

        Task<List<User>> SearchByUser(string user);

        Task<List<User>> SearchByUser(string name);

    }


}