using AutoMapper;
using DRG.Application.DTOs;
using DRG.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<APRDRGV36DTO, APRDRGV36>();
            CreateMap<APRDRGV38DTO, APRDRGV38>();

            CreateMap<HospitalDTO, Domain.Hospital>()
                .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.HospitalName))
                .ForMember(dest => dest.HospitalNPI, opt => opt.MapFrom(src => src.HospitalNPI))
                .ForMember(dest => dest.HospitalPhysicalCity, opt => opt.MapFrom(src => src.HospitalPhysicalCity))
                .ForMember(dest => dest.HospitalPhysicalStreetAddress, opt => opt.MapFrom(src => src.HospitalPhysicalStreetAddress))
                .ForMember(dest => dest.HospitalClass, opt => opt.MapFrom(src => src.HospitalClass))
                .ForMember(dest => dest.TIN, opt => opt.Ignore())
                .ForMember(dest => dest.CHIRPHospital, opt => opt.Ignore())
                .ForMember(dest => dest.HospitalRates, opt => opt.Ignore());


            CreateMap<HospitalRateDTO, HospitalRate>();
            CreateMap<CHIRPHospitalDTO, CHIRPHospital>();
        }
    }
}
