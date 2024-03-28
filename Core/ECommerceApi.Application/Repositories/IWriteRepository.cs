using ECommerceApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        //insert-update-delete
        //solid'e uygunluk, okuma ve manipulasyon interfacelerinin ayirdik
        //single - resp
        //interface seg
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas); //gelen collection'u db'ye ekleme, AddAsync'in overload'i olusturuldu 
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task <bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
