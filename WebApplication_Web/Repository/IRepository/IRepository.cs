using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Web.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<T> GetAsync(string Url, int id);
        Task<IEnumerable<T>> GetAllAsync(string Url);
        Task<bool> CreateAsync(string Url, T objToCreate);
        Task<bool> UpdateAsync(string Url, T objToUpdate);
        Task<bool> DeleteAsync(string Url, int id);
    }
}
