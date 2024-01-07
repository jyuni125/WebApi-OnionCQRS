using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.DTOs.Family
{
    public class CreateFamilyDTO
    {
        [Required]
        public int status { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required, Range(0, 1, ErrorMessage = " (0 = Male, 1 = Female)")]
        public short Gender { get; set; }
    }
}
