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

CREATE TABLE [Actors] (
    [ActorId] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Age] int NULL,
    [Gender] nvarchar(50) NOT NULL,
    [Nationality] nvarchar(100) NOT NULL,
    [BirthDate] datetime NULL,
    [Biography] nvarchar(max) NOT NULL,
    [Images] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY ([ActorId])
);
GO

CREATE TABLE [Directors] (
    [DirectorId] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Age] int NULL,
    [Gender] nvarchar(50) NOT NULL,
    [Nationality] nvarchar(100) NOT NULL,
    [BirthDate] datetime NULL,
    [Biography] nvarchar(max) NOT NULL,
    [Images] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Directors] PRIMARY KEY ([DirectorId])
);
GO

CREATE TABLE [Genres] (
    [GenreId] int NOT NULL IDENTITY,
    [GenreName] nvarchar(100) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
);
GO

CREATE TABLE [Languages] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [IsoCode] nvarchar(2) NOT NULL,
    [Region] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Languages] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movies] (
    [MovieId] int NOT NULL IDENTITY,
    [Title] nvarchar(255) NOT NULL,
    [Rated] nvarchar(10) NOT NULL,
    [ReleasedDate] datetime NULL,
    [Plot] nvarchar(max) NOT NULL,
    [Country] nvarchar(100) NOT NULL,
    [Poster] nvarchar(max) NOT NULL,
    [BoxOffice] decimal(18,2) NULL,
    [Website] nvarchar(max) NOT NULL,
    [Production] nvarchar(max) NOT NULL,
    [Trailer] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([MovieId])
);
GO

CREATE TABLE [Tags] (
    [TagId] int NOT NULL IDENTITY,
    [TagName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(255) NOT NULL,
    [Password] nvarchar(255) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [BirthDate] datetime NULL,
    [Address] nvarchar(255) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [ProfileImage] nvarchar(max) NOT NULL,
    [Gender] bit NULL,
    [Type] bit NULL,
    [Country] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Writers] (
    [WriterId] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Age] int NULL,
    [Gender] nvarchar(50) NOT NULL,
    [Nationality] nvarchar(100) NOT NULL,
    [BirthDate] datetime NULL,
    [Biography] nvarchar(max) NOT NULL,
    [Images] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Writers] PRIMARY KEY ([WriterId])
);
GO

CREATE TABLE [ActorMovies] (
    [ActorId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_ActorMovies] PRIMARY KEY ([ActorId], [MovieId]),
    CONSTRAINT [FK_ActorMovies_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([ActorId]),
    CONSTRAINT [FK_ActorMovies_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId])
);
GO

CREATE TABLE [Awards] (
    [AwardId] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Category] nvarchar(255) NOT NULL,
    [Year] datetime NULL,
    [MovieId] int NOT NULL,
    [ActorId] int NOT NULL,
    [DirectorId] int NOT NULL,
    CONSTRAINT [PK_Awards] PRIMARY KEY ([AwardId]),
    CONSTRAINT [FK_Award_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([ActorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Award_Director] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([DirectorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Award_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]) ON DELETE CASCADE
);
GO

CREATE TABLE [DirectorMovies] (
    [DirectorId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_DirectorMovies] PRIMARY KEY ([DirectorId], [MovieId]),
    CONSTRAINT [FK_DirectorMovies_Director] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([DirectorId]),
    CONSTRAINT [FK_DirectorMovies_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId])
);
GO

CREATE TABLE [MovieGenres] (
    [MovieId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_MovieGenres] PRIMARY KEY ([MovieId], [GenreId]),
    CONSTRAINT [FK_MovieGenres_Genre] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([GenreId]),
    CONSTRAINT [FK_MovieGenres_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId])
);
GO

CREATE TABLE [MovieLanguages] (
    [MovieId] int NOT NULL,
    [LanguageId] int NOT NULL,
    CONSTRAINT [PK_MovieLanguages] PRIMARY KEY ([MovieId], [LanguageId]),
    CONSTRAINT [FK_MovieLanguages_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Languages] ([Id]),
    CONSTRAINT [FK_MovieLanguages_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId])
);
GO

CREATE TABLE [News] (
    [NewsId] int NOT NULL IDENTITY,
    [Title] nvarchar(255) NOT NULL,
    [Category] nvarchar(50) NOT NULL,
    [DatePublished] datetime NULL,
    [Content] nvarchar(max) NOT NULL,
    [MovieId] int NOT NULL,
    [ActorId] int NOT NULL,
    [DirectorId] int NOT NULL,
    CONSTRAINT [PK_News] PRIMARY KEY ([NewsId]),
    CONSTRAINT [FK_News_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([ActorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_News_Director] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([DirectorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_News_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieTags] (
    [MovieId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_MovieTags] PRIMARY KEY ([MovieId], [TagId]),
    CONSTRAINT [FK_MovieTags_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]),
    CONSTRAINT [FK_MovieTags_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId])
);
GO

CREATE TABLE [Comments] (
    [CommentId] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NOT NULL,
    [ReplyTo] int NULL,
    [Time] datetime NULL,
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
    CONSTRAINT [FK_Comment_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Comment_User] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Rates] (
    [RateId] int NOT NULL IDENTITY,
    [NumericRating] decimal(5,2) NULL,
    [Time] datetime NULL,
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Rates] PRIMARY KEY ([RateId]),
    CONSTRAINT [FK_Rate_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]),
    CONSTRAINT [FK_Rate_User] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE TABLE [UserInteractions] (
    [UserId] int NOT NULL,
    [MovieId] int NOT NULL,
    [Timestamp] datetime NULL,
    CONSTRAINT [PK_UserInteractions] PRIMARY KEY ([UserId], [MovieId]),
    CONSTRAINT [FK_UserInteractions_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]),
    CONSTRAINT [FK_UserInteractions_User] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE TABLE [WriterMovies] (
    [WriterId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_WriterMovies] PRIMARY KEY ([WriterId], [MovieId]),
    CONSTRAINT [FK_WriterMovies_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId]),
    CONSTRAINT [FK_WriterMovies_Writer] FOREIGN KEY ([WriterId]) REFERENCES [Writers] ([WriterId])
);
GO

