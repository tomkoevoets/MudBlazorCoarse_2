CREATE TABLE [dbo].[Articles]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NCHAR(80) NOT NULL, 
    [Subtitle] NCHAR(200) NOT NULL, 
    [ArticleBody] NCHAR(3500) NOT NULL, 
    [Authors] NCHAR(700) NOT NULL, 
    [Category] INT NOT NULL, 
    [DatePublished] DATETIME NOT NULL
)
