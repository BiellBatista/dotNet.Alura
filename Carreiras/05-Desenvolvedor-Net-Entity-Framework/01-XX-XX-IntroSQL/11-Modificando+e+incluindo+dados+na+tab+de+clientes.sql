USE [SUCOS_VENDAS]
GO

INSERT INTO [dbo].[TABELA DE CLIENTES]
           ([CPF]
           ,[NOME]
           ,[ENDERECO 1]
           ,[ENDERECO 2]
           ,[BAIRRO]
           ,[CIDADE]
           ,[ESTADO]
           ,[CEP]
           ,[DATA DE NASCIMENTO]
           ,[IDADE]
           ,[SEXO]
           ,[LIMITE DE CREDITO]
           ,[VOLUME DE COMPRA]
           ,[PRIMEIRA COMPRA])
     VALUES
           (<CPF, varchar(11),>
           ,<NOME, varchar(100),>
           ,<ENDERECO 1, varchar(150),>
           ,<ENDERECO 2, varchar(150),>
           ,<BAIRRO, varchar(50),>
           ,<CIDADE, varchar(50),>
           ,<ESTADO, varchar(2),>
           ,<CEP, varchar(8),>
           ,<DATA DE NASCIMENTO, date,>
           ,<IDADE, smallint,>
           ,<SEXO, varchar(1),>
           ,<LIMITE DE CREDITO, money,>
           ,<VOLUME DE COMPRA, float,>
           ,<PRIMEIRA COMPRA, bit,>)
GO

-------------------------------------------Modificando a tabela de vendedores
DROP TABLE [TABELA DE VENDEDORES]

CREATE TABLE [TABELA DE VENDEDORES]
( [MATRICULA] varchar(5),
[NOME] varchar(100),
[PERCENTUAL COMISSÃO] float,
[DATA ADMISSÃO] date,
[DE FERIAS] bit)

ALTER TABLE [TABELA DE VENDEDORES]
ALTER COLUMN [MATRICULA]
VARCHAR(5) NOT NULL

ALTER TABLE [TABELA DE VENDEDORES]
ADD CONSTRAINT PK_VENDEDORES
PRIMARY KEY CLUSTERED ([MATRICULA])

INSERT INTO [TABELA DE VENDEDORES]
([MAtRICULA], [NOME], [DATA ADMISSÃO], [PERCENTUAL COMISSÃO], [DE FERIAS])
VALUES
('00235','Márcio Almeida Silva','2014-08-15',0.08,0)

INSERT INTO [TABELA DE VENDEDORES]
([MAtRICULA], [NOME], [DATA ADMISSÃO], [PERCENTUAL COMISSÃO], [DE FERIAS])
VALUES
('00236','Cláudia Morais','2013-09-17',0.08,1)

INSERT INTO [TABELA DE VENDEDORES]
([MAtRICULA], [NOME], [DATA ADMISSÃO], [PERCENTUAL COMISSÃO], [DE FERIAS])
VALUES
('00237','Roberta Martins','2017-03-18',0.11,1)

INSERT INTO [TABELA DE VENDEDORES]
([MAtRICULA], [NOME], [DATA ADMISSÃO], [PERCENTUAL COMISSÃO], [DE FERIAS])
VALUES
('00238','Pericles Alves','2016-08-21',0.11,0)
