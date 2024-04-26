using DataBase;
using DataBase.Contracts;
using DataBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class REstudiante : RepositoryBase, IEstudianteServices
    {
        public REstudiante(AudisoftContext db) : base(db)
        {
        }


        public async Task<int> CreateAsync(Estudiante request)
        {
            request.Id = 0;
            _db.Estudiante.Add(request);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _db.Estudiante.Where(x => x.Id == id).FirstOrDefault();
            _db.Estudiante.Remove(result);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Estudiante>> GetAsync()
        {
            return _db.Estudiante.ToList();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return _db.Estudiante.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Estudiante request, int id)
        {
            var result = _db.Estudiante.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Id = request.Id;
                result.Nombre = request.Nombre;
            }
            return await _db.SaveChangesAsync();
        }
    }
}
