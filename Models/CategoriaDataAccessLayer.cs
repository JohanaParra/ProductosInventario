using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProductosInventario.Util;

namespace ProductosInventario.Models
{
    public class CategoriaDataAccessLayer
    {
        string connection = Connection.CName;

        public List<Categoria> GetAllCategorias()
        {
            List<Categoria> lsCategoria = new List<Categoria>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Categoria categoría = new Categoria();
                    categoría.idcategoria = Convert.ToInt32(rdr["idcategoria"]);
                    categoría.nombre = rdr["nombre"].ToString();
                    categoría.descripcion = rdr["descripcion"].ToString();
                    categoría.estado = Convert.ToBoolean(rdr["estado"]);

                    lsCategoria.Add(categoría);
                }
                con.Close();
            }
            return lsCategoria;
        }

        public void AddCategoria(Categoria categoría)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spAddCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", categoría.nombre);
                cmd.Parameters.AddWithValue("@descripcion", categoría.descripcion);
                cmd.Parameters.AddWithValue("@estado", categoría.estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCategoria(Categoria categoría)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcategoria", categoría.idcategoria);
                cmd.Parameters.AddWithValue("@nombre", categoría.nombre);
                cmd.Parameters.AddWithValue("@descripcion", categoría.descripcion);
                cmd.Parameters.AddWithValue("@estado", categoría.estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Categoria GetCategoriaData(int? id)
        {
            Categoria categoría = new Categoria();

            using (SqlConnection con = new SqlConnection(connection))
            {
                string sqlQuery = "SELECT * FROM categoria  WHERE  idcategoria = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categoría.idcategoria = Convert.ToInt32(rdr["idcategoria"]);
                    categoría.nombre = rdr["nombre"].ToString();
                    categoría.descripcion = rdr["descripcion"].ToString();
                    categoría.estado = Convert.ToBoolean(rdr["estado"]);
                }
            }
            return categoría;
        }

        public void DeleteCategoria(int? id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcategoria", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
