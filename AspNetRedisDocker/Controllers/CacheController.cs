﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetRedisDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;
        public CacheController(IDatabase database)
        {
            _database = database;
        }
        // GET: api/Cache?key=key
        [HttpGet]
        public string Get([FromQuery] string key)
        {
            return _database.StringGet(key);
        }

        // POST: api/Cache
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> keyValue)
        {
            _database.StringSet(keyValue.Key, keyValue.Value);
        }

        // DELETE api/<CacheController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
