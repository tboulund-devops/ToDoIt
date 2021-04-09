CREATE TABLE [dbo].[Tasks]
(
  [Id] INT NOT NULL IDENTITY(1,1),
  [Description] NVARCHAR(255) NOT NULL,
  [AssigneeId] INT  NOT NULL,
  [IsCompleted] BIT NOT NULL,
  [DueDate] DATETIME2, 
  CONSTRAINT [PK_Task] PRIMARY KEY (Id),
  CONSTRAINT [FK_AssigneeId] FOREIGN KEY (AssigneeId) REFERENCES [dbo].[Assignees](Id)
  ON DELETE CASCADE
)