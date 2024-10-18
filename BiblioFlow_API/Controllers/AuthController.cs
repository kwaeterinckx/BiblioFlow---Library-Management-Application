using BiblioFlow_API.Mappers;
using BiblioFlow_API.Models.Auth;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BiblioFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository<User> _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository<User> authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginForm loginForm)
        {
            try
            {
                User? user = await _authRepository.ValidateUserCredentialsAsync(loginForm.Email, loginForm.Password);

                if (user is null) return Unauthorized();

                await _authRepository.SetLastLoginTimeAsync(user.UserId);

                string accessToken = GenerateJwtToken(user.ToLoginModel());
                string refreshToken = GenerateRefreshToken();

                await _authRepository.SaveRefreshTokenAsync(user.UserId, refreshToken);

                return Ok(new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenForm tokenForm)
        {
            try
            {
                ClaimsPrincipal? principal = GetPrincipalFromExpiredToken(tokenForm.AccessToken);

                if (principal is null) return BadRequest("Invalid Access Token.");

                string? userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                string? role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (userId is null || role is null) return BadRequest("Invalid Access Token.");

                bool isValidToken = await _authRepository.ValidateRefreshTokenAsync(Guid.Parse(userId), tokenForm.RefreshToken);

                if (!isValidToken) return Unauthorized("Invalid Refresh Token.");

                string newAccessToken = GenerateJwtToken(new LoginModel() { UserId = Guid.Parse(userId), Role = role });
                string newRefreshToken = GenerateRefreshToken();

                await _authRepository.SaveRefreshTokenAsync(Guid.Parse(userId), newRefreshToken);

                return Ok(new
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(Guid userId)
        {
            try
            {
                await _authRepository.RevokeRefreshTokenAsync(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateJwtToken(LoginModel user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myClaims = new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: myClaims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(15)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!)),
                    ValidateLifetime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken securityToken);

                JwtSecurityToken? jwtToken = securityToken as JwtSecurityToken;

                if (jwtToken is null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid Token");

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
