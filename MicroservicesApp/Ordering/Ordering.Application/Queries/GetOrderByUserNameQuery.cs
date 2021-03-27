using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries
{
    /*
     * Required packages:
     * 1. MediatR
     * 2. FluentValidation
     * 3. Automapper
     */
    public class GetOrderByUserNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
