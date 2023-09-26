IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='usuarios' and xtype='U')
    CREATE TABLE usuarios (
        id INT identity(1,1) PRIMARY KEY,
        nome NVARCHAR(100),
        email NVARCHAR(100) NOT NULL UNIQUE, 
        site NVARCHAR(100) UNIQUE,
        sobre NVARCHAR(1000)
    )
GO
