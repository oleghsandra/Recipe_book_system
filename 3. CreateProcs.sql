-- SPROCS
USE [RecipeBookSystemTestDB]
GO

-----------------------------------------------------------------
-- Users Sprocs
-----------------------------------------------------------------

CREATE PROCEDURE spUsers_Add(
	@Name NVARCHAR(100),
	@Email NVARCHAR(200),
	@Password NVARCHAR(200)
)
AS
  SET NOCOUNT ON 
  INSERT INTO [dbo].[Users]
	VALUES(@Name, @Email, @Password);
	RETURN SCOPE_IDENTITY();
GO
-----------------------------------------------------------------

CREATE PROCEDURE spUser_Get(
    @Email NVARCHAR(200),
	@Password NVARCHAR(200)
)
AS
  SET NOCOUNT ON 
  SELECT * FROM Users
  WHERE @Email = Users.Email AND @Password = Users.[Password];
GO

-----------------------------------------------------------------

-----------------------------------------------------------------
-- PhotoLinks Sprocs
-----------------------------------------------------------------

CREATE PROCEDURE spPhotoLinks_Add(
	@SmallPhotoLink NVARCHAR(MAX),
	@BigPhotoLink NVARCHAR(MAX)
)
AS
  SET NOCOUNT ON 
  IF ((@SmallPhotoLink IS NOT NULL) OR (@BigPhotoLink IS NOT NULL))
	BEGIN
	INSERT INTO [dbo].[PhotoLinks]
		VALUES (@SmallPhotoLink, @BigPhotoLink);
		RETURN SCOPE_IDENTITY();
	END
GO


-----------------------------------------------------------------
-- Products Sprocs
----------------------------------------------------------------

CREATE PROCEDURE spProduct_AddNew(
	@Name NVARCHAR(100),
	@ProductTypeId INT,
	@Proteins REAL,
	@Fats REAL,
	@Carbohydrates REAL,
	@SmallPhotoLink NVARCHAR(MAX) = NULL,
	@BigPhotoLink NVARCHAR(MAX) = NULL
)
AS
  SET NOCOUNT ON 


  DECLARE @CurrentProductPhotoLinkId INT = NULL;
  
  IF ((@SmallPhotoLink IS NOT NULL) OR (@BigPhotoLink IS NOT NULL))
  BEGIN
	 EXECUTE @CurrentProductPhotoLinkId = spPhotoLinks_Add @SmallPhotoLink, @BigPhotoLink;
  END

  INSERT INTO Products
    VALUES (@Name,
			@ProductTypeId, 
			@Proteins,
			@Fats, 
			@Carbohydrates,
			@CurrentProductPhotoLinkId)
GO

-----------------------------------------------------------------

CREATE PROCEDURE spProduct_Delete(
	@ProductId INT
)
AS
  SET NOCOUNT ON 
  DELETE FROM Products
  WHERE Products.ProductId = @ProductId
GO

-----------------------------------------------------------------

CREATE PROCEDURE sp_Product_GetById(
	@ProductId INT
)
AS
  SELECT ProductId, Name, t.ProductTypeName, Proteins, Fats, Carbohydrates, f.SmallPhotoLink, f.BigPhotoLink
  FROM Products

  INNER JOIN (SELECT Name AS ProductTypeName, ProductTypeId
			 FROM ProductTypes) AS t
  ON (t.ProductTypeId = Products.ProductTypeId)

  LEFT JOIN (SELECT PhotoLinkId, SmallPhotoLink, BigPhotoLink
			 FROM PhotoLinks) AS f
  ON (f.PhotoLinkId = Products.PhotoLinkId)

  WHERE ProductId = @ProductId
GO

-----------------------------------------------------------------
CREATE PROCEDURE spProduct_SearchByName(
	@Name NVARCHAR(100)
)
AS
 SET NOCOUNT ON 
	SELECT ProductId, Name, t.ProductTypeName, Proteins, Fats, Carbohydrates, f.SmallPhotoLink, f.BigPhotoLink
	FROM Products

	INNER JOIN (SELECT Name AS ProductTypeName, ProductTypeId
				FROM ProductTypes) AS t
	ON (t.ProductTypeId = Products.ProductTypeId)

	LEFT JOIN (SELECT PhotoLinkId, SmallPhotoLink, BigPhotoLink
				FROM PhotoLinks) AS f
	ON (f.PhotoLinkId = Products.PhotoLinkId)

	WHERE Name LIKE (@Name + '%')
 GO
