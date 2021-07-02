using AutoMapper;
using SuperVideos.Application.Contracts;
using SuperVideos.Application.Models;
using SuperVideos.Domain.Entities;
using SuperVideos.Domain.Entities.ValueObject;
using SuperVideos.SharedKernel.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SuperVideos.Application
{
    public sealed class MovieApp : IMovieApp
    {
        readonly IMapper _mapper;
        readonly MovieContext _movieContext;

        public MovieApp(MovieContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        public void Create(MovieViewModel model)
        {
            var entity = new Movie
            {
                Available = true,
                Delete = false,
                Gender = model.Gender,
                Id = model.Id,
                Title = model.Title,
                Synopsis = model.Synopsis,
                ContenType = model.ContenType,
                Sleeve = model.SleeveContent,
                MovieDetail = new MovieDetail
                {
                    BarCode = model.BarCode,
                    Code = model.Code,
                    Duration = model.Duration,
                    Isbn = model.Isbn
                }
            };

            _movieContext.Add(entity);

            _movieContext.SaveChanges();
        }

        public void Delete(MovieViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            var register = _movieContext.Movies.FirstOrDefault(c => c.Id == id);

            _movieContext.Movies.Remove(register);

            _movieContext.SaveChanges();
        }

        public void Dispose()
        {
            _movieContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public ICollection<MovieViewModel> GetAll()
        {
            var entities = _movieContext.Movies.ToList();

            return _mapper.Map<List<MovieViewModel>>(entities);
        }

        public MovieViewModel GetByCode(long code)
        {
            throw new NotImplementedException();
        }

        public MovieViewModel GetById(Guid id)
        {
            var entity = _movieContext.Movies.FirstOrDefault(c => c.Id == id);

            return new MovieViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Available = entity.Available,
                BarCode = entity.MovieDetail.BarCode,
                Code = entity.MovieDetail.Code,
                Duration = entity.MovieDetail.Duration,
                Gender = entity.Gender,
                Isbn = entity.MovieDetail.Isbn,
                Synopsis = entity.Synopsis,
                SleeveContent = entity.Sleeve,
                ContenType = entity.ContenType
            };
        }

        public IPagedList<MovieViewModel> Pagination(int page, int registerPerPage)
        {
            var entities = (from m in _movieContext.Movies
                            select new MovieViewModel
                            {
                                Id = m.Id,
                                Title = m.Title,
                                Available = m.Available,
                                BarCode = m.MovieDetail.BarCode,
                                Code = m.MovieDetail.Code,
                                Duration = m.MovieDetail.Duration,
                                Gender = m.Gender,
                                Isbn = m.MovieDetail.Isbn,
                                Synopsis = m.Synopsis
                            }).ToPagedList(page, registerPerPage);

            return entities;
        }

        public void SetAvailable(Guid id)
        {
            var entity = _movieContext.Movies.FirstOrDefault(c => c.Id == id);

            entity.Available = true;

            entity.UpdateOn = DateTime.Now;

            _movieContext.Movies.Update(entity);

            _movieContext.SaveChanges();
        }

        public void SetUnavailable(Guid id)
        {
            var entity = _movieContext.Movies.FirstOrDefault(c => c.Id == id);

            entity.Available = false;

            entity.UpdateOn = DateTime.Now;

            _movieContext.Movies.Update(entity);

            _movieContext.SaveChanges();
        }

        public void Update(MovieViewModel model)
        {
            var entity = new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Available = true,
                Delete = false,
                Gender = model.Gender,
                Synopsis = model.Synopsis,
                ContenType = model.ContenType,
                Sleeve = model.SleeveContent,
                MovieDetail = new MovieDetail
                {
                    BarCode = model.BarCode,
                    Code = model.Code,
                    Duration = model.Duration,
                    Isbn = model.Isbn
                }
            };

            entity.UpdateOn = DateTime.Now;

            _movieContext.Movies.Update(entity);

            _movieContext.SaveChanges();

        }
    }
}
