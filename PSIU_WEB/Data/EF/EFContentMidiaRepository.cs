using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;

namespace PSIU_WEB.Data.EF

{
    public class EFContentMidiaRepository : IContentMidiaRepository
    {
        private AppDbContext context;

        public EFContentMidiaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ContentMidia? Create(ContentMidia cm)
        {
            try
            {
                context.ContentMidias?.Add(cm); // adiciona 
                context.SaveChanges();
            }
            catch
            {
                return null;    // Valida se não ocorreu erro
            }

            return cm;
        }

        public ContentMidia? Delete(int id)
        {
            ContentMidia? cm = GetContentMidiaById(id);

            if (cm == null)    // Validar se existe registro no bando, pra poder excluir
                return null; // Irá interromper 

            context.ContentMidias?.Remove(cm); // Se registro existe, exclua
            context.SaveChanges();

            return cm;
        }

        public ContentMidia? GetContentMidiaById(int id)
        {
            ContentMidia? cm =
                context
                    .ContentMidias?
                    .Where(cm => cm.Id == id) // => Lambida (notação funcional)
                    .FirstOrDefault();

            return cm;
        }

        public IQueryable<ContentMidia>? GetContentMidias()
        {
            return context.ContentMidias;
        }

        public ContentMidia? Update(ContentMidia cm)
        {
            try
            {
                context.ContentMidias?.Update(cm);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return cm;
        }

    }

}