-----------------------------------------------------------------
CREATE PROCEDURE spProduct_Get(
	@ProductCount INT,
	@PageNumber INT,
	@SortColumn NVARCHAR(100) = 'ProductId',
	@SortOrder NVARCHAR(10) = 'DESC',
	@FilterProductTypeId INT = NULL
)
AS
  SET NOCOUNT ON 
  SELECT ProductId, Name, t.ProductTypeId, t.ProductTypeName, Proteins, Fats, Carbohydrates, f.SmallPhotoLink, f.BigPhotoLink
  FROM Products

  INNER JOIN (SELECT Name AS ProductTypeName, ProductTypeId
			 FROM ProductTypes) AS t
  ON (t.ProductTypeId = Products.ProductTypeId)

  LEFT JOIN (SELECT PhotoLinkId, SmallPhotoLink, BigPhotoLink
			 FROM PhotoLinks) AS f
  ON (f.PhotoLinkId = Products.PhotoLinkId)
  
  WHERE (@FilterProductTypeId IS NULL OR @FilterProductTypeId = Products.ProductTypeId) 
  ORDER BY 
	CASE WHEN @SortColumn = 'ProductId' and @SortOrder = 'ASC' 
    THEN ProductId END ASC, 
	CASE WHEN @SortColumn = 'ProductId' and @SortOrder = 'DESC' 
    THEN ProductId END DESC,

	CASE WHEN @SortColumn = 'Proteins'  and @SortOrder = 'ASC' 
    THEN Proteins END ASC, 
	CASE WHEN @SortColumn = 'Proteins' and @SortOrder = 'DESC' 
    THEN Proteins END DESC,	

	CASE WHEN @SortColumn = 'Fats' and @SortOrder = 'ASC' 
    THEN Fats END ASC, 
	CASE WHEN @SortColumn = 'Fats' and @SortOrder = 'DESC' 
    THEN Fats END DESC,	

	CASE WHEN @SortColumn = 'Carbohydrates' and @SortOrder = 'ASC' 
    THEN Carbohydrates END ASC, 
	CASE WHEN @SortColumn = 'Carbohydrates' and @SortOrder = 'DESC' 
    THEN Carbohydrates END DESC,

	CASE WHEN @SortColumn = 'Name' and @SortOrder = 'ASC' 
    THEN Name END ASC, 
	CASE WHEN @SortColumn = 'Name' and @SortOrder = 'DESC' 
    THEN Name END DESC
	
	OFFSET (@ProductCount * (@PageNumber - 1)) ROWS -- skip rows
	FETCH NEXT (@ProductCount) ROWS ONLY; -- take rows
GO
-----------------------------------------------------------------

CREATE PROCEDURE spProduct_Update(
	@UpdateProductId INT,
    @Name NVARCHAR(100),
	@ProductTypeId INT,
	@Proteins REAL,
	@Fats REAL,
	@Carbohydrates REAL,
	@SmallPhotoLink NVARCHAR(MAX) = NULL,
	@BigPhotoLink NVARCHAR(MAX) = NULL
)
AS
 SET NOCOUNT ON 

  DECLARE @CurrentProductPhotoLinkId INT = NULL;
  
  IF ((@SmallPhotoLink IS NOT NULL) OR (@BigPhotoLink IS NOT NULL))
  BEGIN
	 EXECUTE @CurrentProductPhotoLinkId = spPhotoLinks_Add @SmallPhotoLink, @BigPhotoLink;
  END

  UPDATE Products
    SET Name = @Name,
		 ProductTypeId = @ProductTypeId, 
		 Proteins = @Proteins,
		 Fats = @Fats, 
		 Carbohydrates = @Carbohydrates,
		 PhotoLinkId = @CurrentProductPhotoLinkId
	WHERE (Products.ProductId = @UpdateProductId)
go
-----------------------------------------------------------------

-----------------------------------------------------------------
-- ProductType Sprocs
-----------------------------------------------------------------

