CREATE TABLE LogTable
(
	id INT IDENTITY,
	operationType VARCHAR(20),
	tableName VARCHAR(20),
	executionTime DATETIME,
	CONSTRAINT pk_LogTable PRIMARY KEY(id)
)

go

DELETE FROM LogTable
DELETE FROM Repartizari
DELETE FROM Profesori
DELETE FROM Materii


ALTER FUNCTION validateParameters_Profesor(@nume VARCHAR(50), @prenume VARCHAR(50))
RETURNS VARCHAR(200)
AS
BEGIN
	DECLARE @errorMessage VARCHAR(200)
	SET @errorMessage = ''

	IF (@nume = '' OR LEFT(@nume, 1) != UPPER(LEFT(@nume, 1)) COLLATE Latin1_General_BIN)
		SET @errorMessage = @errorMessage + 'Nume Profesor invalid.'

	IF (@prenume = '' OR LEFT(@prenume, 1) != UPPER(LEFT(@prenume, 1)) COLLATE Latin1_General_BIN)
		SET @errorMessage = @errorMessage + 'Prenume Profesor invalid.'


	RETURN @errorMessage
END
go

ALTER FUNCTION validateParameters_Materie(@nume VARCHAR(50), @descriere VARCHAR(50))
RETURNS VARCHAR(200)
AS
BEGIN
	DECLARE @errorMessage VARCHAR(200)
	SET @errorMessage = ''

	IF (@nume = '' OR LEFT(@nume, 1) != UPPER(LEFT(@nume, 1)) COLLATE Latin1_General_BIN)
		SET @errorMessage = @errorMessage + 'Nume Materie invalid.'

	IF (LEFT(@descriere, 1) != UPPER(LEFT(@descriere, 1)) COLLATE Latin1_General_BIN)
		SET @errorMessage = @errorMessage + 'Descriere Materie invalida.'


	RETURN @errorMessage
END
go

ALTER FUNCTION validateParameters_Repartizare(@idProfesor NVARCHAR(50), @idMaterie NVARCHAR(50), @teorie BIT, @laborator BIT)
RETURNS VARCHAR(200)
AS
BEGIN
	DECLARE @errorMessage VARCHAR(200)
	SET @errorMessage = ''

	IF (EXISTS(SELECT id_materie, id_profesor FROM Repartizari WHERE id_materie = @idMaterie AND id_profesor = @idProfesor))
		SET @errorMessage = @errorMessage + 'Valorile deja exista in tabel.'

	IF (@teorie = 0 AND @laborator = 0)
		SET @errorMessage = @errorMessage + 'Profesorul trebuie sa fie cel putin la o categorie (teorie sau/si laborator).'

	RETURN @errorMessage
END
go


ALTER PROCEDURE Insert_Into_Tables(@numeProfesor NVARCHAR(50), @prenumeProfesor NVARCHAR(50), @numeMaterie NVARCHAR(50), @descriereMaterie VARCHAR(100), @teorie BIT, @laborator BIT)
AS
BEGIN
	
	BEGIN TRAN
	BEGIN TRY
		DECLARE @errorMessage VARCHAR(200)
		SET @errorMessage = dbo.validateParameters_Profesor(@numeProfesor, @prenumeProfesor)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Profesori(nume, prenume) VALUES (@numeProfesor, @prenumeProfesor)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Profesori', CURRENT_TIMESTAMP)

		SET @errorMessage = dbo.validateParameters_Materie(@numeMaterie, @descriereMaterie)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Materii(nume, descriere) VALUES (@numeMaterie,@descriereMaterie)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Materii', CURRENT_TIMESTAMP)

		DECLARE @idProfesori INT, @idMaterii INT
		SET @idProfesori = (SELECT MAX(id_profesor) FROM Profesori)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Profesori', CURRENT_TIMESTAMP)
		SET @idMaterii = (SELECT MAX(id_materie) FROM Materii)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Materii', CURRENT_TIMESTAMP)

		SET @errorMessage = dbo.validateParameters_Repartizare(@idProfesori, @idMaterii, @teorie, @laborator)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Repartizari(id_materie, id_profesor, teorie, laborator) VALUES (@idMaterii, @idProfesori, @teorie,@laborator)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Repartizari', CURRENT_TIMESTAMP)

		COMMIT TRAN

		SELECT 'Transaction committed'
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked'
		SELECT @errorMessage
	END CATCH

