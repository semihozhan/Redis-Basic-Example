using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Redis_Basic_Examle.Controllers
{
    public class BaseController : ControllerBase
    {
        internal IDistributedCache _distributedCache;

        public BaseController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
    }
}
