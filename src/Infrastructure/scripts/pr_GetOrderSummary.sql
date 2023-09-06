USE Northwind
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE pr_GetOrderSummary
    @StartDate DATE,
    @EndDate DATE,
    @EmployeeID INT = NULL,
    @CustomerID VARCHAR(10) = NULL
    AS
BEGIN
SELECT
    CONCAT(e.TitleOfCourtesy, ' ', e.FirstName, ' ', e.LastName) AS EmployeeFullName,
    s.CompanyName AS ShipperCompanyName,
    c.CompanyName AS CustomerCompanyName,
    COUNT(*) AS NumberOfOrders,
    o.OrderDate AS Date,
        SUM(o.Freight) AS TotalFreightCost,
        COUNT(DISTINCT od.ProductID) AS NumberOfDifferentProducts,
        SUM(od.UnitPrice * od.Quantity) AS TotalOrderValue
FROM
    Orders o
    INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
    INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
    INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE
    o.OrderDate >= @StartDate
  AND o.OrderDate <= @EndDate
  AND (@EmployeeID IS NULL OR o.EmployeeID = @EmployeeID)
  AND (@CustomerID IS NULL OR o.CustomerID = @CustomerID)
GROUP BY
    o.OrderDate,
    CONCAT(e.TitleOfCourtesy, ' ', e.FirstName, ' ', e.LastName),
    c.CompanyName,
    s.CompanyName
END
GO