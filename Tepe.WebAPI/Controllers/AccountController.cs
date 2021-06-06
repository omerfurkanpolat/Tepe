using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tepe.Core.Constant;
using Tepe.Entities.Concrete;
using Tepe.WebAPI.Models;

namespace Tepe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Student> _usermanager;
        private readonly SignInManager<Student> _signInManager;
        public readonly IConfiguration _configuration;


        public AccountController(UserManager<Student> usermanager, SignInManager<Student> signInManager, IConfiguration configuration)
        {
            _usermanager = usermanager;
           _signInManager = signInManager;
           _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> SignUp(StudentForRegisterDTO studentForRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = new Student()
            {
                UserName = studentForRegisterDto.FirstName,
                LastName = studentForRegisterDto.LastName,
                Email=studentForRegisterDto.Email,
                IdentityNumber=studentForRegisterDto.IdentityNumber,
                City=studentForRegisterDto.City,
                Country=studentForRegisterDto.Country
                
            };

            var result = await _usermanager.CreateAsync(student, studentForRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
            
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login (StudentForLoginDTO studentForLoginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = await _usermanager.FindByEmailAsync(studentForLoginDTO.Email);
            if (student==null)
            {
                return BadRequest(Messages.StudentNotFound);
            }

            var result = await _signInManager.PasswordSignInAsync(student.UserName, studentForLoginDTO.Password,false,false);
        
            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = GenerateJwtToken(student)

                });
            }
           
            return BadRequest(Messages.UsernameOrPasswordWrong);
         
        }

        public string GenerateJwtToken(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, student.Id),
                    new Claim(ClaimTypes.Name, student.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
       
    }
}
