﻿using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Modelo
{
    public class Equipo
    {
        [XmlAttribute()]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Web { get; set; }
        public int Puntos { get; set; }
        public System.Collections.Generic.List<Jugador> Jugadores { get; set; }

        public static Equipo CreateEquipo(int id, string nombre, string ciudad, string web, int puntos)
        {

            return new Equipo(id, nombre, ciudad, web, puntos);
        }





        private Equipo()
        {

        }

        override public string ToString()
        {
            return "ID= " + ID + " Nom: " + Nombre + " Ciudad: " + Ciudad + " Puntos " + Puntos;
        }

        private Equipo(int id, string nombre, string ciudad, string web, int puntos) : this()
        {
            ID = id;
            Nombre = nombre;
            Ciudad = ciudad;
            Web = web;
            Puntos = puntos;
            Jugadores = new System.Collections.Generic.List<Jugador>();
        }
        
    }
}
