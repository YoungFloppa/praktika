using Models;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EntityService<T> : IEntityService<T> where T : EntityBase
    {
        IUnitOfWork _unitOfWork;
        IRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Create(entity);
            _unitOfWork.Save();
        }

        public virtual void CreateMultiple(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            if (!entities.Any())
            {

            }
            foreach (T entity in entities)
            {
                _repository.Create(entity);
            }
            _unitOfWork.Save();
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
          return  _repository.GetAll().ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetAll(predicate).ToList();
        }

        public virtual T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Save();
        }
    }
}
