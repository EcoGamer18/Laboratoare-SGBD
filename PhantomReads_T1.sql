
-- Phantom Reads Transaction 1: delay + insert + commit
ALTER PROCEDURE Phantom_Reads_T1 AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		WAITFOR DELAY '00:00:05'
		INSERT INTO Profesori(nume, prenume) VALUES ('numeNou', 'prenumeNou')
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Profesori', CURRENT_TIMESTAMP)
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END

EXECUTE Phantom_Reads_T1;