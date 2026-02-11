using Microsoft.AspNetCore.Mvc;
using GoldenGroupAPI.Repositories;
using GoldenGroupAPI.Models;
using GoldenGroupAPI.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGroupAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientsController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            var clients = await _repository.GetAllAsync();
            return Ok(clients.Select(c => new ClientDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                IdNumber = c.IdNumber,
                PhoneNumbers = c.PhoneNumbers,
                Email = c.Email,
                Address = c.Address
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null) return NotFound();

            return Ok(new ClientDto
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    IdNumber = client.IdNumber,
                    PhoneNumbers = client.PhoneNumbers,
                    Email = client.Email,
                    Address = client.Address
                });
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(CreateClientDto dto)
        {
            var client = new Client
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdNumber = dto.IdNumber,
                PhoneNumbers = dto.PhoneNumbers,
                Email = dto.Email,
                Address = dto.Address
            };

            await _repository.AddAsync(client);

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, new ClientDto
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                IdNumber = client.IdNumber,
                PhoneNumbers = client.PhoneNumbers,
                Email = client.Email,
                Address = client.Address
            });
        }
    }
}
