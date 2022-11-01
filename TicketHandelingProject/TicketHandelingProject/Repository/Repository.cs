using System.Collections.Generic;
using System.Linq;
using TicketHandelingProject.Models;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly Ticket_Handeling_ProjectContext _context;
        public Repository(Ticket_Handeling_ProjectContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _context.Remove<T>(entity);
        }

        public void Remove(int id)
        {
            var entity = _context.Find<T>(id);
            _context.Remove<T>(entity);
        }
        public void Update(T entity)
        {
            _context.Update<T>(entity);
        }
    }
}

