namespace MovieCustomerWithAuthMVC_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@" 
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f9556b9-cc71-48a8-8ff0-90eba6c21f77', N'guestuser@gmail.com', 0, N'ALkbbpRQFAtPn029iEtPGzIo2IYNtTnVttY72lW5manc4q25K/nh1B0C0Yi9SNCUEA==', N'18552420-71f3-43a4-8da1-a8a3452adbba', NULL, 0, 0, NULL, 1, 0, N'guestuser@gmail.com')

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4667721f-f7a0-4065-9247-9d5fd6e564b2', N'useradmin@gmal.com', 0, N'APnFh4/bcMWJVvThEP4WgfdPVFYebeWW8ZwPGWksKCLOymSd2jOko46KX9v3qZJTaw==', N'a7e4e346-5a7a-4628-8c59-42614ffd6144', NULL, 0, 0, NULL, 1, 0, N'useradmin@gmal.com')

             INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'2ea3e45e-b617-4aeb-a245-ceb7202e518b', N'CanManageMovies')

             INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4667721f-f7a0-4065-9247-9d5fd6e564b2', N'2ea3e45e-b617-4aeb-a245-ceb7202e518b')
            ");
            
        }
        
        public override void Down()
        {
        }
    }
}
