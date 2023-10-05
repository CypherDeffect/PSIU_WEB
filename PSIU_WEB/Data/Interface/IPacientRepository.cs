using PSIU_WEB.Models;

namespace PSIU_WEB.Data.Interface
{
    public interface IPacientRepository
    {
        public Pacient? GetPacientById(int id);

        public IQueryable<Pacient>? GetPacients();

        public Pacient? Update(Pacient psychop);

        public Pacient? Delete(int id);

        public Pacient? Create(Pacient psycho);
    }
}
