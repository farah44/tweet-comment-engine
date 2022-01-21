using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tweet_comment_engine.Models;
using tweet_comment_engine.Repositories;

namespace tweet_comment_engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// get all users
        /// </summary>
        /// <returns> list of all users in the database </returns>
        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {

            return await _userRepository.GetUsers();
        }


        /// <summary>
        /// call the user repo to add new user in the database
        /// </summary>
        /// <param name="user"> 
        /// A user object that hold's the user info </param>
        /// <returns>
        /// the saved user object
        /// </returns>
        [HttpPost("AddUser")]
        public async Task<User> AddUser([FromBody] User user)
        {

              var newUser = await _userRepository.Create(user);

            return newUser;
        }

       
    }
}
