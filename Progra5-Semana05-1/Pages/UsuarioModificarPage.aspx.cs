using Progra5_Semana05_1.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Progra5_Semana05_1.Pages
{
    public partial class UsuarioModificarPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                int idusuario = Convert.ToInt32(Request.QueryString["id"]);
                TxtUsuarioID.Text = idusuario.ToString();

                try
                {
                    using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                    {
                        var datosUsuario = db.SPUsuarioConsultarPorID(idusuario).FirstOrDefault();

                        if (datosUsuario != null)
                        {
                            TxtNombre.Text = datosUsuario.Nombre;
                            TxtTelefono.Text = datosUsuario.Telefono;
                            TxtEmail.Text = datosUsuario.Email;
                        }
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("~/Pages/Error.aspx");
                }


            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idsuario = Convert.ToInt32(TxtUsuarioID.Text.Trim());
                string nombre = TxtNombre.Text.Trim();
                string email = TxtEmail.Text.Trim();
                string telefono = TxtTelefono.Text.Trim();

                //string contrasennia = string.Empty; 
                string contrasennia = "";

                //esto valida que se haya digitado info en el cuatro de texto 
                if (!string.IsNullOrEmpty(TxtContrasennia.Text.Trim()))
                {
                    contrasennia = TxtContrasennia.Text.Trim();
                }

                //llamamos al sp de modificación de usuario 
                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    db.SPUsuarioModificar(idsuario, nombre, email, telefono, contrasennia);
                }

            }
            catch (Exception)
            {
                Response.Redirect("~/Pages/Error.aspx");
            }

            Response.Redirect("ExitoModificarUsuario.aspx");

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idusuario = Convert.ToInt32(TxtUsuarioID.Text.Trim());
                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    db.SPUsuarioEliminar(idusuario);
                }
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }

            Response.Redirect("ExitoEliminarUsuario.aspx");
        }
    }
}