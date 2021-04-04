using FamilyImageViewerApi.models;
using FamilyImageViewerApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyImageViewerApi.Data;
using Microsoft.AspNetCore.Hosting;

namespace FamilyImageViewerApi.Repository
{
    public class FamilyRepository : IFamily
    {
        private readonly FamilyImageViewerApiDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FamilyRepository(FamilyImageViewerApiDbContext context, IWebHostEnvironment hostEnvironment)
        {
            this._context = context;
            this._hostEnvironment = hostEnvironment;
        }


        public bool CreateFamilyMember(Family family)
        {
            _context.Add(family);
            return save();
        }

        public bool DeleteFamilyMember(Family family)
        {
            _context.Remove(family);
            return save();
        }

        public bool FamilyMemberIdExists(int id)
        {
            return _context.Families.Any(member => member.FamilyId == id);
        }

        public IEnumerable<Family> GetAll()
        {
            return _context.Families.ToList();
           

        }

        public Family GetById(int id)
        {
            return _context.Families.FirstOrDefault(member => member.FamilyId == id);
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFamilyMember(Family family)
        {
            _context.Families.Update(family);
            return save();
        }
    }
}
