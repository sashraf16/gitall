USE [practice database]
GO
/****** Object:  StoredProcedure [dbo].[prtasks_qryallusers]    Script Date: 2/27/2019 9:23:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[prtasks_qryallusers] 
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
	from [practice database].dbo.userTable
END
