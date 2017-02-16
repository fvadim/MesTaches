CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [Name]                 NVARCHAR (100) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);




CREATE TABLE [dbo].[Projets] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_dbo.Projets] PRIMARY KEY CLUSTERED ([Id] ASC)
);




CREATE TABLE [dbo].[Taches] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (255) NOT NULL,
    [CreateDT] DATETIME       NOT NULL,
    [EndDT]    DATETIME       NULL,
    [ProjetId] INT            NOT NULL,
    [UserId]   NVARCHAR (128) NOT NULL,
    [FinalDT]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.Taches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Taches_dbo.Projets_ProjetId] FOREIGN KEY ([ProjetId]) REFERENCES [dbo].[Projets] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Taches_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjetId]
    ON [dbo].[Taches]([ProjetId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Taches]([UserId] ASC);



CREATE TABLE [dbo].[Associations] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Projet_Id] INT            NULL,
    [User_Id]   NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Associations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Associations_dbo.Projets_Projet_Id] FOREIGN KEY ([Projet_Id]) REFERENCES [dbo].[Projets] ([Id]),
    CONSTRAINT [FK_dbo.Associations_dbo.AspNetUsers_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_Projet_Id]
    ON [dbo].[Associations]([Projet_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Associations]([User_Id] ASC);

