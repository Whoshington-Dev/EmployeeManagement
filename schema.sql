DROP DATABASE IF EXISTS employee_db;

create database employee_db; 
USE employee_db;
CREATE TABLE Department 
(
	Id int AUTO_INCREMENT PRIMARY KEY,
	DptName varchar(100) not null unique
);

CREATE TABLE JobPosition 
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    jobTitle varchar(1000) not null,
    DepartmentId int not null,
    Seniority int,
    foreign key (DepartmentId) REFERENCES Department(Id)
);

CREATE TABLE Employees 
(
	-- Data Employee 
	Id int AUTO_INCREMENT PRIMARY KEY,
	CPF varchar(11) not null check(length(CPF) = (11)),
	Name varchar(150) not null,
	DateOfAdmission DateTime not null,
		
	-- Status Employee 
	EmployeeStatus int,
		
	-- if the employee was fired
	TerminationDate DateTime, 
	TerminationReason varchar(1000),
        
	-- Connecting tables
	DepartmentId int not null,
	JobPositionId int not null,
		
	constraint FK_Employee_DepartmentId foreign key (DepartmentId) 
		references Department(Id),
	constraint FK_Employee_JobPositionId foreign key (JobPositionId)
		references JobPosition(Id)
	);
    
    SELECT * FROM Employees;	