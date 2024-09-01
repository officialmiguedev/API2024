SELECT Cursoes.Nombre, Leccions.Nombre, Temas.Nombre, Temas.TemaId, Cursoes.CursoId
FROM Cursoes, Leccions, Temas
WHERE Cursoes.CursoId = 1 and Temas.CursoId = 1 and Temas.TemaId = 2

select * from Leccions
select * from Temas

SELECT Temas.TemaId, Temas.Nombre, Leccions.LeccionId, Leccions.Nombre
FROM Temas, Leccions
WHERE Temas.CursoId = 1 and Temas.TemaId = 1 and Leccions.TemaId = 1

SELECT Temas, Leccions
FROM Temas, Leccions
WHERE Temas.CursoId = 1 and Temas.TemaId = 1 and Leccions.TemaId = 1
GROUP BY Temas,Leccions

SELECT Cursoes.Nombre, Leccions.Nombre, Temas.Nombre, Temas.TemaId, Cursoes.CursoId
FROM Cursoes, Leccions, Temas
WHERE Cursoes.CursoId = 1 and Temas.CursoId = 1 and Leccions.TemaId = Temas.TemaId