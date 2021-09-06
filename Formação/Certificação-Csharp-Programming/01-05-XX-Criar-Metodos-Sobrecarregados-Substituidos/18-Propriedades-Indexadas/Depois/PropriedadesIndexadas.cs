﻿using System;
using System.Collections.Generic;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class PropriedadesIndexadas : IAulaItem
    {
        public void Executar()
        {
            var sala = new Sala();
            sala.SetReserva("D01", new ClienteCinema("Maria de Souza"));
            sala.SetReserva("D02", new ClienteCinema("José da Silva"));

            //utilizando uma propriedade indexada. Devo acessá-la como array
            sala["D01"] = new ClienteCinema("Maria de Souza");

            sala.ImprimirReservas();
        }
    }

    internal class ClienteCinema
    {
        public ClienteCinema(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    internal class Sala
    {
        private readonly IDictionary<string, ClienteCinema> reservas
            = new Dictionary<string, ClienteCinema>();

        public ClienteCinema GetReserva(string codigoAssento)
        {
            return reservas[codigoAssento];
        }

        public void SetReserva(string codigoAssento, ClienteCinema value)
        {
            reservas[codigoAssento] = value;
        }

        //aqui vai uma propriedade indexada
        //propeidade indexada não possui nome
        public ClienteCinema this[string codigoAssento]
        {
            get
            {
                return reservas[codigoAssento];
            }

            set
            {
                reservas[codigoAssento] = value;
            }
        }

        public void ImprimirReservas()
        {
            Console.WriteLine("Assentos Reservados");
            Console.WriteLine("===================");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"{reserva.Key} - {reserva.Value}");
            }
        }
    }
}