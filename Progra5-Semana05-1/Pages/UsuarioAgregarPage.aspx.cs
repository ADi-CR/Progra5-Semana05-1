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

            if (!Page.IsPostBack)
            {
                LlenarListaRolesUsuario();
            }

        }

        //cuando tenemos un bloque de código con una funcionalidad determinada
        //lo más conveniendo y ordenado es encapsularo en un su propia función 
        //o método. en este caso el código para llenar el drodownlist lo vamos 
        //incluir en un método 
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
                    ListaRolesUsuario.AddRange( query );

                    //y ahora hacer el binding entre la lista y el ddl 
                    DdlRolesUsuario.DataTextField = "Text";
                    DdlRolesUsuario .DataValueField = "Value";

                    DdlRolesUsuario.DataSource = ListaRolesUsuario;
                    DdlRolesUsuario.DataBind();
                                      

                }
                            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");             
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //primero vamos a capturar en variables locales los valores
            //digitados en la página. 
            string nombre = TxtNombre.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string telefono = TxtTelefono.Text.Trim();
            string contrasennia = TxtContrasennia.Text.Trim();

            int idrol = Convert.ToInt32(DdlRolesUsuario.SelectedItem.Value);

            try
            {
                using (Progra5_Ejemplo1Entities db = new Progra5_Ejemplo1Entities())
                {
                    db.SPUsuarioAgregar(nombre, email, telefono, contrasennia, idrol);
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