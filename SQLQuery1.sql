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
	PriceOfLiter decimal(18,2) not null
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
	[Date] datetime null,
	foreign key(Fueling_id) references Fueling(id),
	foreign key(Workers_id) references Workers(id),
	foreign key(Fuel_id) references Fuel(id)
);
------- Changed ---------
drop database aFueling;
drop table Fueling;
drop table Fuel;
drop table Workers;
drop table FuelForFueling;
drop table Orders;

-------- insert ------------
insert into Fueling(NameFueling, City, [Address])values 
	('Oko', 'Kryvoi Rog', 'Kosmonavtov 50'),
	('Dizel', 'Dnepr', 'Mudrena 73'),
	('OilZap', 'Kiev', 'Pushkina 18');

insert into Fuel(MarkaFuel, CurrentQuantityFuel) values
	('95', 1000),
	('97', 1350),
	('98', 1935),
	('75', 850);

insert into Workers(NameWorker, LastNameWorker, Position, Birthday, E_mail, PhoneNumber, MoreInfo, Fueling_id) values
	('Borya', 'Moiseev', 'Refueler', '12-20-1965','','','',1),
	('Fedia', 'Zhelezni', 'Refueler', '12-20-1985','','','',2),
	('Grisha', 'Lodrich', 'Refueler', '12-15-1932','','','',3);

insert into FuelForFueling(Fueling_id, Fuel_id, PriceOfLiter)values
	(1,1, 20.50),
	(1,2, 25.50),
	(1,3, 18.50),
	(2,4, 21.30),
	(2,3, 22.80),
	(2,2, 19.00),
	(3,1, 22.80),
	(3,4, 28.50);
-------- select ----------
select * from Fueling ;  
select * from Fuel;
select * from Workers;
select * from FuelForFueling;
select 
Workers.NameWorker, Workers.LastNameWorker
from Workers, Fueling 
where
Fueling.id = Workers.Fueling_id
and
Fueling.NameFueling = 'Oko';
select  Fuel.MarkaFuel
from FuelForFueling fff, Fueling, Fuel
where
Fueling.id = fff.Fueling_id
and
Fuel.id = fff.Fuel_id
and
Fueling.NameFueling = 'Oko';

select FuelForFueling.PriceOfLiter
from Fueling, Fuel, FuelForFueling
where 
Fuel.id = FuelForFueling.Fuel_id
and
Fueling.id = FuelForFueling.Fueling_id
and
Fuel.MarkaFuel = '95'
and
Fueling.NameFueling = 'Oko'
go
