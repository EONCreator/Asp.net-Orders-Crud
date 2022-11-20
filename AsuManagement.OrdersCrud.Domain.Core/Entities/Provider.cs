using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Domain.Core.Entities
{
    public class Provider : IEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Provider(string name)
        {
            Name = name;
        }

        public Provider()
        {

        }

        public void SetName(string name) => Name = name;
    }
}
