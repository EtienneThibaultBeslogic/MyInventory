using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInventory.API.Models.Dtos
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
