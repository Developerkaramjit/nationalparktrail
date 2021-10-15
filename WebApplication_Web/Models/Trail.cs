using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Web.Models
{
    public class Trail
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Distance { get; set; }
     public string Elevation { get; set; }
     public enum DifficultyType { Easy, Moderate, Difficult, Expert }
     public DifficultyType Difficulty { get; set; }
     public int NationalParkId { get; set; }
     public NationalPark NationalPark { get; set; }
    }
}
