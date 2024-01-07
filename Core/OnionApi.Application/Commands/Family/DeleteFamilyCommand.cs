using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Commands.Family
{
    public class DeleteFamilyCommand : IRequest<int>
    {
        public Guid Id { get; set; }

       
    }
}
