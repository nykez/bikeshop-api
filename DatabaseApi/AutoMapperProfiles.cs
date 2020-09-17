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
            CreateMap<RetailstoreToCreate, Retailstore>();
            CreateMap<RetailstoreToUpdate, Retailstore>();
            // Bicycles D
            // Bike Parts CRUD
            // Cities CRUD
            // Customer D
            // Manufacturers CRUD
            // For sprint 2. Model Table CRUD
        }
    }
}