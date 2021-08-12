using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeenServer.Domain
{
    public class Movie : EntityBase
    {
        public int MovieId { get; set; }
        public bool Seen { get; set; }
        public bool WatchListed { get; set; }
    }
}
