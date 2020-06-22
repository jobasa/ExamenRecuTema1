using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class apuestas
    {
        /*Ejercicio 1*/
        public apuestas(int Id, decimal Dinero_apostado, decimal Cuota, string Tipo_apuesta, int ID_MERCADO, int ID_USUARIOS)
        {
            this.Id = Id;
            this.Dinero_apostado = Dinero_apostado;
            this.Cuota = Cuota;
            this.Tipo_apuesta = Tipo_apuesta;
            this.ID_MERCADO = ID_MERCADO;
            this.ID_USUARIOS = ID_USUARIOS;
        }

        public int Id { get; set; }
        public decimal Dinero_apostado { get; set; }
        public decimal Cuota { get; set; }
        public string Tipo_apuesta { get; set; }
        public int ID_MERCADO { get; set; }
        public int ID_USUARIOS { get; set; }
    }
    /* Fin Ejercicio 1*/

    

    public class apuestasDTO
    {
        public apuestasDTO(decimal Dinero_apostado, decimal Cuota, string Tipo_apuesta)
        {
            this.Dinero_apostado = Dinero_apostado;
            this.Cuota = Cuota;
            this.Tipo_apuesta = Tipo_apuesta;
        }

        public decimal Dinero_apostado { get; set; }
        public decimal Cuota { get; set; }
        public string Tipo_apuesta { get; set; }

    }

    /*
    public class apuestasPruebas
    {
        public apuestasPruebas(string nombre, int ID_MERCADO, double Cuota, double Dinero_apostado)
        {
            this.nombre = nombre;
            this.ID_MERCADO = ID_MERCADO;
            this.Cuota = Cuota;
            this.Dinero_apostado = Dinero_apostado;
        }

        public string nombre { get; set; }
        public int ID_MERCADO { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }
    }*/
    
}