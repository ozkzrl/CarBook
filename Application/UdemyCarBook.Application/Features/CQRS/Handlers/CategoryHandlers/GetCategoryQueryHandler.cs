using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _Repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _Repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>>Handle()
        {
            var values= await _Repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Name=x.Name,
                CategoryID=x.CategoryID
            }).ToList();
        }
    }
}
