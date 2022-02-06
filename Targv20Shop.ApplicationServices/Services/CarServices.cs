using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using System.Linq;

namespace Targv20Shop.ApplicationServices.Services
{
    public class CarServices : ICarService
    {
        private readonly Targv20ShopDbContext _context;
        private readonly IFileServices _file;

        public CarServices
            (
                Targv20ShopDbContext context,
                IFileServices file
            )
        {
            _context = context;
            _file = file;
        }

        public async Task<Car> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathDto
                {
                    CarId = y.CarId,
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();


            var carId = await _context.Car
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.CarDescription = dto.CarDescription;
            car.CarName = dto.CarName;
            car.CarAmount = dto.CarAmount;
            car.CarPrice = dto.CarPrice;
            car.CarModifiedAt = DateTime.Now;
            car.CarCreatedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, car);

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Edit(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.CarDescription = dto.CarDescription;
            car.CarName = dto.CarName;
            car.CarAmount = dto.CarAmount;
            car.CarPrice = dto.CarPrice;
            car.CarModifiedAt = dto.CarModifiedAt;
            car.CarCreatedAt = dto.CarCreatedAt;
            _file.ProcessUploadedFile(dto, car);

            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
