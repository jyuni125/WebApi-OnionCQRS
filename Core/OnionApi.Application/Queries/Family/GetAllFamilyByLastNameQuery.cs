using MediatR;
using OnionApi.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Queries.Family
{
    public class GetAllFamilyByLastNameQuery : IRequest<IEnumerable<FamilyVIewModel2>>
    {
       public string Lastname { get; set; }   
    }
}
