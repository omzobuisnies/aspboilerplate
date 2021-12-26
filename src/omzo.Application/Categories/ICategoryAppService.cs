using Abp.Application.Services;
using Abp.Application.Services.Dto;
using omzo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omzo.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<
     CategoryDto>
    {
    }
}
