using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication_Web.Models;
using WebApplication_Web.Repository.IRepository;

namespace WebApplication_Web.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
         public NationalParkRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory)
         {
            _httpClientFactory = httpClientFactory;
         }
    }
}
