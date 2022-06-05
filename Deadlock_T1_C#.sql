
ALTER PROCEDURE Deadlock_T1_C# AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	UPDATE Profesori SET nume = 'George' where prenume = 'Deadlock'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:05'
	UPDATE Materii SET nume = 'DEADLOCK' WHERE nume = 'Deadlock'
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Materii', CURRENT_TIMESTAMP)
	COMMIT TRAN
END

EXECUTE Deadlock_T1_C#;