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
            CreateMap<CustomerToUpdate, Customer>();
            CreateMap<Customer, CustomerToUpdate>();
            CreateMap<BicycleToCreate, Bicycle>();
            CreateMap<BicycleToUpdate, Bicycle>();
            CreateMap<Bicycle, BicycleToUpdate>();
            // Bicycles D
            // Bike Parts CRUD
            // Cities CRUD
            // Customer D
            // Manufacturers CRUD
            // Retail Stores CRUD
            // Model Table CRUD
        }
    }
}