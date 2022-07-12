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
        //protected cnn = new SqlConnection
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-QEE7JA6;DataBase= SpeedToner;Integrated Security=true");
        //private SqlConnection Conexion = new SqlConnection("data source=192.168.0.24,1433;initial catalog=SpeedToner; user id=usuario1;password=1234;");


        //private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-QFUKV11;DataBase= SpeedToner;Integrated Security=true");

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
