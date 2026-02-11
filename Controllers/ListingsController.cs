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
    public class ListingsController : ControllerBase
    {
        private readonly IListingRepository _repository;

        public ListingsController(IListingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingDto>>> GetListings()
        {
            var listings = await _repository.GetAllAsync();
            return Ok(listings.Select(l => MapToListingDto(l)));
        }

        private static ListingDto MapToListingDto(Listing l)
        {
            if (l is TaboListing tl)
            {
                return new TaboListingDto
                {
                    Id = l.Id,
                    City = l.City,
                    Street = l.Street,
                    BuildingNumber = l.BuildingNumber,
                    AptNumber = l.AptNumber,
                    Floor = l.Floor,
                    Rooms = l.Rooms,
                    SquaredMeters = l.SquaredMeters,
                    Zone = l.Zone.ToString(),
                    Price = l.Price,
                    ClientId = l.ClientId,
                    EnteringDate = l.EnteringDate,
                    ApplicationDate = l.ApplicationDate,
                    LastUpdateDate = l.LastUpdateDate,
                    PropertyState = l.PropertyState.ToString(),
                    Details = l.Details,
                    HousingUnits = l.HousingUnits.Select(hu => new HousingUnitDto
                    {
                        SquaredMeters = hu.SquaredMeters,
                        Rooms = hu.Rooms,
                        Floor = hu.Floor,
                        PhoneNumber = hu.PhoneNumber
                    }).ToList(),
                    RegistrationType = tl.RegistrationType.ToString(),
                    NumOfPartners = tl.NumOfPartners,
                    RequiredEquity = tl.RequiredEquity
                };
            }
            return new NormalListingDto
            {
                Id = l.Id,
                City = l.City,
                Street = l.Street,
                BuildingNumber = l.BuildingNumber,
                AptNumber = l.AptNumber,
                Floor = l.Floor,
                Rooms = l.Rooms,
                SquaredMeters = l.SquaredMeters,
                Zone = l.Zone.ToString(),
                Price = l.Price,
                ClientId = l.ClientId,
                EnteringDate = l.EnteringDate,
                ApplicationDate = l.ApplicationDate,
                LastUpdateDate = l.LastUpdateDate,
                PropertyState = l.PropertyState.ToString(),
                Details = l.Details,
                HousingUnits = l.HousingUnits.Select(hu => new HousingUnitDto
                {
                    SquaredMeters = hu.SquaredMeters,
                    Rooms = hu.Rooms,
                    Floor = hu.Floor,
                    PhoneNumber = hu.PhoneNumber
                }).ToList()
            };
        }

        [HttpPost("normal")]
        public async Task<ActionResult<ListingDto>> CreateNormalListing(CreateNormalListingDto dto)
        {
            var listing = new NormalListing();
            MapCreateDtoToListing(dto, listing);
            await _repository.AddAsync(listing);
            return CreatedAtAction(nameof(GetListings), new { id = listing.Id }, MapToListingDto(listing));
        }

        [HttpPost("tabo")]
        public async Task<ActionResult<ListingDto>> CreateTaboListing(CreateTaboListingDto dto)
        {
            var listing = new TaboListing
            {
                RegistrationType = dto.RegistrationType,
                NumOfPartners = dto.NumOfPartners,
                RequiredEquity = dto.RequiredEquity
            };
            MapCreateDtoToListing(dto, listing);
            await _repository.AddAsync(listing);
            return CreatedAtAction(nameof(GetListings), new { id = listing.Id }, MapToListingDto(listing));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, UpdateListingDto dto)
        {
            var listing = await _repository.GetByIdAsync(id);
            if (listing == null) return NotFound();

            MapCreateDtoToListing(dto, listing);
            listing.LastUpdateDate = DateTime.Now;

            if (listing is TaboListing tl && dto is UpdateListingDto ud)
            {
                // In a real app, you might want to handle Tabo-specific updates here
                // if UpdateListingDto was separate for Tabo. 
                // For now, let's assume we update base properties only or use cast if possible.
            }

            await _repository.UpdateAsync(listing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        private static void MapCreateDtoToListing(CreateListingDto dto, Listing listing)
        {
            listing.City = dto.City;
            listing.Street = dto.Street;
            listing.BuildingNumber = dto.BuildingNumber;
            listing.AptNumber = dto.AptNumber;
            listing.Floor = dto.Floor;
            listing.Rooms = dto.Rooms;
            listing.SquaredMeters = dto.SquaredMeters;
            listing.Zone = dto.Zone;
            listing.Price = dto.Price;
            listing.ClientId = dto.ClientId;
            listing.EnteringDate = dto.EnteringDate;
            listing.PropertyState = dto.PropertyState;
            listing.Details = dto.Details;
            listing.HousingUnits = dto.HousingUnits.Select(hu => new HousingUnit
            {
                SquaredMeters = hu.SquaredMeters,
                Rooms = hu.Rooms,
                Floor = hu.Floor,
                PhoneNumber = hu.PhoneNumber
            }).ToList();
        }
    }
}
