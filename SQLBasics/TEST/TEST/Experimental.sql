USE AdventureWorksLT2012
SELECT * FROM SalesLT.Customer
WHERE (LEN(PasswordSalt) < 9)

SELECT * FROM   sys.objects 
WHERE type_desc LIKE '%CONSTRAINT'