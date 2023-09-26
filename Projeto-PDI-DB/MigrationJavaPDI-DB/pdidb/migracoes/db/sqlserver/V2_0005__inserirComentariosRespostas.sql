-- Inserir comentário 1
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (1, 1, 'Este é o comentário 1 no artigo 1.');

-- Inserir comentário 2
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (2, 1, 'Este é o comentário 2 no artigo 1.');

    -- Inserir resposta ao comentário 2 do artigo 1
    INSERT INTO comentarios (autor_id, artigo_id, artigo_pai_id, text)
    VALUES (1, 1, 2, 'Esta é uma resposta ao comentário 2 no artigo 1.');

-- Inserir comentário 3
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (3, 2, 'Este é o comentário 1 no artigo 2.');

-- Inserir comentário 4
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (4, 2, 'Este é o comentário 2 no artigo 2.');

-- Inserir comentário 5
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (5, 3, 'Este é o comentário 1 no artigo 3.');

    -- Resposta ao comentário 1 do artigo 3
    INSERT INTO comentarios (autor_id, artigo_id, artigo_pai_id, text)
    VALUES (2, 3, 1, 'Esta é uma resposta ao comentário 1 no artigo 3.');

        -- Resposta à resposta ao comentário 1 do artigo 3
        INSERT INTO comentarios (autor_id, artigo_id, artigo_pai_id, text)
        VALUES (1, 3, (SELECT MAX(id) FROM comentarios), 'Esta é outra resposta à resposta anterior.');

-- Inserir comentário 6
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (1, 3, 'Este é o comentário 2 no artigo 3.');

-- Inserir comentário 7
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (2, 4, 'Este é o comentário 1 no artigo 4.');

-- Inserir comentário 8
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (3, 4, 'Este é o comentário 2 no artigo 4.');

-- Inserir comentário 9
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (4, 5, 'Este é o comentário 1 no artigo 5.');

-- Inserir comentário 10
INSERT INTO comentarios (autor_id, artigo_id, text)
VALUES (5, 5, 'Este é o comentário 2 no artigo 5.');
