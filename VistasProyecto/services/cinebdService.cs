using Microsoft.Data.Sqlite;
using ProyectoCine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VistasProyecto.models;

namespace VistasProyecto.services
{
    class cinebdService
    {
        SqliteConnection conexion;
        SqliteCommand comando;
        public cinebdService()
        {
            conexion = new SqliteConnection("Data Source=cinebalmis.db");
            conexion.Open();
            comando = conexion.CreateCommand();
        }

        public List<Peliculas> getAllPeliculas()
        {
            List<Peliculas> listaPeliculas = new List<Peliculas>();
            comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idPelicula = (int)lector["idPelicula"];
                    string titulo = (string)lector["titulo"];
                    string cartel = (string)lector["cartel"];
                    int anyo = (int)lector["anyo"];
                    string genero = (string)lector["genero"];
                    string calificacion = (string)lector["cartel"];
                    listaPeliculas.Add(new Peliculas(idPelicula, titulo, cartel, anyo, genero, calificacion));
                }
            }
            return listaPeliculas;
        }

        public List<Salas> getAllSalas()
        {
            List<Salas> listaSalas = new List<Salas>();
            comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSala = (int)lector["idSala"];
                    string numero = (string)lector["numero"];
                    int capacidad = (int)lector["capacidad"];
                    bool disponible = (bool)lector["disponible"];
                    listaSalas.Add(new Salas(idSala, numero, capacidad, disponible));
                }
            }
            return listaSalas;
        }
        public void anyadirSala(Salas sala)
        {
            int n;
            comando.CommandText = "INSERT INTO salas VALUES (@numero,@capacidad, @disponible)";
            comando.Parameters.Add("@numero", SqliteType.Text);
            comando.Parameters.Add("@capacidad", SqliteType.Integer);
            comando.Parameters.Add("@disponible", SqliteType.Integer);
            comando.Parameters["@numero"].Value = sala.Numero;
            comando.Parameters["@capacidad"].Value = sala.Capacidad;
            if (sala.Disponible == true)
                n = 1;
            else
                n = 0;
            comando.Parameters["@disponible"].Value = n;
            comando.ExecuteNonQuery();
        }

        public void modificarSala(Salas sala)
        {
            int n;
            comando.CommandText = "UPDATE salas SET numero = @numero, capacidad = @capacidad, disponible = @disponible WHERE idSala = @idSala";
            comando.Parameters.Add("@idSala", SqliteType.Integer);
            comando.Parameters.Add("@numero", SqliteType.Text);
            comando.Parameters.Add("@capacidad", SqliteType.Integer);
            comando.Parameters.Add("@disponible", SqliteType.Integer);
            comando.Parameters["@idSala"].Value = sala.IdSala;
            comando.Parameters["@numero"].Value = sala.Numero;
            comando.Parameters["@capacidad"].Value = sala.Capacidad;
            if (sala.Disponible == true)
                n = 1;
            else
                n = 0;
            comando.Parameters["@disponible"].Value = n;
            comando.ExecuteNonQuery();

        }

        public List<Sesiones> getAllSesiones()
        {
            List<Sesiones> listaSesiones = new List<Sesiones>();
            comando.CommandText = "SELECT * FROM sesiones";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSesion = (int)lector["idSesion"];
                    int pelicula = (int)lector["pelicula"];
                    int sala = (int)lector["sala"];
                    string hora = (string)lector["hora"];
                    listaSesiones.Add(new Sesiones(idSesion, pelicula, sala, hora));
                }
            }
            return listaSesiones;
        }
        public void anyadirSesion(Sesiones sesion)
        {
            comando.CommandText = "INSERT INTO sesiones VALUES (@pelicula,@sala, @hora)";
            comando.Parameters.Add("@pelicula", SqliteType.Integer);
            comando.Parameters.Add("@sala", SqliteType.Integer);
            comando.Parameters.Add("@hora", SqliteType.Text);
            comando.Parameters["@pelicula"].Value = sesion.Pelicula;
            comando.Parameters["@sala"].Value = sesion.Sala;
            comando.Parameters["@hora"].Value = sesion.Hora;
            comando.ExecuteNonQuery();
        }

        public void modificarSesion(Sesiones sesion)
        {
            comando.CommandText = "UPDATE sesiones SET pelicula = @pelicula, sala = @sala, hora = @hora WHERE idSesion = @idSesion";
            comando.Parameters.Add("@idSesion", SqliteType.Integer);
            comando.Parameters.Add("@pelicula", SqliteType.Integer);
            comando.Parameters.Add("@sala", SqliteType.Integer);
            comando.Parameters.Add("@hora", SqliteType.Text);
            comando.Parameters["@idSesion"].Value = sesion.IdSesion;
            comando.Parameters["@pelicula"].Value = sesion.Pelicula;
            comando.Parameters["@sala"].Value = sesion.Sala;
            comando.Parameters["@hora"].Value = sesion.Hora;
            comando.ExecuteNonQuery();
        }

        public void eliminarSesion(int idSesion)
        {
            comando.CommandText = "DELETE FROM sesiones WHERE idSesion = @idSesion";
            comando.Parameters.Add("@idSesion", SqliteType.Integer);
            comando.Parameters["@idSesion"].Value = idSesion;
            comando.ExecuteNonQuery();
        }

        public void anyadirVenta(Ventas venta)
        {
            comando.CommandText = "INSERT INTO ventas VALUES (@sesion,@cantidad, @pago)";
            comando.Parameters.Add("@sesion", SqliteType.Integer);
            comando.Parameters.Add("@cantidad", SqliteType.Integer);
            comando.Parameters.Add("@pago", SqliteType.Text);
            comando.Parameters["@sesion"].Value = venta.Sesion;
            comando.Parameters["@cantidad"].Value = venta.Cantidad;
            comando.Parameters["@pago"].Value = venta.Pago;
            comando.ExecuteNonQuery();
        }

        public List<object[]> getOcupación()
        {
            List<object[]> list = new List<object[]>();
            comando.CommandText = "SELECT sal.numero, " +
                "sal.capacidad, " +
                "s.hora, " +
                "COUNT(v.idVenta) AS NumVentas, " +
                "FROM sesiones s " +
                "JOIN ventas v ON s.idSesion = v.sesion " +
                "JOIN salas sal ON s.sala = sal.idSala " +
                "GROUP BY sal.idSala, s.hora";

            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string numSala = (string)lector["sal.numero"];
                    string capacidadSala = (string)lector["sal.capacidad"];
                    string hora = (string)lector["s.hora"];
                    int numVentas = (int)lector["NumVentas"];
                    object[] objects = { numSala, capacidadSala, hora, numVentas };
                    list.Add(objects);
                }
            }
            return list;
        }
    }
}
