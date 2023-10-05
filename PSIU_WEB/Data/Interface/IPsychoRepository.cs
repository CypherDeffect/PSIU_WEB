using PSIU_WEB.Models;

namespace PSIU_WEB.Data.Interface
{
    public interface IPsychoRepository
    {
        public Psycho? GetPsychoById(int id);

        public IQueryable<Psycho>? GetPsychos();

        public Psycho? Update(Psycho p);

        public Psycho? Delete(int id);

        public Psycho? Create(Psycho p);
    }
}
