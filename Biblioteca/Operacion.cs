using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using trabajoFinal.Models;

namespace Biblioteca {
    public class Operacion {
        SqlDataReader dataReader;
        Conexion cn = new Conexion();

        public bool login(string usuario, string clave) {
            try {
                string sql = $"SELECT * FROM usuarios WHERE usuario='{usuario}' AND passwor='{clave}'";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read()) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception) {
                return false;
            }
        }

        public bool InsertPersona(string rut, string nombre, string apellido, string titulo, int edad) {
            try {
                string sql = $"Insert into Personas values ('{rut}', '{nombre}', '{apellido}', '{titulo}', '{edad}')";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            } catch (Exception) {
                return false;
            }
        }
        public bool InsertUsuario(string usuario, string clave) {
            try {
                string sql = $"Insert into usuarios values ('{usuario}', '{clave}')";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            } catch (Exception) {
                return false;
            }
        }

        public bool ModificarPersona(string rut, string nombre, string apellido, string titulo, int edad) {
            try {
                string sql = $"Update Personas Set rut='{rut}', nombre='{nombre}', apellido='{apellido}', titulo='{titulo}', edad='{edad}' Where rut='{rut}'";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            } catch (Exception) {
                return false;
            }
        }


        public Persona getPersonaByRut(string rut) {
            Persona p = new Persona();
            try {
                string sql = $"SELECT * FROM Personas WHERE rut='{rut}'";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read()) {
                    p.Rut = dataReader["rut"].ToString();
                    p.Nombre = dataReader["nombre"].ToString();
                    p.Apellido = dataReader["apellido"].ToString();
                    p.Titulo = dataReader["titulo"].ToString();
                    p.Edad = dataReader.GetInt32(4);
                }
                dataReader.Close();
                return p;
            } catch (Exception) {
                return null;
            }
        }

        public bool eliminarPersona(string rut) {
            try {
                string sql = $"DELETE FROM Personas WHERE rut='{rut}'";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            } catch (Exception) {
                return false;
            }
        }

        public List<Persona> ListarPersonas() {
            Persona p;
            List<Persona> Personas = new List<Persona>();
            try {
                string sql = "SELECT * FROM Personas ORDER BY nombre ASC";
                SqlCommand cmd = new SqlCommand(sql, cn.getConnection());
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) {
                    p = new Persona();
                    p.Rut = dataReader["rut"].ToString();
                    p.Nombre = dataReader["nombre"].ToString();
                    p.Apellido = dataReader["apellido"].ToString();
                    p.Titulo = dataReader["titulo"].ToString();
                    p.Edad = dataReader.GetInt32(4);
                    Personas.Add(p);
                }
                dataReader.Close();
                return Personas;
            } catch (Exception) {
                return null;
            }
        }
    }
}
