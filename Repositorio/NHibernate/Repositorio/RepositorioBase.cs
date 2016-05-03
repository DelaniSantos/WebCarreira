using System;
using System.Linq;
using System.Collections.Generic;
using Dominio.IRepositorio;
using NHibernate;
using NHibernate.Criterion;
using Repositorio.NHibernate.Conexao;
using System.Collections.ObjectModel;
using System.Collections;
using Dominio.Entidades;

namespace Repositorio.NHibernate.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public T RetornaPorId(int id)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
                return session.Get<T>(id);
        }

        public IList<T> RetornaTodos(int empId)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
                return new Collection<T>(session.CreateCriteria(typeof(T)).List<T>());
        }

        public IList<T> RetornaPorHql(string hql)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())

                return session.CreateQuery(hql).List<T>();
        }

        public virtual IList<object> RetornaConsultaHql(string hql)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                IQuery query = session.CreateQuery(hql);                
                return query.List<object>();
                //IList<object> obj = query.List<object>();
                //IList<Dictionary<string, object>> retorno = new List<Dictionary<string, object>>();
                //foreach (object[] x in obj)
                //{
                //    Dictionary<string, object> row = new Dictionary<string, object>();
                //    for (int i = 0; i < campoSelect.Count; i++)
                //    {
                //        row.Add(campoSelect[i].ToString(), x[i]);

                //    }
                //    retorno.Add(row);
                //}
                //return retorno;
            }
        }

        public string RetornaTesteConexao(string _server, string _database, string _usuario, string _senha)
        {
            return null;
        }

        public T Salvar(T entity)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();                    
                }
            }
            return entity;
        }

        public T Excluir(T entity)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
            return entity;
        }
    }
}
