using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Common
{
    public class BaseEntity : IBaseEntity   
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int status { get; set; }
    }
}
