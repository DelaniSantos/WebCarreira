using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades
{
    public class NotaUsuario
    {
        public virtual int notId { get; set; }
        public virtual int notNota { get; set; }
        public virtual string notUsuario { get; set; }

        public virtual int carId { get; set; }

        public virtual string notDescricaoCarreira { get; set; }
    }
}
