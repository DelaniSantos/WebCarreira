using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;

namespace Repositorio.NHibernate.Conexao
{
    public class ConexaoMysql
    {
        public static ISessionFactory SessionFactory()
        {
            return Fluently.Configure()
                 .Database(FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(
                             c => c.FromConnectionStringWithKey("MySql")
                     )
                 )
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ConexaoNHibernate>())
                //
                // Cria as tabelas do Banco de Dados
                //
                //.ExposeConfiguration(cfg =>
                // {
                //     new SchemaExport(cfg)
                //       .Create(false, true);
                // })
                 .BuildSessionFactory();
        }
    }
}
