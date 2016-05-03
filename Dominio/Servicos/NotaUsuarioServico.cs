using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.IRepositorio;
using Dominio.Entidades;

namespace Dominio.Servicos
{
    public class NotaUsuarioServico
    {
        // Repositórios que este serviço usa          
        private readonly INotaUsuarioRepositorio _repositorio;

        public NotaUsuarioServico(INotaUsuarioRepositorio NotaUsuarioRepositorio)
        {
            _repositorio = NotaUsuarioRepositorio;
        }

        public virtual NotaUsuario RetornaPorId(int _id)
        {
            return _repositorio.RetornaPorId(_id);
        }

        

        public virtual IList<NotaUsuario> RetornaPorHql(string hql)
        {
            return _repositorio.RetornaPorHql(hql);
        }

        public virtual IList<NotaUsuario> RetornaTodos(int _empId)
        {
            return _repositorio.RetornaTodos(_empId);
        }

        public virtual void Salvar(NotaUsuario obj)
        {
            _repositorio.Salvar(obj);
        }

        public virtual void Excluir(NotaUsuario obj)
        {
            _repositorio.Excluir(obj);
        }
    }
}
