using CoreWebApi.Data;
using CoreWebApi.Models;
using CoreWebApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _context;
        public TrailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.Trails.Include(t => t.NationalPark).FirstOrDefault(s => s.Id == trailId);
            
        }

        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.Include(t => t.NationalPark).ToList();
        }

        public ICollection<Trail> GetTrailsByNationalPark(int nationalParkId)
        {
            return _context.Trails.Include(t => t.NationalPark).Where(s => s.NationalParkId == nationalParkId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool TrailExists(int trailId)
        {
            return _context.Trails.Any(t => t.Id == trailId);
        }

        public bool TrailExists(string name)
        {
            return _context.Trails.Any(t => t.Name == name);
        }

        public bool UpdateTrail(Trail trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }
        
    }
}
