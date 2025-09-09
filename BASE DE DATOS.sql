CREATE DATABASE pruebatecnica CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

USE pruebatecnica;

CREATE TABLE login_log (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    login_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    access_token TEXT NOT NULL
);