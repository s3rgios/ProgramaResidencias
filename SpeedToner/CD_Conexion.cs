using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpeedToner
{
    internal class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-QEE7JA6;DataBase= Pruebas;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if(Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }

    }
}
