USE [FINCONTROL]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Add]    Script Date: 12.03.2017 12:10:00 ******/
DROP PROCEDURE [dbo].[sp_Table_Template_Add]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_Add]    Script Date: 12.03.2017 12:10:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE  PROCEDURE [dbo].[sp_Table_Template_Add] 
(@par1 nvarchar(100), @par2 date, @par3 decimal(18,0),@par4 bit, @par5 int, @par6 datetime)  
as
Declare @NEWID as bigint
--[dbo].[sp_Table_Template_Add] 'Следующий', '20150101', 100.19, 1, 112, '20150101 23:01:20'
--declare @i int;
BEGIN TRY
  insert [dbo].[Table_Template]([Nvarchar],[Date],[Decimal],[Boolean],[Int],[DateTime])
  values (@par1,@par2,@par3/100,@par4,@par5,@par6)    
--  select @i = 1/0
  select @NEWID = max(ID) from [dbo].[Table_Template]
  select 1 as result,'' as error_message  ,'' as error_procedure  ,'' as error_line,  @NEWID as newID
END TRY
BEGIN CATCH
  select 0 as result, ERROR_MESSAGE() as error_message, ERROR_PROCEDURE() as error_procedure, convert(varchar(20),ERROR_LINE()) as error_line, 0 as newID
END CATCH




GO


