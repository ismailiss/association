IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [Associations] (
        [AssociationID] int NOT NULL IDENTITY,
        [Nom] nvarchar(30) NULL,
        [Adresse] nvarchar(255) NULL,
        [Telephone] nvarchar(15) NULL,
        CONSTRAINT [PK_Associations] PRIMARY KEY ([AssociationID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [Tarif] (
        [TarifID] int NOT NULL IDENTITY,
        [Montant] real NOT NULL,
        [DateApplication] datetime2 NOT NULL,
        [DateFinApplication] datetime2 NOT NULL,
        CONSTRAINT [PK_Tarif] PRIMARY KEY ([TarifID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Nom] nvarchar(30) NULL,
        [Prenom] nvarchar(30) NULL,
        [AssociationID] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_Associations_AssociationID] FOREIGN KEY ([AssociationID]) REFERENCES [Associations] ([AssociationID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [Clients] (
        [ClientID] int NOT NULL IDENTITY,
        [Nom] nvarchar(30) NULL,
        [Prenom] nvarchar(30) NULL,
        [CIN] nvarchar(10) NULL,
        [Adresse] nvarchar(255) NULL,
        [Telephone] nvarchar(15) NULL,
        [AssociationID] int NOT NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientID]),
        CONSTRAINT [FK_Clients_Associations_AssociationID] FOREIGN KEY ([AssociationID]) REFERENCES [Associations] ([AssociationID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [CompteurEaus] (
        [CompteurEauID] int NOT NULL IDENTITY,
        [Numero] nvarchar(20) NOT NULL,
        [Emplacement] nvarchar(max) NULL,
        [DateDebut] datetime2 NOT NULL,
        [DateFin] datetime2 NOT NULL,
        [Actif] bit NOT NULL,
        [ClientID] int NOT NULL,
        CONSTRAINT [PK_CompteurEaus] PRIMARY KEY ([CompteurEauID]),
        CONSTRAINT [FK_CompteurEaus_Clients_ClientID] FOREIGN KEY ([ClientID]) REFERENCES [Clients] ([ClientID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE TABLE [Factures] (
        [FactureID] int NOT NULL IDENTITY,
        [DateFacture] datetime2 NOT NULL,
        [ValeurCompteur] int NOT NULL,
        [ValeurCompteurPrecedente] int NOT NULL,
        [isPayee] bit NOT NULL,
        [CompteurEauID] int NOT NULL,
        [TarifID] int NOT NULL,
        CONSTRAINT [PK_Factures] PRIMARY KEY ([FactureID]),
        CONSTRAINT [FK_Factures_CompteurEaus_CompteurEauID] FOREIGN KEY ([CompteurEauID]) REFERENCES [CompteurEaus] ([CompteurEauID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Factures_Tarif_TarifID] FOREIGN KEY ([TarifID]) REFERENCES [Tarif] ([TarifID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_AspNetUsers_AssociationID] ON [AspNetUsers] ([AssociationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_Clients_AssociationID] ON [Clients] ([AssociationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_CompteurEaus_ClientID] ON [CompteurEaus] ([ClientID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_Factures_CompteurEauID] ON [Factures] ([CompteurEauID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    CREATE INDEX [IX_Factures_TarifID] ON [Factures] ([TarifID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190119233144_mig12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190119233144_mig12', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120131354_mig13')
BEGIN
    ALTER TABLE [AspNetRoles] ADD [Description] nvarchar(30) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120131354_mig13')
BEGIN
    ALTER TABLE [AspNetRoles] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120131354_mig13')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190120131354_mig13', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120232731_mig15')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Associations_AssociationID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120232731_mig15')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'AssociationID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [AssociationID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120232731_mig15')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Associations_AssociationID] FOREIGN KEY ([AssociationID]) REFERENCES [Associations] ([AssociationID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190120232731_mig15')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190120232731_mig15', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190130221032_mig16')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tarif]') AND [c].[name] = N'DateFinApplication');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Tarif] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Tarif] ALTER COLUMN [DateFinApplication] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190130221032_mig16')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CompteurEaus]') AND [c].[name] = N'DateFin');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CompteurEaus] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [CompteurEaus] ALTER COLUMN [DateFin] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190130221032_mig16')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190130221032_mig16', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131011146_mig17')
BEGIN
    ALTER TABLE [Factures] DROP CONSTRAINT [FK_Factures_Tarif_TarifID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131011146_mig17')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Factures]') AND [c].[name] = N'TarifID');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Factures] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Factures] ALTER COLUMN [TarifID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131011146_mig17')
BEGIN
    ALTER TABLE [Factures] ADD CONSTRAINT [FK_Factures_Tarif_TarifID] FOREIGN KEY ([TarifID]) REFERENCES [Tarif] ([TarifID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131011146_mig17')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190131011146_mig17', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190214223913_mig18')
BEGIN
    ALTER TABLE [Factures] ADD [FactureDe] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190214223913_mig18')
BEGIN
    CREATE TABLE [FacturesGeneree] (
        [FactureID] int NOT NULL IDENTITY,
        [DateFactures] datetime2 NOT NULL,
        [DateGeneration] datetime2 NOT NULL,
        [FactureDE] datetime2 NOT NULL,
        [NombreFacturesGenerees] int NOT NULL,
        [AssociationID] int NOT NULL,
        CONSTRAINT [PK_FacturesGeneree] PRIMARY KEY ([FactureID]),
        CONSTRAINT [FK_FacturesGeneree_Associations_AssociationID] FOREIGN KEY ([AssociationID]) REFERENCES [Associations] ([AssociationID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190214223913_mig18')
BEGIN
    CREATE INDEX [IX_FacturesGeneree_AssociationID] ON [FacturesGeneree] ([AssociationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190214223913_mig18')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190214223913_mig18', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FacturesGeneree]') AND [c].[name] = N'NombreFacturesGenerees');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [FacturesGeneree] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [FacturesGeneree] DROP COLUMN [NombreFacturesGenerees];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    EXEC sp_rename N'[FacturesGeneree].[FactureDE]', N'FactureDe', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    EXEC sp_rename N'[FacturesGeneree].[FactureID]', N'FacturesGenereeID', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    ALTER TABLE [FacturesGeneree] ADD [FacturesGenereeID1] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    ALTER TABLE [Factures] ADD [FacturesGenereeID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    CREATE INDEX [IX_FacturesGeneree_FacturesGenereeID1] ON [FacturesGeneree] ([FacturesGenereeID1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    CREATE INDEX [IX_Factures_FacturesGenereeID] ON [Factures] ([FacturesGenereeID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    ALTER TABLE [Factures] ADD CONSTRAINT [FK_Factures_FacturesGeneree_FacturesGenereeID] FOREIGN KEY ([FacturesGenereeID]) REFERENCES [FacturesGeneree] ([FacturesGenereeID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    ALTER TABLE [FacturesGeneree] ADD CONSTRAINT [FK_FacturesGeneree_FacturesGeneree_FacturesGenereeID1] FOREIGN KEY ([FacturesGenereeID1]) REFERENCES [FacturesGeneree] ([FacturesGenereeID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190217113111_mig19')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190217113111_mig19', N'2.1.4-rtm-31024');
END;

GO

