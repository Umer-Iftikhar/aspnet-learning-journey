CREATE TABLE Categories(
    CategoryID INTEGER PRIMARY KEY AUTO_INCREMENT,
    CategoryName VARCHAR(50) NOT NULL
);
CREATE TABLE Products (
    ProductID INTEGER PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2),
    Stock INTEGER,
    CategoryID INTEGER,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
INSERT INTO Categories (CategoryName) VALUES ('Electronics'), ('Clothing'), ('Books'), ('Sports'), ('Food');
INSERT INTO Products (ProductName, Price, Stock, CategoryID) VALUES
('Laptop', 999.99, 15, 1),
('Phone', 699.99, 0, 1),
('Headphones', 149.99, 40, 1),
('Keyboard', 79.99, 25, 1),
('Monitor', NULL, 10, 1),
('T-Shirt', 19.99, 100, 2),
('Jeans', 49.99, 60, 2),
('Jacket', 89.99, 0, 2),
('Dress', NULL, 35, 2),
('Python Book', 39.99, 20, 3),
('Clean Code', 34.99, 15, 3),
('SQL Guide', 29.99, 0, 3),
('Football', 24.99, 50, 4),
('Tennis Racket', 59.99, 30, 4),
('Yoga Mat', 29.99, 45, 4),
('Dumbbells', 49.99, 20, 4),
('Running Shoes', 89.99, 0, 4),
('Skipping Rope', NULL, 80, 4);