CREATE PROC spProductType_Add(
	@Name NVARCHAR(100),
	@SmallPhotoLink NVARCHAR(MAX) = NULL,
	@BigPhotoLink NVARCHAR(MAX) = NULL
)
AS
 SET NOCOUNT ON 

   DECLARE @CurrentProductTypePhotoLinkId INT = NULL;
   EXECUTE @CurrentProductTypePhotoLinkId = spPhotoLinks_Add @SmallPhotoLink, @BigPhotoLink;

	INSERT INTO ProductTypes
		VALUES(@Name, @CurrentProductTypePhotoLinkId);
GO
-----------------------------------------------------------------

--EXEC spProductType_GetAll;

CREATE PROC spProductType_GetAll
AS
 SET NOCOUNT ON 
   SELECT ProductTypeId, Name, PhotoLinks.SmallPhotoLink, PhotoLinks.BigPhotoLink 
   FROM ProductTypes
   LEFT JOIN PhotoLinks
  ON (PhotoLinks.PhotoLinkId = ProductTypes.PhotoLinkId)
GO
-----------------------------------------------------------------

-----------------------------------------------------------------
-- Dish Sprocs
-----------------------------------------------------------------

CREATE PROC spDish_Add(
	@Name NVARCHAR(100), 
	@OwnerId INT,
	@CookingInstructions NVARCHAR(MAX) = NULL,
	@SmallPhotoLink NVARCHAR(MAX) = NULL,
	@BigPhotoLink NVARCHAR(MAX) = NULL,
	@DishId INT OUTPUT
)
AS
 SET NOCOUNT ON 

	DECLARE @CurrentDishPhotoLinkId INT = NULL;

	IF ((@SmallPhotoLink IS NOT NULL) OR (@BigPhotoLink IS NOT NULL))
	  BEGIN
		 EXECUTE @CurrentDishPhotoLinkId = spPhotoLinks_Add @SmallPhotoLink, @BigPhotoLink;
	  END

	INSERT INTO Dishes
		VALUES(@Name, @CurrentDishPhotoLinkId, @CookingInstructions);

	DECLARE @CurrentDishId INT = SCOPE_IDENTITY();
	SELECT @DishId = @CurrentDishId;
	INSERT INTO UsersDishes 
		VALUES(@OwnerId, @CurrentDishId);
GO
-----------------------------------------------------------------

CREATE PROC spDish_Delete(
	@DishId INT
)
AS
 SET NOCOUNT ON 

	DELETE FROM Dishes
	WHERE Dishes.DishId = @DishId;
GO
-----------------------------------------------------------------

CREATE PROC spDishes_Get(
	@OwnerId INT,
	@DishCount INT,
	@PageNumber INT,
	@Name NVARCHAR(100) = ''
)
AS
 SET NOCOUNT ON 
	
	SELECT Dishes.DishId, Name, CookingInstructions, PhotoLinks.SmallPhotoLink, PhotoLinks.BigPhotoLink
    FROM Dishes
	INNER JOIN UsersDishes
	ON Dishes.DishId = UsersDishes.DishId
	LEFT JOIN PhotoLinks
	ON (PhotoLinks.PhotoLinkId = Dishes.PhotoLinkId)
	WHERE (UsersDishes.UserId = @OwnerId) AND (Name LIKE (@Name + '%'))
	ORDER BY Dishes.DishId DESC
	OFFSET (@DishCount * (@PageNumber - 1)) ROWS -- skip rows
	FETCH NEXT (@DishCount) ROWS ONLY; -- take rows
GO
-----------------------------------------------------------------

-----------------------------------------------------------------
-- Ingrediends Sprocs
-----------------------------------------------------------------

CREATE PROC spDishIngrediends_Get(
	@DishId INT
)
AS
 SET NOCOUNT ON 
	DECLARE @AllProductCount INT;

	SELECT IngredientId, DishId, Products.ProductId, Name, [Weight] FROM Ingredients
	INNER JOIN Products
	ON Products.ProductId = Ingredients.ProductId
	WHERE DishId = @DishId

GO
-----------------------------------------------------------------

CREATE PROC spIngredient_Add(
	@DishId INT,
	@ProductId INT, 
	@Weight REAL
)
AS
 SET NOCOUNT ON 

	INSERT INTO Ingredients
		VALUES (@DishId, @ProductId, @Weight)
GO

