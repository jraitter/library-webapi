-- NOTE Authors
-- CREATE TABLE authors (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     publication VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

--  NOTE drop books table and recreate w/ LibId
--  DROP TABLE books;

-- NOTE Books | ONE TO MANY RELATIONSHIP LIBS

-- CREATE TABLE books (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     author VARCHAR(255) NOT NULL,
--     LibId INT NOT NULL,
--     available TINYINT,
--     PRIMARY KEY (id),

--     FOREIGN KEY (libId)
--         REFERENCES libraries(id)
--         ON DELETE CASCADE
-- );



-- NOTE bookAuthors

-- CREATE TABLE bookAuthors (
--     id INT NOT NULL AUTO_INCREMENT,
--     bookId INT NOT NULL,
--     authId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (bookId)
--         REFERENCES books (id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (authId)
--         REFERENCES authors (id)
--         ON DELETE CASCADE
-- );


-- NOTE Getting books by author id
-- SELECT * FROM bookAuthors ba
-- INNER JOIN authors a ON a.id = ba.authId
-- WHERE bookId = 1;

-- SELECT * FROM bookAuthors ba
-- INNER JOIN books b ON b.id = ba.bookId
-- WHERE authId = 7;


-- api/carts/1/shoes

-- select * from bookauthors;

-- NOTE these below work and are in code
-- SELECT * FROM bookauthors ba
-- INNER JOIN authors a ON a.id = ba.authId
-- WHERE bookId = @ID;

  -- SELECT b.* FROM bookauthors ba
  -- INNER JOIN books b ON b.id = ba.bookId
  -- WHERE authId = @Id;";