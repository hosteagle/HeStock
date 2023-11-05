using HeStock.Domain.Entities.Common;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public string pageName { get; set; }
        public string Description { get; set; }
        public List<RoleEndpoint> RoleEndpoints { get; set; }
    }
}
