using MediatR;
using OnionApi.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Queries.Family
{
     public class GetFamilyByIdQuery : IRequest<FamilyVIewModel2>
    {
        public Guid Id { get; set; }
    }
}
