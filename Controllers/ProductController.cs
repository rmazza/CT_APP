using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CT_App.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(Models.ProductModel m)
        {
             //m = new ProductModel();

            List<StateModel> stModel = new List<StateModel>();
            List<SalesModel> slModel = new List<SalesModel>();

            List<string> ArrStates = new List<string>();

            if(m.SelectedState == null)
            {
                m.SelectedState = "";
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvWorks"].ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM States";
                cmd.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {                
                    while (reader.Read())
                    {
                        ArrStates.Add(reader.GetString(0));
                    }
                }

                m.ArrayOfStates = ArrStates.ToArray();

                cmd.CommandText = "sp_GetTopSalesByState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stateName", m.SelectedState);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StateModel st = new StateModel();

                        st.StateProvince = reader.GetString(0);
                        st.ProductId = reader.GetInt32(1);
                        st.LineTotal = reader.GetDecimal(2);
                        st.ProductName = reader.GetString(3);

                        stModel.Add(st);                 
                    }
                }

                m.state = stModel;

                cmd.CommandText = "sp_GetTopProductsByState";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@stateName", model.SelectedState);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SalesModel sl = new SalesModel();

                        sl.StateProvince = reader.GetString(0);
                        sl.ProductId = reader.GetInt32(1);
                        sl.OrderQty = reader.GetInt32(2);
                        sl.ProductName = reader.GetString(3);

                        slModel.Add(sl);
                    }
                }

                m.sales = slModel;

                return View(m);
            }
        }
    }
}
