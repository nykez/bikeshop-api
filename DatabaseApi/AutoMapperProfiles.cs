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
            CreateMap<RetailstoreToCreate, Retailstore>();
            CreateMap<RetailstoreToUpdate, Retailstore>();
            // Bicycles CRUD
            // Bike Parts CRUD
            // Cities CRUD
            // Customer CRUD
            // Manufacturers CRUD
            // For sprint 2. Model Table CRUD
        }
    }
}