using housewarming78.Domain;
using housewarming78.Domain.Entities;
using housewarming78.Service;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.IO;
using System.Text.RegularExpressions;

namespace housewarming78.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RealEstatesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public RealEstatesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var enity = id == default ? new RealEstate() : dataManager.RealEstates.GetRealEstateById(id);
            return View(enity);
        }
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [HttpPost]
        public IActionResult Edit(RealEstate model, [FromForm] IFormFileCollection imagesFiles, [FromForm] IFormFile? titleImageFile)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (Regex.IsMatch(model.CountRooms, @"^\d+$"))
            {
                model.Title = model.CountRooms + "-комн. квартира, " + model.TotalArea + "м²";
            }
            else
            {
                model.Title = model.CountRooms + ", " + model.TotalArea + "м²";
            }
            model.MetaTitle = model.Title;
            model.MetaDescription = model.Title;
            model.MetaKeywords = model.Title;

            dataManager.RealEstates.SaveRealEstate(model);

            if (titleImageFile != null)
            {
                model.TitleImagePath = titleImageFile.FileName;
                Directory.CreateDirectory(Path.Combine(hostingEnvironment.WebRootPath, "img/", model.Id.ToString("N").ToUpper()));
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/", model.Id.ToString("N").ToUpper(), titleImageFile.FileName) , FileMode.Create))
                {
                    titleImageFile.CopyTo(stream);
                }
            }
            if (imagesFiles != null)
            {
                if (imagesFiles.Count() > 0)
                {
                    foreach (var image in imagesFiles)
                    {
                        model.ImagesPaths.Add(image.FileName);
                        using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/", model.Id.ToString("N").ToUpper(), image.FileName), FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }
                    }
                }    
            }


            dataManager.RealEstates.SaveRealEstate(model);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Directory.Delete(Path.Combine(hostingEnvironment.WebRootPath, "img/", id.ToString("N").ToUpper()), true);
                dataManager.RealEstates.DeleteRealEstate(id);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
