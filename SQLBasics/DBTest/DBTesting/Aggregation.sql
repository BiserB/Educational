CREATE DATABASE product
GO
USE product
GO
CREATE TABLE Main(
product NVARCHAR(10) PRIMARY KEY,
company NVARCHAR(10) NOT NULL,
qty INT NOT NULL,
rate INT NOT NULL,
cost INT NOT NULL
)
INSERT INTO Main (product, company, qty, rate, cost) VALUES
('item1','com1', 2,10,20),
('item2','com2', 2,25,75),
('item3','com1', 2,30,60),
('item4','com3', 5,10,50),
('item5','com2', 2,20,40),
('item6','com1', 3,25,75),
('item7','com1', 5,30,150),
('item8','com1', 3,10,30),
('item9','com2', 2,25,50),
('item10','com3', 4,30,120)

SELECT * FROM Main
ORDER BY LEN(product), product

UPDATE  Main
SET qty = 3
WHERE product = 'item2'

SELECT * FROM sys.objects
WHERE type_desc LIKE '%CONSTRAINT'

ALTER TABLE Main
DROP CONSTRAINT PK__Main__583517CEEF43A39A


------------------------------------------
SELECT company ,SUM(cost) 
FROM Main
GROUP BY company
HAVING SUM(cost) >= 170

------------------------------------------
SELECT company, AVG(cost) AS Average FROM Main
group by company
having AVG(cost) >= 65