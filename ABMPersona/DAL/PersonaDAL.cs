using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class PersonaDAL
    {
        public static int Agregar(PersonaBE persona)
        {
            int id = DAO.ObtenerSiguienteId();
            return DAO.ExecuteNonQuery("INSERT INTO Persona (Id, Nombre, Apellido, Documento)" +
                $"VALUES ({id}, '{persona.Nombre}', '{persona.Apellido}', {persona.Documento})");
        }

        public static int Eliminar(int id)
        {
            return DAO.ExecuteNonQuery($"DELETE FROM Persona WHERE Id = {id}");
        }

        public static int Modificar(PersonaBE persona)
        {
            return DAO.ExecuteNonQuery($"UPDATE Persona SET Nombre = '{persona.Nombre}', Apellido = '{persona.Apellido}', Documento = {persona.Documento}" +
                $"WHERE Id = {persona.Id}");
        }

        public static List<PersonaBE> Listar()
        {
            List<PersonaBE> listaPersonas = new List<PersonaBE>();
            DataSet dataset = DAO.ExecuteDataSet("SELECT * FROM Persona");
            if (dataset != null)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    PersonaBE persona = new PersonaBE(int.Parse(row["Id"].ToString()));
                    persona.Nombre = row["Nombre"].ToString();
                    persona.Apellido = row["Apellido"].ToString();
                    persona.Documento = int.Parse(row["Documento"].ToString());
                    listaPersonas.Add(persona);
                }
            }
            return listaPersonas;
        }

        public static PersonaBE ObtenerPersona(int id)
        {
            DataSet dataset = DAO.ExecuteDataSet($"SELECT * FROM Persona WHERE Id = {id}");
            if (dataset != null && dataset.Tables[0].Rows.Count > 0 && dataset.Tables.Count > 0)
            {
                DataRow row = dataset.Tables[0].Rows[0];
                PersonaBE persona = new PersonaBE(int.Parse(row["Id"].ToString()));
                persona.Nombre = row["Nombre"].ToString();
                persona.Apellido = row["Apellido"].ToString();
                persona.Documento = int.Parse(row["Documento"].ToString());
                return persona;
            }
            return null;
        } 


    }
}
