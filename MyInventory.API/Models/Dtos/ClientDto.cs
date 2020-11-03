using System;

namespace MyInventory.API.Models.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static ClientDto ToDto(Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Firstname = client.Firstname,
                Lastname = client.Lastname,
                DateOfBirth = client.DateOfBirth,
            };
        }
    }
}
