using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis_Basic_Examle.Model;
using System;

namespace Redis_Basic_Examle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisGetController : BaseController
    {
        public RedisGetController(IDistributedCache distributedCache) : base(distributedCache)
        {

        }

        [HttpPost("RedisGetValue", Name = "RedisGetValue")]
        public string RedisGetValue(string key)
        {
            return _distributedCache.GetString(key);    
        }

        [HttpPost("RedisGetComplexValue", Name = "RedisGetComplexValue")]
        public RedisComplex RedisGetComplexValue(string key)
        {
            string jsonRedis =_distributedCache.GetString(key);
            return jsonRedis!= null ? JsonConvert.DeserializeObject<RedisComplex>(jsonRedis) : null;
        }
    }
}
