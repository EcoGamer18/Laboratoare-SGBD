
/*
Izolarea tranzacțiilor în SQL Server rezolvă patru probleme majore de concurență:
• Lost updates
– Când doi scriitori modifică aceleași date

• Dirty reads
– Când un cititor citește date necomise

• Unrepeatable reads
– Când o înregistrare existentă se schimbă în cadrul unei tranzacții

• Phantom reads
– Când sunt adăugate noi înregistrări și apar în cadrul unei tranzacții

Deadlocks
• Un deadlock are loc atunci când două sau mai multe tranzacții se blochează
reciproc permanent din cauza faptului că fiecare tranzacție deține o blocare pe o
resursă pentru care cealaltă tranzacție încearcă să obțină o blocare
*/

-- Dirty reads:
SELECT * FROM Profesori WITH (NOLOCK)

-- Non-repeatable reads:
SELECT * FROM Profesori WITH (NOLOCK)
UPDATE Profesori SET nume = 'George' WHERE prenume = 'Mihai'

-- Phantom reads:
SELECT * FROM Profesori
DELETE FROM Profesori WHERE nume = 'Mihai'

-- Deadlock:
SELECT * FROM sys.sysprocesses WHERE open_tran = 1

INSERT INTO Profesori(nume, prenume) VALUES ('Deadlock', 'Profesor')
INSERT INTO Materii(nume,descriere) VALUES ('Deadlock', 'Materie')
SELECT * FROM Profesori
SELECT * FROM Materii

-- Log table:
SELECT * FROM LogTable WITH (NOLOCK)
DELETE FROM LogTable

