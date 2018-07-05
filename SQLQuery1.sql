-------- create BD ---------
create database aFueling;
use aFueling;

-------- create table --------
create table Fueling (
	id int primary key identity,
	NameFueling varchar(25) not null,
	City varchar(25) not null,
	[Address] varchar(50) not null,
); 

create table Fuel(
	id int primary key identity,
	MarkaFuel varchar(25) not null,
	CurrentQuantityFuel decimal not null
);

create table FuelForFueling(
	Fueling_id int not null,
	Fuel_id int not null,
	foreign key (Fueling_id) references Fueling(id),
	foreign key (Fuel_id) references Fuel(id),
	PriceOfLiter decimal not null
);

create table Workers(
	id int primary key identity,
	NameWorker varchar(25) not null,
	LastNameWorker varchar(25) not null,
	Position varchar(50) not null,
	Birthday datetime not null,
	E_mail varchar(50) null,
	PhoneNumber varchar(15) null,
	MoreInfo text null,
	Fueling_id int not null,
	foreign key(Fueling_id) references Fueling(id)
);

create table Orders(
	id int primary key identity,
	Fueling_id int not null,
	Workers_id int not null,
	Fuel_id int not null,
	QuantityFuelSale decimal not null,
	TotalSum decimal not null,
	[Date] datetime not null
);
------- Changed ---------
drop table Fueling;
drop table Fuel;
drop table Workers;
drop table FuelForFueling;

-------- insert ------------
insert into Fueling(NameFueling, City, [Address])values 
	('Oko', 'Kryvoi Rog', 'Kosmonavtov 50'),
	('Dizel', 'Dnepr', 'Mudrena 73'),
	('Oko', 'Kiev', 'Pushkina 18');

insert into Fuel(MarkaFuel, PriceOfLiter, CurrentQuantityFuel) values
	('95', 25.50, 1000),
	('97', 28.30, 1350),
	('98', 22.50, 1935),
	('75', 30.20, 850);

insert into Workers(NameWorker, LastNameWorker, Position, Birthday, E_mail, PhoneNumber, MoreInfo, Fueling_id) values
	()
-------- select ----------
select * from Fuel;
select * from Fueling;
select * from Workers;
select * from FuelForFueling;