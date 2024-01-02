using MediatR;
using OnionApi.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Queries.Family
{
    public class GetAllFamilyQuery2 : IRequest<IEnumerable<FamilyVIewModel2>>
    {
    }
}
