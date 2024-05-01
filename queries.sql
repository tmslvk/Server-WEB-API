--�������� ���� ������.
CREATE DATABASE FridgesDB

USE FridgesDB

--�������� �������� ���������.
CREATE OR ALTER PROCEDURE SelectFridgeProducts
AS
BEGIN
	SELECT fp.Quantity, fp.ProductId, fp.Id, p.DefaultQuantity
	FROM FridgeProducts AS fp
	JOIN Products p ON p.Id = fp.ProductId
	WHERE fp.Quantity = 0
END

EXEC SelectFridgeProducts

--����� �������� 1. ������� 1. ����� ��������� �� �������������, ������ ������� ���������� �� A
SELECT p.Name AS ProductName, fp.Quantity AS Quantity, fm.Name AS FridgeModelName
FROM FridgeProducts fp
JOIN Products p ON fp.ProductId = p.Id
JOIN Fridges f ON fp.FridgeId = f.Id
JOIN FridgeModels fm ON f.ModelId = fm.Id
WHERE fm.Name LIKE 'A%'

--������� 2. ����� �����������, � ������� ���� �������� � ���-��, ������ ��� ���-�� �� ���������
SELECT f.Name AS FridgeName, fp.Quantity AS Quantity, p.Name AS ProductName, p.DefaultQuantity AS DefaultQuantity
FROM Fridges f 
JOIN FridgeProducts fp ON f.Id = fp.FridgeId 
JOIN Products p ON fp.ProductId = p.Id 
WHERE fp.Quantity < p.DefaultQuantity

--������� 3. ����� ����, � ������� ��������� ����������� � ���������� �����������
SELECT fm.Year AS FridgeYear, f.Name AS FridgeName, SUM(fp.Quantity) AS TotalQuantity
FROM Fridges f
JOIN FridgeModels fm ON f.ModelId = fm.Id
JOIN FridgeProducts fp ON f.Id = fp.FridgeId
GROUP BY f.Name
ORDER BY TotalQuantity DESC

--������� 4. ������� ���� ��������� � ����� ���������, � �������� ������ ����� ������������ ���������.
SELECT f.OwnerName, p.Name AS ProductName
FROM Fridges f
JOIN FridgeProducts fp ON f.Id = fp.FridgeId
JOIN Products p ON fp.ProductId = p.Id
GROUP BY f.Name
ORDER BY COUNT(DISTINCT p.Name) DESC

--����� �������� 2. ������� 1. ����� ���� ��������� �� ������������
SELECT f.Name, f.OwnerName, p.Name, fp.Quantity
FROM FridgeProducts fp
JOIN Fridges f ON fp.FridgeId = f.Id 
JOIN Products p ON fp.ProductId = p.Id
WHERE f.Id = 2

--������� 2. ����� ���� ��������� ��� ���� �������������
SELECT f.Id, f.Name, f.OwnerName, fp.Quantity
FROM FridgeProducts fp
JOIN Products p ON fp.ProductId = p.Id
JOIN Fridges f ON fp.FridgeId = f.Id 

