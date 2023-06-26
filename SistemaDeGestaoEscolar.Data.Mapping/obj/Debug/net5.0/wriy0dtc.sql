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

CREATE TABLE [aluno] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [data_nascimento] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_aluno] PRIMARY KEY ([id])
);
GO

CREATE TABLE [professor] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [data_nascimento] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_professor] PRIMARY KEY ([id])
);
GO

CREATE TABLE [turma] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [periodo] datetime2 NOT NULL,
    [id_aluno] int NOT NULL,
    [id_professor] int NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_turma] PRIMARY KEY ([id]),
    CONSTRAINT [fk_turma_id_aluno] FOREIGN KEY ([id_aluno]) REFERENCES [aluno] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_turma_id_professor] FOREIGN KEY ([id_professor]) REFERENCES [professor] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [indx_turma_id_aluno] ON [turma] ([id_aluno]);
GO

CREATE INDEX [indx_turma_id_professor] ON [turma] ([id_professor]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230424152827_AddInicial', N'5.0.5');
GO

COMMIT;
GO

