using AutoMapper;
using AutoMapper.Configuration;
using BusinessHR.Admin.Models;
using BusinessHR.Model;

namespace BusinessHR.Admin
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<Certificate, CertificateViewModel>().ReverseMap().ForMember(
                dest => dest.Employees, opt => opt.Ignore());

            cfg.CreateMap<City, CityViewModel>().ForMember(
            dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name)).ReverseMap().ForMember(
            dest => dest.Employees, opt => opt.Ignore()).ForMember(dest => dest.Employees, opt => opt.Ignore()).ForMember(dest => dest.Regions, opt => opt.Ignore()).ForMember(dest => dest.Companies, opt => opt.Ignore());


            cfg.CreateMap<Country, CountryViewModel>().ReverseMap().ForMember(
                dest => dest.Employees, opt => opt.Ignore()).ForMember(
                dest => dest.Cities, opt => opt.Ignore()).ForMember(
                dest => dest.Companies, opt => opt.Ignore());

            cfg.CreateMap<Salary, SalaryViewModel>().ReverseMap().ForMember(
                dest => dest.Employees, opt => opt.Ignore());

            cfg.CreateMap<Region, RegionViewModel>().ForMember(
                dest => dest.CityName,
                opt => opt.MapFrom(src => src.City.Name)).ReverseMap().ForMember(
                dest => dest.City, opt => opt.Ignore()).ForMember(
                dest => dest.Employees, opt => opt.Ignore()).ForMember(
                dest => dest.Companies, opt => opt.Ignore());
              


            cfg.CreateMap<Company, CompanyViewModel>().ForMember(
            dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name)).ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name)).ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region.Name));
            //en altta kalsın
            Mapper.Initialize(cfg);
            
        }
    }
}