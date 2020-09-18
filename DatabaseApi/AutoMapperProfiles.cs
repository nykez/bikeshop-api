using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Configuration.Conventions;
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
            CreateMap<RetailstoreToCreate, Retailstore>();
            CreateMap<RetailstoreToUpdate, Retailstore>();
            CreateMap<Retailstore, RetailstoreToUpdate>();
            CreateMap<CityToCreate, City>();
            CreateMap<CityToUpdate, City>();
            CreateMap<City, CityToUpdate>();
            CreateMap<BikepartsToCreate, Bikeparts>();
            CreateMap<BikepartsToUpdate, Bikeparts>();
            // Bicycles D
            // Bike Parts CRUD
            // Cities CRUD
            // Customer D
            // Manufacturers CRUD
            // For sprint 2. Model Table CRU;
        }

    }
}