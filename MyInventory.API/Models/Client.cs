using System;

namespace MyInventory.API.Models
{
    public class Client: BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
