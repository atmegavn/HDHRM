using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD.HRM.Migrations
{
    public partial class Profiles_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hrm");

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decsiption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactProvider",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractCategory",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DecisionType",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobFamily",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFamily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobFamily_JobFamily_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Hrm",
                        principalTable: "JobFamily",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "National",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_National", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Organization_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Hrm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfileType",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PeriodUnit = table.Column<int>(type: "int", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyAAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyBAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyBBirdDay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_ContractCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Hrm",
                        principalTable: "ContractCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_JobFamily_JobFamilyId",
                        column: x => x.JobFamilyId,
                        principalSchema: "Hrm",
                        principalTable: "JobFamily",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfOnboard = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganzinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "Hrm",
                        principalTable: "JobTitle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provincial",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincial_National_NationalId",
                        column: x => x.NationalId,
                        principalSchema: "Hrm",
                        principalTable: "National",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBird = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_ProfileType_ProfileTypeId",
                        column: x => x.ProfileTypeId,
                        principalSchema: "Hrm",
                        principalTable: "ProfileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Relative",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelationshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relative_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalSchema: "Hrm",
                        principalTable: "Relationship",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Decision",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExperiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decision_DecisionType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Hrm",
                        principalTable: "DecisionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Decision_Employee_DecisionMakerId",
                        column: x => x.DecisionMakerId,
                        principalSchema: "Hrm",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Decision_Employee_DecisionReceiverId",
                        column: x => x.DecisionReceiverId,
                        principalSchema: "Hrm",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvincialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Provincial_ProvincialId",
                        column: x => x.ProvincialId,
                        principalSchema: "Hrm",
                        principalTable: "Provincial",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Hrm",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "Hrm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Hrm",
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_ContactProvider_ContactProviderId",
                        column: x => x.ContactProviderId,
                        principalSchema: "Hrm",
                        principalTable: "ContactProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "Hrm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Hrm",
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosition_Decision_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "Hrm",
                        principalTable: "Decision",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosition_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Hrm",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosition_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "Hrm",
                        principalTable: "Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosition_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "Hrm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Village",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Village_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Hrm",
                        principalTable: "District",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Street",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Street_Village_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Hrm",
                        principalTable: "Village",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvincialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Hrm",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_National_NationalId",
                        column: x => x.NationalId,
                        principalSchema: "Hrm",
                        principalTable: "National",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Provincial_ProvincialId",
                        column: x => x.ProvincialId,
                        principalSchema: "Hrm",
                        principalTable: "Provincial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Street_StreetId",
                        column: x => x.StreetId,
                        principalSchema: "Hrm",
                        principalTable: "Street",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Village_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Hrm",
                        principalTable: "Village",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Hrm",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "Hrm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Hrm",
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdCard",
                schema: "Hrm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBith = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfExpiry = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaceOfOriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaceOfResidenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonalIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfProvided = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdCard_Location_PlaceOfOriginId",
                        column: x => x.PlaceOfOriginId,
                        principalSchema: "Hrm",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdCard_Location_PlaceOfResidenceId",
                        column: x => x.PlaceOfResidenceId,
                        principalSchema: "Hrm",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdCard_National_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "Hrm",
                        principalTable: "National",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdCard_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Hrm",
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BankId",
                schema: "Hrm",
                table: "Account",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrganizationId",
                schema: "Hrm",
                table: "Account",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ProfileId",
                schema: "Hrm",
                table: "Account",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "Hrm",
                table: "Address",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_OrganizationId",
                schema: "Hrm",
                table: "Address",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProfileId",
                schema: "Hrm",
                table: "Address",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactProviderId",
                schema: "Hrm",
                table: "Contact",
                column: "ContactProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OrganizationId",
                schema: "Hrm",
                table: "Contact",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ProfileId",
                schema: "Hrm",
                table: "Contact",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CategoryId",
                schema: "Hrm",
                table: "Contract",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_DecisionMakerId",
                schema: "Hrm",
                table: "Decision",
                column: "DecisionMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_DecisionReceiverId",
                schema: "Hrm",
                table: "Decision",
                column: "DecisionReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_TypeId",
                schema: "Hrm",
                table: "Decision",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvincialId",
                schema: "Hrm",
                table: "District",
                column: "ProvincialId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTitleId",
                schema: "Hrm",
                table: "Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdCard_NationalityId",
                schema: "Hrm",
                table: "IdCard",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdCard_PlaceOfOriginId",
                schema: "Hrm",
                table: "IdCard",
                column: "PlaceOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_IdCard_PlaceOfResidenceId",
                schema: "Hrm",
                table: "IdCard",
                column: "PlaceOfResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdCard_ProfileId",
                schema: "Hrm",
                table: "IdCard",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobFamilyId",
                schema: "Hrm",
                table: "Job",
                column: "JobFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFamily_ParentId",
                schema: "Hrm",
                table: "JobFamily",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_DecisionId",
                schema: "Hrm",
                table: "JobPosition",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_EmployeeId",
                schema: "Hrm",
                table: "JobPosition",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_JobId",
                schema: "Hrm",
                table: "JobPosition",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_OrganizationId",
                schema: "Hrm",
                table: "JobPosition",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DistrictId",
                schema: "Hrm",
                table: "Location",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_NationalId",
                schema: "Hrm",
                table: "Location",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ProvincialId",
                schema: "Hrm",
                table: "Location",
                column: "ProvincialId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_StreetId",
                schema: "Hrm",
                table: "Location",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_VillageId",
                schema: "Hrm",
                table: "Location",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ParentId",
                schema: "Hrm",
                table: "Organization",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ProfileTypeId",
                schema: "Hrm",
                table: "Profile",
                column: "ProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincial_NationalId",
                schema: "Hrm",
                table: "Provincial",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Relative_RelationshipId",
                schema: "Hrm",
                table: "Relative",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_VillageId",
                schema: "Hrm",
                table: "Street",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Village_DistrictId",
                schema: "Hrm",
                table: "Village",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Contract",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "IdCard",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "JobPosition",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Relative",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "ContactProvider",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "ContractCategory",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Decision",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Relationship",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Street",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "ProfileType",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "DecisionType",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "JobFamily",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Village",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "JobTitle",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "District",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "Provincial",
                schema: "Hrm");

            migrationBuilder.DropTable(
                name: "National",
                schema: "Hrm");
        }
    }
}
