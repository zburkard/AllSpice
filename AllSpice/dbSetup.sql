CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

DROP TABLE accounts;

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        title VARCHAR(50) NOT NULL,
        instructions VARCHAR(2000) NOT NULL,
        img VARCHAR(255),
        category VARCHAR(25) NOT NULL DEFAULT 'misc',
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

INSERT INTO
    recipes (
        title,
        instructions,
        category,
        coverImg,
        creatorId
    )
VALUES (
        'Pulled Pork',
        'Pull the Pork appart',
        'BBQ',
        'https://playswellwithbutter.com/wp-content/uploads/2021/04/BBQ-Pulled-Pork-16.jpg',
        '639911997e960bd91519ce50'
    );

INSERT INTO
    recipes (
        title,
        instructions,
        category,
        coverImg,
        creatorId
    )
VALUES (
        'Sloppy Steaks',
        'Get a nice grilled steak and dump a glass of water all over it.',
        'Fine Dining',
        'https://pbs.twimg.com/media/E535dKSXsAAfde5.jpg',
        '639911997e960bd91519ce50'
    );