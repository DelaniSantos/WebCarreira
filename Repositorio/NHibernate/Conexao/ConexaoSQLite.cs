using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;

namespace Repositorio.NHibernate.Conexao
{
    public class ConexaoSQLite
    {
        public static ISessionFactory SessionFactory()
        {
            return Fluently.Configure()
                 .Database(SQLiteConfiguration.Standard.ConnectionString(
                             c => c.FromConnectionStringWithKey("SQLite")
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
