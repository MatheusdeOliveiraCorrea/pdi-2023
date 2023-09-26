IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='imagens_artigos' and xtype='U')
    CREATE TABLE imagens_artigos (
      id INT IDENTITY (1, 1) PRIMARY KEY,
      artigo_id INT NOT NULL,
      image_path NVARCHAR(800) NOT NULL,

      FOREIGN KEY (artigo_id)
        REFERENCES artigos (id)
    )
GO

