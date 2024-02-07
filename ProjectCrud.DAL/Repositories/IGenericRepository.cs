using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrud.DAL.Repositories
{
    public  interface IGenericRepository<TEntityModel> where TEntityModel:class
    {
        Task<bool> Insert(TEntityModel model);
        Task<bool> Update(TEntityModel model);
        Task<bool> Delete(int Id);
        Task<TEntityModel> GetById(int Id);
        Task<IQueryable<TEntityModel>> GetAll();
    }
}
