create table Author 
(
	id int not null identity primary key,
	firstname nvarchar(100) not null,
	lastname nvarchar(100) not null
)

create table Publisher
(
	id int not null identity primary key,
	publisherName nvarchar(100) not null,
	address nvarchar(100) not null
)

create table Book
(
	id int not null identity primary key,
	title nvarchar(100) not null,
	idAuthor int not null foreign key references Author(id),
	pages int,
	price int,
	idPublisher int not null foreign key references Publisher(id)
)