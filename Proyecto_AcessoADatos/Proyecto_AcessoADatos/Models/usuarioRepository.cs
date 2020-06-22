using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class usuarioRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb3;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<usuario>  Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario";

            try { 
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            usuario u = null;

                //Cada vez que ecuentra un objeto lo añade al list
                List<usuario> usuarios = new List<usuario>();

                //Devolver objeto usuario. Se devolvera un registro y lo añadira a la lista
                while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4));
                u = new usuario(res.GetString(0), res.GetString(1), res.GetString(2),res.GetInt32(3), res.GetString(4));
                    usuarios.Add(u);
            }

            con.Close();
            return usuarios;

            }
            //Error que salta cuando esta puesto mal el server
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha porducido un error de conexión");
                return null;
            }

        }
    }
}