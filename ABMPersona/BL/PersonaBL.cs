using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PersonaBL
    {
        public static int Agregar(PersonaBE persona) 
        {
            return PersonaDAL.Agregar(persona);
        }
        public static int Eliminar(int id)
        {
            return PersonaDAL.Eliminar(id);
        }
        public static int Modificar(PersonaBE persona)
        {
            return PersonaDAL.Modificar(persona);
        }
        public static List<PersonaBE> Listar()
        {
            return PersonaDAL.Listar();
        }
        public static PersonaBE ObtenerPersona(int id)
        {
            return PersonaDAL.ObtenerPersona(id);
        }
    }
}
