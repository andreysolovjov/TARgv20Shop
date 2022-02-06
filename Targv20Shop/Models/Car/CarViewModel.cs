using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Targv20Shop.Models.Files;

namespace Targv20Shop.Models.Car
{
    public class CarViewModel
    {
        public Guid? Id { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public double CarPrice { get; set; }
        public int CarAmount { get; set; }
        public DateTime CarCreatedAt { get; set; }
        public DateTime CarModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();
    }
}
