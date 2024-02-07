using ProjectCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrud.BLL.Service
{
    public interface IContactoService
    {
        Task<bool> Insert(Contacto model);
        Task<bool> Update(Contacto model);
        Task<bool> Delete(int Id);
        Task<Contacto> GetById(int Id);
        Task<IQueryable<Contacto>> GetAll();

        Task<Contacto> GetByName(string Name);
    }
}
