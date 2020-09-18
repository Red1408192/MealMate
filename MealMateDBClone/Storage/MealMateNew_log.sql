ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [MealMateNew_log], FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.REDPC\MSSQL\DATA\MealMateNew_log.ldf', SIZE = 8192 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 65536 KB);

