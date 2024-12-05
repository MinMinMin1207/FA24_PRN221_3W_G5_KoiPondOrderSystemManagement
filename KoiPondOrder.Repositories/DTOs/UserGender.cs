using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories.DTOs
{
    public class UserGender
    {
        public static List<GendersModel> GetGenderList()
        {
            return new List<GendersModel>()
            {
                new GendersModel {Gender = "Male"},
                new GendersModel {Gender = "Female"},
                new GendersModel {Gender = "Other"}
            };
        }
    }

    public class GendersModel
    {
        public string Gender { get; set; } = null!;
    }
}
