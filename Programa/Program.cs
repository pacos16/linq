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
            Console.WriteLine("Jugadores que juegan de pivot en la liga");
            jugadores.Where((j)=> j.Posicion=="Pivot").ToList().ForEach(Console.WriteLine);
            

            //5.1 Equipo con jugador con salario mas alto;

            Console.WriteLine("Equipo con jugador con salario mas alto");
            Console.WriteLine(jugadores.OrderBy((j) => j.Salario).First().Equipo);

            //5.2 mas de dos metros
            Console.WriteLine("Jugadores con mas de dos metros");
            jugadores.Where((j) => j.Altura > 2.0).ToList().ForEach(Console.WriteLine);

            //5.3 capitanes del equipo

            jugadores.Select((j) => j.Capitan).Distinct().ToList().ForEach(Console.WriteLine);


            //4.1 Princesa
            Console.WriteLine("Lista de strings");
            jugadores.ForEach((j) => Console.WriteLine("Nombre: {0} Apellido: {1} Equipo: {2}",j.Nombre,j.Apellido,j.Equipo.Nombre));

            //4.2 Ardua tarea
            Console.WriteLine("Ardua Tarea");
            Dictionary<Equipo, int> equiposGanadores = new Dictionary<Equipo, int>();
            String[] splited;

            equipos.ForEach((e) => equiposGanadores.Add(e, 0));
            
            partidos.ForEach((p) =>
            {
                splited=p.Resultado.Split("-");
                if (int.Parse(splited[0]) > int.Parse(splited[1]))
                {
                    equiposGanadores[p.Local]++;
                }
                else
                {
                    equiposGanadores[p.Visitante]++;
                }
            });

       
            Console.WriteLine(equiposGanadores.OrderBy((e) => e.Value).First());
            
            Console.ReadLine();

        }




    }
}
