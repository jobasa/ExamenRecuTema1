using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class mercadoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb3;Uid=root;password=none;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<mercado> Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select(A.Cuota,A.Tipo_apuesta,A.Dinero_apostado,U.Email,M.tipo_mercado) from mercado M INNER JOIN usuario U INNER JOIN apuestas A ON A.ID_MERCADO = M.id AND A.ID_USUARIOS = U.ID; from mercado";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            mercado m = null;
            List<mercado> mercados = new List<mercado>();

                //Cada vez que ecuentra un objeto lo añade al list
                //List<mercado> mercados = new List<mercado>();

            ////Devolver objeto mercado. Se devolvera un registro
            while (res.Read())
            {
                m = new mercado(res.GetString(0), res.GetDecimal(1), res.GetDecimal(2), res.GetInt32(3), res.GetFloat(4), res.GetFloat(5), res.GetInt32(6));
                mercados.Add(m);
            }

            con.Close();
            return mercados;
        }

        internal List<mercadoDTO> RetrieveDTO()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            mercadoDTO m = null;
            List<mercadoDTO> mercados = new List<mercadoDTO>();

                //Cada vez que ecuentra un objeto lo añade al list
                //List<mercadoDTO> mercados = new List<mercadoDTO>();

            ////Devolver objeto mercado. Se devolvera un registro
            while (res.Read())
                {
                    m = new mercadoDTO(res.GetString(0), res.GetDecimal(1), res.GetDecimal(2));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;

        }
    }
}