using Microsoft.EntityFrameworkCore;
using ProjectCrud.DAL.DataContext;
using ProjectCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrud.DAL.Repositories
{
    public class ContactRepository : IGenericRepository<Contacto>
    {
        private readonly AspncapasContext _dbContext;

        public ContactRepository(AspncapasContext context)
        {
            this._dbContext = context;
        }


        public async Task<bool> Delete(int Id)
        {
           var modelo = _dbContext.Contactos
                .First(c=>c.IdContacto == Id);

            if(modelo == null)
            {
                return false;
            }
            _dbContext.Contactos.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            IQueryable<Contacto> queryableContacto = _dbContext
                .Contactos;
            return queryableContacto;
        }

        public async Task<Contacto> GetById(int Id)
        {
            return await _dbContext.Contactos.FindAsync(Id);
        }

        public async Task<bool> Insert(Contacto model)
        {
            _dbContext.Contactos.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Contacto model)
        {
            _dbContext.Contactos.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
