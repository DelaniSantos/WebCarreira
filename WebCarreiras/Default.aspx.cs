using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCarreiras
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {

            if (ValidarLogin())
            {
                Session.Add("Usuario", this.txt1.Text);
                Server.Transfer("CadastroCarreira.aspx", true);
                
            }

        }

        private void GravandoDadosCookie(string nomeCookie)
        {
            // Verificando se já existe o cookie na máquina do usuário
            HttpCookie cookie = Request.Cookies[nomeCookie];
            if (cookie == null)
            {
                // Criando a Instância do cookie
                cookie = new HttpCookie(nomeCookie);
                //Adicionando a propriedade "Nome" no cookie
                cookie.Values.Add("valorNome", this.txt1.Text);
                //colocando o cookie para expirar em 365 dias
                cookie.Expires = DateTime.Now.AddMinutes(5);
                // Definindo a segurança do nosso cookie
                cookie.HttpOnly = true;
                // Registrando cookie
                this.Page.Response.AppendCookie(cookie);

            }
        }

        private bool ValidarLogin()
        {
            if (txt1.Text == "Admin" && txt2.Text == "123")
            {
                return true;
            }

            if (txt1.Text == "Usuario1" && txt2.Text == "123")
            {
                return true;
            }

            if (txt1.Text == "Usuario2" && txt2.Text == "123")
            {
                return true;
            }

            return false;
        }
    }
}