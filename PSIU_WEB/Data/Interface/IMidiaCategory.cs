using PSIU_WEB.Models;

namespace PSIU_WEB.Data.Interface
{
    public interface IMidiaRepository
    {
        public Midia? GetMidiaById(int id);

        public IQueryable<Midia>? GetMidias();

        public Midia? Update(Midia m);

        public Midia? Delete(int id);

        public Midia? Create(Midia m);

    }

}

    // A interface é a camada que específica quais metódos serão
    // utilizados
