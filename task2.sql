-- postgres SQL --
-- Products and categories -- 

BEGIN;
CREATE TABLE products 
(
	id serial PRIMARY KEY,
	name varchar(256) NOT NULL
);

CREATE TABLE categories
(
	id serial PRIMARY KEY,
	name varchar(256) NOT NULL
);

CREATE TABLE products_categories
(
	product_id int REFERENCES products(id),
	category_id int REFERENCES categories(id),
	CONSTRAINT products_categories_PK PRIMARY KEY (product_id, category_id)
);
COMMIT;

BEGIN;
INSERT INTO products (name) VALUES ('Product 1'), ('Product 2'), ('Product 3'), ('Product 4');

INSERT INTO categories (name) VALUES ('Category 1'), ('Category 2'), ('Category 3'), ('Category 4');

INSERT INTO products_categories VALUES (1, 1), (2, 2), (3,2), (3, 3), (3, 4);
COMMIT;

SELECT p.name, c.name
FROM products p
LEFT JOIN products_categories pc ON pc.product_id = p.id
LEFT JOIN categories c ON pc.category_id = c.id;