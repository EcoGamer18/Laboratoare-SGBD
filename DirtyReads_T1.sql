
-- Dirty Reads Transaction 1: update + delay + rollback
ALTER PROCEDURE Dirty_Reads_T1 AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		UPDATE Profesori SET nume = 'George' WHERE prenume = 'Mihai'
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
		WAITFOR DELAY '00:00:05'
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked - good!' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked - bad!' AS [Message]
	END CATCH
END
go

EXECUTE Dirty_Reads_T1;