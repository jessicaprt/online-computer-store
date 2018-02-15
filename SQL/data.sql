CREATE TABLE de_user (
    userId      int,
    username    VARCHAR(40),
    password    VARCHAR(40)
);

CREATE TABLE de_computers (
    id          int,
    computer    VARCHAR(10),
    PRIMARY KEY (id, computer)
);

CREATE TABLE de_partType (
    typename    VARCHAR(10),
    computerId  int
    FOREIGN KEY (computerId) REFERENCES de_computers(id)
);

CREATE TABLE de_parts (
    typename    VARCHAR(10),
    computerId  int,
    partname    text,
    shortname   VARCHAR(20),
    price       int,
    FOREIGN KEY (typename) REFERENCES de_partType(typename),
    FOREIGN KEY (computerId)  REFERENCES de_computers(id)
);

CREATE TABLE de_laptops(
    typename    VARCHAR(10),
    laptopid    int,
    userId      int,
    username    VARCHAR(40),
    screen      VARCHAR(20),
    processor   VARCHAR(20),
    ram         VARCHAR(20),
    ssd         VARCHAR(20),
    os          VARCHAR(20),
    PRIMARY KEY (typename, laptopid),
    FOREIGN KEY (userid) REFERENCES de_user(userId),
    FOREIGN KEY (username) REFERENCES de_user(username)
);

CREATE TABLE de_desktops(
    typename    VARCHAR(10),
    desktopId   int,
    userId      int,
    username    VARCHAR(40),
    processor   VARCHAR(20),
    ram         VARCHAR(20),
    ssd         VARCHAR(20),
    os          VARCHAR(20),
    videocard   VARCHAR(20),
    PRIMARY KEY (typename, desktopid),
    FOREIGN KEY (userid) REFERENCES de_user(userId),
    FOREIGN KEY (username) REFERENCES de_user(username)
);

CREATE TABLE de_orders (
    orderId     int,
    username    VARCHAR(40),
    typename    VARCHAR(10),
    computerId  int,
    PRIMARY KEY (orderId, username),
    FOREIGN KEY (username) REFERENCES de_user(username)
);

CREATE TABLE de_onCart (
    orderId     int,
    username    VARCHAR(40),
    typename    VARCHAR(10),
    computerId  int,
    PRIMARY KEY (orderId, username),
    FOREIGN KEY (username) REFERENCES de_user(username)
)

INSERT INTO de_user VALUES (1, 'user', 'password');

INSERT INTO de_computers VALUES (1, 'laptop');
INSERT INTO de_computers VALUES (2, 'desktop');
INSERT INTO de_computers VALUES (3, 'all');

INSERT INTO de_partType VALUES ('screen', 1);
INSERT INTO de_partType VALUES ('videocard', 2);
INSERT INTO de_partType VALUES ('processor', 3);
INSERT INTO de_partType VALUES ('ram', 3);
INSERT INTO de_partType VALUES ('ssd', 3);
INSERT INTO de_partType VpartsALUES ('OS', 3);

INSERT INTO de_parts VALUES ('screen', 1, '12-inch Retina display', '12-inch', 60);
INSERT INTO de_parts VALUES ('screen', 1, '13-inch Retina display', '13-inch', 70);
INSERT INTO de_parts VALUES ('screen', 1, '15-inch Retina display', '15-inch', 80);
INSERT INTO de_parts VALUES ('screen', 1, '17-inch Retina display', '17-inch', 90);

INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 970', '970', 100);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1070', '1070', 120);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1080', '1080', 140);
INSERT INTO de_parts VALUES ('videocard', 2, 'GTX 1080 TI', '1080TI', 180);

INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i3', 'i3', 200);
INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i5', 'i5', 300);
INSERT INTO de_parts VALUES ('processor', 3, 'Intel Core i7', 'i7', 500);

INSERT INTO de_parts VALUES ('ram', 3, '4GB RAM', '4GB', 150);
INSERT INTO de_parts VALUES ('ram', 3, '8GB RAM', '8GB', 200);
INSERT INTO de_parts VALUES ('ram', 3, '16GB RAM', '16GB', 250);
INSERT INTO de_parts VALUES ('ram', 3, '32GB RAM', '32GB', 300);

INSERT INTO de_parts VALUES ('ssd', 3, '256GB SSD', '256GB', 200);
INSERT INTO de_parts VALUES ('ssd', 3, '512GB SSD', '512GB', 300);
INSERT INTO de_parts VALUES ('ssd', 3, '1TB SSD', '1TB', 500);

INSERT INTO de_parts VALUES ('os', 3, 'Linux', 'Linux', 30);
INSERT INTO de_parts VALUES ('os', 3, 'Windows 10', 'Windows', 50);
INSERT INTO de_parts VALUES ('os', 3, 'Mac OSX', 'Mac', 90);