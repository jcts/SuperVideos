using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace SuperVideos.Application.Contracts
{
    public interface IBaseApp<T> : IDisposable where T : class
    {
        void Create(T model);
        void Delete(T model);
        void Update(T model);
        T GetById(Guid id);
        ICollection<T> GetAll();
        IPagedList<T>  Pagination(int page, int registerPerPage);
    }
}
