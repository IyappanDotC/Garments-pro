Select * from Departments
Drop table Departments
truncate table Departments


Create Table Departments(
DepID int Identity (1,1) Primary key ,
DepName varchar(40), 
)


Create Table OrderStatus(
ID int Identity (1,1) Primary key ,
OrderID varchar(30), 
Current_Department int,
Status int
)

drop table OrderStatus


	insert into Departments (depname) values ('Yarn Formation')
    insert into Departments (depname) values ('Fabric Formation')
	insert into Departments (depname) values ('Wet Processing')
	insert into Departments (depname) values ('Fabrication')
	insert into Departments (depname) values ('Finished Goods')







