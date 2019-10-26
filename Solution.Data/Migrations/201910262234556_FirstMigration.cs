namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        Candidat_Id = c.Int(nullable: false),
                        Job_Offer_Id = c.Int(nullable: false),
                        Application_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Application_Description = c.String(),
                        Application_Status = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        Representator_Id = c.Int(nullable: false),
                        Availability_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Quiz_Result_Status = c.String(),
                    })
                .PrimaryKey(t => t.AvailabilityId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        username = c.String(),
                        password = c.String(),
                        status = c.Int(nullable: false),
                        picture = c.String(nullable: false),
                        role = c.Int(nullable: false),
                        CandidateId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Company_CompanyId = c.Int(),
                        Payment_PaymentId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.Payments", t => t.Payment_PaymentId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.Payment_PaymentId);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        CertificationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CertificationId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(),
                        Company_Number = c.Int(nullable: false),
                        Company_Email = c.String(),
                        Company_Description = c.String(),
                        Company_Website = c.String(),
                        Company_Logo = c.String(),
                        NumberOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbrLikes = c.Int(nullable: false),
                        PostId = c.Int(),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.PostId)
                .Index(t => t.Company_CompanyId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        UrlImage = c.String(),
                        UrlVideo = c.String(),
                        PostDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbrLikes = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);
            
            CreateTable(
                "dbo.Diplomata",
                c => new
                    {
                        DiplomaId = c.Int(nullable: false, identity: true),
                        DiplomaName = c.String(),
                        DiplomaSpeciality = c.String(),
                        ObtainingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DiplomaUniversity = c.String(),
                    })
                .PrimaryKey(t => t.DiplomaId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        Nbr = c.Int(nullable: false),
                        field = c.String(),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        languageName = c.String(),
                        Nbr = c.Int(nullable: false),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        OffreId = c.Int(nullable: false, identity: true),
                        DatePublished = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiredDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        description = c.String(),
                        Validity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OffreId);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        Object_claim = c.String(),
                        Content_claim = c.String(),
                        Type_claim = c.String(),
                        Date_claim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TreatmentDate_claim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        State_claim = c.String(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        Compnay_Id = c.Int(nullable: false),
                        Candidat_Id = c.Int(nullable: false),
                        Interview_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Interview_Location = c.String(),
                        Interview_Type = c.String(),
                    })
                .PrimaryKey(t => t.InterviewId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Destination = c.Int(nullable: false),
                        DateSend = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        TypeNotification = c.String(),
                        Content = c.String(),
                        DateNotification = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Amount_payment = c.Double(nullable: false),
                        Payment_date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Quiz_Id = c.Int(nullable: false),
                        Question_Value = c.Int(nullable: false),
                        Question_Description = c.String(),
                        Question_1stSuggestion = c.String(),
                        Question_2ndSuggestion = c.String(),
                        Question_3rdSuggestion = c.String(),
                        Question_Correct_Answer = c.Int(nullable: false),
                        Quiz_QuizId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizs", t => t.Quiz_QuizId)
                .Index(t => t.Quiz_QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        Compnay_Id = c.Int(nullable: false),
                        Candidat_Id = c.Int(nullable: false),
                        Max_Score = c.Int(nullable: false),
                        Success_Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        ReactionId = c.Int(nullable: false, identity: true),
                        TypeReaction = c.String(),
                        PublicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReactionId);
            
            CreateTable(
                "dbo.CertificationOfCandidate",
                c => new
                    {
                        Certification = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Certification, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Certification, cascadeDelete: true)
                .ForeignKey("dbo.Certifications", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Certification)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Company = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Company, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Company)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.DiplomaOfCandidate",
                c => new
                    {
                        Diploma = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Diploma, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Diploma, cascadeDelete: true)
                .ForeignKey("dbo.Diplomata", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Diploma)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.ExperienceOfCandidate",
                c => new
                    {
                        Experience = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Experience, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Experience, cascadeDelete: true)
                .ForeignKey("dbo.Experiences", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Experience)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.Knowledge",
                c => new
                    {
                        Language = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Language, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Language)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.OffresOfCandidate",
                c => new
                    {
                        Offres = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offres, t.Candidate })
                .ForeignKey("dbo.Users", t => t.Offres, cascadeDelete: true)
                .ForeignKey("dbo.Offres", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Offres)
                .Index(t => t.Candidate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Quiz_QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Payments", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Claims", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offres");
            DropForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Users");
            DropForeignKey("dbo.Knowledge", "Candidate", "dbo.Languages");
            DropForeignKey("dbo.Knowledge", "Language", "dbo.Users");
            DropForeignKey("dbo.ExperienceOfCandidate", "Candidate", "dbo.Experiences");
            DropForeignKey("dbo.ExperienceOfCandidate", "Experience", "dbo.Users");
            DropForeignKey("dbo.DiplomaOfCandidate", "Candidate", "dbo.Diplomata");
            DropForeignKey("dbo.DiplomaOfCandidate", "Diploma", "dbo.Users");
            DropForeignKey("dbo.Subscribers", "Candidate", "dbo.Companies");
            DropForeignKey("dbo.Subscribers", "Company", "dbo.Users");
            DropForeignKey("dbo.Users", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Posts", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Comments", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.CertificationOfCandidate", "Candidate", "dbo.Certifications");
            DropForeignKey("dbo.CertificationOfCandidate", "Certification", "dbo.Users");
            DropIndex("dbo.OffresOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.OffresOfCandidate", new[] { "Offres" });
            DropIndex("dbo.Knowledge", new[] { "Candidate" });
            DropIndex("dbo.Knowledge", new[] { "Language" });
            DropIndex("dbo.ExperienceOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.ExperienceOfCandidate", new[] { "Experience" });
            DropIndex("dbo.DiplomaOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.DiplomaOfCandidate", new[] { "Diploma" });
            DropIndex("dbo.Subscribers", new[] { "Candidate" });
            DropIndex("dbo.Subscribers", new[] { "Company" });
            DropIndex("dbo.CertificationOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.CertificationOfCandidate", new[] { "Certification" });
            DropIndex("dbo.Questions", new[] { "Quiz_QuizId" });
            DropIndex("dbo.Payments", new[] { "UserId_UserId" });
            DropIndex("dbo.Claims", new[] { "UserId_UserId" });
            DropIndex("dbo.Posts", new[] { "Company_CompanyId" });
            DropIndex("dbo.Comments", new[] { "Company_CompanyId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Users", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Users", new[] { "Company_CompanyId" });
            DropTable("dbo.OffresOfCandidate");
            DropTable("dbo.Knowledge");
            DropTable("dbo.ExperienceOfCandidate");
            DropTable("dbo.DiplomaOfCandidate");
            DropTable("dbo.Subscribers");
            DropTable("dbo.CertificationOfCandidate");
            DropTable("dbo.Reactions");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Payments");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.Interviews");
            DropTable("dbo.Claims");
            DropTable("dbo.Offres");
            DropTable("dbo.Languages");
            DropTable("dbo.Experiences");
            DropTable("dbo.Diplomata");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Companies");
            DropTable("dbo.Certifications");
            DropTable("dbo.Users");
            DropTable("dbo.Availabilities");
            DropTable("dbo.Applications");
        }
    }
}
