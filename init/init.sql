IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'vehicleadverts')
BEGIN
    CREATE DATABASE vehicleadverts;
END

GO
USE vehicleadverts; 
GO

IF OBJECT_ID('Adverts', 'U') IS NULL
BEGIN
    CREATE TABLE Adverts (
        Id int,
        MemberId int,
        CityId int,
        CityName NVARCHAR(MAX),
        TownId int,
        TownName NVARCHAR(MAX),
        ModelId int,
        ModelName NVARCHAR(MAX),
        Year int,
        Price float,
        Title NVARCHAR(MAX),
        Date date,
        CategoryId int,
        Category NVARCHAR(MAX),
        Km int,
        Color NVARCHAR(MAX),
        Gear NVARCHAR(MAX),
        Fuel NVARCHAR(MAX),
        FirstPhoto NVARCHAR(MAX),
        SecondPhoto NVARCHAR(MAX),
        UserInfo NVARCHAR(MAX),
        UserPhone NVARCHAR(10),
        Text NVARCHAR(MAX)
    );

    PRINT 'Adverts table created.';
END
ELSE
BEGIN
    PRINT 'Adverts table already exists.';
END

IF (SELECT COUNT(*) FROM Adverts) = 0
BEGIN
    BULK INSERT Adverts
    FROM '/var/opt/mssql/csvdata/Adverts.csv'
    WITH (
        FIELDTERMINATOR = ',', 
        ROWTERMINATOR = '0x0D0A',  
        FIRSTROW = 2,   
        DATAFILETYPE = 'char', 
        TABLOCK,
        KEEPNULLS,
        FORMAT = 'CSV',
        FIELDQUOTE = '"'
    );

    PRINT 'Adverts table data imported.';
END
ELSE
BEGIN
    PRINT 'Adverts table already has data.';
END

IF OBJECT_ID('AdvertVisits', 'U') IS NULL
BEGIN
    CREATE TABLE AdvertVisits (
        AdvertId int,
        IPAdress NVARCHAR(50),
        VisitDate date
    );

    PRINT 'AdvertVisits table created.';
END
ELSE
BEGIN
    PRINT 'AdvertVisits table already exists.';
END

IF (SELECT COUNT(*) FROM AdvertVisits) = 0
BEGIN
    BULK INSERT AdvertVisits
    FROM '/var/opt/mssql/csvdata/AdvertVisits.csv'
    WITH (
        FIELDTERMINATOR = ',', 
        ROWTERMINATOR = '0x0D0A',  
        FIRSTROW = 2,   
        TABLOCK,
        KEEPNULLS
    );

    PRINT 'AdvertVisits table data imported.';
END
ELSE
BEGIN
    PRINT 'AdvertVisits table already has data.';
END
