-- T?o database
CREATE DATABASE DatingAppDB;
GO
USE DatingAppDB;
GO

drop table Users

-- B?ng Users: L?u thông tin ??ng nh?p
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1), -- S? d?ng IDENTITY thay cho AUTO_INCREMENT
    Username VARCHAR(255) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

drop table Profiles
-- B?ng Profiles: L?u thông tin h? s? ng??i dùng
CREATE TABLE Profiles (
    ProfileID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    FullName VARCHAR(255) NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN (N'Nam', N'N?', N'Khác')),
    DateOfBirth DATE NOT NULL,
    Gmail VARCHAR(255) UNIQUE NOT NULL,
    Location NVARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

INSERT INTO Users (Username, PasswordHash)
VALUES ('user1', 'hashed_password_123'),
       ('user2', 'hashed_password_456');


INSERT INTO Profiles (UserID, FullName, Gender, DateOfBirth, Gmail, Location)
VALUES (1, 'Nguyen Van A', N'Nam', '1995-08-12', 'nguyenvana@gmail.com', N'Hà N?i' ),
       (2, 'Tran Thi B', N'N?', '1997-04-22', 'tranthib@gmail.com', N'H? Chí Minh');

