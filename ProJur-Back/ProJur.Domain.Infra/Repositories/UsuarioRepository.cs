using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProJur.Domain.Application.Entities;
using ProJur.Domain.Application.Repositories;
using ProJur.Domain.Infra.Context;

namespace ProJur.Domain.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ProjurContext _context;

        public UsuarioRepository(ProjurContext context)
        {
            _context = context;
        }

        public Task Create(Usuario item)
        {
            _context.Usuarios.Add(item);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(Usuario item)
        {
            _context.Usuarios.Remove(item);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Update(Usuario item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }
    }
}