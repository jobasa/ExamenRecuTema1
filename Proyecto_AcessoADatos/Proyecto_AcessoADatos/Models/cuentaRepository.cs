using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class cuentaRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb3;Uid=root;password=none;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<cuenta>  Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from cuenta";

            try { 
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            cuenta c = null;

                //Cada vez que ecuentra un objeto lo añade al list
                List<cuenta> cuentas = new List<cuenta>();

                ////Devolver objeto cuenta. Se devolvera un registro y lo añadira a la lista
                while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3));
                c = new cuenta(res.GetString(0), res.GetInt32(1), res.GetString(2),res.GetInt32(3));
                    cuentas.Add(c);
            }

            con.Close();
            return cuentas;

           }
            //Error que salta cuando esta puesto mal el server
            catch(MySqlException e)
            {
                Debug.WriteLine("Se ha porducido un error de conexión");
                return null;
            }

        }
    }
}