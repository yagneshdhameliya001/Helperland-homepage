create database HelperLandProject

create table ContactUs(
	ID int IDENTITY(1,1) primary key NOT NULL,
	Fname nvarchar(50) NOT NULL,
	Lname nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL UNIQUE,
	Phone nvarchar(10) NOT NULL UNIQUE,
	category nvarchar(50) NOT NULL,
	msg nvarchar(100) NOT NULL 
);

create table NewsLetter(
	ID int identity(1,1) primary key NOT NULL,
	Email nvarchar(50) NOT NULL UNIQUE
);

create table Address(
	a_id int identity(1,1) primary key NOT NULL,
	street nvarchar(10) NOT NULL,
	houseno int NOT NULL,
	postal int NOT NULL,
	city nvarchar(30) NOT NULL
);

create table customer(
	c_id int identity(1,1) primary key NOT NULL,
	fname nvarchar(10) NOT NULL,
	lname nvarchar(10) NOT NULL,
	email nvarchar(50) NOT NULL UNIQUE,
	phone nvarchar(10) NOT NULL UNIQUE,
	pass nvarchar(50) NOT NULL,
	addressID int NOT NULL foreign key references Address(a_id) 
);

create table Payment(
	p_id int identity(1,1) primary key NOT NULL,
	t_id int NOT NULL,
	CardNumber nvarchar NOT NULL,
	amount int NOT NULL,
	msg nvarchar(100)
);

create table ServiceProvider(
	s_id int identity(1,1) primary key NOT NULL,
	fname nvarchar(10) NOT NULL,
	lname nvarchar(10) NOT NULL,
	email nvarchar(50) NOT NULL UNIQUE,
	phone nvarchar(10) NOT NULL UNIQUE,
	pass nvarchar(50) NOT NULL,
	gender nvarchar(10),
	addressID int NOT NULL foreign key references Address(a_id) 
);

create table ExtraServices(
	extra_ID int identity(1,1) primary key NOT NULL,
	c_id int NOT NULL foreign key references customer(c_id),
	InsideCabinets bit,
	InsideFridge bit,
	InsideOven bit,
	LaundryWashDry bit,
	InteriorWindows bit
);

create table BookService(
	b_id int identity(1,1) primary key NOT NULL,
	s_date date NOT NULL,
	s_time datetime NOT NULL,
	s_hours time NOT NULL,
	extra_service_ID int,
	pets bit,
	comments nvarchar(100),
	accepted bit,
	c_id int NOT NULL foreign key references customer(c_id) 
);

alter table BookService add constraint BookService_extraServiceID_FK foreign key(extra_service_ID) references ExtraServices(extra_ID);

create table Invoice(
	Invoice_id int identity(1,1) primary key NOT NULL,
	c_id int NOT NULL foreign key references customer(c_id),
	p_id int NOT NULL foreign key references Payment(p_id),
	b_id int NOT NULL foreign key references BookService(b_id)
);

create table Refund(
	r_id int identity(1,1) primary key NOT NULL,
	Invoice_id int NOT NULL foreign key references Invoice(Invoice_id),
	descr nvarchar(100)
);

create table CancelOrder(
	id int identity(1,1) primary key NOT NULL,
	c_id int NOT NULL foreign key references customer(c_id),
	b_id int NOT NULL foreign key references BookService(b_id)
);


select * from customer

select * from ContactUs

select * from Address

select * from BookService

select * from CancelOrder

select * from ExtraServices

select * from Invoice

select * from NewsLetter

select * from Payment

select * from Refund

select * from ServiceProvider





