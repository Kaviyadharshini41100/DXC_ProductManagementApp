Create Database ProductManagementApp
Create Table Product(
ProdId int identity Primary key,
ProdName varchar(30),
ProdDescription varchar(80),
Quantity int,
Price int
)
Select * from Product

