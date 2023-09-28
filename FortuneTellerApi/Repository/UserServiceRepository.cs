using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FortuneTellerApi.Models;
using Microsoft.AspNetCore.Identity;
using FortuneTellerApi.Repository.Interfaces;

namespace FortuneTellerApi.Repository
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly APIDbContext _db;

        public UserServiceRepository(APIDbContext db)
        {
            _db = db;
        }

        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens userToken)
        {
           User userDetail = _db.Users.FirstOrDefault(x => x.UserName == userToken.UserName);

            userToken.UserId = userDetail.UserId;  
            _db.UserRefreshToken.Add(userToken);
            return userToken;
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _db.UserRefreshToken.Remove(item);
            }
        }

        public List<User> GetSavedUsers()
        { 
            return _db.Users.ToList();
        }

        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken)
        {
            return _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
        }

        public int SaveCommit()
        {
            return _db.SaveChanges();
        }

        public async Task<bool> IsValidUserAsync(LoginDetail users)
        {
            var u = _db.Users.FirstOrDefault(o => o.UserName == users.UserName);
            if (u != null)
            {
                return _db.Users.FirstOrDefault(o => o.UserName == users.UserName).Password == users.Password;
            }

            if (u != null)
            {
                return _db.Users.FirstOrDefault(o => o.UserName == users.UserName).Password == users.Password;
            }
            return false;

        }

        
        public async Task<bool> RegisterAsync(User userCredentials)
        {


            var userCreationResult = _db.Users.Add(userCredentials); ;
           await _db.SaveChangesAsync();

            return await IsValidUserAsync(new LoginDetail()
            {
                UserName = userCredentials.UserName,
                Password = userCredentials.Password
            });

            
        }
    }
}

