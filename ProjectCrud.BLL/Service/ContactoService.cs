using Microsoft.EntityFrameworkCore;
using ProjectCrud.DAL.Repositories;
using ProjectCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrud.BLL.Service
{
    public class ContactoService : IContactoService
    {
        private readonly IGenericRepository<Contacto> _contactRepository;

        public ContactoService(IGenericRepository<Contacto> contactRepository)
        {
            this._contactRepository = contactRepository;
        }


        public async Task<bool> Delete(int Id)
        {
          return await _contactRepository.Delete(Id);
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            return await _contactRepository.GetAll();
        }



        public async Task<Contacto> GetByName(string Name)
        {
            IQueryable<Contacto> query = await _contactRepository.GetAll();
            Contacto contact = query.Where(c => c.Nombre == Name).FirstOrDefault();
            return contact;
        }



        public async Task<Contacto> GetById(int Id)
        {
            return await _contactRepository.GetById(Id);
        }

        public async Task<bool> Insert(Contacto model)
        {
            return await _contactRepository.Insert(model);
        }

        public async Task<bool> Update(Contacto model)
        {
           return await _contactRepository.Update(model);
        }
    }
}
