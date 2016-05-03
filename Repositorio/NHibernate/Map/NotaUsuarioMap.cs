using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace Repositorio.NHibernate.Map
{
    public class NotaUsuarioMap : ClassMap<NotaUsuario>
    {
        public NotaUsuarioMap()
        {            
            Table("notausuario");
            Id(x => x.notId);
            Map(x => x.notUsuario);
            Map(x => x.notNota);
            Map(x => x.carId);


        }
    }
}
