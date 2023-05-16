CREATE TABLE [dbo].[HighScores]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Score] INT NOT NULL,
	[PlayerName] VARCHAR(3) NOT NULL,
    CONSTRAINT [FK_HighScores_Players] FOREIGN KEY ([PlayerName]) REFERENCES [Players]([Name])
)
