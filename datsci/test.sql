DROP TABLE items;
CREATE TABLE items (
id     integer PRIMARY KEY,
name   varchar(40)
);
INSERT INTO items VALUES (1, 'Item1');
SELECT * FROM items;
