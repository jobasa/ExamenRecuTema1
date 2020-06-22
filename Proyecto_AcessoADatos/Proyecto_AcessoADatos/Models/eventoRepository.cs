using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class eventoRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb3;Uid=root;password=;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<evento> Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select(m.tipo_mercado,m.Cuota_over,m.Cuota_under) from mercado m";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            evento e = null;
            List<evento> listaEvento = new List<evento>();


            //Devolver objeto evento. Se devolvera un registro y lo añadira a la lista
            while (res.Read()){
                e = new evento(res.GetInt32(0), res.GetString(1), res.GetString(2));
                listaEvento.Add(e);
            }

            con.Close();
            return listaEvento;
        }

        internal List<eventoDTO> RetrieveDTO()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from partido";

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                eventoDTO e = null;
                List<eventoDTO> listaEvento = new List<eventoDTO>();


            //Devolver objeto evento. Se devolvera un registro
            while (res.Read())
            {
                e = new eventoDTO(res.GetString(2), res.GetString(1));
                listaEvento.Add(e);
            }

                con.Close();
                return listaEvento;


        }
    }
}