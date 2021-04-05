CREATE TABLE Tasks(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Description] NVARCHAR(255) NOT NULL,
    AssigneeId INT NOT NULL,
    DueDate datetime2 NOT NULL,
    IsCompleted bit NOT NULL
)