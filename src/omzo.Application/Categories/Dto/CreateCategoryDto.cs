using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omzo.Categories.Dto
{
    [AutoMapFrom(typeof(Category))]
    [AutoMapTo(typeof(Category))]
    public class CreateCategoryDto: EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }

    }
}
