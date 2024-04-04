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

                LlenarListaRolesUsuario();

                CargarInformacionDeUsuario();

            }
        }

        private void CargarInformacionDeUsuario()
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

                        //vamos a seleccionar el rol que tiene actualmente el
                        //usuario 

                        string idrol = datosUsuario.UsuarioRolID.ToString();

                        DdlRolesUsuario.Items.FindByValue(idrol).Selected = true;

                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
        }

        private void LlenarListaRolesUsuario()
        {
            try
            {
                //esta será la lista que va a almacenar los datos 
                //del SP para luego usarla en el dropdownlist
                var ListaRolesUsuario = new List<ListItem>();

                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    //ahora vamos a usar un linq para invocar al SP y asignar los 
                    //valores necesarios para que funcione el dropdownlist 

                    //usamon LINQ para hacer consultar similares las que hemos hecho
                    //con T-SQL, los clásicos SELECT FROM de las bases de datos. 
                    //Estas consultas las podemos hacer directamente en el código
                    //usando COLECCIONES que sean consultables. 

                    var query = (from lr in db.SPUsuarioRolListar()
                                 select new ListItem
                                 {
                                     Value = lr.id.ToString(),
                                     Text = lr.descrip
                                 }
                                 ).ToList();

                    //acá lo que hacemos es incorporar cada posible resultado
                    //a la variable que usamos para el datasource del dropdownlist
                    ListaRolesUsuario.AddRange(query);

                    //y ahora hacer el binding entre la lista y el ddl 
                    DdlRolesUsuario.DataTextField = "Text";
                    DdlRolesUsuario.DataValueField = "Value";

                    DdlRolesUsuario.DataSource = ListaRolesUsuario;
                    DdlRolesUsuario.DataBind();

                    DdlRolesUsuario.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
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

                int idrol = Convert.ToInt32(DdlRolesUsuario.SelectedItem.Value);

                //esto valida que se haya digitado info en el cuatro de texto 
                if (!string.IsNullOrEmpty(TxtContrasennia.Text.Trim()))
                {
                    contrasennia = TxtContrasennia.Text.Trim();
                }

                //llamamos al sp de modificación de usuario 
                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    db.SPUsuarioModificar(idsuario, nombre, email, telefono, contrasennia, idrol);
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