---------------------------------------------------------------------------------------------------------------------------

-- CREATE DATABASE InternetBanking;
USE InternetBanking;

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Cliente;
-- DELETE FROM Cliente;
CREATE TABLE Cliente(
	idCliente							    INT										NOT NULL	IDENTITY(1, 1)					PRIMARY KEY,
	cpf									    VARCHAR(11)								NOT NULL									UNIQUE,
	rg									    VARCHAR(9)								NOT NULL,	
	orgaoEmissor						    VARCHAR(5)								NOT NULL,
	dtNascimento						    DATE 									NOT NULL,
	nome								    VARCHAR(20)								NOT NULL,
	sobrenome							    VARCHAR(30)								NOT NULL,
	nacionalidade						    VARCHAR(20)								NOT NULL,
	naturalidade						    VARCHAR(20)								NOT NULL
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Login;
-- DELETE FROM Login;
 CREATE TABLE Login(
	idLogin								    INT										NOT NULL	IDENTITY(1, 1)				PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	cpf									    VARCHAR(11)								NOT NULL,
	senha								    VARCHAR(15)								NOT NULL
	CONSTRAINT FKClienteLogin			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Familiares;
-- DELETE FROM Familiares;
CREATE TABLE Familiares(
	idFamiliares						    INT										NOT NULL	IDENTITY(1, 1)				PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	nomeMae								    VARCHAR(20)								NOT NULL,
	sobrenomeMae						    VARCHAR(30)								NOT NULL,
	nomePai								    VARCHAR(20)									NULL,
	sobrenomePai						    VARCHAR(30)									NULL,
	CONSTRAINT FKClienteFamiliares		    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Endereco;
-- DELETE FROM Endereco;
CREATE TABLE Endereco(
	idEndereco							    INT										NOT NULL	IDENTITY(1, 1)				 PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	logradouro							    VARCHAR(50)								NOT NULL,
	numero								    INT										NOT NULL,
	complemento							    VARCHAR(30)								NOT NULL,
	bairro								    VARCHAR(20)								NOT NULL,
	cidade								    VARCHAR(30)								NOT NULL,
	siglaEstado							    CHAR(2)									NOT NULL,
	cep									    VARCHAR(8)								NOT NULL,
	flagStatus							    CHAR(1)	DEFAULT(1)						NOT NULL,
	CONSTRAINT FKClienteEndereco		    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Contato;
-- DELETE FROM Contato;
CREATE TABLE Contato(
	idContato							    INT										NOT NULL	IDENTITY(1, 1)					PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	email								    VARCHAR(30)								NOT NULL									UNIQUE,
	telResid							    VARCHAR(12)									NULL,
	telCel								    VARCHAR(13)								NOT NULL									UNIQUE,
	flagStatus							    CHAR(1)			DEFAULT(1)				NOT NULL,
	CONSTRAINT FKClienteContato			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Conta;
-- DELETE FROM Conta;
CREATE TABLE Conta(
	idConta								    INT										NOT NULL	IDENTITY(1, 1)					PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	Agencia									INT										NOT NULL DEFAULT (1),
	Banco								    INT										NOT NULL DEFAULT (1),
	senhaTransacoes						    VARCHAR(4)								NOT NULL DEFAULT '1234',
	dtCriacao							    DATE									NOT NULL DEFAULT GETDATE(),
	flagAtivo							    CHAR(1)									NOT NULL DEFAULT(1),
	CONSTRAINT FKClienteConta			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente),
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE ContaCorrente;
-- DELETE FROM ContaCorrente;
CREATE TABLE ContaCorrente(
	idContaCorrente						    INT										NOT NULL	IDENTITY(1, 1)					PRIMARY KEY,
	idConta									INT										NOT NULL,
	numConta							    INT										NOT NULL,
	saldo								    NUMERIC  DEFAULT(0)						NOT NULL,
	CONSTRAINT FKContaContaCorrente			FOREIGN KEY (idConta)					REFERENCES Conta(idConta)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE TipoTransacao;
-- DELETE FROM TipoTransacao;
--CREATE TABLE TipoTransacao(
--	idTipoTransacao							INT										NOT NULL					PRIMARY KEY,
--	cdTipoTransacao							INT										NOT NULL,
--	-- CONSTRAINT FKTipoTransacaoTransacao		FOREIGN KEY (idTipoTransacao)					REFERENCES TipoTransacao(idTipoTransacao)
--);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Transacao;
-- DELETE FROM Transacao;
CREATE TABLE Transacao(
	idTransacao							    INT										NOT NULL					IDENTITY(1, 1) PRIMARY KEY,
	idContaCorrenteOrigem					INT										NOT NULL,
	idContaCorrenteDestino					INT										NOT NULL,
	idTipoTransacao							INT										NOT NULL,
	dtTransacao							    DATE									NOT NULL					DEFAULT(GETDATE()),
	numeroContaOrigem						INT										    NULL,
	numeroContaDestino						INT											NULL,
	valor									NUMERIC									NOT NULL,
	CONSTRAINT FKContaTransacao			    FOREIGN KEY (idContaCorrente)					REFERENCES ContaCorrente(idContaCorrente)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Banco;
-- DELETE FROM Banco;
--CREATE TABLE Banco(
--	idBanco								    INT										NOT NULL									PRIMARY KEY,
--	idEndereco							    INT										NOT NULL,
--	nomeFantasia						    VARCHAR(30)								NOT NULL,
--	cnpj								    VARCHAR(14)								NOT NULL,
--	ispb								    VARCHAR(8)								NOT NULL
--);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Agencia;
-- DELETE FROM Agencia;
--CREATE TABLE Agencia(
--	idAgencia							    INT										NOT NULL									PRIMARY KEY,
--	idBanco								    INT										NOT NULL,
--	numAgencia							    INT										NOT NULL,
--	CONSTRAINT FKBancoAgencia			    FOREIGN KEY (idBanco)					REFERENCES Banco (idBanco)
--);

---------------------------------------------------------------------------------------------------------------------------


-- COMANDOS INSERT

-- CLIENTE
INSERT INTO Cliente (cpf, rg, orgaoEmissor, dtNascimento, nome, sobrenome, nacionalidade, naturalidade)
VALUES ('11111111111', '111111111', 'SSPSP', '2000-01-01', 'Nome', 'Sobrenome', 'Nacionalidade', 'Naturalidade');

INSERT INTO Login (idCliente, cpf, senha)
VALUES (1, '11111111111', 'senha');

INSERT INTO Familiares (idCliente, nomeMae, sobrenomeMae, nomePai, sobrenomePai)
VALUES (1, 'NomeMãe', 'SobrenomeMãe', 'NomePai', 'SobrenomePai');

INSERT INTO Endereco (idCliente, logradouro, numero, complemento, bairro, cidade, siglaEstado, cep)
VALUES (1, 'Rua Logradouro', 1, 'Complemento', 'Bairro', 'Cidade', 'SP', '11111111');

INSERT INTO Contato (idCliente, email, telResid, telCel)
VALUES (1, 'email@email.com', '11 0000-0000','11 11111-1111');


-- CONTA
INSERT INTO Cliente (cpf, rg, orgaoEmissor, dtNascimento, nome, sobrenome, nacionalidade, naturalidade)
VALUES ('11111111112', '111111112', 'SSPSP', '2000-01-01', 'Nome', 'Sobrenome', 'Nacionalidade', 'Naturalidade');

INSERT INTO Conta (idCliente)
VALUES (1);

INSERT INTO ContaCorrente (idConta , numConta)
VALUES (1, 1235456);

INSERT INTO Conta (idCliente)
VALUES (2);

INSERT INTO ContaCorrente (idConta , numConta)
VALUES (2, 654321);

-- TRANSACAO
/*
INSERT INTO Transacao (idContaCorrente, idTipoTransacao, numConta, valor)
VALUES (1, 1, 123456, 500);

-- INSERT INTO Banco (idBanco, idEndereco, nomeFantasia, cnpj, ispb)
-- VALUES (1, 1, 'NomeFantasia', '11111111111111', '11111111');

-- INSERT INTO Agencia (idAgencia, idBanco, numAgencia)
-- VALUES (1, 1, 1);
*/

-- COMANDOS SELECT
/*
SELECT * FROM Cliente;
SELECT * FROM Login;
SELECT * FROM Familiares;
SELECT * FROM Endereco;
SELECT * FROM Contato;

SELECT * FROM Conta;
SELECT * FROM ContaCorrente;

SELECT * FROM Transacao;

-- SELECT * FROM Agencia;
-- SELECT * FROM Banco;
*/


-- COMANDOS DROP
/*
DROP TABLE Login;
DROP TABLE Familiares;
DROP TABLE Endereco;
DROP TABLE Contato;
DROP TABLE Transacao;
DROP TABLE TipoTransacao;
DROP TABLE ContaCorrente;
DROP TABLE Conta;
DROP TABLE Cliente;

-- DROP TABLE Agencia;
-- DROP TABLE Banco;
*/


-- COMANDOS DELETE
/*
DELETE FROM Login;
DELETE FROM Familiares;
DELETE FROM Endereco;
DELETE FROM Contato;
DELETE FROM Transacao;
DELETE FROM ContaCorrente;
DELETE FROM Conta;
DELETE FROM Cliente;

-- DELETE FROM Agencia;
-- DELETE FROM Banco;
-- DELETE FROM Transferencia;
*/