using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using Targv20Shop.Models.Files;
using Targv20Shop.Models.Car;

namespace Targv20Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly Targv20ShopDbContext _context;
        private readonly ICarService _carService;
        private readonly IFileServices _fileService;

        public CarController
            (
                Targv20ShopDbContext context,
                ICarService carService,
                IFileServices fileService
            )
        {
            _context = context;
            _carService = carService;
            _fileService = fileService;
        }


        public IActionResult Index()
        {
            var result = _context.Car
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    CarName = x.CarName,
                    CarPrice = x.CarPrice,
                    CarAmmount = x.CarAmount,
                    CarDescription = x.CarDescription
                });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.Delete(id);

            if (car == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel model = new CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                CarDescription = model.CarDescription,
                CarName = model.CarName,
                CarAmount = model.CarAmount,
                CarPrice = model.CarPrice,
                CarModifiedAt = model.CarModifiedAt,
                CarCreatedAt = model.CarCreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.Edit(id);
            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();


            var model = new CarViewModel();

            model.Id = car.Id;
            model.CarDescription = car.CarDescription;
            model.CarName = car.CarName;
            model.CarAmount = car.CarAmount;
            model.CarPrice = car.CarPrice;
            model.CarModifiedAt = car.CarModifiedAt;
            model.CarCreatedAt = car.CarCreatedAt;
            model.ExistingFilePaths.AddRange(photos);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                CarDescription = model.CarDescription,
                CarName = model.CarName,
                CarAmount = model.CarAmount,
                CarPrice = model.CarPrice,
                CarModifiedAt = model.CarModifiedAt,
                CarCreatedAt = model.CarCreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                FilePath = model.FilePath
            };

            var image = await _fileService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
