using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Cache
{
    public record CacheOptions(
        TimeSpan? AbsoluteExpiration = null,
        TimeSpan? SlidingExpiration = null
    );
}
