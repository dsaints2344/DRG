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
        }
    }
}
