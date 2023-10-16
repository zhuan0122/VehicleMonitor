-- Create the task database if it doesn't exist
CREATE DATABASE IF NOT EXISTS task;

-- Switch to the task database
USE task;

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    Address VARCHAR(255)
);

-- Insert sample data into Customers table
INSERT INTO Customers (Name, Address) VALUES
('Kalles Grustransporter AB', 'Cementvägen 8, 111 11 Södertälje'),
('Johans Bulk AB', 'Balkvägen 12, 222 22 Stockholm'),
('Haralds Värdetransporter AB', 'Budgetvägen 1, 333 33 Uppsala');

-- Create Vehicles table
CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY AUTO_INCREMENT,
    CustomerID INT,
    VIN VARCHAR(255),
    RegNumber VARCHAR(255),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Insert sample data into Vehicles table
INSERT INTO Vehicles (CustomerID, VIN, RegNumber) VALUES
(1, 'YS2R4X20005399401', 'ABC123'),
(1, 'VLUR4X20009093588', 'DEF456'),
(1, 'VLUR4X20009048066', 'GHI789'),
(2, 'YS2R4X20005388011', 'JKL012'),
(2, 'YS2R4X20005387949', 'MNO345'),
(3, 'YS2R4X20005387765', 'PQR678'),
(3, 'YS2R4X20005387055', 'STU901');

-- Create VehicleStatus table
CREATE TABLE VehicleStatus (
    StatusID INT PRIMARY KEY AUTO_INCREMENT,
    VehicleID INT,
    Status VARCHAR(255),
    Timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID)
);

-- Insert sample data into VehicleStatus table (optional for initial testing)
INSERT INTO VehicleStatus (VehicleID, Status) VALUES
(1, 'Connected'),
(2, 'Disconnected'),
(3, 'Connected'),
(4, 'Connected'),
(5, 'Disconnected'),
(6, 'Connected'),
(7, 'Disconnected');
