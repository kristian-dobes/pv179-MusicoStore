using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UnitOfWorkController : ControllerBase
    {
        //private readonly IUnitOfWork _uow;

        //public UnitOfWorkController(IUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        //[HttpGet]
        //[Route("[controller]/fetch/images")]
        //public IActionResult FetchImages()
        //{
        //    var images = _uow.ImageRepository.GetAll();
        //    return Ok(images);
        //}

        //[HttpPost]
        //[Route("[controller]/fetch/images")]
        //public async Task<IActionResult> FetchImages(int id, IFormFile file, int id2, IFormFile file2)
        //{
        //    var before = _uow.ImageRepository.GetAll().Count();

        //    await AddImageToRepository(id, file);
        //    await AddImageToRepository(id2, file2);

        //    var after = _uow.ImageRepository.GetAll().Count();

        //    return Ok(new
        //    {
        //        BeforeCount = before,
        //        AfterCount = after,
        //    });
        //}

        //[HttpPost]
        //[Route("[controller]/fetch/images/save")]
        //public async Task<IActionResult> FetchImagesSaved(int id, IFormFile file, int id2, IFormFile file2)
        //{
        //    var before = _uow.ImageRepository.GetAll().Count();

        //    await AddImageToRepository(id, file);
        //    await AddImageToRepository(id2, file2);

        //    _uow.Commit();

        //    var after = _uow.ImageRepository.GetAll().Count();

        //    return Ok(new
        //    {
        //        BeforeCount = before,
        //        AfterCount = after,
        //    });
        //}

        //private async Task AddImageToRepository(int id, IFormFile file)
        //{
        //    _uow.ImageRepository
        //        .Add(new Image
        //        {
        //            Data = await file.GetBytes(),
        //            Id = id,
        //        });
        //}

        //[HttpGet]
        //[Route("[controller]/fetch/logs")]
        //public IActionResult FetchLogs()
        //{
        //    var logs = _uow.LogMessageRepository.GetAll();
        //    return Ok(logs);
        //}
    }
}
