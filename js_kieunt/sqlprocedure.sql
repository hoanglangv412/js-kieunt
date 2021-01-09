USE [db_img]  
GO  
/****** Object:  StoredProcedure [dbo].[sp_insert_file]    Script Date: 11/18/2018 12:27:55 AM ******/  
DROP PROCEDURE [dbo].[sp_insert_file]  
GO  
/****** Object:  StoredProcedure [dbo].[sp_get_file_details]    Script Date: 11/18/2018 12:27:55 AM ******/  
DROP PROCEDURE [dbo].[sp_get_file_details]  
GO  
/****** Object:  StoredProcedure [dbo].[sp_get_all_files]    Script Date: 11/18/2018 12:27:55 AM ******/  
DROP PROCEDURE [dbo].[sp_get_all_files]  
GO  
/****** Object:  Table [dbo].[tbl_file]    Script Date: 11/18/2018 12:27:55 AM ******/  
DROP TABLE [dbo].[tbl_file]  
GO  
/****** Object:  Table [dbo].[tbl_file]    Script Date: 11/18/2018 12:27:55 AM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[tbl_file](  
 [file_id] [int] IDENTITY(1,1) NOT NULL,  
 [file_name] [nvarchar](max) NOT NULL,  
 [file_ext] [nvarchar](max) NOT NULL,  
 [file_base6] [nvarchar](max) NOT NULL,  
 CONSTRAINT [PK_tbl_file] PRIMARY KEY CLUSTERED   
(  
 [file_id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  
  
GO  
/****** Object:  StoredProcedure [dbo].[sp_get_all_files]    Script Date: 11/18/2018 12:27:55 AM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_get_all_files]  
   
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 SELECT [file_id]  
    ,[file_name]  
    ,[file_ext]  
 FROM [db_img].[dbo].[tbl_file]  
END  
  
GO  
/****** Object:  StoredProcedure [dbo].[sp_get_file_details]    Script Date: 11/18/2018 12:27:55 AM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_get_file_details]   
 @file_id INT  
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 SELECT [file_id]  
    ,[file_name]  
    ,[file_ext]  
    ,[file_base6]  
 FROM [db_img].[dbo].[tbl_file]  
 WHERE [tbl_file].[file_id] = @file_id  
END  
  
GO  
/****** Object:  StoredProcedure [dbo].[sp_insert_file]    Script Date: 11/18/2018 12:27:55 AM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sp_insert_file]  
 @file_name NVARCHAR(MAX),  
 @file_ext NVARCHAR(MAX),  
 @file_base64 NVARCHAR(MAX)  
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 INSERT INTO [dbo].[tbl_file]  
           ([file_name]  
           ,[file_ext]  
           ,[file_base6])  
     VALUES  
           (@file_name  
           ,@file_ext  
           ,@file_base64)  
END  
  
GO 