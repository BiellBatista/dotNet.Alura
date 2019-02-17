CREATE DATABASE SUCOS_VENDAS_01

CREATE DATABASE SALES_VENDAS_02
ON ( NAME = SUCO_VENDAS_DAT,  // nome da particao do banco
    FILENAME = 'C:\TEMP\DATA\SALES_VENDAS_02.mdf', // criando o banco de dados nesse diretório 
    SIZE = 10,  // tamanho inicial de 10 MB
    MAXSIZE = 50,  // tamanho máximo de 50 MB
    FILEGROWTH = 5 )  // o banco irá crescer de 5 em 5 MB
LOG ON  // logs
( NAME = SUCOS_VENDAS_LOG,  // nome da particao do log
    FILENAME = 'C:\TEMP\DATA\SALES_VENDAS_02.ldf',  // criando o arquivo log do banco
    SIZE = 5MB,  // tamanho inicial de 5 MB
    MAXSIZE = 25MB,  // tamanho máximo de 25 MB
    FILEGROWTH = 5MB ) // o banco irá crescer de 5 em 5 MB
