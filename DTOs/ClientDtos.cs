using System.Collections.Generic;

namespace GoldenGroupAPI.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class CreateClientDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
