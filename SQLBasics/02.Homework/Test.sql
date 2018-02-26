CREATE TABLE Test(
[ID] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[MiddleName] NVARCHAR(30) ,
[LastName] NVARCHAR(30) NOT NULL
)
INSERT INTO Test(FirstName, LastName) values
('Sponge','Bob'),
('Baba','Jaga'),
('Kuma','Lisa'),
('Baba','Meca'),
('Toshko','Afrikanski')

drop view v_test

CREATE VIEW v_test AS
SELECT [FirstName] + ' '+ COALESCE([MiddleName],'')+ ' ' +[LastName] AS [FullName] 
FROM Test
SELECT * FROM v_test

drop table Test