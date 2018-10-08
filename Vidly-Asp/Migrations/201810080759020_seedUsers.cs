namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'221ca434-52aa-4492-9042-564d822a3954', N'harshrajkumar001@gmail.com', 0, NULL, N'9e015768-0574-4974-a125-a72cb1d39631', NULL, 0, 0, NULL, 1, 0, N'harshrajkumar001@gmail.com', N'')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'b56c8968-38d9-4d28-9f6c-4e3a16be3f1d', N'manish@vidly-asp.com', 0, N'AMs2TF9u1WWk2jDOZj6mkDeVU3d+rr/yvKMw4b4GMMiQ2islwFbws1T25yKMfWs8rQ==', N'69d1d3ee-9207-4ec7-816c-e0c60cd99d60', NULL, 0, 0, NULL, 1, 0, N'manish@vidly-asp.com', N'123456')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'f6d6b20c-70b8-47ca-8965-e123be0b7833', N'harsh@vidly-asp.com', 0, N'AC/S2PPtmuOE62sfxEr3iH+ty0jO6EY/GOpzmlfv0gBoSvtPAGlrVw3kkNcLar5g+g==', N'9e9af84d-cbdd-4a8f-9888-1c9ae5aed1de', NULL, 0, 0, NULL, 1, 0, N'harsh@vidly-asp.com', N'')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eee22248-602c-4c78-820e-822fd4a54711', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f6d6b20c-70b8-47ca-8965-e123be0b7833', N'eee22248-602c-4c78-820e-822fd4a54711')
        ");
        }

        public override void Down()
        {
        }
    }
}
