using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProductosInventario.Util;

namespace ProductosInventario.Models
{
    public class ProductoDataAccessLayer
    {
        string connection = Connection.CName;

        public IEnumerable<Producto> GetAllProducto()
        {
            List<Producto> lsProducto = new List<Producto>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spGetAllProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Producto producto = new Producto();
                    producto.idproducto = Convert.ToInt32(rdr["idproducto"]);
                    producto.idcategoria = Convert.ToInt32(rdr["idcategoria"]);
                    producto.NombreCat = rdr["NombreCat"].ToString();
                    producto.codigo = rdr["codigo"].ToString();
                    producto.nombre = rdr["nombre"].ToString();
                    producto.precio_venta = Convert.ToDecimal(rdr["precio_venta"]);
                    producto.stock = Convert.ToInt32(rdr["stock"]);
                    producto.descripcion = rdr["descripcion"].ToString();
                    producto.imagen = rdr["imagen"].ToString();
                    producto.estado = Convert.ToBoolean(rdr["estado"]);


                    lsProducto.Add(producto);
                }
                con.Close();
            }
            return lsProducto;
        }

        public void AddProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spAddProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcategoria", producto.idcategoria );
                cmd.Parameters.AddWithValue("@codigo", producto.codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@precio_venta", producto.precio_venta);
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion );
                //cmd.Parameters.AddWithValue("@imagen", producto.imagen);
                cmd.Parameters.AddWithValue("@estado", producto.estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spUpdateProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idproducto", producto.idproducto);
                cmd.Parameters.AddWithValue("@idcategoria", producto.idcategoria);
                cmd.Parameters.AddWithValue("@codigo", producto.codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@precio_venta", producto.precio_venta);
                cmd.Parameters.AddWithValue("@stock", producto.stock);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                //cmd.Parameters.AddWithValue("@imagen", producto.imagen);
                cmd.Parameters.AddWithValue("@estado", producto.estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Producto GetProductoData(int? id)
        {
            Producto producto = new Producto();

            using (SqlConnection con = new SqlConnection(connection))
            {
                string sqlQuery = "SELECT * FROM Producto WHERE idproducto= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    producto.idproducto = Convert.ToInt32(rdr["idproducto"]);
                    producto.idcategoria = Convert.ToInt32(rdr["idcategoria"]);
                    producto.codigo = rdr["codigo"].ToString();
                    producto.nombre = rdr["nombre"].ToString();
                    producto.precio_venta = Convert.ToDecimal(rdr["precio_venta"]);
                    producto.stock = Convert.ToInt32(rdr["stock"]);
                    producto.descripcion = rdr["descripcion"].ToString();
                    producto.imagen = rdr["imagen"].ToString();
                    producto.estado = Convert.ToBoolean(rdr["estado"]);
                }
                return producto;
            }
        }

        public void DeleteProducto(int? id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spDeleteProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
    
}
