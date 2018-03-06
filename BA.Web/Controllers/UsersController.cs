﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.DataContext;
using BA.Database.Modeles;
using BA.Database.UnitOfWork;
using DA.Business.Enteties;
using DA.Business.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private UnitOfWork _Unit;
        private IMapper _Mapper;

        public UsersController(DataContext context, IMapper mapper)
        {
            _Mapper = mapper;
            _Unit = new UnitOfWork(context);
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            var List = _Unit.Users.GetList();
            var UserInfoList = _Mapper.Map<List<UserInfo>>(List);
            return UserInfoList;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
    }
}
