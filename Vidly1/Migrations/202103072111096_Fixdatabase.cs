namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixdatabase : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c5605bb-91be-4176-925a-377169e2bead', N'admin@vidly.com', 0, N'AM7awwxAy8bZUE8HbaQ3C4J+aHEf91+l88p1bbCje4dAzhlnRI3buneOGGaY7u5PVw==', N'a06468cf-3bcf-4f37-8b97-a3f31edfd97b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c390991e-fc8c-440b-a01f-1c74a7ba67fe', N'william27gigi@gmail.com', 0, N'AJ1b5o2Ju6VEvccyFeLtYlnG/1SV3WSWAN2Ma8Lho0omPPUgRpRsm8pm5/w6LrDvrw==', N'ee0ae991-297a-4b5d-8170-789c1e18dfc3', NULL, 0, 0, NULL, 1, 0, N'william27gigi@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cd74085e-f1a8-4467-aded-6479c51ac747', N'guest@vidly.com', 0, N'AHtaHlHPI4paumdNYQPRStIRoD15MZ/RcoieSfVD1mgqm1TKAebEgERmUGVbNiuTCA==', N'295c21c5-ddf8-47cd-a3a3-9ba0c263fa71', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f693ce58-27d7-490b-9dfa-98234f7951e5', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4c5605bb-91be-4176-925a-377169e2bead', N'f693ce58-27d7-490b-9dfa-98234f7951e5')
             ");
        }
        
        public override void Down()
        {
        }
    }
}
