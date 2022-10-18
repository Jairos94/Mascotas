namespace BE_CRUDMascotas.Models.Repository
{
    public interface IMascotaRepository
    {
        Task<List<Mascota>> GetListMascotas();

        Task<Mascota> GetMascota(int id);

        void DeleteMascota(Mascota mascota);
        Task<Mascota> AddMacota(Mascota mascota);
        Task<Mascota> UpdateMascota(Mascota mascota);
    }
}
