using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CommentsRepository : BaseRepository, IRepository<Comment>
    {

        public CommentsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Comment Add(Comment item)
        {
            _entities.Comments.Add(item);
            return item;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _entities.Comments;
        }

        public Comment Remove(Comment item)
        {
            _entities.Comments.Remove(item);
            return item;
        }

        public IList<Comment> RemoveList(IList<Comment> items)
        {
            _entities.Comments.RemoveRange(items);
            return items;
        }

        public Comment Update(Comment item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
