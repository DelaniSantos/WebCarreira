using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using Repositorio.NHibernate.Conexao;
using NHibernate;
using Dominio.IRepositorio;

namespace Repositorio.NHibernate.Repositorio
{
    public class CarreiraRepositorio : RepositorioBase<Carreira>, ICarreiraRepositorio
    {
        public IList<Carreira> RetornaTodos()
        {
            string hql = "from Carreira";
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                IQuery q = session.CreateQuery(hql);
                IList<Carreira> m = q.List<Carreira>();
                if (m.Count > 0)
                    return (IList<Carreira>)m;
                else
                    return null;
            }
        }

        public Carreira RetornaPorDescricao(int _empId, string _crgDescricao)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                string hql = "from Carreira as c where c.empId.empId = " + _empId + " and c.crgDescricao = '" + _crgDescricao + "'";
                return session.CreateQuery(hql).List<Carreira>().FirstOrDefault();
            }
        }

        public new IList<Carreira> RetornaPorHql(string _hql)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                IQuery q = session.CreateQuery(_hql);
                IList<Carreira> m = q.List<Carreira>();
                if (m.Count > 0)
                    return (IList<Carreira>)m;
                else
                    return null;
            }
        }
    }
}
