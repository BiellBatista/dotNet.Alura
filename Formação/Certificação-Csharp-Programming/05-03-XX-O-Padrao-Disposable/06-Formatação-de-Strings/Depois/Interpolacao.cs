using System;

namespace _05_03_XX_O_Padrao_Disposable.Depois
{
    public class Interpolacao : IAulaItem
    {
        public void Executar()
        {
            var contrato = new
            {
                Empresa = "Alura Serviços Hidráulicos Ltda.",
                Funcionario = "Mario Mario",
                Inicio = new DateTime(2019, 1, 1),
                Cargo = "encanador",
                Salario = 3108.45,
                InicioJornada = new DateTime(2018, 1, 10, 9, 0, 0),
                FimJornada = new DateTime(2018, 1, 10, 18, 0, 0)
            };

            string documento =

$@"CONTRATO INDIVIDUAL DE TRABALHO TEMPORÁRIO
            EMPREGADOR: {contrato.Empresa}
            EMPREGADO: {contrato.Funcionario}
Pelo presente instrumento particular de contrato individual de trabalho,
fica justo e contratado o seguinte:
 Cláusula 1ª - O EMPREGADO prestará ao EMPREGADOR, a partir de
{contrato.Inicio:d} e assinatura deste instrumento, seus trabalhos
exercendo a função de {contrato.Cargo}, prestando pessoalmente o
labor diário no período compreendido entre {contrato.InicioJornada:t} e {contrato.FimJornada:t},
e intervalo de 1 hora para almoço;
            Cláusula 2ª - Não haverá expediente nos dias de sábado, sendo
prestado a compensação de horário semanal;
            Cláusula 3ª - O EMPREGADOR pagará mensalmente, ao EMPREGADO, a
título de salário a importância de {contrato.Salario:C}, com os
descontos previstos por lei;

São Paulo, {DateTime.Now:D}
_______________________________________________________
{contrato.Empresa}
______________________________________________________
{contrato.Funcionario}
_______________________________________________________
(Nome, R.G, Testemunha)
_______________________________________________________
(Nome, R.G, Testemunha)";

            Console.WriteLine(documento);
            Console.ReadKey();
        }
    }
}