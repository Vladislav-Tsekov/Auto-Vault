CREATE DATABASE VehicleData

USE VehicleData

GO

CREATE TABLE DrivetrainTypes (
    Id INT NOT NULL IDENTITY,
    Drivetrain NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_DrivetrainTypes PRIMARY KEY (Id)
);

CREATE TABLE TransmissionTypes (
    Id INT NOT NULL IDENTITY,
    Transmission NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_TransmissionTypes PRIMARY KEY (Id)
);

CREATE TABLE VehicleClasses (
    Id INT NOT NULL IDENTITY,
    Class NVARCHAR(75) NOT NULL,
    CONSTRAINT PK_VehicleClasses PRIMARY KEY (Id)
);

CREATE TABLE VehicleBaseModels (
    Id INT NOT NULL IDENTITY,
    BaseModel NVARCHAR(150) NOT NULL,
    CONSTRAINT PK_VehicleBaseModels PRIMARY KEY (Id)
);

CREATE TABLE VehicleMakes (
    Id INT NOT NULL IDENTITY,
    Make NVARCHAR(69) NOT NULL,
    CONSTRAINT PK_VehicleMakes PRIMARY KEY (Id)
);

CREATE TABLE VehicleModels (
    Id INT NOT NULL IDENTITY,
    Model NVARCHAR(150) NOT NULL,
    CONSTRAINT PK_VehicleModels PRIMARY KEY (Id)
);

CREATE TABLE Years (
    Id INT NOT NULL IDENTITY,
    ManufacturingYear INT NOT NULL,
    CONSTRAINT PK_Years PRIMARY KEY (Id)
);

CREATE TABLE VehicleEngines (
    Id INT NOT NULL IDENTITY,
    Engine DECIMAL(3, 1) NOT NULL,
    CONSTRAINT PK_VehicleEngines PRIMARY KEY (Id)
);

CREATE TABLE Vehicles (
    Id INT NOT NULL IDENTITY,
    VehicleMake INT NOT NULL,
    Model INT NOT NULL,
    BaseModel INT NOT NULL,
    Engine INT NOT NULL,
    DrivetrainType INT NOT NULL,
    TransmissionType INT NOT NULL,
    VehicleSizeClass INT NOT NULL,
    [Year] INT NOT NULL,
    CONSTRAINT PK_Vehicles PRIMARY KEY (Id),
    CONSTRAINT FK_Vehicles_Make FOREIGN KEY (VehicleMake) REFERENCES VehicleMakes (Id),
    CONSTRAINT FK_Vehicles_Model FOREIGN KEY (Model) REFERENCES VehicleModels (Id),
    CONSTRAINT FK_Vehicles_Engine FOREIGN KEY (Engine) REFERENCES VehicleEngines (Id),
    CONSTRAINT FK_Vehicles_Drivetrain FOREIGN KEY (DrivetrainType) REFERENCES DrivetrainTypes (Id),
    CONSTRAINT FK_Vehicles_Transmission FOREIGN KEY (TransmissionType) REFERENCES TransmissionTypes (Id),
    CONSTRAINT FK_Vehicles_Class FOREIGN KEY (VehicleSizeClass) REFERENCES VehicleClasses (Id),
    CONSTRAINT FK_Vehicles_Year FOREIGN KEY ([Year]) REFERENCES Years (Id),
    CONSTRAINT FK_Vehicles_BaseModel FOREIGN KEY (BaseModel) REFERENCES VehicleBaseModels (Id),
);

