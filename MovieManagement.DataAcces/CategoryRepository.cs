using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAcces
{
    public class CategoryRepository : BaseRepository
    {
        public List<Category> searchCategories()
        {

            return DbContext.Categories.ToList();

        }
        //get method
        public Category GetCategory(Guid categoryId)
        {

            var category = DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);
            return category;

        }

        public Category GetCategorybyName(string name)
        {
            //I called Tolower methos which transforms the string into lowercase, because we want strings like Drama, dRama, dRaMa to Match
            var lowercaseName = name.ToLower();
            var category = DbContext.Categories.FirstOrDefault(a => a.Name.ToLower().Contains(lowercaseName));
            return category;
        }

        //post method add category
        public void AddCategory(Category newCategory)
        {
            DbContext.Categories.Add(newCategory);
            DbContext.SaveChanges();
        }

        //delete category method
        public void DeleteCategory(Guid categoryId)
        {
            var category = DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);

            if (category != null)
            {
                DbContext.Categories.Remove(category);
                DbContext.SaveChanges();
            }

        }

        public void updateCategory(Category updatedCategory)
        {
            var existingCategory = DbContext.Categories.FirstOrDefault(a => a.Id == updatedCategory.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                DbContext.SaveChanges();
            }
        }
    }
}

