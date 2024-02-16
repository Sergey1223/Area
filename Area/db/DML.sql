USE TT_DB;

-- START Table "Products"
INSERT "Products" VALUES (N'Молоко', 100);
INSERT "Products" VALUES (N'Йогурт', 100);
INSERT "Products" VALUES (N'Говядина', 500);
INSERT "Products" VALUES (N'Яблоко', 150);
INSERT "Products" VALUES (N'Сковорода', 3500.99);
-- END Table "Products"

-- START Table "Categories"
INSERT "Categories" VALUES (N'Скоропортящийся');
INSERT "Categories" VALUES (N'Весовой');
INSERT "Categories" VALUES (N'Скидка');
INSERT "Categories" VALUES (N'Молочный');
INSERT "Categories" VALUES (N'Мясо');
INSERT "Categories" VALUES (N'Растительного происхождения');
INSERT "Categories" VALUES (N'Животного происхождения');
INSERT "Categories" VALUES (N'Фрукты');
INSERT "Categories" VALUES (N'Овощи');
-- END Table Categories

-- START Table ProductCategories

-- Product "Молоко"
INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Молоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Скоропортящийся')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Молоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Молочный')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Молоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Животного происхождения')
);

-- Product "Йогурт"
INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Йогурт'),
	(SELECT Id FROM Categories WHERE [Name] = N'Скоропортящийся')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Йогурт'),
	(SELECT Id FROM Categories WHERE [Name] = N'Молочный')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Йогурт'),
	(SELECT Id FROM Categories WHERE [Name] = N'Животного происхождения')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Йогурт'),
	(SELECT Id FROM Categories WHERE [Name] = N'Скидка')
);

-- Product "Говядина"
INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Говядина'),
	(SELECT Id FROM Categories WHERE [Name] = N'Скоропортящийся')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Говядина'),
	(SELECT Id FROM Categories WHERE [Name] = N'Весовой')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Говядина'),
	(SELECT Id FROM Categories WHERE [Name] = N'Животного происхождения')
);

-- Product "Яблоко"
INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Яблоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Скоропортящийся')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Яблоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Весовой')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Яблоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Растительного происхождения')
);

INSERT "ProductCategories" VALUES (
	(SELECT Id FROM Products WHERE [Name] = N'Яблоко'),
	(SELECT Id FROM Categories WHERE [Name] = N'Фрукты')
);
-- END Table ProductCategories

-- Query
SELECT p.[Name] AS Product, p.Price, c.[Name] AS Category FROM Products AS p
LEFT JOIN ProductCategories AS pc ON p.Id = pc.ProductId
LEFT JOIN Categories AS c ON pc.CategoryId = c.Id;