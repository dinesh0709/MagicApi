using MagicApi.Data;
using MagicApi.Logging;
using MagicApi.Models;
using MagicApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicApi.Controllers
{
    //[Route("api/[Controller]")] this can also use for route it gives same result
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        //  private readonly ILogging _logging;
        // public VillaAPIController(ILogging logging, AppDbContext db) 
        public VillaAPIController(AppDbContext db)
        {  
            _db = db;
          //  _logging = logging;
        }


        /* [HttpGet]//all
         public ActionResult<IEnumerable<VillaDTO>> Gets() //IEnumerable is return type use for list or many things(collection)
         {
             try
             {

                 return Ok(_db.Villas.ToList());
             }
             catch (Exception ex)
             {

                 return BadRequest(ex.Message);
             }

              return new List<VillaDTO>
             {
                 new VillaDTO { Id = 1, Name = "Pool View" },
                 new VillaDTO { Id = 2, Name = "Beach View" }
             };//this is called object initializer C# is Awesome 
         }*/

        [HttpGet("{id:int}", Name = "Metsssssss")]
        public ActionResult<VillaDTO> Get(int id)
        {
            try
            {

                var villa = _db.Villas.Where(u => u.Id == id).FirstOrDefault();
                 if (villa == null)
                 {
                     Console.WriteLine("Awesomeeeeeeeeeeeeeeee");
                    // return NotFound($"the villa with id {id} not found");
                  //  _logging.Log("Get villa with ID Error" +  id,"error");
                    return NotFound();

                 }
              //  _logging.Log("Get Villa by ID Successfully" + id," ");
                 return Ok(villa);
               
            }
            catch (Exception ex)
            {
               
               return BadRequest(ex.Message);
                
            }
            
            
           
        }

        //[HttpGet("{id:int}", Name = "Get")]//by id 
        /* [HttpGet("id", Name = "Get")]
         [ProducesResponseTypeAttribute(200, Type = typeof(VillaDTO))]
         [ProducesResponseTypeAttribute(404)]
         [ProducesResponseTypeAttribute(400)]*/

        [HttpGet("id", Name = "Geta")]//same as below
        // [HttpGet("id")]//url as /id?params
       // [HttpGet]

        //this also works. public ActionResult<VillaDTO> Get(int? id = -1, string? name = "", string? detail = "", int? sqft = -1, int? occupancy = -1, string? imageurl = "")
        public ActionResult<VillaDTO> Geta( string? name, string? detail, int? sqft, int? occupancy, string? imageurl)
        {
            try
            {
                if(name==null && detail==null && sqft==null && occupancy==null && imageurl == null)
                {
                    return Ok(_db.Villas.ToList());
                }
                var villa1 = _db.Villas.Where(u => u.Name == name || u.Details == detail || u.Sqft == sqft || u.Occupancy == occupancy || u.ImageUrl == imageurl).ToList();
                if (villa1.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(villa1);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    }
        /* {

                 // var villa = _db.Villas.Where((u => u.Id == id || u.Name == name || u.Details == detail || u.Sqft == sqft || u.Occupancy == occupancy || u.ImageUrl == imageurl)).ToList();
            //  var villa = _db.Villas.Where(u=>u.Id==id).FirstOrDefault();
             if (villa == null)
             {
                 return NotFound();
             }
             return Ok(villa);
         }*/
        // {
        /* if (id != null)
         {
             // var villa = _db.Villas.Where((u => u.Id == id || u.Name==name ||u.Details==detail ||u.Sqft==sqft||u.Occupancy==occupancy||u.ImageUrl==imageurl)).ToList();
             var villa = _db.Villas.Where(u => u.Id == id).FirstOrDefault();
             if (villa == null)
             {
                 return NotFound();
             }

             return Ok(villa);
         }*/

        /*

        //var villa1 = _db.Villas.Where(u => u.Name.ToLower() == name.ToLower()).FirstOrDefault();
        var villa1 = _db.Villas.Where(u => u.Name == name || u.Details == detail || u.Sqft == sqft || u.Occupancy == occupancy || u.ImageUrl == imageurl);
        if (villa1 == null)
        {
            return NotFound();
        }
        return Ok(villa1);
        }*/
        /*
        if (detail != null)
        {
            var villa2 = _db.Villas.Where(u => u.Details == detail).ToList();

            if (villa2 == null)
            {
                return NotFound();
            }
            return Ok(villa2);
        }
        if (sqft != null)
        {
            var villa3 = _db.Villas.Where(u => u.Sqft == sqft).ToList();
            if (villa3 == null)
            {
                return NotFound();
            }
            return Ok(villa3);
        }
        if (occupancy != null)
        {
            var villa4 = _db.Villas.Where(u => u.Occupancy == occupancy).ToList();
            if (villa4 == null)
            {
                return NotFound();
            }
            return Ok(villa4);
        }
        if (imageurl != null)
        {
            var villa5 = _db.Villas.Where(u => u.ImageUrl == imageurl).ToList();
            if (villa5 == null)
            {
                return NotFound();
            }
            return Ok(villa5);
        }
        return BadRequest();
        }*/







        // by using fields #2 
        /*[HttpGet("{id:int}", Name = "Geti")]//by id 
        [ProducesResponseTypeAttribute(200, Type = typeof(VillaDTO))]
        [ProducesResponseTypeAttribute(404)]
        [ProducesResponseTypeAttribute(400)]
        public ActionResult<VillaDTO> Geti(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                var villa1 = _db.Villas.FirstOrDefault(u => u.Sqft == id);
                if (villa1 == null)
                {
                    var villa2 = _db.Villas.FirstOrDefault(u => u.Occupancy == id);
                    if(villa2 == null)
                    {
                        return NotFound();
                    }
                    return Ok(villa2);

                }
                return Ok(villa1);
            }
            return Ok(villa);
        }

        //by using anopther field #1
        [HttpGet("{name}")]
        public ActionResult<VillaDTO> Getn(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var villa = _db.Villas.Where(u => u.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if(villa == null)
            {
                var villa1 = _db.Villas.Where(u => u.Amenity.ToLower() == name.ToLower()).FirstOrDefault();
                if (villa1 == null)
                {
                    var villa2 = _db.Villas.Where(u => u.Details.ToLower() == name.ToLower()).FirstOrDefault();
                    if (villa2 == null)
                    {
                        var villa3 = _db.Villas.Where(u => u.ImageUrl.ToLower() == name.ToLower()).FirstOrDefault();
                        if (villa3 == null)
                        {
                            return NotFound() ;
                        }
                        return Ok(villa3);
                    }
                    return Ok(villa2);
                }
                return Ok(villa1);
               // return NotFound();
            }
            return Ok(villa);
        }*/






        [HttpPost]//create
        public ActionResult<VillaDTO> Add([FromBody] VillaDTO villaDTO)
        {   //below first bllock is custom validqation add
            try
            {
                if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("error made by u", "Villa already exist");
                    return BadRequest(ModelState);
                }
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
                _db.Villas.Add(model);
                _db.SaveChanges();
                var villa1 = _db.Villas.Where(u => u.Name == villaDTO.Name).FirstOrDefault();
                //return Ok(villa1);
                 return CreatedAtRoute("Metsssssss", new { id = villaDTO.Id }, villaDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            /*   Villa model = new ()
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

           }*/


            [HttpDelete("{id:int}", Name = "Delete")]//delete
        public IActionResult Delete(int id)
        {
            try
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
            catch(Exception ex) { 
            return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id:int}", Name = "Update")]//update
        public IActionResult Update(int id, [FromBody] VillaDTO villaDTO)
        {
            try
            {
                if (villaDTO == null || id != villaDTO.Id)
                {
                    return BadRequest();
                }
                var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                    //return BadRequest();
                }

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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id:int}", Name = "UpdatePartial")]
        public IActionResult UpdatePartial(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);

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
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        
        }


    }



 }

