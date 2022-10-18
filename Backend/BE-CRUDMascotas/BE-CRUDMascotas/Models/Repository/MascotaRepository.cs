using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Models.Repository
{
    public class MascotaRepository:IMascotaRepository
    {
        private readonly AplicationDbContext _context;

        public MascotaRepository( AplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Mascota> AddMacota(Mascota mascota)
        {
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public void DeleteMascota(Mascota mascota)
        {
            _context.Mascota.Remove(mascota);
             _context.SaveChangesAsync();
        }

        public async Task<List<Mascota>> GetListMascotas()
        {
          return  await _context.Mascota.ToListAsync();
        }

        public async Task<Mascota> GetMascota(int id)
        {
            
            return await _context.Mascota.FindAsync(id);
        }

        public async Task<Mascota> UpdateMascota(Mascota mascota)
        {
            _context.Mascota.Update(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }
    }
}
