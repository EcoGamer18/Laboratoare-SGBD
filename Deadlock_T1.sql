
-- Deadlock Transaction 1: update on MAGAZIN + delay + update on MANAGER
ALTER PROCEDURE Deadlock_T1 AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	BEGIN TRY
		UPDATE Profesori SET nume = 'numeNou' where nume = 'Deadlock'
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
		WAITFOR DELAY '00:00:05'
		UPDATE Materii SET nume = 'Deadlock' WHERE nume = 'DEADLOCK'
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Materii', CURRENT_TIMESTAMP)
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END

EXECUTE Deadlock_T1;