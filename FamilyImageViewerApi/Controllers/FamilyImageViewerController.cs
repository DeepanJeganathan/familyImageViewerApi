using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyImageViewerApi.models;
using FamilyImageViewerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyImageViewerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyImageViewerController : Controller

    {
        private readonly IFamily _family;

        public FamilyImageViewerController(IFamily family)
        {
            this._family = family;
        }

        [HttpGet]
        // GET: FamilyImageViewer
        public ActionResult FamilyMembers()
        {

            return Ok(_family.GetAll());
        }

        [HttpGet("{id}")]
        // GET: FamilyImageViewer/Details/5
        public ActionResult FamilyMember(int id)
        {
            var familyMember = _family.GetById(id);
            if (familyMember == null)
            {
                return NotFound();
            }
            return Ok(familyMember);
        }

    
        // POST: FamilyImageViewer/Create
        [HttpPost]
       
        public ActionResult Create([FromBody] Family family)
        {
            if (family == null)
            {
                return BadRequest(ModelState);
            }
            if (!_family.CreateFamilyMember(family))
            {
                ModelState.AddModelError("", "Error in saving entry");
                return StatusCode(500, ModelState);
            }

            return Ok();
           //return CreatedAtAction(nameof(FamilyMember), new { id = family.FamilyId }, family);
        }

        [HttpPatch("{id}")]
        
        public ActionResult Edit(int id, [FromBody] Family family)
        {
            if (!_family.FamilyMemberIdExists(id))
            {
                return NotFound();
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

    }
}