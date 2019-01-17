using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PictureService.Data;
using PictureService.Models;

namespace PictureService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        public ApplicationDbContext _context { get; set; }
        public PicturesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<Picture> Get() => await _context.Pictures.FirstOrDefaultAsync();

        [Route("Amount")]
        [HttpGet]
        public async Task<int> Amount()
        {
            List<Picture> PictureList = new List<Picture>();
            PictureList = await _context.Pictures.ToListAsync();
            return PictureList.Count;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Picture Get(int id)
        {
            Picture currentPicture = _context.Pictures.Where(p => p.ID == id).SingleOrDefault();
            return currentPicture;
        }

        // POST api/values
        [Route("{name}")]
        [HttpPost]
        public async Task<Picture> Post(IFormFile Picture, string name)
        {
            Picture currentPicture = new Picture();
            currentPicture.Name = name;
            using (var ms = new MemoryStream())
            {
                await Picture.CopyToAsync(ms);
                currentPicture.PictureFile = ms.ToArray();
            }
            await _context.Pictures.AddAsync(currentPicture);
            await _context.SaveChangesAsync();
            List<Picture> PictureList = new List<Picture>();
            PictureList = await _context.Pictures.ToListAsync();
            currentPicture = PictureList[PictureList.Count - 1];
            return currentPicture;
        }
    }
}
