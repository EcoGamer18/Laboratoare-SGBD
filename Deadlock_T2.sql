
-- Deadlock Transaction 2 : update on MANAGER + delay + update on MAGAZIN

ALTER PROCEDURE Deadlock_T2 AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	-- SET DEADLOCK_PRIORITY HIGH
	SET DEADLOCK_PRIORITY LOW
	BEGIN TRAN
	BEGIN TRY
		UPDATE Materii SET nume = 'Deadlock' WHERE nume = 'DEADLOCK'
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Materii', CURRENT_TIMESTAMP)
		WAITFOR DELAY '00:00:05'
		UPDATE Profesori SET nume = 'numeNou' where nume = 'Deadlock'
			INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
		COMMIT TRAN
		SELECT 'Transaction committed' AS [Message]
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked' AS [Message]
	END CATCH
END

EXECUTE Deadlock_T2;