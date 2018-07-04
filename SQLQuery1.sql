-------- create BD ---------
create database aFueling;
use aFueling;

-------- create table --------
create table Fueling (
	id int primary key identity,
	NameFueling varchar(25) not null,
	City varchar(25) not null,
	[Address] varchar(50) not null,
	Fuel_id int not null,
	foreign key (Fuel_id) references Fuel(id)
); 

create table Fuel(
	id int primary key identity,
	MarkaFuel varchar(25) not null,
	PriceOfLiter decimal not null,
	MaxQuantityFuel decimal not null,
	CurrentQuantityFuel decimal not null,
);

create table Workers(
	id int primary key identity,
	NameWorker varchar(25) not null,
	LastNameWorker varchar(25) not null,
	Position varchar(50) not null,
	Birthday datetime not null,
	E_mail varchar(50) null,
	PhoneNumber varchar(15) null,
	MoreInfo text null
);

create table Orders(
	
);
------- Changed ---------
drop table Fueling;
drop table Fuel;

---- select ----------
select * from Fuel;