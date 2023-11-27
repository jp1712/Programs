
DROP TABLE IF EXISTS Employee;

CREATE TABLE Employee (
    Id INT PRIMARY KEY,
    Name VARCHAR(255)
);

INSERT INTO Employee (Id, Name)
VALUES
    (1, 'Jatin'),
    (2, 'Dhruvin'),
    (3, 'Sarvesh'),
    (4, 'Panth'),
    (5, 'Sarvesh'),
    (6, 'Dhruvin'),
    (7, 'Jatin'),
    (8, 'Sarvesh')

;WITH duplicate_employees AS (
    SELECT
        Name,
        Id,
        ROW_NUMBER() OVER (PARTITION BY Name ORDER BY Id) AS row_num,
        COUNT(*) OVER (PARTITION BY Name ORDER BY Name) AS total_count
    FROM
        Employee
)
SELECT
    Name,
    total_count
FROM
    duplicate_employees
WHERE
    row_num = 1;