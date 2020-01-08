---------------------------------------------------------------------------------------------------------------------------
-- CREATE DATABASE InternetBanking;
--USE InternetBanking;
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
	senhaAcesso								VARCHAR(15)								NOT NULL,
	novaSenha								VARCHAR(15)									NULL,
	antigaSenha								VARCHAR(15)									NULL
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
	nomePai								    VARCHAR(20)								NULL,
	sobrenomePai						    VARCHAR(30)								NULL,
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
-- DROP TABLE Agencia;
-- DELETE FROM Agencia;
CREATE TABLE Agencia(
	idAgencia							    INT										NOT NULL	PRIMARY KEY,
	numeroAgencia							INT										NOT NULL	DEFAULT(1)
);

INSERT INTO Agencia (idAgencia) VALUES (1);
---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Conta;
-- DELETE FROM Conta;
CREATE TABLE Conta(
	numeroConta								INT										NOT NULL	IDENTITY(1000, 1)					PRIMARY KEY,
	idCliente							    INT										NOT NULL,
	idAgencia								INT										NOT NULL	DEFAULT (1),
	senhaTransacoes						    VARCHAR(4)								NOT NULL,
	dtCriacao							    DATE									NOT NULL	DEFAULT GETDATE(),
	flagAtivo							    INT										NOT NULL,
	saldoAtual								NUMERIC(10,2)							NOT NULL	DEFAULT (0),
	CONSTRAINT FKClienteConta			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente),
	CONSTRAINT FKAgenciaConta			    FOREIGN KEY (idAgencia)					REFERENCES Agencia (idAgencia),
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Status;
-- DELETE FROM Status;
CREATE TABLE Status(
	IDStatus						INT												IDENTITY(1,1)	PRIMARY KEY,
	flagAtivo						INT												NOT NULL,
	dataAlteracao					date											NOT NULL	DEFAULT GETDATE(),
	numeroConta						INT												NOT NULL,
	CONSTRAINT FKContaStatus		FOREIGN KEY (numeroConta)						REFERENCES Conta(numeroConta)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Transacao;
-- DELETE FROM Transacao;
-- QUANDO "idTipoTransacao" ESTIVER COMO "1", É DEPÓSITO
-- QUANDO "idTipoTransacao" ESTIVER COMO "2", É SAQUE
-- QUANDO "idTipoTransacao" ESTIVER COMO "3", É TRANSFERÊNCIA
CREATE TABLE Transacao(
	idTransacao							    INT										NOT NULL					IDENTITY(1, 1) PRIMARY KEY,
	numeroConta								INT										NOT NULL,
	idTipoTransacao							INT										NOT NULL,
	dtTransacao							    VARCHAR(MAX)							NOT NULL,
	numeroContaOrigem						INT										NULL,
	numeroContaDestino						INT										NULL,
	valor									NUMERIC(10,2)							NOT NULL,
	senhaTransacoes						    VARCHAR(4)								NOT NULL,
	CONSTRAINT FKContaTransacao			    FOREIGN KEY (numeroConta)					REFERENCES Conta(numeroConta)
);

---------------------------------------------------------------------------------------------------------------------------
-- DROP TABLE Foto;
-- DELETE FROM Foto;
CREATE TABLE Foto (
    idFoto									INT IDENTITY (1, 1)						 NULL,
	idCliente							    INT										 NULL,
    Binario									VARCHAR(max)							 NULL,
	CONSTRAINT FKClienteFoto			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);

---------------------------------------------------------------------------------------------------------------------------
-- COMANDOS INSERT

/*
INSERT INTO Cliente (cpf, rg, orgaoEmissor, dtNascimento, nome, sobrenome, nacionalidade, naturalidade) 
VALUES ('12345678901', '123456789', 'SSPSP', '1998-06-12', 'José', 'da Silva', 'Brasileira', 'São Paulo');
   
INSERT INTO Conta (idCliente, senhaTransacoes, flagAtivo) 
VALUES (1, '1234', 1);

INSERT INTO Foto (idCliente,binario) 
SELECT 1, * from openrowset (bulk 'C:\Users\Public\Pictures\Foto\teste.jpg', single_blob) imagem
*/

---------------------------------------------------------------------------------------------------------------------------

-- COMANDOS SELECT
/*

SELECT * FROM Login;
SELECT * FROM Familiares;
SELECT * FROM Endereco;
SELECT * FROM Contato;

SELECT * FROM Cliente;
SELECT * FROM Agencia;
SELECT * FROM Conta;
select * from Status;

SELECT * FROM Transacao;

SELECT * FROM Foto;

*/


-- COMANDOS DROP
/*

DROP TABLE Login;
DROP TABLE Familiares;
DROP TABLE Endereco;
DROP TABLE Contato;

DROP TABLE Transacao;
DROP TABLE Conta;
DROP TABLE Foto;
DROP TABLE Agencia
DROP TABLE Cliente;

*/


-- COMANDOS DELETE
/*

DELETE FROM Foto;
DELETE FROM Login;
DELETE FROM Familiares;
DELETE FROM Endereco;
DELETE FROM Contato;
DELETE FROM Transacao;
DELETE FROM Conta;
DELETE FROM Cliente;
DELETE FROM status;

*/


UPDATE login
SET senhaAcesso = '12345678'
WHERE idCliente = 1

UPDATE conta
SET flagAtivo = -1
WHERE idCliente = 1
