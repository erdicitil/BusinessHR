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
            dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name)).ReverseMap().ForMember(dest => dest.Employees, opt => opt.Ignore());
            Mapper.Initialize(cfg);
            
        }
    }
}