using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NhibernateHelper _nHibernateHelper;
        IQueryable<T> _entities;

        public NhQueryableRepository(NhibernateHelper nhibernateHelper)
        {
            _nHibernateHelper = nhibernateHelper;
        }
        
        /*
        public IQueryable<T> Table { 
            get
            {
                return this.Entities;
            }
        }
        */

        public IQueryable<T> Table => this.Entities;

        /*
        public virtual IQueryable<T> Entities 
        { 
            get
            {
                if (_entities == null)
                {
                    _entities = _nHibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
        */

        public virtual IQueryable<T> Entities
        {
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
        }
    }
}
