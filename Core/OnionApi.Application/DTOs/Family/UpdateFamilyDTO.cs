using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.DTOs.Family
{
    public class UpdateFamilyDTO
    {

        public Guid Id { get; set; }

        public int status { get; set; } 

        public string FirstName { get; set; }

        public string? LastName { get; set; } = "";

        public short Gender { get; set; }
    }
}
