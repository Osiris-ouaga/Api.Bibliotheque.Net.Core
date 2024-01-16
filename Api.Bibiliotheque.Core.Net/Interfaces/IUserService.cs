using Api.Bibiliotheque.Core.Net.Models;

namespace Api.Bibiliotheque.Core.Net.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers(CancellationToken cancel);
        Task<UserModel?> GetUser(int id);
        Task<UserModel> AddUser(UserModel book);
        Task<UserModel?> UpdateUser(int id, UserModel book);
        Task<UserModel?> DeleteUser(int id);

    }
}
