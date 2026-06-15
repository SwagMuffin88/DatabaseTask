IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employee] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221121144306_init', N'8.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Employee] ADD [Gender] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Children] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [EmployeeId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Children] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Children_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Children_EmployeeId] ON [Children] ([EmployeeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260613213420_AddGenderAndChildren', N'8.0.12');
GO

COMMIT;
GO

