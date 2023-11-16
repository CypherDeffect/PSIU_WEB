using PSIU_WEB.Models;

namespace PSIU_WEB.Data.Interface
{
    public interface IContentMidiaRepository
    {
        public ContentMidia? GetContentMidiaById(int id);

        public IQueryable<ContentMidia>? GetContentMidias();

        public ContentMidia? Update(ContentMidia cm);

        public ContentMidia? Delete(int id);

        public ContentMidia? Create(ContentMidia cm);
    }
}
