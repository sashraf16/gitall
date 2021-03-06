USE [practice database]
GO
/****** Object:  StoredProcedure [dbo].[prtasks_qrygetuserbyusername]    Script Date: 3/22/2019 11:42:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[prtasks_qrygetuserbyusername] 
	@name varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserId,
	firstname,
	lastname,
	username,
	password
	from [practice database].dbo.usertable 
	where username = @name
END
