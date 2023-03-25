using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis_Basic_Examle.Model;
using System;
using System.Text.Json.Serialization;

namespace Redis_Basic_Examle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisSetController : BaseController
    {
        public RedisSetController(IDistributedCache distributedCache) : base(distributedCache)
        {
        }

        [HttpPost("RedisSetValue", Name = "RedisSetValue")]
        public bool RedisSetValue(string key,string value)
        {
            bool res = true;
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            try
            {
                _distributedCache.SetString(key, value, options);
            }
            catch (System.Exception)
            {
                res = false;
            }

            return res;
        }

        [HttpPost("RedisSetComplexValue", Name = "RedisSetComplexValue")]
        public bool RedisSetComplexValue([FromBody] RedisComplex redisComplex)
        {
            bool res = true;
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            try
            {
                string jsonCustomer = JsonConvert.SerializeObject(redisComplex);
                _distributedCache.SetString("customer", jsonCustomer, options);
            }
            catch (System.Exception)
            {
                res = false;
            }

            return res;
        }


    }
}
