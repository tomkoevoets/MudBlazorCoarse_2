CREATE PROCEDURE [dbo].[INSERT_NewArticle]
	@Title NVARCHAR(80),
	@Subtitle NVARCHAR(200),
	@ArticleBody NVARCHAR(3500),
	@Category int, 
	@Authors NVARCHAR(700)
AS
INSERT INTO Articles
(Id,Title,Subtitle,ArticleBody,Category,Authors,DatePublished)
values
(NEWID(),@Title,@Subtitle,@ArticleBody,@Category,@Authors,SYSUTCDATETIME())


