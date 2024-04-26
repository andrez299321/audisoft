
using DataBase;
using DataBase.Contracts;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RNota : RepositoryBase, INotaServices
    {
        public RNota(AudisoftContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Nota request)
        {
            request.Id = 0;
            _db.Nota.Add(request);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Nota.Where(x => x.Id == id).FirstOrDefault();
            _db.Nota.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Nota>> GetAsync()
        {
            return _db.Nota.ToList();
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return _db.Nota.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Nota request, int id)
        {
            var result = _db.Nota.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Id = request.Id;
                result.Nombre = request.Nombre;
            }
            return await _db.SaveChangesAsync();
        }
    }
}
