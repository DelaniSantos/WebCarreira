using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.IRepositorio;
using Dominio.Entidades;

namespace Dominio.Servicos
{
    public class CarreiraServico
    {
        // Repositórios que este serviço usa          
        private readonly ICarreiraRepositorio _repositorio;

        public CarreiraServico(ICarreiraRepositorio CarreiraRepositorio)
        {
            _repositorio = CarreiraRepositorio;
        }

        public virtual Carreira RetornaPorId(int _id)
        {
            return _repositorio.RetornaPorId(_id);
        }

        public virtual Carreira RetornaPorDescricao(int _empId, string _crgDescricao)
        {
            return _repositorio.RetornaPorDescricao(_empId, _crgDescricao);
        }

        public virtual IList<Carreira> RetornaPorHql(string hql)
        {
            return _repositorio.RetornaPorHql(hql);
        }

        public virtual IList<Carreira> RetornaTodos(int _empId)
        {
            return _repositorio.RetornaTodos(_empId);
        }

        public virtual void Salvar(Carreira obj)
        {
            _repositorio.Salvar(obj);
        }

        public virtual void Excluir(Carreira obj)
        {
            _repositorio.Excluir(obj);
        }
    }
}
