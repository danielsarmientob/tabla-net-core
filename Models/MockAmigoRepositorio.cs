using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class MockAmigoRepositorio:IAmigoAlmacen
    {
        private List<Amigo> amigosLista;
        public MockAmigoRepositorio()
        {
            amigosLista = new List<Amigo>();
            amigosLista.Add(new Amigo(){Id = 1, Nombre = "Pedro",Ciudad = "Madrid",Email = "Pedro@gmail.com"});
            amigosLista.Add(new Amigo(){Id = 2, Nombre = "Carlos",Ciudad = "Madrid",Email = "Carlos@gmail.com"});
            amigosLista.Add(new Amigo(){Id = 3, Nombre = "Paola",Ciudad = "Madrid",Email = "Paola@gmail.com"});
        }

        public Amigo dameDatosAmigo(int Id)
        {
            return this.amigosLista.FirstOrDefault(e => e.Id == Id);
        }
    }
}