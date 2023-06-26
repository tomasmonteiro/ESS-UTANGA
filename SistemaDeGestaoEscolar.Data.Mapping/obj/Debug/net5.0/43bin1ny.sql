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

CREATE TABLE [identity_role] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(256) NULL,
    [normalized_name] nvarchar(256) NULL,
    [concurrency_stamp] nvarchar(max) NULL,
    CONSTRAINT [pk_identity_role] PRIMARY KEY ([id])
);
GO

CREATE TABLE [identity_user] (
    [id] int NOT NULL IDENTITY,
    [nome_completo] nvarchar(200) NOT NULL,
    [senha] nvarchar(100) NULL,
    [senha_confirmacao] nvarchar(100) NULL,
    [user_name] nvarchar(256) NULL,
    [normalized_user_name] nvarchar(256) NULL,
    [email] nvarchar(256) NULL,
    [normalized_email] nvarchar(256) NULL,
    [email_confirmed] bit NOT NULL,
    [password_hash] nvarchar(max) NULL,
    [security_stamp] nvarchar(max) NULL,
    [concurrency_stamp] nvarchar(max) NULL,
    [phone_number] nvarchar(max) NULL,
    [phone_number_confirmed] bit NOT NULL,
    [two_factor_enabled] bit NOT NULL,
    [lockout_end] datetimeoffset NULL,
    [lockout_enabled] bit NOT NULL,
    [access_failed_count] int NOT NULL,
    CONSTRAINT [pk_identity_user] PRIMARY KEY ([id])
);
GO

CREATE TABLE [identity_role_claim] (
    [id] int NOT NULL IDENTITY,
    [role_id] int NOT NULL,
    [claim_type] nvarchar(max) NULL,
    [claim_value] nvarchar(max) NULL,
    CONSTRAINT [pk_identity_role_claim] PRIMARY KEY ([id]),
    CONSTRAINT [fk_identity_role_claim_role_id] FOREIGN KEY ([role_id]) REFERENCES [identity_role] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [identity_user_claim] (
    [id] int NOT NULL IDENTITY,
    [user_id] int NOT NULL,
    [claim_type] nvarchar(max) NULL,
    [claim_value] nvarchar(max) NULL,
    CONSTRAINT [pk_identity_user_claim] PRIMARY KEY ([id]),
    CONSTRAINT [fk_identity_user_claim_user_id] FOREIGN KEY ([user_id]) REFERENCES [identity_user] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [identity_user_login] (
    [login_provider] nvarchar(450) NOT NULL,
    [provider_key] nvarchar(450) NOT NULL,
    [provider_display_name] nvarchar(max) NULL,
    [user_id] int NOT NULL,
    CONSTRAINT [pk_identity_user_login] PRIMARY KEY ([login_provider], [provider_key]),
    CONSTRAINT [fk_identity_user_login_user_id] FOREIGN KEY ([user_id]) REFERENCES [identity_user] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [identity_user_role] (
    [user_id] int NOT NULL,
    [role_id] int NOT NULL,
    CONSTRAINT [pk_identity_user_role] PRIMARY KEY ([user_id], [role_id]),
    CONSTRAINT [fk_identity_user_role_role_id] FOREIGN KEY ([role_id]) REFERENCES [identity_role] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_identity_user_role_user_id] FOREIGN KEY ([user_id]) REFERENCES [identity_user] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [identity_user_token] (
    [user_id] int NOT NULL,
    [login_provider] nvarchar(450) NOT NULL,
    [name] nvarchar(450) NOT NULL,
    [value] nvarchar(max) NULL,
    CONSTRAINT [pk_identity_user_token] PRIMARY KEY ([user_id], [login_provider], [name]),
    CONSTRAINT [fk_identity_user_token_user_id] FOREIGN KEY ([user_id]) REFERENCES [identity_user] ([id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [idx_identity_role_name] ON [identity_role] ([normalized_name]) WHERE [normalized_name] IS NOT NULL;
GO

CREATE INDEX [idx_identity_role_claim_role_id] ON [identity_role_claim] ([role_id]);
GO

CREATE INDEX [idx_identity_email] ON [identity_user] ([normalized_email]);
GO

CREATE UNIQUE INDEX [idx_identity_user_name] ON [identity_user] ([normalized_user_name]) WHERE [normalized_user_name] IS NOT NULL;
GO

CREATE INDEX [idx_identity_user_claim_user_id] ON [identity_user_claim] ([user_id]);
GO

CREATE INDEX [idx_identity_user_login_user_id] ON [identity_user_login] ([user_id]);
GO

CREATE INDEX [idx_identity_user_role_role_id] ON [identity_user_role] ([role_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230520130900_AddIdentity', N'5.0.5');
GO

COMMIT;
GO

