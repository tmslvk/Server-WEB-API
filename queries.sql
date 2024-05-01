--Создание базы данных.
CREATE DATABASE FridgesDB

USE FridgesDB

--Создание хранимой процедуры.
CREATE OR ALTER PROCEDURE SelectFridgeProducts
AS
BEGIN
	SELECT fp.Quantity, fp.ProductId, fp.Id, p.DefaultQuantity
	FROM FridgeProducts AS fp
	JOIN Products p ON p.Id = fp.ProductId
	WHERE fp.Quantity = 0
END

EXEC SelectFridgeProducts

--Набор запросов 1. Задание 1. Вывод продуктов по холодильникам, модель которых начинается на A
SELECT p.Name AS ProductName, fp.Quantity AS Quantity, fm.Name AS FridgeModelName
FROM FridgeProducts fp
JOIN Products p ON fp.ProductId = p.Id
JOIN Fridges f ON fp.FridgeId = f.Id
JOIN FridgeModels fm ON f.ModelId = fm.Id
WHERE fm.Name LIKE 'A%'

--Задание 2. Вывод холодильнов, в которых есть продукты в кол-ве, меньше чем кол-во по умолчанию
SELECT f.Name AS FridgeName, fp.Quantity AS Quantity, p.Name AS ProductName, p.DefaultQuantity AS DefaultQuantity
FROM Fridges f 
JOIN FridgeProducts fp ON f.Id = fp.FridgeId 
JOIN Products p ON fp.ProductId = p.Id 
WHERE fp.Quantity < p.DefaultQuantity

--Задание 3. Вывод года, в котором выпустили холодильник с наибольшей вместимости
SELECT fm.Year AS FridgeYear, f.Name AS FridgeName, SUM(fp.Quantity) AS TotalQuantity
FROM Fridges f
JOIN FridgeModels fm ON f.ModelId = fm.Id
JOIN FridgeProducts fp ON f.Id = fp.FridgeId
GROUP BY f.Name
ORDER BY TotalQuantity DESC

--Задание 4. Выборка всех продуктов и имени владельца, у которого больше всего наименований продуктов.
SELECT f.OwnerName, p.Name AS ProductName
FROM Fridges f
JOIN FridgeProducts fp ON f.Id = fp.FridgeId
JOIN Products p ON fp.ProductId = p.Id
GROUP BY f.Name
ORDER BY COUNT(DISTINCT p.Name) DESC

--Набор запросов 2. Задание 1. Вывод всех продуктов по холодильнику
SELECT f.Name, f.OwnerName, p.Name, fp.Quantity
FROM FridgeProducts fp
JOIN Fridges f ON fp.FridgeId = f.Id 
JOIN Products p ON fp.ProductId = p.Id
WHERE f.Id = 2

--Задание 2. Вывод всех продуктов для всех холодильников
SELECT f.Id, f.Name, f.OwnerName, fp.Quantity
FROM FridgeProducts fp
JOIN Products p ON fp.ProductId = p.Id
JOIN Fridges f ON fp.FridgeId = f.Id 

