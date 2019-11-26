---------------------------------------------------------------------------------------------------------------------------

-- CREATE DATABASE InternetBanking;
USE InternetBanking;

---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Cliente;
-- DELETE FROM Cliente;
CREATE TABLE Cliente(
	idCliente							    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
	cpf									    VARCHAR(11)								NOT NULL										UNIQUE,
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
	idLogin								    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
	idCliente							    INT										NOT NULL,
	cpf									    VARCHAR(11)								NOT NULL,
	senha								    VARCHAR(15)								NOT NULL
	CONSTRAINT FKClienteLogin			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Familiares;
-- DELETE FROM Familiares;
CREATE TABLE Familiares(
	idFamiliares						    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
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
	idEndereco							    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
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
	idContato							    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
	idCliente							    INT										NOT NULL,
	email								    VARCHAR(30)								NOT NULL										UNIQUE,
	telResid							    VARCHAR(12)									NULL,
	telCel								    VARCHAR(13)								NOT NULL										UNIQUE,
	flagStatus							    CHAR(1)			DEFAULT(1)				NOT NULL,
	CONSTRAINT FKClienteContato			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente)
);


---------------------------------------------------------------------------------------------------------------------------

-- DROP TABLE Banco;
-- DELETE FROM Banco;
--CREATE TABLE Banco(
--	idBanco								    INT										NOT NULL						 PRIMARY KEY CLUSTERED,
--	idEndereco							    INT										NOT NULL,
--	nomeFantasia						    VARCHAR(30)								NOT NULL,
--	cnpj								    VARCHAR(14)								NOT NULL,
--	ispb								    VARCHAR(8)								NOT NULL
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Agencia;
-- DELETE FROM Agencia;
--CREATE TABLE Agencia(
--	idAgencia							    INT										NOT NULL						 PRIMARY KEY CLUSTERED,
--	idBanco								    INT										NOT NULL,
--	numAgencia							    INT										NOT NULL,
--	CONSTRAINT FKBancoAgencia			    FOREIGN KEY (idBanco)					REFERENCES Banco (idBanco)
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Transferencia;
-- DELETE FROM Transferencia;
--CREATE TABLE Transferencia(
--	idTransferencia						    INT										NOT NULL						 PRIMARY KEY CLUSTERED,
--	contaOrigem							    INT										NOT NULL,
--	contaDestino						    INT										NOT NULL
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Deposito;
-- DELETE FROM Deposito;
--CREATE TABLE Deposito(
--	idDeposito							    INT										NOT NULL						 PRIMARY KEY CLUSTERED,
--	contaDestino						    INT										NOT NULL,
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Saque;
-- DELETE FROM Saque;
--CREATE TABLE Saque(
--	idSaque								    INT										NOT NULL						 PRIMARY KEY CLUSTERED,
--	contaOrigem							    INT										NOT NULL,
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Transacao;
-- DELETE FROM Transacao;
--CREATE TABLE Transacao(
--	idTransacao							    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
--	idSaque								    INT										NOT NULL,
--	idDeposito							    INT										NOT NULL,
--	idTransferencia						    INT										NOT NULL,
--	dtTransacao							    DATE									NOT NULL,
--	valor								    NUMERIC									NOT NULL
--	CONSTRAINT FKSaqueTransacao			    FOREIGN KEY (idSaque)					REFERENCES Saque(idSaque),
--	CONSTRAINT FKDepositoTransacao		    FOREIGN KEY (idDeposito)				REFERENCES Deposito(idDeposito),
--	CONSTRAINT FKTransferenciaTransacao     FOREIGN KEY (idTransferencia)			REFERENCES Transferencia(idTransferencia)
--);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE Conta;
-- DELETE FROM Conta;
CREATE TABLE Conta(
	idConta								    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
	idCliente							    INT										NOT NULL,
	idAgencia							    INT										NOT NULL DEFAULT (1),
	idBanco								    INT										NOT NULL DEFAULT (1),
	senhaTransacoes						    VARCHAR(4)								NOT NULL DEFAULT '1234',
	dtCriacao							    DATE									NOT NULL DEFAULT GETDATE(),
	flagAtivo							    CHAR(1)									NOT NULL DEFAULT(1),
	CONSTRAINT FKClienteConta			    FOREIGN KEY (idCliente)					REFERENCES Cliente (idCliente),
);


---------------------------------------------------------------------------------------------------------------------------


-- DROP TABLE ContaCorrente;
-- DELETE FROM ContaCorrente;
--CREATE TABLE ContaCorrente(
--	idContaCorrente						    INT										NOT NULL	IDENTITY(1, 1)		 PRIMARY KEY CLUSTERED,
--	idTransacao							    INT										NOT NULL,
--	idConta									INT										NOT NULL,
--	numConta							    INT										NOT NULL,
--	saldo								    VARCHAR(6)  DEFAULT(0)					NOT NULL,
--	CONSTRAINT FKTransacaoContaCorrente	    FOREIGN KEY (idTransacao)				REFERENCES Transacao(idTransacao),
--	CONSTRAINT FKContaContaCorrente			FOREIGN KEY (idConta)					REFERENCES Conta(idConta)
--);


---------------------------------------------------------------------------------------------------------------------------


-- COMANDOS INSERT
/*
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
INSERT INTO Conta (idCliente);
VALUES (1);

*/



-- COMANDOS SELECT
/*
SELECT * FROM Login;
SELECT * FROM Familiares;
SELECT * FROM Endereco;
SELECT * FROM Contato;
SELECT * FROM Conta;
SELECT * FROM Cliente;
SELECT * FROM Agencia;
SELECT * FROM Banco;
SELECT * FROM ContaCorrente;
SELECT * FROM Transacao;
SELECT * FROM Deposito;
SELECT * FROM Saque;
SELECT * FROM Transferencia;
*/



-- COMANDOS DROP
/*
DROP TABLE Login;
DROP TABLE Familiares;
DROP TABLE Endereco;
DROP TABLE Contato;
DROP TABLE Conta;
DROP TABLE Cliente;
DROP TABLE Agencia;
DROP TABLE Banco;
DROP TABLE ContaCorrente;
DROP TABLE Transacao;
DROP TABLE Deposito;
DROP TABLE Saque;
DROP TABLE Transferencia;
*/



-- COMANDOS DELETE
/*
DELETE FROM Login;
DELETE FROM Familiares;
DELETE FROM Endereco;
DELETE FROM Contato;
DELETE FROM Conta;
DELETE FROM Cliente;
DELETE FROM Agencia;
DELETE FROM Banco;
DELETE FROM ContaCorrente;
DELETE FROM Transacao;
DELETE FROM Deposito;
DELETE FROM Saque;
DELETE FROM Transferencia;
*/