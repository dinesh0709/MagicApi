
using MagicApi.Models.Dto;

namespace MagicApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
               new VillaDTO { Id = 1, Name = "Pool View ok",Sqft=400,Occupancy=2 },
                new VillaDTO { Id = 2, Name = "Beach View" ,Sqft=200,Occupancy=1}
            };
    }
}
