using PSIU_WEB.Models;
using PSIU_WEB.Data.Interface;
using System;
using System.Linq;


namespace PSIU_WEB.Data.EF
{
    public class EFPsychoRepository : IPsychoRepository
    {
        private AppDbContext context;

        public EFPsychoRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Psycho? Create(Psycho psycho)
        {
            try
            {
                context.Psychos?.Add(psycho);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return psycho;
        }

        public Psycho? Delete(int id)
        {
            Psycho? psycho = GetPsychoById(id);

            if (psycho == null)
                return null;

            context.Psychos?.Remove(psycho);
            context.SaveChanges();

            return psycho;
        }

        public Psycho? GetPsychoById(int id)
        {
            Psycho? psycho =
                context
                    .Psychos?
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return psycho;
        }

        public IQueryable<Psycho>? GetPsychos()
        {
            return context.Psychos;
        }

        public Psycho? Update(Psycho psycho)
        {
            try
            {
                context.Psychos?.Update(psycho);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return psycho;
        }
    }
}
