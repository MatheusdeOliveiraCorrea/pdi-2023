IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tags_artigos' and xtype='U')
	CREATE TABLE tags_artigos (
		artigo_id INT NOT NULL,
		tag_id INT NOT NULL,

		FOREIGN KEY (artigo_id)
			REFERENCES artigos (id),
		
		FOREIGN KEY (tag_id)
			REFERENCES tags (id)
	)
GO