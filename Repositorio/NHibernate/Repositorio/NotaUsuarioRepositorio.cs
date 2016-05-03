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
    public class NotaUsuarioRepositorio : RepositorioBase<NotaUsuario>, INotaUsuarioRepositorio
    {
        public new IList<NotaUsuario> RetornaTodos(int _empId)
        {
            string hql = "from NotaUsuario";
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                try
                {
                    IQuery q = session.CreateQuery(hql);
                    IList<NotaUsuario> m = q.List<NotaUsuario>();
                    if (m.Count > 0)
                        return (IList<NotaUsuario>)m;
                    else
                        return null;
                }
                catch
                {
                    return new List<NotaUsuario>();
                }
            }
        }

        public NotaUsuario RetornaPorDescricao(int _empId, string _crgDescricao)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                string hql = "from NotaUsuario as c where c.empId.empId = " + _empId + " and c.crgDescricao = '" + _crgDescricao + "'";
                return session.CreateQuery(hql).List<NotaUsuario>().FirstOrDefault();
            }
        }

        public new IList<NotaUsuario> RetornaPorHql(string _hql)
        {
            using (ISession session = ConexaoNHibernate.OpenSession())
            {
                IQuery q = session.CreateQuery(_hql);
                IList<NotaUsuario> m = q.List<NotaUsuario>();
                if (m.Count > 0)
                    return (IList<NotaUsuario>)m;
                else
                    return null;
            }
        }
    }
}
