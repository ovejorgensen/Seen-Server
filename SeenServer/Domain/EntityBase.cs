using System;

namespace SeenServer.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
