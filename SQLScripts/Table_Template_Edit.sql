USE [FINCONTROL]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Edit]    Script Date: 12.03.2017 12:11:02 ******/
DROP PROCEDURE [dbo].[sp_Table_Template_Edit]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Edit]    Script Date: 12.03.2017 12:11:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE  PROCEDURE [dbo].[sp_Table_Template_Edit] 
(@par1 nvarchar(100), @par2 date, @par3 decimal(18,0),@par4 bit, @par5 int, @par6 datetime, @ID bigint)  
as
--[dbo].[sp_Table_Template_Edit] 'Следующий', '20150101', 100.19, 1, 112, '20150101 23:01:20',2
--declare @i int;
  if exists(select * from [dbo].[Table_Template] where [ID] = @ID) 
    BEGIN
	 BEGIN TRY
      update [dbo].[Table_Template]
      set [Nvarchar] = @par1,[Date]=@par2,[Decimal]=@par3/100,[Boolean]=@par4,[Int]=@par5,[DateTime]=@par6
      where [ID] = @ID
	  --select @i = 1/0
	  select 1 as result,'' as error_message  ,'' as error_procedure  ,'' as error_line
     END TRY 
	 BEGIN CATCH
      select 0 as result, ERROR_MESSAGE() as error_message, ERROR_PROCEDURE() as error_procedure, convert(varchar(20),ERROR_LINE()) as error_line
     END CATCH
    END
	ELSE 
	BEGIN
	 select 0 as result,'Updated row does not exist (ID = ' + convert(varchar(10),@ID) + ')' as error_message  ,'sp_Table_Template_Edit' as error_procedure  ,'' as error_line
	END

  



GO


