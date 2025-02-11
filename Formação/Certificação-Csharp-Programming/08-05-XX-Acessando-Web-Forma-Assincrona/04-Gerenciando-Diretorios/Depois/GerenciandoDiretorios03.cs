﻿using System;
using System.IO;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class GerenciandoDiretorios03 : IAulaItem //Trabalhando com caminhos
    {
        public void Executar()
        {
            //TAREFAS:
            //Descobrir o caminho da pasta "Meus Documentos"
            //Combinar caminho da pasta "Meus Documentos" com arquivo "alura.txt"
            //Obter somente o nome do diretório do arquivo
            //Obter somente o nome do arquivo
            //Obter a extensão do arquivo
            //Modificar a extensão do arquivo

            var meusDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Meus Documentos: {0}", meusDocumentos);

            var caminhoCompleto = Path.Combine(meusDocumentos, "alura.txt");
            Console.WriteLine("Caminho Completo: {0}", caminhoCompleto);

            var somenteNomeDiretorio = Path.GetDirectoryName(caminhoCompleto);
            Console.WriteLine("Somente Nome do Diretório: {0}", somenteNomeDiretorio);

            var somenteNomeArquivo = Path.GetFileName(caminhoCompleto);
            Console.WriteLine("Somente Nome do Arquivo: {0}", somenteNomeArquivo);

            var extensaoArquivo = Path.GetExtension(caminhoCompleto);
            Console.WriteLine("Extensão do Arquivo: {0}", extensaoArquivo);

            caminhoCompleto = Path.ChangeExtension(caminhoCompleto, "xyz");
            Console.WriteLine("Nova extensão do arquivo: {0}", caminhoCompleto);
        }
    }
}