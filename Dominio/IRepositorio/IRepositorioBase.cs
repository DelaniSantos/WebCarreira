using System;
using System.Collections.Generic;
using System.Collections;

namespace Dominio.IRepositorio
{
    public interface IRepositorioBase<T>
    {
        T RetornaPorId(int id);
        IList<T> RetornaTodos(int empId);
        IList<T> RetornaPorHql(string hql);
        IList<object> RetornaConsultaHql(string hql);
        T Salvar(T item);
        T Excluir(T item);
    }
}
