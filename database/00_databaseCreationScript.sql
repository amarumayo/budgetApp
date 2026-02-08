USE budget;
GO

-- ============================
-- Accounts
-- ============================
CREATE TABLE Accounts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL, -- Checking, Savings, CreditCard, Cash
    StartingBalance DECIMAL(18,2) NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

-- ============================
-- Categories
-- ============================
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(20) NOT NULL, -- Income or Expense
    ParentCategoryId INT NULL,
    CONSTRAINT FK_Categories_Parent
        FOREIGN KEY (ParentCategoryId) REFERENCES Categories(Id)
);
GO

-- ============================
-- Transactions
-- ============================
CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AccountId INT NOT NULL,
    CategoryId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL, -- positive = income, negative = expense
    [Date] DATE NOT NULL,
    Description NVARCHAR(200) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_Transactions_Account
        FOREIGN KEY (AccountId) REFERENCES Accounts(Id),

    CONSTRAINT FK_Transactions_Category
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

CREATE INDEX IX_Transactions_AccountId ON Transactions(AccountId);
CREATE INDEX IX_Transactions_CategoryId ON Transactions(CategoryId);
CREATE INDEX IX_Transactions_Date ON Transactions([Date]);
GO

-- ============================
-- Budgets
-- ============================
CREATE TABLE Budgets (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    [Month] INT NOT NULL CHECK ([Month] BETWEEN 1 AND 12),
    [Year] INT NOT NULL CHECK ([Year] >= 2000),

    CONSTRAINT FK_Budgets_Category
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
