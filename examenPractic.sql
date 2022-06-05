USE master
GO
IF(EXISTS(SELECT * FROM sys.databases WHERE name='P72022'))
	DROP DATABASE P72022;
GO
CREATE DATABASE P72022;
GO
USE P72022;
GO
CREATE TABLE Firme
(cod_f INT PRIMARY KEY IDENTITY,
nume_f VARCHAR(100),
tara_de_origine VARCHAR(100)
);
CREATE TABLE Parfumuri
(cod_p INT PRIMARY KEY IDENTITY,
nume_p VARCHAR(100),
descriere_p VARCHAR(100),
pret INT,
an_lansare INT,
cod_f INT FOREIGN KEY REFERENCES Firme(cod_f) 
ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE TABLE Orase
(cod_o INT PRIMARY KEY IDENTITY,
nume_o VARCHAR(100)
);
CREATE TABLE Clienti
(cod_c INT PRIMARY KEY IDENTITY,
nume_c VARCHAR(100),
email_c VARCHAR(100),
cod_o INT FOREIGN KEY REFERENCES Orase(cod_o) 
ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE TABLE Note
(cod_p INT FOREIGN KEY REFERENCES Parfumuri(cod_p)
ON UPDATE CASCADE ON DELETE CASCADE,
cod_c INT FOREIGN KEY REFERENCES Clienti(cod_c)
ON UPDATE CASCADE ON DELETE CASCADE,
nota REAL,
CONSTRAINT pk_Note PRIMARY KEY (cod_p, cod_c)
);
--Firme
INSERT INTO Firme (nume_f,tara_de_origine) VALUES
('Armani','Italia');
INSERT INTO Firme (nume_f,tara_de_origine) VALUES
('Chanel','Franta');
INSERT INTO Firme (nume_f,tara_de_origine) VALUES
('Versace','Italia');
--Parfumuri Armani
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum1 Armani','descriere parfum1',400,2020,1);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum2 Armani','descriere parfum2',500,2022,1);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum3 Armani','descriere parfum3',350,2020,1);
--Parfumuri Chanel
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum4 Chanel','descriere parfum4',400,2010,2);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum5 Chanel','descriere parfum5',600,2000,2);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum6 Chanel','descriere parfum6',900,1992,2);
--Parfumuri Versace
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum7 Versace','descriere parfum7',1000,2002,3);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum8 Versace','descriere parfum8',1200,2009,3);
INSERT INTO Parfumuri (nume_p,descriere_p,pret,an_lansare,cod_f)
VALUES ('parfum9 Versace','descriere parfum9',1100,2007,3);
--Tari
INSERT INTO Orase (nume_o) VALUES ('Roma');
INSERT INTO Orase (nume_o) VALUES ('Madrid');
INSERT INTO Orase (nume_o) VALUES ('Atena');
--Clienti
INSERT INTO Clienti (nume_c, email_c,cod_o) VALUES 
('client1','client1@gmail.com',1);
INSERT INTO Clienti (nume_c, email_c,cod_o) VALUES 
('client2','client2@gmail.com',2);
INSERT INTO Clienti (nume_c, email_c,cod_o) VALUES 
('client3','client3@gmail.com',3);
--Note
INSERT INTO Note (cod_p,cod_c,nota) VALUES (1,1,10);
INSERT INTO Note (cod_p,cod_c,nota) VALUES (2,1,9);
INSERT INTO Note (cod_p,cod_c,nota) VALUES (3,3,7);



---------------- Rezolvare exercitiu 2 -------------

go
ALTER PROCEDURE Phantom_Reads_T1 AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		WAITFOR DELAY '00:00:05'
		INSERT INTO Orase(nume_o) VALUES ('numeNou')
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END


go 
ALTER PROCEDURE Phantom_Reads_T2 AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ		-- !!!!!!!!
	BEGIN TRAN
	BEGIN TRY
		SELECT * FROM Orase
		WAITFOR DELAY '00:00:10'
		SELECT * FROM Orase
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END


go 
ALTER PROCEDURE Phantom_Reads_T2_Solved AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	BEGIN TRY
		SELECT * FROM Orase
		WAITFOR DELAY '00:00:10'
		SELECT * FROM Orase
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END


-------------

EXECUTE Phantom_Reads_T1;

SELECT * FROM Orase;

-------------- Rezolvare Exercitiul 3 ---------

SELECT * FROM Firme;

SELECT nume_f FROM Firme ORDER BY tara_de_origine;

CREATE INDEX idx_tara_nume_firme ON Firme(tara_de_origine) INCLUDE (nume_f);