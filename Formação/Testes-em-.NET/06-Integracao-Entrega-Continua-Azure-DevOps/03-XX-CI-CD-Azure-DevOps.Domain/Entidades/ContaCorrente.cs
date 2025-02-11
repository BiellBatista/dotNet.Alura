﻿using System.ComponentModel.DataAnnotations;

namespace _03_XX_CI_CD_Azure_DevOps.Domain.Entidades
{
    public class ContaCorrente
    {
        [Key]
        public int Id { get; set; }

        public int Numero { get; set; }
        public Guid Identificador { get; set; }

        public ContaCorrente()
        {
        }

        private Cliente _cliente;

        public virtual Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Cliente não pode ser nulo.");
                }
                _cliente = value;
            }
        }

        private Agencia _agencia;

        public virtual Agencia Agencia
        {
            get { return _agencia; }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Agência não pode ser nulo.");
                }
                _agencia = value;
            }
        }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("O valor para saldo não pode ser menor ou igual a zero.");
                }

                _saldo += value;
            }
        }

        private Guid _pix;
        public Guid PixConta { get => _pix; set => _pix = value; }
    }
}