END
go

-- with success (commit)
EXECUTE dbo.Insert_Into_Tables 'Petracovici', 'Daniel', 'Romana', '', 1, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable


-- without success (rollback) no repartizare
EXECUTE dbo.Insert_Into_Tables 'Petracovici', 'Daniel', 'Romana', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable

-- without success (rollback) no materie
EXECUTE dbo.Insert_Into_Tables 'Petracovici', 'Daniel', '', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable


-- without success (rollback) no profesor
EXECUTE dbo.Insert_Into_Tables 'Petracovici', '', 'Romana', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable

go


ALTER PROCEDURE Insert_Into_Tables_v2(@numeProfesor NVARCHAR(50), @prenumeProfesor NVARCHAR(50), @numeMaterie NVARCHAR(50), @descriereMaterie VARCHAR(100), @teorie BIT, @laborator BIT)
AS
BEGIN

	DECLARE @error INT
	SET @error = 0
	
	BEGIN TRAN
	BEGIN TRY
		DECLARE @errorMessage VARCHAR(200)
		SET @errorMessage = dbo.validateParameters_Profesor(@numeProfesor, @prenumeProfesor)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Profesori(nume, prenume) VALUES (@numeProfesor, @prenumeProfesor)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Profesori', CURRENT_TIMESTAMP)

		COMMIT TRAN
		SELECT 'Transaction committed for table Profesori'
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked for table Profesori'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('ROLLBACK', 'Profesori', CURRENT_TIMESTAMP)
		SET @error = 1
	END CATCH

	BEGIN TRAN
	BEGIN TRY
		SET @errorMessage = dbo.validateParameters_Materie(@numeMaterie, @descriereMaterie)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Materii(nume, descriere) VALUES (@numeMaterie,@descriereMaterie)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Materii', CURRENT_TIMESTAMP)

		COMMIT TRAN
		SELECT 'Transaction committed for table Materii'

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked for table Materii'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('ROLLBACK', 'Materii', CURRENT_TIMESTAMP)
	END CATCH

	IF (@error != 0)
		RETURN

	BEGIN TRAN
	BEGIN TRY
		DECLARE @idProfesori INT, @idMaterii INT
		SET @idProfesori = (SELECT MAX(id_profesor) FROM Profesori)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Profesori', CURRENT_TIMESTAMP)
		SET @idMaterii = (SELECT MAX(id_materie) FROM Materii)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Materii', CURRENT_TIMESTAMP)

		SET @errorMessage = dbo.validateParameters_Repartizare(@idProfesori, @idMaterii, @teorie, @laborator)
		IF (@errorMessage != '')
		BEGIN
			RAISERROR(@errorMessage, 14, 1)
		END

		INSERT INTO Repartizari(id_materie, id_profesor, teorie, laborator) VALUES (@idMaterii, @idProfesori, @teorie,@laborator)
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Repartizari', CURRENT_TIMESTAMP)

		COMMIT TRAN
		SELECT 'Transaction committed for table Repartizari'
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked for table Repartizari'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('ROLLBACK', 'Repartizari', CURRENT_TIMESTAMP)
		SET @error = 1
	END CATCH

END
go


-- with success (commit)
EXECUTE dbo.Insert_Into_Tables_v2 'Petracovici', 'Daniel', 'Romana', '', 1, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable

-- without success (rollback) no repartizare
EXECUTE dbo.Insert_Into_Tables_v2 'Petracovici', 'Daniel', 'Romana', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable

-- without success (rollback) no materie
EXECUTE dbo.Insert_Into_Tables_v2 'Petracovici', 'Daniel', '', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable


-- without success (rollback) no profesor
EXECUTE dbo.Insert_Into_Tables_v2 'Petracovici', '', 'Matematica', '', 0, 0
SELECT * FROM Profesori
SELECT * FROM Materii
SELECT * FROM Repartizari
SELECT * FROM LogTable

