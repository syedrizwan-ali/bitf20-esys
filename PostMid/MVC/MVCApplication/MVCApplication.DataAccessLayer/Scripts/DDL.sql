CREATE TABLE Students
(
	ID bigint primary key identity(1,1),
	Name nvarchar(255) NOT NULL,
	RollNumber varchar(10) NOT NULL,
	CreatedBy nvarchar(100) NOT NULL,
	CreatedOn DateTime NOT NULL,
	ModifiedBy nvarchar(100) NULL,
	ModifiedOn DateTime NULL
);

CREATE TABLE Users
(
	ID bigint primary key identity(1,1),
	Name nvarchar(255) NOT NULL,
	Email nvarchar(255) NOT NULL,
	Password nvarchar(max) NOT NULL,
	CreatedBy nvarchar(100) NOT NULL,
	CreatedOn DateTime NOT NULL,
	ModifiedBy nvarchar(100) NULL,
	ModifiedOn DateTime NULL
);