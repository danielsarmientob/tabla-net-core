using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public interface IAlumnos
    {
      Alumno dameDatosAlumno(int id);
      List<Alumno> GetAmigos();  
    } 
}