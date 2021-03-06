namespace Clone_MovieMVC_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_attributes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cast",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmdbUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Gender = c.String(),
                        TmdbUrl = c.String(),
                        ProfilePath = c.String(nullable: false, maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Overview = c.String(),
                        Tagline = c.String(maxLength: 512),
                        Budget = c.Decimal(precision: 18, scale: 2),
                        Revenue = c.Decimal(precision: 18, scale: 2),
                        ImdbUrl = c.String(maxLength: 2084),
                        TmdbUrl = c.String(maxLength: 2084),
                        PosterUrl = c.String(maxLength: 2084),
                        BackdropUrl = c.String(maxLength: 2084),
                        OriginalLanguage = c.String(maxLength: 64),
                        ReleaseDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RunTime = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        CreatedBy = c.String(),
                        Crew_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crew", t => t.Crew_Id)
                .Index(t => t.Crew_Id);
            
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        Email = c.String(maxLength: 256),
                        HashedPassword = c.String(maxLength: 1024),
                        Salt = c.String(maxLength: 1024),
                        PhoneNumber = c.String(maxLength: 16),
                        TwoFactorEnabled = c.Boolean(),
                        LockoutEndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        LastLoginDateTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsLocked = c.Boolean(),
                        AccessFailedCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCast",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CastId = c.Int(nullable: false),
                        Character = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CastId, t.Character })
                .ForeignKey("dbo.Cast", t => t.CastId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CastId);
            
            CreateTable(
                "dbo.MovieCrew",
                c => new
                    {
                        MovieID = c.Int(nullable: false),
                        CrewID = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 128),
                        Job = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieID, t.CrewID, t.Department, t.Job })
                .ForeignKey("dbo.Crew", t => t.CrewID, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.CrewID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseNumber = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.MovieId })
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew");
            DropForeignKey("dbo.Review", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Purchase", "UserId", "dbo.User");
            DropForeignKey("dbo.Purchase", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "CrewID", "dbo.Crew");
            DropForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCast", "CastId", "dbo.Cast");
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Favorite", "MovieId", "dbo.Movie");
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "UserId" });
            DropIndex("dbo.MovieCrew", new[] { "CrewID" });
            DropIndex("dbo.MovieCrew", new[] { "MovieID" });
            DropIndex("dbo.MovieCast", new[] { "CastId" });
            DropIndex("dbo.MovieCast", new[] { "MovieId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "MovieId" });
            DropIndex("dbo.Movie", new[] { "Crew_Id" });
            DropTable("dbo.MovieGenre");
            DropTable("dbo.UserRole");
            DropTable("dbo.Review");
            DropTable("dbo.Purchase");
            DropTable("dbo.MovieCrew");
            DropTable("dbo.MovieCast");
            DropTable("dbo.Genre");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Favorite");
            DropTable("dbo.Movie");
            DropTable("dbo.Crew");
            DropTable("dbo.Cast");
        }
    }
}
