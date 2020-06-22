using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class apuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb3;Uid=root;password=;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<apuestas> Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            apuestas a = null;
            List<apuestas> apuesta = new List<apuestas>();

                //Cada vez que ecuentra un objeto lo añade al list
                //List<apuestas> apuesta = new List<apuestas>();

                //Devolver objeto apuestas. Se devolvera un registro y lo añadira a la lista
                while (res.Read())
                {
                    a = new apuestas(res.GetInt32(0), res.GetDecimal(1), res.GetDecimal(2), res.GetString(3), res.GetInt32(4), res.GetInt32(5));
                    apuesta.Add(a);
                }

            con.Close();
            return apuesta;



        }

        /*Ejercicio 1*/
        internal List<apuestas> RetrieveExamen(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select Id,Tipo_apuesta,Cuota,Dinero_apostado,ID_MERCADO,ID_USUARIOS from apuestas where ID_MERCADO =" + id;

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            apuestas a = null;
            List<apuestas> apuestaExamen = new List<apuestas>();

            while (res.Read())
            {
                a = new apuestas(res.GetInt32(0),res.GetDecimal(1), res.GetDecimal(2), res.GetString(3), res.GetInt32(4), res.GetInt32(5));
                apuestaExamen.Add(a);
            }

            con.Close();
            return apuestaExamen;

        }
        /*Fin Ejercicio 1*/



        internal List<apuestasDTO> RetrieveDTO()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select(A.Cuota,A.Tipo_apuesta,A.Dinero_apostado,U.Email,M.tipo_mercado) from apuestas A INNER JOIN usuario U INNER JOIN mercado M ON A.ID_MERCADO = M.id AND A.ID_USUARIOS = U.ID; ";


                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                apuestasDTO a = null;
                List<apuestasDTO> Listapuestas = new List<apuestasDTO>();

            //Cada vez que ecuentra un objeto lo añade al list
            //List<apuestasDTO> apuesta = new List<apuestasDTO>();

            //Devolver objeto apuestas. Se devolvera un registro y lo añadira a la lista
            while (res.Read())
                {
                    a = new apuestasDTO(res.GetDecimal(0), res.GetDecimal(1), res.GetString(2));
                    Listapuestas.Add(a);
                }

                con.Close();
                return Listapuestas;



        }

        internal void Save(apuestas a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO apuestas(Id,Tipo_apuesta,Cuota,Dinero_apostado,ID_MERCADO,ID_USUARIOS) values ('"+a.Id+"','"+a.Tipo_apuesta+"','"+a.Cuota+"','"+a.Dinero_apostado+"','"+a.ID_MERCADO+"','"+a.ID_USUARIOS+"');";
            Debug.WriteLine("comando" + command.CommandText);

            //Mercado asociado a la apuesta
            command.CommandText = "Select(A.Cuota,A.Tipo_apuesta,A.Dinero_apostado,U.Email,M.tipo_mercado) from mercado M INNER JOIN usuario U INNER JOIN apuestas A ON A.ID_MERCADO = M.id AND A.ID_USUARIOS = U.ID from mercado where id="+a.ID_MERCADO;
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            mercado m = null;

            //Cada vez que ecuentra un objeto lo añade al list
            //List<mercado> mercados = new List<mercado>();

            ////Devolver objeto mercado. Se devolvera un registro
            if (res.Read())
            {
                m = new mercado(res.GetString(0), res.GetDecimal(1), res.GetDecimal(2), res.GetInt32(3), res.GetFloat(4), res.GetFloat(5), res.GetInt32(6));
            }

            con.Close();

            double Cuota_over; 
            double Cuota_under;
            double prob_over;
            double prob_under;

            prob_over = m.Dinero_over / (m.Dinero_over + m.Dinero_under);
            prob_under = m.Dinero_under / (m.Dinero_over + m.Dinero_under);

            Cuota_over = 1 / prob_over * 0.95;
            Cuota_under = 1 / prob_under * 0.95;

            if (a.Tipo_apuesta == "over")
            {
                command.CommandText = "UPDATE mercado set Dinero_over = Dinero_over" + a.Dinero_apostado + "WHERE id =" + a.ID_MERCADO + ";";
                Debug.WriteLine("comando" + command.CommandText);
            }
            else if (a.Tipo_apuesta == "under")
            {
                command.CommandText = "UPDATE mercado set Dinero_under = Dinero_under" + a.Dinero_apostado + "WHERE id =" + a.ID_MERCADO + ";";
                Debug.WriteLine("comando" + command.CommandText);
            }

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }


        }

        /*Ejercicio
        internal List<apuestasExamen> RetrieveExamen()
        {
            apuestas a = null;
            List<apuestasExamen> apuestasExamen = new List<apuestasExamen>();

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT U.Nombre, M.id, A.Cuota, A.Dinero_apostado from apuestas A, usuario U, mercado M WHERE A.ID_MERCADO = M.id AND A.ID_USUARIOS = U.ID";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            
            while (res.Read())
            {
                a = new apuestasExamen(res.GetString(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3));
                apuestasExamen.Add(a);
                    
            }
            return apuestasExamen;

        }*/
        /* Fin Ejercicio*/

    }
}