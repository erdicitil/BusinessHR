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
            dest => dest.Employees, opt => opt.Ignore());
            dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name)).ReverseMap().ForMember(dest => dest.Employees, opt => opt.Ignore()).ForMember(dest => dest.Regions, opt => opt.Ignore()).ForMember(dest => dest.Companies, opt => opt.Ignore());


            cfg.CreateMap<Country, CountryViewModel>().ReverseMap().ForMember(
                dest => dest.Employees, opt => opt.Ignore()).ForMember(
                dest => dest.Cities, opt => opt.Ignore()).ForMember(
                dest => dest.Companies, opt => opt.Ignore());

            cfg.CreateMap<Salary, SalaryViewModel>().ReverseMap().ForMember(
              dest => dest.Employees, opt => opt.Ignore());


            //en altta kalsın
            Mapper.Initialize(cfg);
            
        }
    }
}