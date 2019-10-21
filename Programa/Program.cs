using System;
using Modelo;
using System.Linq;
using System.Collections.Generic;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Equipos :");
            /*
            foreach (var e in LigaDAO.Instance.Equipos)
            {
                Console.WriteLine("\t" + e);
            }
            */
            List<Equipo> equipos = LigaDAO.Instance.Equipos;
            equipos.ForEach(Console.WriteLine);


            Console.WriteLine("Jugadores:");
            /*
            foreach (var j in LigaDAO.Instance.Jugadores)
            {
                Console.WriteLine("\t" + j);
            }
            */
            List<Jugador> jugadores = LigaDAO.Instance.Jugadores;
            jugadores.ForEach(Console.WriteLine);
            Console.WriteLine("Partidos:");
            /*
            foreach (var p in LigaDAO.Instance.Partidos)
            {
                Console.WriteLine("\t" + p);
            }*/
            List<Partido> partidos = LigaDAO.Instance.Partidos;
            partidos.ForEach(Console.WriteLine);

            
            //Hola señor mago.
            //2.1 Mostrar jugadores regal Barcelona orderby fecha alta 
            Console.WriteLine("Regal barcelona");
            equipos.Where((e) => e.Nombre == "Regal Barcelona").First().Jugadores.OrderBy((jugador) => jugador.FechaAlta).ToList().ForEach(Console.WriteLine);

            //2.2 Ordena por Apellidos los jugadores del gran canaria
            Console.WriteLine("Apellidos");
            equipos.Where((e) => e.Nombre == "Gran Canaria").First().Jugadores.OrderBy((jugador) => jugador.Apellido).ToList().ForEach(Console.WriteLine);

            //2.3 Dime quien es el jugador mas alto y de que equipo
            Console.WriteLine("Jugador más alto");
            Console.WriteLine(jugadores.OrderBy((j) => j.Altura).Last().ToString());

            //2.4 Que jugadores juegan de pivot en la liga.



            //4.2 Lolaso

            Dictionary<Equipo, int> equiposGanadores = new Dictionary<Equipo, int>();
            String[] splited;
            partidos.ForEach((p) =>
            {
                splited=p.Resultado.Split("-");
                if (int.Parse(splited[0]) > int.Parse(splited[1]))
                {
                    if(equiposGanadores.Add(p.Local, 1));
                }
                else
                {
                    equiposGanadores.Add(p.Visitante);
                }
            });

            
            Console.ReadLine();

        }
    }
}
