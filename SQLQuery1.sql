CREATE TABLE MONETARY
(
monetaryId int not null identity primary key,
amount int not null,
monetaryDate DATE not null,
donorName varchar(100)
)