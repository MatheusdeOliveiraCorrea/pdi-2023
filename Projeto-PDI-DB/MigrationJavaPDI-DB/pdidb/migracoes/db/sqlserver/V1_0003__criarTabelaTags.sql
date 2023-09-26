IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tags' and xtype='U')
    CREATE TABLE tags (
        id int IDENTITY (1, 1) PRIMARY KEY,
    	valor NVARCHAR(50) NOT NULL,
    )
GO