USE sql_practice_phase4;


-- BLOCK 1: Filtering
select ProductName, Stock from Products where Stock > 20;

select ProductName from Products where ProductName LIKE "%o%";

select ProductName from Products where CategoryID IN ( select CategoryID from Categories where CategoryName IN ('Books', 'Sports') );

select ProductName, Price from products where Price BETWEEN 30 and 90;

select ProductName from products where price IS NULL;

select ProductName from products where price IS NOT NULL;


-- Block 2: Sorting & Pagination
SELECT * FROM Products ORDER BY Price DESC;

select * from Products order by ProductName limit 5 offset 0;

select * from Products order by ProductName limit 5 offset 5;

select * from Products order by ProductName limit 5 offset 10;


-- BLOCK 3: Joins
select Products.ProductName, Products.Price, Categories.CategoryName 
	from Products
	inner join Categories  on Products.CategoryID = Categories.CategoryID;

SELECT c.CategoryName, p.ProductName
	FROM Categories c
	LEFT JOIN Products p ON c.CategoryID = p.CategoryID;

SELECT c.CategoryName, p.ProductName
	FROM Products p
	Right JOIN Categories c  ON c.CategoryID = p.CategoryID;

SELECT c.CategoryName, p.ProductName
	FROM Categories c
	LEFT JOIN Products p ON c.CategoryID = p.CategoryID
	UNION
    SELECT c.CategoryName, p.ProductName
	FROM Categories c
	Right JOIN Products p ON c.CategoryID = p.CategoryID;
    
    
-- Block 4: Union and Union all
select ProductName from Products Where CategoryID = (select CategoryID from Categories where CategoryName = 'Electronics')
union
select ProductName from Products Where CategoryID = (select CategoryID from Categories where CategoryName = 'Sports');

select ProductName from Products Where CategoryID = (select CategoryID from Categories where CategoryName = 'Electronics')
union all
select ProductName from Products Where CategoryID = (select CategoryID from Categories where CategoryName = 'Sports');

SELECT 'Laptop' AS ProductName
UNION ALL
SELECT 'Laptop' AS ProductName;


-- Block 5: Aggregations
SELECT 
    COUNT(*) AS Total_Rows,
    COUNT(Price) AS Non_Null_Prices,
    SUM(Price) AS Total_Value,
    AVG(Price) AS Average_Price,
    MIN(Price) AS Cheapest_Product,
    MAX(Price) AS Most_Expensive
FROM Products;


-- Block 6: GROUP BY & HAVING
SELECT 
    c.CategoryName, 
    SUM(p.Stock) AS TotalStock
	FROM Categories c
	JOIN Products p ON c.CategoryID = p.CategoryID
	GROUP BY c.CategoryName
	ORDER BY TotalStock DESC;
    
SELECT 
    c.CategoryName, 
    SUM(p.Stock) AS TotalStock
FROM Categories c
JOIN Products p ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName
having TotalStock > 100
ORDER BY TotalStock DESC;

SELECT 
    c.CategoryName, 
    AVG(p.Price) AS AveragePrice
FROM Categories c
JOIN Products p ON c.CategoryID = p.CategoryID
WHERE p.Price IS NOT NULL
GROUP BY c.CategoryName
HAVING AveragePrice > 50;


-- Block 7: Subqueries
SELECT 
    ProductName, 
    Price
FROM Products
WHERE Price > (SELECT AVG(Price) FROM Products);

SELECT c.CategoryName, pc.ProductCount
FROM (
    SELECT CategoryID, COUNT(*) AS ProductCount
    FROM Products
    GROUP BY CategoryID
) pc
JOIN Categories c ON c.CategoryID = pc.CategoryID
WHERE pc.ProductCount > 3;


-- Block 8: Indexes
EXPLAIN
select Products.ProductName, Products.Price, Categories.CategoryName 
	from Products
	inner join Categories  on Products.CategoryID = Categories.CategoryID;

CREATE INDEX idx_product_name ON Products(ProductName);
EXPLAIN SELECT * FROM Products 
WHERE ProductName = 'Laptop';

DROP INDEX idx_product_name ON Products;


-- Block 9: Transactions
START TRANSACTION;
INSERT INTO Products (ProductName, CategoryID, Price, Stock)
VALUES ('New Widget', 1, 25.00, 100);
COMMIT;
SELECT * FROM Products WHERE ProductName = 'New Widget';

START TRANSACTION;
INSERT INTO Products (ProductName, CategoryID, Price, Stock)
VALUES ('Ghost Widget', 1, 99.99, 1);
SELECT * FROM Products WHERE ProductName = 'Ghost Widget';
ROLLBACK;
SELECT * FROM Products WHERE ProductName = 'Ghost Widget';

START TRANSACTION;
INSERT INTO Products (ProductName, CategoryID, Price, Stock)
VALUES ('Product A', 1, 10.00, 50);
SAVEPOINT my_checkpoint;
INSERT INTO Products (ProductName, CategoryID, Price, Stock)
VALUES ('Product B', 1, 20.00, 50);
ROLLBACK TO SAVEPOINT my_checkpoint;
COMMIT;
SELECT * FROM Products WHERE ProductName IN ('Product A', 'Product B');