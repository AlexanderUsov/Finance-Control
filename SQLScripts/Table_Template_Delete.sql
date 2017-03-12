USE [FINCONTROL]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Delete]    Script Date: 12.03.2017 12:10:36 ******/
DROP PROCEDURE [dbo].[sp_Table_Template_Delete]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Delete]    Script Date: 12.03.2017 12:10:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE  PROCEDURE [dbo].[sp_Table_Template_Delete] 
(@ID bigint)  
as
--[dbo].[sp_Table_Template_Delete] 2
--declare @i int;
  if exists(select * from [dbo].[Table_Template] where [ID] = @ID) 
    BEGIN
	 BEGIN TRY
      delete [dbo].[Table_Template] where [ID] = @ID 
	  --select @i = 1/0
	  select 1 as result,'' as error_message  ,'' as error_procedure  ,'' as error_line
     END TRY 
	 BEGIN CATCH
      select 0 as result, ERROR_MESSAGE() as error_message, ERROR_PROCEDURE() as error_procedure, convert(varchar(20),ERROR_LINE()) as error_line
     END CATCH
    END
	ELSE 
	BEGIN
	 select 0 as result,'row to be deleted does not exist (ID = ' + convert(varchar(10),@ID) + ')' as error_message  ,'sp_Table_Template_Delete' as error_procedure  ,'' as error_line
	END

  



GO


