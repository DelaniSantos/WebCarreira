using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Repositorio.NHibernate.Conexao
{
    public class ConexaoSQLServer
    {
        public static ISessionFactory SessionFactory()
        {
            return Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                             c => c.FromConnectionStringWithKey("SQLServer")
                     )
                 )
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ConexaoNHibernate>())
                 .ExposeConfiguration(c => c.Properties.Add("hbm2ddl.keywords", "none"))

                // Cria as tabelas do Banco de Dados

                //.ExposeConfiguration(cfg =>
                // {
                //     new SchemaExport(cfg)
                //       .Create(false, true);
                // })
                 .BuildSessionFactory();
        }
    }
}
