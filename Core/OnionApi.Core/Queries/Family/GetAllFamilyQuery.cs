using MediatR;
using OnionApi.Core.ViewModel;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Core.Queries.Family
{
    public class GetAllFamilyQuery : IRequest<IEnumerable<FamilyVIewModel>>
    {
    }
}
