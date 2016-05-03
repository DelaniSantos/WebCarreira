using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace Repositorio.NHibernate.Map
{
    public class CarreiraMap : ClassMap<Carreira>
    {
        public CarreiraMap()
        {            
            Table("carreira");
            Id(x => x.carId);
            Map(x => x.carDescricao);
            
        }
    }
}
