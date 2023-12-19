DECLARE @StartYear INT = 1983;
DECLARE @EndYear INT = 2030;

WHILE @StartYear <= @EndYear
BEGIN
    INSERT INTO Years (ManufacturingYear) VALUES (@StartYear);
    SET @StartYear = @StartYear + 1;
END;