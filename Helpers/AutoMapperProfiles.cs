using AutoMapper;
using DataTransferObjects.KorisnikDTOs;
using DataTransferObjects.OdgovorDTOs;
using DataTransferObjects.PitanjeDTOs;
using DataTransferObjects.PricaDTOs;
using Domain;
using System;

namespace Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Prica, PricaForListDTO>();
            CreateMap<Prica, PricaForDetailsDTO>();
            CreateMap<Odgovor, OdgovorDTO>();
            CreateMap<OdgovorDTO, Odgovor>();
            CreateMap<Pitanje, PitanjeToGetDTO>();
            CreateMap<PitanjeToReturnDTO, Pitanje>()
                .ForMember(dest => dest.Odgovori,
                opt => opt.MapFrom(p => p.Odgovor.ConvertToList()));
            CreateMap<KorisnikToRegisterDTO, Korisnik>();
            CreateMap<Korisnik, KorisnikForResultDTO>();
            CreateMap<Pitanje, PitanjeToReturnDTO>()
                .ForMember(dest => dest.Odgovor,
                opt => opt.MapFrom(p => p.Odgovori.ConvertToOdgovor()));
        }
    }
}
