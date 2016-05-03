using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using System.Configuration;

namespace Repositorio.NHibernate.Conexao
{
    public class ConexaoNHibernate
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

        private static ISessionFactory SessionFactory()
        {
            if (_sessionFactory != null)
                return _sessionFactory;

            //string _BancoDados = ConfigurationSettings.AppSettings["NomeBancoDados"].ToString().ToLower();
            string _BancoDados = "sqlite";
            switch (_BancoDados)
            {
                case "mysql":
                    _sessionFactory = Conexao.ConexaoMysql.SessionFactory();
                    break;
                case "sqlite":
                    _sessionFactory = ConexaoSQLite.SessionFactory();
                    break;
                case "sqlserver":
                    _sessionFactory = ConexaoSQLServer.SessionFactory();
                    break;
            }
            return _sessionFactory;
        }
    }
}
