﻿using OnionApi.Domain.Common;
using OnionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Entities
{
    public class Family :BaseEntity,IBaseModel,IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Gender { get; set; }
    }
}
