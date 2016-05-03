using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarreiraDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dominio.Servicos.CarreiraServico _carreiraSer = new Dominio.Servicos.CarreiraServico(new Repositorio.NHibernate.Repositorio.CarreiraRepositorio());

        private void button1_Click(object sender, EventArgs e)
        {
            Dominio.Entidades.Carreira car = new Dominio.Entidades.Carreira();
            car.carDescricao = "Analista";
            _carreiraSer.Salvar(car);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource= this._carreiraSer.RetornaTodos(1);
        }
    }
}
