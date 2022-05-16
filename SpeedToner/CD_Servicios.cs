﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace SpeedToner
{
    public class CD_Servicios
    {
        private CD_Conexion conexion = new CD_Conexion();

        
        DataTable tabla = new DataTable();
        SqlCommand  comando = new SqlCommand();

        //Se podra reutilizar, solo le mandamos un parametro de busqueda para que cambie de stop procedure
        public DataTable Mostrar(string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public SqlDataReader LlenarComboBox(string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            return leer;
        }


        public SqlDataReader BuscarId(string campo, string sp)
        {
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sp;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CampoBusqueda", campo);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }
        #region Servicios
        public void InsertarServicio(string NumeroFolio,int IdCliente, int IdMarca, string Modelo, string Serie, string Contador, DateTime Fecha, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla )
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarServicio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("IdMarca", IdMarca);
            comando.Parameters.AddWithValue("Modelo",Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Contador", int.Parse(Contador));
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@Fusor", Fusor);
            comando.Parameters.AddWithValue("@ServicioRealizado", ServicioRealizado);
            comando.Parameters.AddWithValue("@ReporteFalla",ReporteFalla);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarServicio(string NumeroFolio, string IdCliente, string IdMarca, string Modelo, string Serie, string Contador, string Fecha, string Hora, string Tecnico, string Usuario, string Fusor, string ServicioRealizado, string ReporteFalla)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarServicio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NumeroFolio", int.Parse(NumeroFolio));
            comando.Parameters.AddWithValue("@IdCliente", int.Parse(IdCliente));
            comando.Parameters.AddWithValue("IdMarca", int.Parse(IdMarca));
            comando.Parameters.AddWithValue("Modelo", Modelo);
            comando.Parameters.AddWithValue("@Serie", Serie);
            comando.Parameters.AddWithValue("@Contador", int.Parse(Contador));
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Hora", Hora);
            comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            comando.Parameters.AddWithValue("@Usuario", Usuario);
            comando.Parameters.AddWithValue("@ServicioRealizado", ServicioRealizado);
            comando.Parameters.AddWithValue("@ReporteFalla", ReporteFalla);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarServicio(string NumeroFolio)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumerFolio", int.Parse(NumeroFolio));
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        #endregion

        #region Clientes
        public void InsertarCliente(string Empresa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AgregarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Empresa", Empresa);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarCliente(int IdCliente,string Empresa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Empresa", Empresa);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarCliente(int IdCliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        #endregion



    }
}
