using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Parcial1w502019
{
    class AccesoDato
    {
        OleDbCommand comando;
        OleDbConnection conexion;
        OleDbDataReader lector;
        DataTable tabla;
        string cadenaConexion;


        public AccesoDato(string cadenaConexion)
        {
            comando = new OleDbCommand();
            conexion = new OleDbConnection();
            lector = null;
            tabla = new DataTable();
            this.cadenaConexion = cadenaConexion;
        }
        public AccesoDato()
        {
            comando = new OleDbCommand();
            conexion = new OleDbConnection();
            lector = null;
            tabla = new DataTable();
            cadenaConexion = null;
        }
        public OleDbCommand pComando
        {
            set { comando = value; }
            get { return comando; }
        }
        public OleDbConnection pConexion
        {
            set { conexion = value; }
            get { return conexion; }
        }
        public OleDbDataReader pLector
        {
            set { lector = value; }
            get { return lector; }
        }
        public DataTable pTabla
        {
            set { tabla = value; }
            get { return tabla; }
        }
        public string pCadenaconexion
        {
            set { cadenaConexion = value; }
            get { return cadenaConexion; }
        }
        public void conectar()
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;

        }
        public void desconectar()
        {
            conexion.Close();
            conexion.Dispose();
        }
        public DataTable consultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        public void leerTabla(string nombreTabla)
        {
            conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader();    
        }

        public DataTable consutarBD(string consultaSQL)
        {
            DataTable table = new DataTable();
            conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;

        }
        public  void actualizarBD(string consultaSQL)
        {
            conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            desconectar();
        }
    }
    
}
