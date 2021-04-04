using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FamilyImageViewerApi.models;
using FamilyImageViewerApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyImageViewerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyImageViewerController : Controller

    {
        private readonly IFamily _family;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FamilyImageViewerController(IFamily family,IWebHostEnvironment webHostEnvironment)
        {
            this._family = family;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        // GET: FamilyImageViewer
        public ActionResult FamilyMembers()
        {
            var model = _family.GetAll();
             var newModel=   model.Select(x => new Family()
                {
                    FamilyId = x.FamilyId,
                    FamilyFirstName = x.FamilyFirstName,
                    FamilyLastName = x.FamilyLastName,
                    BirthDate = x.BirthDate,
                    Quote = x.Quote,
                    Relation = x.Relation,
                    ImageName = x.ImageName,
                    ImageSrc = 
                    String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)
                }).ToList();
            
           
            return Ok(newModel);
        }

        [HttpGet("{id}")]
        // GET: FamilyImageViewer/Details/5
        public ActionResult FamilyMember(int id)
        {
            var familyMember = _family.GetById(id);
            familyMember.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, familyMember.ImageName);
            if (familyMember == null)
            {
                return NotFound();
            }
            return Ok(familyMember);
        }

    
        // POST: FamilyImageViewer/Create
        [HttpPost]
       
        public async Task <ActionResult> Create([FromForm] Family family)
        {

            if (family == null)
            {
                return BadRequest(ModelState);
            }
            family.ImageName = await SaveImage(family.ImageFile);
            if (!_family.CreateFamilyMember(family))
            {
                ModelState.AddModelError("", "Error in saving entry");
                return StatusCode(500, ModelState);
            }

            return Ok();
           //return CreatedAtAction(nameof(FamilyMember), new { id = family.FamilyId }, family);
        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult> Edit(int id, [FromForm] Family family)
        {
            if (!_family.FamilyMemberIdExists(id))
            {
                return NotFound();
            }

            if (family.ImageFile!=null)
            {
                DeleteImage(family.ImageName);
                family.ImageName = await SaveImage(family.ImageFile);

            }

            if (!_family.UpdateFamilyMember(family)
)
            {
                ModelState.AddModelError("", "error in updating");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_family.FamilyMemberIdExists(id))
            {
                return NotFound();
            }
            var member = _family.GetById(id);
            if (!_family.DeleteFamilyMember(member))
            {
                ModelState.AddModelError("", "Erroe in deleting record");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {

            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray());
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);

            using(var filestream= new FileStream(imagePath, FileMode.Create))
            {
              await  imageFile.CopyToAsync(filestream);
            }
            return imageName;

        }


        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}