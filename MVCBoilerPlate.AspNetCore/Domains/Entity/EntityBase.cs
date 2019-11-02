using System;

namespace MvcBoilerPlate.AspNetCore.Domains.Entity
{
    public class EntityBase
    {
        public long RowCreatedBy{ get; set; }
        public long RowModifiedBy { get; set; }
        public DateTime RowCreatedDateTimeUTC { get; set; } = DateTime.UtcNow;
        public DateTime RowModifiedDateTimeUTC { get; set; } = DateTime.UtcNow;
    }
}
