using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryReult>> Handle()
        {
            var values= await _repository.GetAllAsync();
            return values.Select(x => new GetCarWithBrandQueryReult
            {
            
                BrandID=x.BrandID,
                BigImageUrl=x.BigImageUrl,
                CarID=x.CarID,
                CoverImageurl=x.CoverImageurl,
                Fuel=x.Fuel,
                Km=x.Km,
                Louggage=x.Louggage,
                Model=x.Model,
                Seat=x.Seat,
                Transmission= x.Transmission
            }).ToList();
        }
    }
}
