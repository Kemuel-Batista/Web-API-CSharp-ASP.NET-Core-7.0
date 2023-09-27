using AutoMapper;
using WebApiYoutube.Domain.DTOs;
using WebApiYoutube.Domain.Models;

namespace WebApiYoutube.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}
