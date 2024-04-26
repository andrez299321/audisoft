using DataBase;
using DataBase.Contracts;
using DataBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class RProfesor : RepositoryBase, IProfesorServices
    {
        public RProfesor(AudisoftContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Profesor request)
        {
            request.Id = 0;
            _db.Profesor.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Profesor.Where(x => x.Id == id).FirstOrDefault();
            _db.Profesor.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Profesor>> GetAsync()
        {
            return _db.Profesor.ToList();
        }

        public async Task<Profesor> GetByIdAsync(int id)
        {
            return _db.Profesor.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Profesor request, int id)
        {
            var result = _db.Profesor.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Id = request.Id;
                result.Nombre = request.Nombre;
            }
            return await _db.SaveChangesAsync();
        }
    }
}