CREATE TABLE [ActorAwards] (
    [ActorId] int NOT NULL,
    [AwardId] int NOT NULL,
    CONSTRAINT [PK_ActorAwards] PRIMARY KEY ([ActorId], [AwardId]),
    CONSTRAINT [FK_ActorAwards_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([ActorId]),
    CONSTRAINT [FK_ActorAwards_Award] FOREIGN KEY ([AwardId]) REFERENCES [Awards] ([AwardId])
);
GO

CREATE TABLE [DirectorAwards] (
    [DirectorId] int NOT NULL,
    [AwardId] int NOT NULL,
    CONSTRAINT [PK_DirectorAwards] PRIMARY KEY ([DirectorId], [AwardId]),
    CONSTRAINT [FK_DirectorAwards_Award] FOREIGN KEY ([AwardId]) REFERENCES [Awards] ([AwardId]),
    CONSTRAINT [FK_DirectorAwards_Director] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([DirectorId])
);
GO

CREATE TABLE [MovieAwards] (
    [MovieId] int NOT NULL,
    [AwardId] int NOT NULL,
    CONSTRAINT [PK_MovieAwards] PRIMARY KEY ([MovieId], [AwardId]),
    CONSTRAINT [FK_MovieAwards_Award] FOREIGN KEY ([AwardId]) REFERENCES [Awards] ([AwardId]),
    CONSTRAINT [FK_MovieAwards_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([MovieId])
);
GO

CREATE TABLE [DirectorNews] (
    [DirectorId] int NOT NULL,
    [NewsId] int NOT NULL,
    CONSTRAINT [PK_DirectorNews] PRIMARY KEY ([DirectorId], [NewsId]),
    CONSTRAINT [FK_DirectorNews_Director] FOREIGN KEY ([DirectorId]) REFERENCES [Directors] ([DirectorId]),
    CONSTRAINT [FK_DirectorNews_News] FOREIGN KEY ([NewsId]) REFERENCES [News] ([NewsId])
);
GO

CREATE INDEX [IX_ActorAwards_AwardId] ON [ActorAwards] ([AwardId]);
GO

CREATE INDEX [IX_ActorMovies_MovieId] ON [ActorMovies] ([MovieId]);
GO

CREATE INDEX [IX_Awards_ActorId] ON [Awards] ([ActorId]);
GO

CREATE INDEX [IX_Awards_DirectorId] ON [Awards] ([DirectorId]);
GO

CREATE INDEX [IX_Awards_MovieId] ON [Awards] ([MovieId]);
GO

CREATE INDEX [IX_Comments_MovieId] ON [Comments] ([MovieId]);
GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
GO

CREATE INDEX [IX_DirectorAwards_AwardId] ON [DirectorAwards] ([AwardId]);
GO

CREATE INDEX [IX_DirectorMovies_MovieId] ON [DirectorMovies] ([MovieId]);
GO

CREATE INDEX [IX_DirectorNews_NewsId] ON [DirectorNews] ([NewsId]);
GO

CREATE INDEX [IX_MovieAwards_AwardId] ON [MovieAwards] ([AwardId]);
GO

CREATE INDEX [IX_MovieGenres_GenreId] ON [MovieGenres] ([GenreId]);
GO

CREATE INDEX [IX_MovieLanguages_LanguageId] ON [MovieLanguages] ([LanguageId]);
GO

CREATE INDEX [IX_MovieTags_TagId] ON [MovieTags] ([TagId]);
GO

CREATE INDEX [IX_News_ActorId] ON [News] ([ActorId]);
GO

CREATE INDEX [IX_News_DirectorId] ON [News] ([DirectorId]);
GO

CREATE INDEX [IX_News_MovieId] ON [News] ([MovieId]);
GO

CREATE INDEX [IX_Rates_MovieId] ON [Rates] ([MovieId]);
GO

CREATE INDEX [IX_Rates_UserId] ON [Rates] ([UserId]);
GO

CREATE INDEX [IX_UserInteractions_MovieId] ON [UserInteractions] ([MovieId]);
GO

CREATE INDEX [IX_WriterMovies_MovieId] ON [WriterMovies] ([MovieId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825041437_Initialize', N'6.0.21');
GO

COMMIT;
GO

