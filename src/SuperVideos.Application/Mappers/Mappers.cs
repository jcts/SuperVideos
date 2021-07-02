using SuperVideos.Application.Models;
using SuperVideos.Domain.Entities;

namespace SuperVideos.Application.Mappers
{
    public static class Mappers
    {
        public static AutoMapper.MapperConfiguration Mappings
           => new(cfg =>
           {
               _ = cfg.CreateMap<Movie, MovieViewModel>();
               _ = cfg.CreateMap<MovieViewModel, Movie>();

           });
    }
}