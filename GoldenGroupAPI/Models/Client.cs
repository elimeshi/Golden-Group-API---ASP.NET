using System.Collections.Generic;

namespace GoldenGroupAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Navigation properties
        public List<Listing> Listings { get; set; } = new List<Listing>();
        public List<BuyerRequest> BuyerRequests { get; set; } = new List<BuyerRequest>();
    }
}
