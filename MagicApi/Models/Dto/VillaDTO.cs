using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MagicApi.Models.Dto
{
    //relation between model & database
    public class VillaDTO
    {
        public int Id { get; set; }
     //   [Required]
     //   [MaxLength(255)]

        public string Name { get; set; }
        public string Details { get; set; }
       
        [Required] //this annotation id for rate as required field
        public Double Rate { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }

        public string ImageUrl { get; set; }
        public string Amenity { get; set; }


    }
}
