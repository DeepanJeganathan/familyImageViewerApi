using FamilyImageViewerApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyImageViewerApi.Services
{
    public interface IFamily
    {

        IEnumerable<Family> GetAll();
        Family GetById(int id);
        bool FamilyMemberIdExists(int id);
        bool CreateFamilyMember(Family family);
        bool UpdateFamilyMember(Family family);
        bool DeleteFamilyMember(Family family);
        bool save();
    }
}
