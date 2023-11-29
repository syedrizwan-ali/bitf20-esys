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