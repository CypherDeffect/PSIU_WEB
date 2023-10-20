﻿using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;
using PSIU_WEB.Data;

namespace PSIU_WEB.Data.EF
{
    public class EFCategoryRepository : ICategoryRepository
    {

        private AppDbContext context;

        public EFCategoryRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public Category? Create(Category c)
        {
            try
            {
                context.Categories?.Add(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }

        public Category? Delete(int id)
        {
            Category? c = GetCategoryById(id);

            if (c == null)
                return null;

            context.Categories?.Remove(c);
            context.SaveChanges();

            return c;
        }

        public IQueryable<Category>? GetCategories()
        {
            return context.Categories;
        }

        public Category? GetCategoryById(int id)
        {
            Category? c =
                context
                    .Categories?
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

            return c;
        }

        public Category? Update(Category c)
        {
            try
            {
                context.Categories?.Update(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }
    }
}