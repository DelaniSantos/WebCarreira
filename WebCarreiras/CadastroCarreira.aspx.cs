using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCarreiras
{
    public partial class CadastroCarreira : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Server.Transfer("Default.aspx", true);

            }

            var lista = this._carreiraSer.RetornaTodos(1);
            if (lista.Count > 0)
            {
                Carreira car = new Carreira();
                car.carId = lista[0].carId;
                car.carDescricao = lista[0].carDescricao;
                this._carreiraSer.Salvar(car);
            }

            if (!IsPostBack)
            {
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Codigo");
                //dt.Columns.Add("Descricao");
                //gridView1.DataSource = dt;

                Grid();

            }



        }

        private void Grid()
        {
            var lista = this._carreiraSer.RetornaTodos(1);
            if (lista.Count == 0)
            {
                Carreira car = new Carreira();
                car.carDescricao = "Analista";
                this._carreiraSer.Salvar(car);
            }

            lista = this._carreiraSer.RetornaTodos(1);
            gridView1.DataSource = lista;
            gridView1.DataBind();



            var lista2 = this._notaUsuarioSer.RetornaTodos(1);
            if (lista2 != null)
            {
                if (lista2.Count > 0)
                {
                    foreach (var i in lista2)
                    {
                        i.notDescricaoCarreira = lista.Where(x => x.carId == i.carId).ToList()[0].carDescricao;
                    }

                    gridView2.DataSource = lista2;
                    gridView2.DataBind();
                }
            }
        }

        Dominio.Servicos.CarreiraServico _carreiraSer = new Dominio.Servicos.CarreiraServico(new Repositorio.NHibernate.Repositorio.CarreiraRepositorio());
        Dominio.Servicos.NotaUsuarioServico _notaUsuarioSer = new Dominio.Servicos.NotaUsuarioServico(new Repositorio.NHibernate.Repositorio.NotaUsuarioRepositorio());
        protected void Unnamed_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvarCarreira_Click(object sender, EventArgs e)
        {
            Carreira car = new Carreira();
            if (!string.IsNullOrEmpty(this.txtId.Text))
            {
                car.carId = int.Parse(this.txtId.Text);
            }
            car.carDescricao = txtCarreira.Text;
            this._carreiraSer.Salvar(car);

            Grid();
        }

        protected void gridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridView1.Rows)
            {
                if (row.RowIndex == gridView1.SelectedIndex)
                {

                    row.ToolTip = string.Empty;
                }
                else
                {

                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //Server.Transfer("CadastroEditarCarreira.aspx", true);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            var listaNotas = this._carreiraSer.RetornaTodos(1);
            listaNotas = listaNotas.Where(x => x.carId == int.Parse(this.txtId.Text)).ToList();
            if (listaNotas.Count == 0)
            {
                Carreira car = new Carreira();
                car.carId = int.Parse(this.txtId.Text);

                this._carreiraSer.Excluir(car);
                Grid();
            }
            else
            {
                Response.Write("<script>alert('Carreira já possui nota e não pode ser excluída!');</script>");
            }
        }

        protected void btnNota_Click(object sender, EventArgs e)
        {
            NotaUsuario notaUsuario = new NotaUsuario();
            notaUsuario.notNota = int.Parse(this.txtNota.Text);
            if (Session["Usuario"] != null)
            {
                notaUsuario.notUsuario = Session["Usuario"].ToString();
            }
            
            notaUsuario.carId = int.Parse(this.txtId.Text);
            this._notaUsuarioSer.Salvar(notaUsuario);

            Grid();
        }

        protected void btnEditarNota_Click(object sender, EventArgs e)
        {
            var listaNotas = this._notaUsuarioSer.RetornaTodos(1);
            listaNotas = listaNotas.Where(x => x.notId == int.Parse(this.txtIdentificadorNota.Text) && x.notUsuario == Session["Usuario"].ToString()).ToList();
            if (listaNotas.Count > 0)
            {
                listaNotas[0].notNota = int.Parse(this.txtNota.Text);
                this._notaUsuarioSer.Salvar(listaNotas[0]);
            }
            else
            {
                Response.Write("<script>alert('Você não pode alterar uma nota que você não criou!');</script>");
            }
            Grid();

        }

        protected void btnExcluirNota_Click(object sender, EventArgs e)
        {
            var listaNotas = this._notaUsuarioSer.RetornaTodos(1);
            listaNotas = listaNotas.Where(x => x.notId == int.Parse(this.txtIdentificadorNota.Text) && x.notUsuario == Session["Usuario"].ToString()).ToList();
            if (listaNotas.Count > 0)
            {
                this._notaUsuarioSer.Excluir(listaNotas[0]);
            }
            else
            {
                Response.Write("<script>alert('Você não pode excluir uma nota que você não criou!');</script>");
            }
            Grid();

        }
    }
}