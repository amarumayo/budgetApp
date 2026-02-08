USE budget;
GO

---------------------------------------------------------
-- Accounts (1 row)
---------------------------------------------------------
INSERT INTO Accounts (Name, Type, StartingBalance)
VALUES ('Everyday Checking', 'Checking', 1500.00);
GO


---------------------------------------------------------
-- Categories (3 rows: parent + 2 children)
---------------------------------------------------------
-- Parent category
INSERT INTO Categories (Name, Type, ParentCategoryId)
VALUES ('Food & Dining', 'Expense', NULL);

-- Child categories
INSERT INTO Categories (Name, Type, ParentCategoryId)
VALUES ('Groceries', 'Expense', 1);

INSERT INTO Categories (Name, Type, ParentCategoryId)
VALUES ('Restaurants', 'Expense', 1);
GO


---------------------------------------------------------
-- Transactions (1 row)
---------------------------------------------------------
INSERT INTO Transactions (AccountId, CategoryId, Amount, [Date], Description)
VALUES (1, 2, -54.23, '2025-01-15', 'Grocery run at King Soopers');
GO


---------------------------------------------------------
-- Budgets (1 row)
---------------------------------------------------------
INSERT INTO Budgets (CategoryId, Amount, [Month], [Year])
VALUES (2, 400.00, 1, 2025);
GO
