using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CoreWebApi.Models.Trail;

namespace CoreWebApi.Models.Dtos
{
    public class TrailUpsertDto
    {
       public int id { get; set; }
       public string Name { get; set; }
       public string Distance { get; set; }
       public string Elevation { get; set; }
       public DifficultyType Difficulty { get; set; }
       public int NationalParkId { get; set; }
    }
}
