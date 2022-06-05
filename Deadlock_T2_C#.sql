
ALTER PROCEDURE Deadlock_T2_C# AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	SET DEADLOCK_PRIORITY HIGH
	-- SET DEADLOCK_PRIORITY LOW
	BEGIN TRAN
	UPDATE Materii SET nume = 'DEADLOCK' WHERE nume = 'Deadlock'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Manager', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:05'
	UPDATE Profesori SET nume = 'George' where prenume = 'Deadlock'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
	COMMIT TRAN
END

SELECT * FROM Materii
insert into Profesori(nume, prenume) values ('Deadlock', 'Mihai')
insert into Materii(nume, descriere) values ('Deadlock', 'Materii')

EXECUTE Deadlock_T2_C#;