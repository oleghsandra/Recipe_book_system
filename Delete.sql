USE [RecipeBookSystemTestDB];
GO
---------------------------------------------------------
--Delete and create tables considering the FOREIGN keys
IF OBJECT_ID('UsersDishes', 'U') IS NOT NULL 
    DROP TABLE UsersDishes
GO

IF OBJECT_ID('Ingredients', 'U') IS NOT NULL 
    DROP TABLE Ingredients
GO

IF OBJECT_ID('Dishes', 'U') IS NOT NULL 
    DROP TABLE Dishes
GO

IF OBJECT_ID('Products', 'U') IS NOT NULL 
    DROP TABLE Products
GO

IF OBJECT_ID('ProductTypes', 'U') IS NOT NULL 
    DROP TABLE ProductTypes
GO

IF OBJECT_ID('PhotoLinks', 'U') IS NOT NULL 
    DROP TABLE PhotoLinks
GO

IF OBJECT_ID('Users', 'U') IS NOT NULL 
    DROP TABLE Users
GO

-----------------------------------------------------------
--Delete all SP

IF OBJECT_ID('spUsers_Add') IS NOT NULL 
	DROP PROCEDURE spUsers_Add
GO

IF OBJECT_ID('spUser_Get') IS NOT NULL 
	DROP PROCEDURE spUser_Get
GO

IF OBJECT_ID('spPhotoLinks_Add') IS NOT NULL 
	DROP PROCEDURE spPhotoLinks_Add
GO


IF OBJECT_ID('spProduct_AddNew') IS NOT NULL 
	DROP PROCEDURE spProduct_AddNew
GO

IF OBJECT_ID('spProduct_SearchByName') IS NOT NULL 
	DROP PROCEDURE spProduct_SearchByName
GO

IF OBJECT_ID('spProduct_Delete') IS NOT NULL 
	DROP PROCEDURE spProduct_Delete
GO

IF OBJECT_ID('sp_Product_GetById') IS NOT NULL 
	DROP PROCEDURE sp_Product_GetById
GO

IF OBJECT_ID('spProduct_Get') IS NOT NULL 
	DROP PROCEDURE spProduct_Get
GO

IF OBJECT_ID('spProduct_Update') IS NOT NULL 
	DROP PROCEDURE spProduct_Update
GO

IF OBJECT_ID('spProductType_Add') IS NOT NULL 
	DROP PROCEDURE spProductType_Add
GO

IF OBJECT_ID('spProductType_GetAll') IS NOT NULL 
	DROP PROCEDURE spProductType_GetAll
GO


IF OBJECT_ID('spDish_Add') IS NOT NULL 
	DROP PROCEDURE spDish_Add
GO

IF OBJECT_ID('spDish_Delete') IS NOT NULL 
	DROP PROCEDURE spDish_Delete
GO

IF OBJECT_ID('spDishes_Get') IS NOT NULL 
	DROP PROCEDURE spDishes_Get
GO

IF OBJECT_ID('spDishIngrediends_Get') IS NOT NULL 
	DROP PROCEDURE spDishIngrediends_Get
GO

IF OBJECT_ID('spIngredient_Add') IS NOT NULL 
	DROP PROCEDURE spIngredient_Add
GO