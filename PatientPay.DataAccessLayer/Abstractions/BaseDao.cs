using AutoMapper;
using PatientPay.BusinessObjects.Abstractions;
using PatientPay.DataAccessLayer.Context;
using PatientPay.DatabaseEntities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


//necessary methods, get all, get selected with expression filtering, get single by id, get single by expression, insert, update, delete

namespace PatientPay.DataAccessLayer.Abstractions
{
    public abstract class BaseDao: IDao
    {
        private PayContext _testContext;  //for testing purposes

        public BaseDao() { }
        public BaseDao(PayContext testContext)
        {
            _testContext = testContext;
        }

        //to generate a disposable context for each transaction
        protected PayContext GetDbContext()
        {
            if (_testContext != null) { return _testContext; }

            return new PayContext();
        }

        public IMapper Mapper
        {
            get { return Mapping.GetMapper(); }
        }

        protected IEnumerable<TResult> GetAllAsInfo<TEntity, TResult>() where TEntity : class, IEntity
        {
            var allEntity = GetAll<TEntity>();
            var allData = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResult>>(allEntity);
            return allData;
        }

        protected IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Set<TEntity>().ToList();
            }
        }

        protected TResult GetSingleAsInfo<TEntity, TResult>(int id)where TEntity : class, IEntity
        {
            var entity = GetSingle<TEntity>(id);
            var data = Mapper.Map<TEntity, TResult>(entity);
            return data;
        }

        protected TEntity GetSingle<TEntity>(int id) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Set<TEntity>().Find(id);
            }
        }

        protected IEnumerable<TResult> GetAllFilteredAsInfo<TEntity, TResult>(Expression<Func<TEntity, bool>> func) where TEntity : class, IEntity
        {
            var allFilteredEntities = GetAllFiltered(func);
            var allFilteredData = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResult>>(allFilteredEntities);
            return allFilteredData;
        }

        protected IEnumerable<TEntity> GetAllFiltered<TEntity>(Expression<Func<TEntity, bool>> func) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Set<TEntity>().Where(func).ToList();
            }
        }

        protected TResult GetSingleFilteredAsInfo<TEntity, TResult>(Expression<Func<TEntity, bool>> func)where TEntity : class, IEntity
        {
            var entity = GetSingleFiltered(func);
            var data = Mapper.Map<TEntity, TResult>(entity);
            return data;
        }

        protected TEntity GetSingleFiltered<TEntity>(Expression<Func<TEntity, bool>> func) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Set<TEntity>().Where(func).FirstOrDefault();
            }
        }

        protected int AddFromData<TData, TEntity>(TData data) where TData : IData where TEntity : class, IEntity
        {
            var entity = Mapper.Map<TData, TEntity>(data);
            return Add(entity);
        }

        protected int Add<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                payContext.Set<TEntity>().Add(entity);
                return payContext.SaveChanges();
            }
        }

        protected int UpdatePartial<TEntity>(dynamic partialEntity) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                TEntity oldEntity = payContext.Set<TEntity>().Find(partialEntity.Id);
                if (oldEntity == null)
                {
                    return 0;
                }

                payContext.Entry(oldEntity).CurrentValues.SetValues(partialEntity);
                return payContext.SaveChanges();
            }
        }

        protected int UpdateFromData<TData, TEntity>(TData data) where TData : IData where TEntity : class, IEntity
        {
            var entity = Mapper.Map<TData, TEntity>(data);
            return Update(entity);
        }

        protected int Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                TEntity formerEntity = payContext.Set<TEntity>().Find(entity.Id);

                PropertyInfo[] properties = typeof(TEntity).GetProperties();
                foreach (var property in properties)
                {
                    object value = property.GetMethod.Invoke(entity, null);
                    Type propType = property.PropertyType;

                    if (propType.GetProperty("Count") != null) continue;    //if it is a collection

                    if (propType.IsValueType && !Activator.CreateInstance(propType).Equals(value))  //if it is a value type and it is not default value
                    {
                        property.SetMethod.Invoke(formerEntity, new[] { value });
                    }
                    else if (!propType.IsValueType && value != null)               //if it is a reference type and it is not null
                    {
                        property.SetMethod.Invoke(formerEntity, new[] { value });
                    }
                }

                return payContext.SaveChanges();
            }
        }

        protected int Delete<TEntity>(int id) where TEntity : class, IEntity
        {
            using (var payContext = GetDbContext())
            {
                var entity = payContext.Set<TEntity>().Find(id);
                payContext.Set<TEntity>().Remove(entity);
                return payContext.SaveChanges();
            }
        }
    }
}
