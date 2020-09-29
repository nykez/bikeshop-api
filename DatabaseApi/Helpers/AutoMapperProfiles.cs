using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Configuration.Conventions;
using DatabaseApi.Dtos;

namespace DatabaseApi
{
    public class AutoMapperProfiles: Profile
    {
        /// <summary>
        /// Maps models to Dtos
        /// </summary>
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
            CreateMap<ManufacturerToCreate, Manufacturer>();
            CreateMap<ManufacturerToUpdate, Manufacturer>();
            // For sprint 2. Model Table CRU;
        }

    }
}