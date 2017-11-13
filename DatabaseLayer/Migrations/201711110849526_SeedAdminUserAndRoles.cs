namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUserAndRoles : DbMigration
    {
        public override void Up()
        {
            //Add Admin user and "Administrator" Role
            Sql(@"
            INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'37932bea-54cf-43cf-b196-ac66eff38327', N'admin@admin.com', 0, N'AJJ6xfpiCg+Aj/W4A6EjpkPJhtFyqoHVKWqW3Fjy1Jw5SfKUlzworUmIExIHVpXvXw==', N'c4145a62-7a85-4f6a-9eb0-77daf6d0c699', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id]) VALUES (N'37932bea-54cf-43cf-b196-ac66eff38327')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b4a8cf47-2620-4e03-b178-de15b491b1d6', N'Administrator')
            INSERT INTO [dbo].[AspNetUserRoles] ([RoleId], [UserId], [IdentityUser_Id]) VALUES (N'b4a8cf47-2620-4e03-b178-de15b491b1d6', N'37932bea-54cf-43cf-b196-ac66eff38327', NULL)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
