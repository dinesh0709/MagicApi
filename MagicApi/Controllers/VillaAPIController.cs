using MagicApi.Data;
using MagicApi.Models;
using MagicApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicApi.Controllers
{
    //[Route("api/[Controller]")] this can also use for route it gives same result
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        public VillaAPIController(AppDbContext db) 
        {  
            _db = db;
        }

        [HttpGet]//all
        public ActionResult<IEnumerable<VillaDTO>> GetAll() //IEnumerable is return type use for list or many things(collection)
        {
            return Ok(_db.Villas.ToList());

            /* return new List<VillaDTO>
            {
                new VillaDTO { Id = 1, Name = "Pool View" },
                new VillaDTO { Id = 2, Name = "Beach View" }
            };//this is called object initializer C# is Awesome */
        }

        // [HttpGet("id")]

        [HttpGet("{id:int}", Name = "Get")]//by id 
        [ProducesResponseTypeAttribute(200, Type = typeof(VillaDTO))]
        [ProducesResponseTypeAttribute(404)]
        [ProducesResponseTypeAttribute(400)]
        public ActionResult<VillaDTO> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]//create
        public ActionResult<VillaDTO> Add([FromBody] VillaDTO villaDTO)
        {   //below first bllock is custom validqation add
            if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("error made by u", "Villa already exist");
                return BadRequest(ModelState);
            }

            /*if (villaDTO == null)
            {
                return BadRequest();
            }
            
        if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }*/
            //villaDTO.Id = _db.Villas.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            Villa model = new ()
            {
                Amenity= villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Sqft = villaDTO.Sqft,
                Name = villaDTO.Name,
                Occupancy =villaDTO.Occupancy,
                Rate = villaDTO.Rate   
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("Get", new { id = villaDTO.Id }, villaDTO);
            //  return CreatedAtRoute("GetVilla",  villaDTO);

        }


        [HttpDelete("{id:int}", Name = "Delete")]//delete
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();

        }


        [HttpPut("{id:int}", Name = "Update")]//update
        public IActionResult Update(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            /* var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
             villa.Name = villaDTO.Name;
             villa.Sqft = villaDTO.Sqft;
             villa.Occupancy = villaDTO.Occupancy; */
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Sqft = villaDTO.Sqft,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartial")]
        public IActionResult UpdatePartial(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if(patchDTO==null || id == 0)
            {
                return BadRequest();
            }
            var villa= _db.Villas.AsNoTracking().FirstOrDefault(u=>u.Id == id);
         
            VillaDTO villaDTO = new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Sqft = villa.Sqft,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate
            };
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Sqft = villaDTO.Sqft,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        
        }


    }



 }

