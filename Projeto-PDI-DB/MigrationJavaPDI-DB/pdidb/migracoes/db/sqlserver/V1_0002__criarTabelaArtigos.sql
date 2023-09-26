IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='artigos' and xtype='U')
	CREATE TABLE artigos (
		id INT IDENTITY (1, 1) PRIMARY KEY,
		autor_id INT NOT NULL,
		data_criacao DATE NOT NULL DEFAULT GETDATE(),
		titulo NVARCHAR(500) NOT NULL,
		tempo_estimado_leitura INT DEFAULT 5,
		texto NVARCHAR(MAX) NOT NULL,
		FOREIGN KEY (autor_id) 
	        REFERENCES usuarios (id) 
	)
GO

