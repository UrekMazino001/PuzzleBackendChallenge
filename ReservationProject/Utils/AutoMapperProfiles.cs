using AutoMapper;
using ReservationProject.DTO;
using ReservationProject.Entities;

namespace ReservationProject.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClientDTO, Client>()
                .ForMember(c => c.Reservations, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ClientCreationDTO, Client>()
                 .ForMember(c => c.Reservations, opt => opt.Ignore());
            CreateMap<ClientUpdateDTO, Client>()
                 .ForMember(c => c.Reservations, opt => opt.Ignore());


            //CreateMap<List<Client>, List<ClientDTO>>()
            //     .ForMember(x => x., opt => opt.Ignore())
            //     .ReverseMap();

            //CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();

            //Mapeando un list<int> a un HashSet<Genero>
            //CreateMap<PeliculaCreacionDTO, Pelicula>()
            //    .ForMember(ent => ent.Generos, dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            //CreateMap<Actor, ActorDTO>();
        }
    }
}
