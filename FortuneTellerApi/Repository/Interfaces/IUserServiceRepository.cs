using FortuneTellerApi.Models;

namespace FortuneTellerApi.Repository.Interfaces
{
    public interface IUserServiceRepository
    {
        Task<bool> IsValidUserAsync(LoginDetail users);

        UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);

        UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken);

        void DeleteUserRefreshTokens(string username, string refreshToken);

        Task<bool> RegisterAsync(User userCredentials);
        List<User> GetSavedUsers();

        int SaveCommit();
    }
}
