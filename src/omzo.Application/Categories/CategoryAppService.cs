using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using omzo.Authorization;
using omzo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omzo.Categories
{
    [AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedAndSortedResultRequestDto, CreateCategoryDto, CategoryDto>
    {
        private readonly IRepository<Category,int> _categoryRepository;

        public CategoryAppService(IRepository<Category, int> repository) : base(repository)
        {
            _categoryRepository = repository;
        }
        public async Task ActiveAsync(EntityDto<int> id)
        {
            var cat = _categoryRepository.Get(id.Id);
            if (cat!=null)
            {
                cat.Published = true;
                await _categoryRepository.UpdateAsync(cat);
            }

        }
        public async Task SamplemethodAsync(EntityDto<int> input)
        {
            var cat = _categoryRepository.Get(input.Id);
            if (cat!=null)
            {
                var count=_categoryRepository.GetAll().Count();
                cat.Name += count;
                await _categoryRepository.UpdateAsync(cat);
            }

        }

    }
    #region oldcode
    //    [AbpAuthorize(PermissionNames.Pages_Categories)]
    //    public class CategoryAppService : AsyncCrudAppService<
    //Category, CategoryDto, int, PagedAndSortedResultRequestDto,
    //CategoryDto>, ICategoryAppService
    //    {
    //        private readonly IRepository<Category> _categoryRepository;

    //        public CategoryAppService(IRepository<Category> repository) : base(repository)
    //        {
    //            _categoryRepository = repository;
    //        }

    //        //public override async Task<CategoryDto> CreateAsync(CreateCategory input)
    //        //{
    //        //    CheckCreatePermission();

    //        //    // Create tenant
    //        //    //var cat = ObjectMapper.Map<Category>(input);
    //        //    var catcount = _categoryRepository.GetAll().Count();
    //        //    var categ = new Category
    //        //    {
    //        //        Description = input.Description,
    //        //        Id = catcount + 1,
    //        //        Name = input.Name
    //        //    };

    //        //    await _categoryRepository.InsertAsync(categ);
    //        //    await CurrentUnitOfWork.SaveChangesAsync(); // To get new tenant's id.



    //        //    return MapToEntityDto(categ);
    //        //}

    //    } 
    #endregion
}
