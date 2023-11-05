using HeStock.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Domain.Entities
{
    public class RoleEndpoint : BaseEntity
    {
        public Guid AppRoleId { get; set; }
        public Guid EndpointId { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Display { get; set; }

    }
}
