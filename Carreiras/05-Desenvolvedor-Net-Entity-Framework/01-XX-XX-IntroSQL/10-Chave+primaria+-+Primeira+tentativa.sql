
INSERT INTO [TABELA DE PRODUTOS]
([CODIGO DO PRODUTO], [NOME DO PRODUTO], [EMBALAGEM], [TAMANHO], [SABOR], [PRE�O DE LISTA])
VALUES
('788975', 'Peda�os de Frutas - 1,5 Litros - Ma�a', 'PET', '1,5 Litros', 'Ma�a', 18.01)

INSERT INTO [TABELA DE PRODUTOS]
([CODIGO DO PRODUTO], [NOME DO PRODUTO], [EMBALAGEM], [TAMANHO], [SABOR], [PRE�O DE LISTA])
VALUES
('788975', 'Peda�os de Frutas - 1,5 Litros - Ma�a', 'PET', '1,5 Litros', 'Ma�a', 18.01)

DELETE FROM [TABELA DE PRODUTOS] WHERE [CODIGO DO PRODUTO] = '788975'

ALTER TABLE [TABELA DE PRODUTOS]
ADD CONSTRAINT PK_PRODUTOS 
PRIMARY KEY CLUSTERED ([CODIGO DO PRODUTO])


INSERT INTO [TABELA DE PRODUTOS]
([CODIGO DO PRODUTO], [NOME DO PRODUTO], [EMBALAGEM], [TAMANHO], [PRE�O DE LISTA])
VALUES
('788975', 'Peda�os de Frutas - 1,5 Litros - Ma�a', 'PET', '1,5 Litros', 18.01)


---------------FORMA CERTA---------------------------------------
ALTER TABLE [TABELA DE VENDEDORES]
ALTER COLUMN [MATRICULA]
VARCHAR(5) NOT NULL

ALTER TABLE [TABELA DE VENDEDORES]
ADD CONSTRAINT PK_VENDEDORES
PRIMARY KEY CLUSTERED ([MATRICULA])



