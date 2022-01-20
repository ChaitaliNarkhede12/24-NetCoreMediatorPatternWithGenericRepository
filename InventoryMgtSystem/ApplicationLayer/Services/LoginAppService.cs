using ApplicationLayer.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly AppSettings _appSettings;
        private readonly IGenericRepository<UserDetail,int> _userDetailsRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDetailsRepository"></param>
        public LoginAppService(IGenericRepository<UserDetail,int> userDetailsRepository,
            IOptions<AppSettings> appSettings)
        {
            this._userDetailsRepository = userDetailsRepository;
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserDetail>> GetUserDetailsByExpression(Expression<Func<UserDetail, bool>> predicate)
        {
            var result = await _userDetailsRepository.GetByExpression(predicate).ConfigureAwait(false);

            if (result == null)
            {
                throw new Exception("No item found");
            }
            return result;
        }

        /// <summary>
        /// Generate token model
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenViewModel GetTokenModel(UserDetail user)
        {
            DateTime accessTokenExpirtTime = DateTime.UtcNow.AddDays(1);

            var token = new TokenViewModel
            {
                accessToken = GenerateJwtToken(user),
                accessTokenExpiryTime = accessTokenExpirtTime,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailId = user.EmailId
            };

            return token;
        }

        private string GenerateJwtToken(UserDetail user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim("userName", user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var finaltoken = tokenHandler.WriteToken(token);
            return finaltoken;
        }
    }
}
