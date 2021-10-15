using CoreWebApi.Data;
using CoreWebApi.Models;
using CoreWebApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _context;
        public NationalParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateNationalPark(NationalPark nationalpark)
        {
            _context.nationalParks.Add(nationalpark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.nationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.nationalParks.FirstOrDefault(np => np.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.nationalParks.ToList();
        }

        public bool NationalParkExists(int nationalParkId)
        {
            return _context.nationalParks.Any(np => np.Id == nationalParkId);
        }

        public bool NationalParkExists(string nationalParkName)
        {
            return _context.nationalParks.Any(np => np.Name == nationalParkName);
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.nationalParks.Update(nationalPark);
            return Save();
        }
    }
}
