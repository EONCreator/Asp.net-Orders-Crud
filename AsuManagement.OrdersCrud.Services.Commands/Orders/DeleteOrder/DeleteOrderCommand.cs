using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using MediatR;

namespace AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<SucceededResult>
    {
        public int Id { get; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
