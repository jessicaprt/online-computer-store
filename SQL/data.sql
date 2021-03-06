--drop table de_onCart;
--drop table de_orders;
--drop table de_savedComputers;
drop table de_parts;
drop table de_partType;
drop table de_computers;
drop table de_user;

CREATE TABLE de_user (
    userId      int,
    username    VARCHAR(40),
    password    VARCHAR(40),
    PRIMARY KEY (userId, username)
);

CREATE TABLE de_computers (
    id          int,
    computer    VARCHAR(10),
    PRIMARY KEY (id)
);

CREATE TABLE de_partType (
    typename    VARCHAR(10),
    computerId  int,
    PRIMARY KEY (typename),
    FOREIGN KEY (computerId) REFERENCES de_computers(id)
);

CREATE TABLE de_parts (
    typename    VARCHAR(10),
    computerId  int,
    partname    text,
    price       int,
    FOREIGN KEY (typename) REFERENCES de_partType(typename),
    FOREIGN KEY (computerId)  REFERENCES de_computers(id)
);

CREATE TABLE de_savedComputers(
    typename    VARCHAR(10),
    computerId  int,
    userId      int,
    username    VARCHAR(40),
    part1       text,
    part2       text,
    part3       text,
    part4       text,
    part5       text,
    PRIMARY KEY (typename, computerId),
    FOREIGN KEY (userid, username) REFERENCES de_user(userId, username)
);

CREATE TABLE de_orders (
    username    VARCHAR(40),
    typename    VARCHAR(10),
    computerId  int,
    price       int,
    PRIMARY KEY (computerId, typename, username)
);

CREATE TABLE de_onCart (
    username    VARCHAR(40),
    typename    VARCHAR(10),
    computerId  int,
    price       int,
    PRIMARY KEY (computerId, typename, username)
);

INSERT INTO de_user VALUES (1, 'user', 'password');

INSERT INTO de_computers VALUES (1, 'laptop');
INSERT INTO de_computers VALUES (2, 'desktop');
INSERT INTO de_computers VALUES (3, 'all');

INSERT INTO de_partType VALUES ('screen', 1);
INSERT INTO de_partType VALUES ('videocard', 2);
INSERT INTO de_partType VALUES ('processor', 3);
INSERT INTO de_partType VALUES ('ram', 3);
INSERT INTO de_partType VALUES ('ssd', 3);
INSERT INTO de_partType VALUES ('OS', 3);

INSERT INTO de_parts VALUES ('screen', 1, '12-inch Retina display', 60);
INSERT INTO de_parts VALUES ('screen', 1, '13-inch Retina display', 70);
INSERT INTO de_parts VALUES ('screen', 1, '15-inch Retina display', 80);
INSERT INTO de_parts VALUES ('screen', 1, '17-inch Retina display', 90);

INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 970', 100);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1070', 120);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1080', 140);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1080 TI', 180);

INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i3', 200);
INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i5', 300);
INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i7', 500);

INSERT INTO de_parts VALUES ('ram', 3, '4GB RAM', 150);
INSERT INTO de_parts VALUES ('ram', 3, '8GB RAM', 200);
INSERT INTO de_parts VALUES ('ram', 3, '16GB RAM', 250);
INSERT INTO de_parts VALUES ('ram', 3, '32GB RAM', 300);

INSERT INTO de_parts VALUES ('ssd', 3, '256GB SSD', 200);
INSERT INTO de_parts VALUES ('ssd', 3, '512GB SSD', 300);
INSERT INTO de_parts VALUES ('ssd', 3, '1TB SSD', 500);

INSERT INTO de_parts VALUES ('os', 3, 'Linux', 30);
INSERT INTO de_parts VALUES ('os', 3, 'Windows 10', 50);
INSERT INTO de_parts VALUES ('os', 3, 'Mac OSX', 90);