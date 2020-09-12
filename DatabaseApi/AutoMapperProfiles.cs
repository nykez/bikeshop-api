using System.Linq;
using AutoMapper;
using DatabaseApi.Dtos;

namespace DatabaseApi
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerToCreate, Customer>();
<<<<<<< Updated upstream
            CreateMap<CustomerToUpdate, Customer>();
            CreateMap<Customer, CustomerToUpdate>();
=======
            CreateMap<BicycleToCreate, Bicycle>();
            
>>>>>>> Stashed changes
        }
    }
}