﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public UsersController(UserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        protected UserProvider userProvider;

        // GET api/Users/GetUser?login=oleg&password=1234...
        [HttpGet]
        public IActionResult GetUser(string login, string password)
        {
            var result = this.userProvider.GetUser(login, password);
            return Ok(result);
        }

        // POST api/Users
        [HttpPost]
        public IActionResult AddUser(UserModel model)
        {
            this.userProvider.AddUser(model);
            return Ok();
        }
    }
}
