using Progra5_Semana05_1.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Progra5_Semana05_1.Pages
{
    public partial class UsuarioAgregarPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //primero vamos a capturar en variables locales los valores
            //digitados en la página. 
            string nombre = TxtNombre.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string telefono = TxtTelefono.Text.Trim();
            string contrasennia = TxtContrasennia.Text.Trim();

            //en este ejemplo el rol será opcional
            //TODO: dar funcionalidad al combo para seleccionar el rol 

            try
            {
                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    db.SPUsuarioAgregar(nombre, email, telefono, contrasennia, 2);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Pages/Error.aspx");
            }

            Response.Redirect("~/Pages/ExitoAgregarUsuario.aspx");

        }
    }
}