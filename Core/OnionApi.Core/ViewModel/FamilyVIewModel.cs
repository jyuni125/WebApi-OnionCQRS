﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Core.ViewModel
{
    public class FamilyVIewModel
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Gender { get; set; }
    }
}
