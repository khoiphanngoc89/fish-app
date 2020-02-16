using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NFC.Common.Utility;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIdentityService
    {
        IdentityDto Authenticate(string email, string password);
    }


    /// <summary>
    /// 
    /// </summary>
    public class IdentityService : ServiceBase, IIdentityService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The member repos
        /// </summary>
        private readonly IMemberRepository memberRepos;

        /// <summary>
        /// The token validation parameters
        /// </summary>
        private readonly TokenValidationParameters tokenValidationParameters;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="tokenValidationParameters"></param>
        /// <param name="memberRepository"></param>
        /// <param name="mapper"></param>
        public IdentityService(IConfiguration configuration, TokenValidationParameters tokenValidationParameters, IMemberRepository memberRepository, IMapper mapper) : base(mapper)
        {
            this.configuration = configuration;
            this.memberRepos = memberRepository;
            this.tokenValidationParameters = tokenValidationParameters;
        }

        /// <summary>
        /// Authenticates the specified user name.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public IdentityDto Authenticate(string email, string password)
        {
            var dao = this.memberRepos.Authenticate(email, password);
            if (Equals(dao, null))
            {
                return new Authentication();
            }

            var model = this.mapper.Map<Member, Authentication>(dao);
            model.Token = this.GenerateToken(dao);
            return model;
        }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        /// <param name="token">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public string RefreshToken(string token)
        {
            var validatedToken = this.GetPrincipleFromToken(token);
            if (validatedToken == null)
            {
                return new IdentityDto();
            }


            throw new NotImplementedException();

        }

        /// <summary>
        /// Gets the principle from token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        private ClaimsPrincipal GetPrincipleFromToken(string token)
        {
            try
            {
                var principal = new JwtSecurityTokenHandler().ValidateToken(token, this.tokenValidationParameters, out var validatedToken);
                return !this.IsJwtWithValidSecurityAlgorithm(validatedToken) ? null : principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether [is JWT with valid security algorithm] [the specified validated token].
        /// </summary>
        /// <param name="validatedToken">The validated token.</param>
        /// <returns>
        ///   <c>true</c> if [is JWT with valid security algorithm] [the specified validated token]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <returns></returns>
        private string GenerateToken(Member member)
        {
            IdentityModelEventSource.ShowPII = true;
            var signinKey = new SymmetricSecurityKey(EncodeHelper.EncodeASCII(this.configuration["JwtToken:SecretKey"]));
            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, member.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, member.Email),
                            new Claim(JwtRegisteredClaimNames.GivenName, member.FirstName),
                            new Claim(JwtRegisteredClaimNames.FamilyName, member.LastName),
                            new Claim("id", member.Id.ToString())
                        }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature)
            };
            //return new JwtSecurityTokenHandler().WriteToken(token);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
