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
    public class BuyerRequestsController : ControllerBase
    {
        private readonly IBuyerRequestRepository _repository;

        public BuyerRequestsController(IBuyerRequestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerRequestDto>>> GetBuyerRequests()
        {
            var requests = await _repository.GetAllAsync();
            return Ok(requests.Select(r => MapToBuyerRequestDto(r)));
        }

        private static BuyerRequestDto MapToBuyerRequestDto(BuyerRequest r)
        {
            if (r is TaboBuyerRequest tr)
            {
                return new TaboBuyerRequestDto
                {
                    Id = r.Id,
                    Zones = r.Zones.Select(z => z.ToString()).ToList(),
                    MinFloor = r.MinFloor,
                    MaxFloor = r.MaxFloor,
                    MaxPrice = r.MaxPrice,
                    MinSize = r.MinSize,
                    Details = r.Details,
                    Liquidity = r.Liquidity.ToString(),
                    ClientId = r.ClientId,
                    MaxEquity = tr.MaxEquity,
                    Community = tr.Community.ToString(),
                    RegistrationType = tr.RegistrationType.ToString(),
                    MaxPartners = tr.MaxPartners
                };
            }
            return new NormalBuyerRequestDto
            {
                Id = r.Id,
                Zones = r.Zones.Select(z => z.ToString()).ToList(),
                MinFloor = r.MinFloor,
                MaxFloor = r.MaxFloor,
                MaxPrice = r.MaxPrice,
                MinSize = r.MinSize,
                Details = r.Details,
                Liquidity = r.Liquidity.ToString(),
                ClientId = r.ClientId
            };
        }

        [HttpPost("normal")]
        public async Task<ActionResult<BuyerRequestDto>> CreateNormalRequest(CreateNormalBuyerRequestDto dto)
        {
            var request = new NormalBuyerRequest();
            MapCreateDtoToRequest(dto, request);
            await _repository.AddAsync(request);
            return CreatedAtAction(nameof(GetBuyerRequests), new { id = request.Id }, MapToBuyerRequestDto(request));
        }

        [HttpPost("tabo")]
        public async Task<ActionResult<BuyerRequestDto>> CreateTaboRequest(CreateTaboBuyerRequestDto dto)
        {
            var request = new TaboBuyerRequest
            {
                MaxEquity = dto.MaxEquity,
                Community = dto.Community,
                RegistrationType = dto.RegistrationType,
                MaxPartners = dto.MaxPartners
            };
            MapCreateDtoToRequest(dto, request);
            await _repository.AddAsync(request);
            return CreatedAtAction(nameof(GetBuyerRequests), new { id = request.Id }, MapToBuyerRequestDto(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, UpdateBuyerRequestDto dto)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return NotFound();

            MapCreateDtoToRequest(dto, request);
            await _repository.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        private static void MapCreateDtoToRequest(CreateBuyerRequestDto dto, BuyerRequest request)
        {
            request.Zones = dto.Zones;
            request.MinFloor = dto.MinFloor;
            request.MaxFloor = dto.MaxFloor;
            request.MaxPrice = dto.MaxPrice;
            request.MinSize = dto.MinSize;
            request.Details = dto.Details;
            request.Liquidity = dto.Liquidity;
            request.ClientId = dto.ClientId;
        }
    }
}
