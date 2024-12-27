CREATE TABLE [dbo].[Bookings] (
    [BookingID]     INT            IDENTITY (1, 1) NOT NULL,
    [TableID]       INT            NOT NULL,
    [CustomerName]  NVARCHAR (50)  NOT NULL,
    [ContactNumber] NVARCHAR (15)  NOT NULL,
    [BookingTime]   DATETIME       NOT NULL,
    [PeopleCount]   INT            NOT NULL,
    [Notes]         NVARCHAR (200) NULL,
    [Status]        NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingID] ASC),
    FOREIGN KEY ([TableID]) REFERENCES [dbo].[Tables] ([TableID])
);

CREATE TABLE [dbo].[ImportHistory] (
    [ImportID]     INT             IDENTITY (1, 1) NOT NULL,
    [DateOfImport] DATE            NOT NULL,
    [TotalCost]    DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([ImportID] ASC)
);

CREATE TABLE [dbo].[Inventory] (
    [InventoryID] INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Quantity]    INT             NOT NULL,
    [UnitPrice]   DECIMAL (10, 2) NOT NULL,
    [Unit]        NVARCHAR (20)   NOT NULL,
    [ExpiryDate]  DATE            NULL,
    PRIMARY KEY CLUSTERED ([InventoryID] ASC)
);

INSERT INTO Inventory (InventoryID, Name, Quantity, UnitPrice, Unit, ExpiryDate)
VALUES 
(1, 'Rice', 50, 150.00, 'Kg', '2024-12-31'),
(2, 'Chicken', 20, 300.00, 'Kg', '2024-11-30'),
(3, 'Oil', 10, 200.00, 'Litre', '2025-01-01');


CREATE TABLE [dbo].[InventoryTransactions] (
    [TransactionID]   INT             IDENTITY (1, 1) NOT NULL,
    [InventoryID]     INT             NOT NULL,
    [Quantity]        INT             NOT NULL,
    [TotalPrice]      DECIMAL (10, 2) NOT NULL,
    [TransactionDate] DATETIME        DEFAULT (getdate()) NOT NULL,
    [ExpiryDate]      DATE            NULL,
    [TransactionType] NVARCHAR (50)   DEFAULT ('Add') NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID])
);

CREATE TABLE [dbo].[Menu] (
    [MenuItemID] INT             IDENTITY (1, 1) NOT NULL,
    [Category]   NVARCHAR (50)   NOT NULL,
    [Name]       NVARCHAR (100)  NOT NULL,
    [Price]      DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([MenuItemID] ASC)
);

INSERT INTO Menu (MenuItemID,Category, Name, Price)
VALUES 
(1,'Appetizer', 'Spring Rolls', 50.00),
(2,'Main Course', 'Grilled Chicken', 150.00),
(3,'Dessert', 'Fruit Salad', 30.00),
(4,'Beverage', 'Coke', 20.00);

CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailID] INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]       INT             NOT NULL,
    [MenuItemID]    INT             NOT NULL,
    [Quantity]      INT             NOT NULL,
    [Price]         DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderDetailID] ASC),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    FOREIGN KEY ([MenuItemID]) REFERENCES [dbo].[Menu] ([MenuItemID])
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT           IDENTITY (1, 1) NOT NULL,
    [TableID]       INT           NOT NULL,
    [OrderDateTime] DATETIME      DEFAULT (getdate()) NOT NULL,
    [OrderStatus]   NVARCHAR (50) NOT NULL,
    [BookingID]     INT           NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    FOREIGN KEY ([TableID]) REFERENCES [dbo].[Tables] ([TableID]),
    FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings] ([BookingID]),
    CONSTRAINT [FK_Orders_Booking] FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings] ([BookingID])
);

CREATE TABLE [dbo].[Payment] (
    [PaymentID]   INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]     INT             NOT NULL,
    [BookingID]   INT             NOT NULL,
    [BookingTime] DATETIME        NOT NULL,
    [Total]       DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings] ([BookingID])
);

CREATE TABLE [dbo].[Tables] (
    [TableID]     INT           IDENTITY (1, 1) NOT NULL,
    [TableNumber] NVARCHAR (10) NOT NULL,
    [Seats]       INT           NOT NULL,
    [Status]      NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([TableID] ASC),
    UNIQUE NONCLUSTERED ([TableNumber] ASC)
);

INSERT INTO Tables (TableID, TableNumber, Seats, Status)
VALUES 
(1, 'Table 01', 4, 'Occupied'),
(2, 'Table 02', 4, 'Empty'),
(3, 'Table 03', 6, 'Empty');


CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

INSERT INTO Users (UserID, Username, Password, Role)
VALUES 
(1, 'waiter1', '1234', 'Waiter'),
(2, 'chef1', '1234', 'Chef'),
(3, 'manager1', '1234', 'Manager');


