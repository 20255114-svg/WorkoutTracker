CREATE DATABASE workoutdb;

USE workoutdb;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE workouts (
    id INT AUTO_INCREMENT PRIMARY KEY,
    workoutname VARCHAR(100) NOT NULL,
    duration INT NOT NULL,
    calories INT NOT NULL,
    workoutdate DATE NOT NULL,
    username VARCHAR(50) NOT NULL,
    CONSTRAINT fk_workout_user FOREIGN KEY (username) REFERENCES users(username)
);

drop table workoutdb.users;