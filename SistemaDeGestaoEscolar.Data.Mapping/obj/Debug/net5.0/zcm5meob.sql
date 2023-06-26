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

CREATE TABLE [asp_net_roles] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(256) NULL,
    [normalized_name] nvarchar(256) NULL,
    [concurrency_stamp] nvarchar(max) NULL,
    CONSTRAINT [pk_asp_net_roles] PRIMARY KEY ([id])
);
GO

CREATE TABLE [asp_net_users] (
    [id] int NOT NULL IDENTITY,
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
    CONSTRAINT [pk_asp_net_users] PRIMARY KEY ([id])
);
GO

CREATE TABLE [asp_net_role_claims] (
    [id] int NOT NULL IDENTITY,
    [role_id] int NOT NULL,
    [claim_type] nvarchar(max) NULL,
    [claim_value] nvarchar(max) NULL,
    CONSTRAINT [pk_asp_net_role_claims] PRIMARY KEY ([id]),
    CONSTRAINT [fk_asp_net_role_claims_role_id] FOREIGN KEY ([role_id]) REFERENCES [asp_net_roles] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [asp_net_user_claims] (
    [id] int NOT NULL IDENTITY,
    [user_id] int NOT NULL,
    [claim_type] nvarchar(max) NULL,
    [claim_value] nvarchar(max) NULL,
    CONSTRAINT [pk_asp_net_user_claims] PRIMARY KEY ([id]),
    CONSTRAINT [fk_asp_net_user_claims_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [asp_net_user_logins] (
    [login_provider] nvarchar(450) NOT NULL,
    [provider_key] nvarchar(450) NOT NULL,
    [provider_display_name] nvarchar(max) NULL,
    [user_id] int NOT NULL,
    CONSTRAINT [pk_asp_net_user_logins] PRIMARY KEY ([login_provider], [provider_key]),
    CONSTRAINT [fk_asp_net_user_logins_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [asp_net_user_roles] (
    [user_id] int NOT NULL,
    [role_id] int NOT NULL,
    CONSTRAINT [pk_asp_net_user_roles] PRIMARY KEY ([user_id], [role_id]),
    CONSTRAINT [fk_asp_net_user_roles_role_id] FOREIGN KEY ([role_id]) REFERENCES [asp_net_roles] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_asp_net_user_roles_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [asp_net_user_tokens] (
    [user_id] int NOT NULL,
    [login_provider] nvarchar(450) NOT NULL,
    [name] nvarchar(450) NOT NULL,
    [value] nvarchar(max) NULL,
    CONSTRAINT [pk_asp_net_user_tokens] PRIMARY KEY ([user_id], [login_provider], [name]),
    CONSTRAINT [fk_asp_net_user_tokens_user_id] FOREIGN KEY ([user_id]) REFERENCES [asp_net_users] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [idx_identity_asp_net_role_claims_role_id] ON [asp_net_role_claims] ([role_id]);
GO

CREATE UNIQUE INDEX [idx_identity_role_name] ON [asp_net_roles] ([normalized_name]) WHERE [normalized_name] IS NOT NULL;
GO

CREATE INDEX [idx_identity_asp_net_user_claims_user_id] ON [asp_net_user_claims] ([user_id]);
GO

CREATE INDEX [idx_identity_asp_net_user_logins_user_id] ON [asp_net_user_logins] ([user_id]);
GO

CREATE INDEX [idx_identity_asp_net_user_roles_role_id] ON [asp_net_user_roles] ([role_id]);
GO

CREATE INDEX [idx_identity_email] ON [asp_net_users] ([normalized_email]);
GO

CREATE UNIQUE INDEX [idx_identity_user_name] ON [asp_net_users] ([normalized_user_name]) WHERE [normalized_user_name] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514124514_AddIdentity', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [identity_user] ADD [nome_completo] nvarchar(200) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230514125133_AddUserColumnNomeCompleto', N'5.0.5');
GO

COMMIT;
GO

