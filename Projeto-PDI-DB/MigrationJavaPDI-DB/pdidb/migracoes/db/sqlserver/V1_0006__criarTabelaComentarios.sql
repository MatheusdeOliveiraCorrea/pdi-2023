IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='comentarios' and xtype='U')
    CREATE TABLE comentarios (
        id INT IDENTITY (1, 1) PRIMARY KEY,
        autor_id INT NOT NULL,
        artigo_id INT NOT NULL,
        artigo_pai_id INT DEFAULT NULL,
        data_criacao DATE DEFAULT GETDATE(), 
        text NVARCHAR(600) NOT NULL,

        FOREIGN KEY (autor_id)
            REFERENCES usuarios (id),
        
        FOREIGN KEY (artigo_id)
            REFERENCES artigos (id)
    )
GO