﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace _12_08_XX_Fazendo_Hash_Dados.Depois
{
    public class Startup0804 : IAulaItem
    {
        public void Executar()
        {
            //CRIPTOGRAFIA DE MENSAGEM
            //USANDO O PADRÃO AES (ADVANCED ENCRYPTION STANDARD)

            string mensagemSecreta = "Dados secretos que precisam ser protegidos";

            // 1. array de bytes para manter a mensagem criptografada
            byte[] textoCifrado = new byte[0];
            string textoDecifrado = "";
            // 2. matriz de bytes para manter a chave usada para criptografia
            byte[] chave = new byte[0];
            byte[] vetorInicializacao = new byte[0];

            // 3. Cria uma instância de Aes
            // Isso cria uma chave aleatória e um vetor de inicialização
            using (Aes aes = Aes.Create())
            {
                // 3.1. copia a chave
                chave = aes.Key;
                vetorInicializacao = aes.IV;

                // 3.2 cria um criptografador para criptografar alguns dados
                ICryptoTransform codificador = aes.CreateEncryptor();

                // 3.3 Cria um novo fluxo de memória para receber os
                // dados criptografados.
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // 3.4. crie um CryptoStream, diga ao stream para gravar
                    // e o encriptador para usar. Também defina o modo
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, codificador, CryptoStreamMode.Write))
                    {
                        // 3.5 cria um gravador de fluxo a partir do cryptostream
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            // 3.6 Escreva a mensagem secreta para o fluxo.
                            streamWriter.Write(mensagemSecreta);
                        }

                        // 3.7 obtém a mensagem criptografada do fluxo
                        textoCifrado = memoryStream.ToArray();
                    }
                }
            }

            // 4. Exibir o texto, a chave e o texto encriptado
            Console.WriteLine("Mensagem original: {0}", mensagemSecreta);

            ExibirBytes("Chave: ", chave);
            ExibirBytes("Texto encriptado: ", textoCifrado);

            //TAREFA : DESCRIPTOGRAFAR OS DADOS DA VARIÁVEL textoCifrado
            //USANDO O PADRÃO AES (ADVANCED ENCRYPTION STANDARD)
            //E USANDO VETOR DE INICIALIZAÇÃO

            using (Aes aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = vetorInicializacao;

                ICryptoTransform decodificador = aes.CreateDecryptor();

                using (MemoryStream memoryStream = new MemoryStream(textoCifrado))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decodificador, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            textoDecifrado = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            Console.WriteLine("Texto decifrado: {0}", textoDecifrado);
            Console.ReadLine();
        }

        private static void ExibirBytes(string titulo, byte[] bytes)
        {
            Console.Write(titulo);

            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();
        }
    }
}