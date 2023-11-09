using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;

namespace PSIU_WEB.Data.EF
{
    public class EFMidiaRepository : IMidiaRepository // Referenia e Implementa a Interface
    {
        private AppDbContext context; // Construtor do DbContext

        public EFMidiaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Midia? Create(Midia m)
        {
            try
            {
                context.Midias?.Add(m); // adiciona 
                context.SaveChanges();
            }
            catch
            {
                return null;    // Valida se não ocorreu erro
            }

            return m;
        }

        public Midia? Delete(int id)
        {
            Midia? m = GetMidiaById(id);

            if (m == null)    // Validar se existe registro no bando, pra poder excluir
                return null; // Irá interromper 

            context.Midias?.Remove(m); // Se registro existe, exclua
            context.SaveChanges();

            return m;

        }

        public new Midia? GetMidiaById(int id)
        {
            Midia? m =
                 context
                     .Midias?
                     .Where(m => m.Id == id) // => Lambida (notação funcional)
                     .FirstOrDefault();

            return m;
        }

        public IQueryable<Midia>? GetMidias()
        {
            return context.Midias;
        }

        public Midia? Update(Midia m)
        {
            try
            {
                context.Midias?.Update(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;

        }

    }
}
