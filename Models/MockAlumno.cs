using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySqlConnector;

namespace prueba.Models
{
    public class MockAlumno:IAlumnos
    {
        private List<Alumno> listaAlumnos;
        public MockAlumno()
        {
            listaAlumnos = new List<Alumno>();
            // amigosLista = new List<Amigo>();
            // amigosLista.Add(new Amigo(){Id = 1, Nombre = "Pedro",Ciudad = "Madrid",Email = "Pedro@gmail.com"});
            // amigosLista.Add(new Amigo(){Id = 2, Nombre = "Carlos",Ciudad = "Madrid",Email = "Carlos@gmail.com"});
            // amigosLista.Add(new Amigo(){Id = 3, Nombre = "Paola",Ciudad = "Madrid",Email = "Paola@gmail.com"});
            GetUser();
        }


         public void GetUser() {
            // listaAlumnos = new List<Alumno>();

            using var connection = new MySqlConnection("datasource=localhost;username=root;password=;database=sistema_fc");
            connection.Open();
            
            using var command = new MySqlCommand("SELECT * FROM alumno", connection);
           
            
            using var reader = command.ExecuteReader();
          
            var cont = 0;
            while (reader.Read())
            {
                this.listaAlumnos.Add(new Alumno(){
                    id_estudiante = (int)reader.GetValue(0) ,
                    codigo = reader.GetValue(1).ToString(),
                    escuela = reader.GetValue(2).ToString(),
                    nombres = reader.GetValue(3).ToString(),  
                    apellidos = reader.GetValue(4).ToString(),
                    correo = reader.GetValue(5).ToString(),
                    correo2 = reader.GetValue(6).ToString(),
                    telefono1 = reader.GetValue(7).ToString(),
                    telefono2 = reader.GetValue(8).ToString(),
                });
                
         
                cont = cont +1;
                
            }
           
        }
        public Alumno dameDatosAlumno(int id_estudiante)
        {
            return this.listaAlumnos.FirstOrDefault(e => e.id_estudiante == id_estudiante);
        }

        public List<Alumno> GetAmigos(){
            return this.listaAlumnos;
        }

        
    }
}