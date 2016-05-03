using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;

namespace Dominio.IRepositorio
{
    public interface ICarreiraRepositorio : IRepositorioBase<Carreira>
    {
        IList<Carreira> RetornaTodos();
        new Carreira RetornaPorId(int id);
        Carreira RetornaPorDescricao(int _empId, string crgDescricao);
        new Carreira Salvar(Carreira obj);
        new Carreira Excluir(Carreira obj);
    }
}
