using MovieManagement.DataAcces;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.ManageMent
{
    public class CategoryManagement
    {
        //Declare a private repositroty which can only be called inside this class
        private CategoryRepository _repo = new CategoryRepository();
        //Search list
        public List<CategoryDTO> search()
        {
            var result = _repo.searchCategories();

            var toreturn = result.Select(a => new CategoryDTO
            {
                Id = a.Id,
                Name = a.Name              
            }).ToList();
            return toreturn;
        }

        //Get Method
        public CategoryDTO GetCategory (Guid id)
        {
            var repoResult = _repo.GetCategory(id);

            return new CategoryDTO
            {
                Id = repoResult.Id,
                Name = repoResult.Name
            };
        }

        public void DeleteCategory(Guid id)
        {
            _repo.DeleteCategory(id);
        }

        public void AddOrUpdateCategory(CategoryDTO category)
        {
            var cat = new Category
            {
                Id = category.Id!= Guid.Empty ? category.Id : Guid.NewGuid(), //inline if
                Name = category.Name
            };

            if (category.Id != Guid.Empty)
            {
                //category exists ==> Update
                _repo.updateCategory(cat);
            }

            else
            {
                //category does no exist ==> Add
                _repo.AddCategory(cat);
            }
        }
    }
}
