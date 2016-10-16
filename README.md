# Recipe_book_system
Public project for EPAM courses
How to install.
1)Download the latest release (setup file and source code).
2)Open source code in Visual Studio and execute from SqlQueries folder all the database scripts in the following order: CreateDB – CreateTable – CreateProcs – Insert. 
3)Close all connections to the database from a visual studio or Sql server, depending on where you performed scripts. 
4) Install file RecipeBookSystem.Stup of HitHab release. Select some folder to install. 
5)Open this folder. Find the file RecipeBookSystem.UI.exe.configs  and open it with notepad.
6) Change the connectionString to one that matches your database.
7) Change connectionString in Add.config of RecipeBookSystem.UI project of solution in Visual Studio if  you want to run the program from there.
8) Running the program, it is advisable to leave data entry of test user(in LoginForm) who has already added a few recipes.
