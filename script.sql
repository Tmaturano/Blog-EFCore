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

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tag] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [Bio] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [AuthorId] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Summary] nvarchar(max) NOT NULL,
    [Body] nvarchar(max) NOT NULL,
    [Slug] nvarchar(450) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [LastUpdateDate] SMALLDATETIME NOT NULL DEFAULT '2021-12-06T18:03:39.3463122Z',
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY ([AuthorId]) REFERENCES [User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostTag] (
    [PostId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_TagPost_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TagPost_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Category_Slug] ON [Category] ([Slug]);
GO

CREATE INDEX [IX_Post_AuthorId] ON [Post] ([AuthorId]);
GO

CREATE INDEX [IX_Post_CategoryId] ON [Post] ([CategoryId]);
GO

CREATE UNIQUE INDEX [IX_Post_Slug] ON [Post] ([Slug]);
GO

CREATE INDEX [IX_PostTag_TagId] ON [PostTag] ([TagId]);
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [User] ([Email]);
GO

CREATE UNIQUE INDEX [IX_User_Slug] ON [User] ([Slug]);
GO

CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211206180339_InitialMigration', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [User] ADD [Github] VARCHAR(100) NOT NULL DEFAULT '';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Post]') AND [c].[name] = N'LastUpdateDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Post] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Post] ADD DEFAULT '2021-12-06T18:20:11.4327101Z' FOR [LastUpdateDate];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211206182011_AddedColumnGithub', N'6.0.0');
GO

COMMIT;
GO

