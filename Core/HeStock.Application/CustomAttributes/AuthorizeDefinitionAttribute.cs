using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public OperationType OperationType { get; set; }
    }
}
