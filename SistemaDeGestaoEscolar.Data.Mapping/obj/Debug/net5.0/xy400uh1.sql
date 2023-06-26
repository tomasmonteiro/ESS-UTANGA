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

CREATE TABLE [curso] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [requisito] nvarchar(100) NULL,
    [carga_horaria] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_curso] PRIMARY KEY ([id])
);
GO

CREATE TABLE [disciplina] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [area] nvarchar(100) NULL,
    [programa] nvarchar(100) NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_disciplina] PRIMARY KEY ([id])
);
GO

CREATE TABLE [professor] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [data_nascimento] datetime2 NOT NULL,
    [email] nvarchar(100) NULL,
    [hora] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_professor] PRIMARY KEY ([id])
);
GO

CREATE TABLE [aluno] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [data_nascimento] datetime2 NOT NULL,
    [numero] int NOT NULL,
    [morada] nvarchar(100) NULL,
    [idade] int NOT NULL,
    [contacto] int NOT NULL,
    [email] nvarchar(100) NULL,
    [id_disciplina] int NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_aluno] PRIMARY KEY ([id]),
    CONSTRAINT [fk_aluno_id_disciplina] FOREIGN KEY ([id_disciplina]) REFERENCES [disciplina] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [turma] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [periodo] datetime2 NOT NULL,
    [id_aluno] int NOT NULL,
    [id_professor] int NOT NULL,
    [data_inicio] datetime2 NOT NULL,
    [data_final] datetime2 NOT NULL,
    [carga_horaria] datetime2 NOT NULL,
    [id_curso] int NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_turma] PRIMARY KEY ([id]),
    CONSTRAINT [fk_turma_id_aluno] FOREIGN KEY ([id_aluno]) REFERENCES [aluno] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_turma_id_curso] FOREIGN KEY ([id_curso]) REFERENCES [curso] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_turma_id_professor] FOREIGN KEY ([id_professor]) REFERENCES [professor] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [matricula] (
    [id] int NOT NULL IDENTITY,
    [id_turma] int NOT NULL,
    [id_aluno] int NOT NULL,
    [data_matricula] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_matricula] PRIMARY KEY ([id]),
    CONSTRAINT [fk_matricula_id_aluno] FOREIGN KEY ([id_aluno]) REFERENCES [aluno] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_matricula_id_turma] FOREIGN KEY ([id_turma]) REFERENCES [turma] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [idx_aluno_id_disciplina] ON [aluno] ([id_disciplina]);
GO

CREATE INDEX [idx_matricula_id_aluno] ON [matricula] ([id_aluno]);
GO

CREATE INDEX [idx_matricula_id_turma] ON [matricula] ([id_turma]);
GO

CREATE INDEX [idx_turma_id_aluno] ON [turma] ([id_aluno]);
GO

CREATE INDEX [idx_turma_id_curso] ON [turma] ([id_curso]);
GO

CREATE INDEX [idx_turma_id_professor] ON [turma] ([id_professor]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230606101314_AddInicial', N'5.0.5');
GO

COMMIT;
GO

