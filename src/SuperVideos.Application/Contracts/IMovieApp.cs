using SuperVideos.Application.Models;
using System;

namespace SuperVideos.Application.Contracts
{
    public interface IMovieApp : IBaseApp<MovieViewModel>
    {
        MovieViewModel GetByCode(long code);
        void Delete(Guid code);
        void SetUnavailable(Guid id);
        void SetAvailable(Guid id);
    }
}
