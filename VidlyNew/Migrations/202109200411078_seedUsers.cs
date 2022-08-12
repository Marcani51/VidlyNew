namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3894fa57-d2c2-4d65-b6ef-6de270344c6c', N'denta.marcellus@gmail.com', 0, N'AAv3ATLfi4v/GEOAiejPnToCW6NiGynj5fkrTATXlaWAvdN78ZIGSiVMYJPjINuGfA==', N'b9e8fb7a-e541-40e3-96a4-1b58dbfa3e3b', NULL, 0, 0, NULL, 1, 0, N'denta.marcellus@gmail.com')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'51ab1b47-724c-4ecd-8aef-2b1e8b9c7428', N'guest@vidly.com', 0, N'AP8Wi5z2yz9mWqq3Iiv4/CnVNdV8YQ+l31qjDBBWQOxTy2b2xm8MUbcrkSnIEvcohA==', N'87390a4c-0474-4640-8057-aef3e0d52099', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc9b6666-c892-4e85-9caa-d21e42ef10bc', N'admin@vidly.com', 0, N'APhK1xNpOhAly/WfddqW6/brRU4x/qZCFFAmvgDwYeBfb1R1MNyhZGC+Zeg4heoyLQ==', N'ba7ee50b-b7c7-40cc-9e7a-70365a341f1c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                 INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fa9526b3-b472-44fd-b9a1-5e639596cabe', N'CanManageMovies')
                 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc9b6666-c892-4e85-9caa-d21e42ef10bc', N'fa9526b3-b472-44fd-b9a1-5e639596cabe')
                ");

        }
        
        public override void Down()
        {
        }
    }
}
