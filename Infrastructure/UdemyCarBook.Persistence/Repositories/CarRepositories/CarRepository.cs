using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.CarBookContext;
namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookDbContext _context;

        public CarRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public List<Car> GetCarWithBrands()
        {
            var values=_context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }
    }
}
