using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simulacrum.API.Database.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.CreateTable(
			name: "AspNetRoles",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetRoles", x => x.Id);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetUsers",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
				PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
				SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
				TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
				LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
				LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
				AccessFailedCount = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetUsers", x => x.Id);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetRoleClaims",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				RoleId = table.Column<int>(type: "int", nullable: false),
				ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
					column: x => x.RoleId,
					principalTable: "AspNetRoles",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetUserClaims",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserId = table.Column<int>(type: "int", nullable: false),
				ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_AspNetUserClaims_AspNetUsers_UserId",
					column: x => x.UserId,
					principalTable: "AspNetUsers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetUserLogins",
			columns: table => new
			{
				LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
				ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
				ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
				UserId = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
				_ = table.ForeignKey(
					name: "FK_AspNetUserLogins_AspNetUsers_UserId",
					column: x => x.UserId,
					principalTable: "AspNetUsers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetUserRoles",
			columns: table => new
			{
				UserId = table.Column<int>(type: "int", nullable: false),
				RoleId = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
				_ = table.ForeignKey(
					name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
					column: x => x.RoleId,
					principalTable: "AspNetRoles",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				_ = table.ForeignKey(
					name: "FK_AspNetUserRoles_AspNetUsers_UserId",
					column: x => x.UserId,
					principalTable: "AspNetUsers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "AspNetUserTokens",
			columns: table => new
			{
				UserId = table.Column<int>(type: "int", nullable: false),
				LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
				Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
				Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
				_ = table.ForeignKey(
					name: "FK_AspNetUserTokens_AspNetUsers_UserId",
					column: x => x.UserId,
					principalTable: "AspNetUsers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "Characters",
			columns: table => new
			{
				CharacterId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserId = table.Column<int>(type: "int", nullable: false),
				CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ExperiencePoints = table.Column<int>(type: "int", nullable: true),
				Strength = table.Column<int>(type: "int", nullable: true),
				Dexterity = table.Column<int>(type: "int", nullable: true),
				Constitution = table.Column<int>(type: "int", nullable: true),
				Intelligence = table.Column<int>(type: "int", nullable: true),
				Wisdom = table.Column<int>(type: "int", nullable: true),
				Charisma = table.Column<int>(type: "int", nullable: true),
				ProficiencyBonus = table.Column<int>(type: "int", nullable: true),
				JackOfAllTrades = table.Column<bool>(type: "bit", nullable: false),
				ArmorClass = table.Column<int>(type: "int", nullable: true),
				Initiative = table.Column<int>(type: "int", nullable: true),
				Speed = table.Column<int>(type: "int", nullable: true),
				HitPointMaximum = table.Column<int>(type: "int", nullable: true),
				CurrentHitPoints = table.Column<int>(type: "int", nullable: true),
				TemporaryHitPoints = table.Column<int>(type: "int", nullable: true),
				HitDice = table.Column<string>(type: "nvarchar(max)", nullable: true),
				HitDiceTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PersonalityTraits = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Ideals = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Bonds = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Flaws = table.Column<string>(type: "nvarchar(max)", nullable: true),
				OtherProficienciesAndLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
				AttacksAndSpellcasting = table.Column<string>(type: "nvarchar(max)", nullable: true),
				CopperPieces = table.Column<int>(type: "int", nullable: true),
				SilverPieces = table.Column<int>(type: "int", nullable: true),
				ElectrumPieces = table.Column<int>(type: "int", nullable: true),
				GoldPieces = table.Column<int>(type: "int", nullable: true),
				PlatinumPieces = table.Column<int>(type: "int", nullable: true),
				Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
				FeaturesAndTraits = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Acrobatics = table.Column<string>(type: "nvarchar(max)", nullable: false),
				AnimalHandling = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Arcana = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Athletics = table.Column<string>(type: "nvarchar(max)", nullable: false),
				CharismaSavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Classes = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ConstitutionSavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
				DeathSaves = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Deception = table.Column<string>(type: "nvarchar(max)", nullable: false),
				DexteritySavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
				History = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Insight = table.Column<string>(type: "nvarchar(max)", nullable: false),
				IntelligenceSavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Intimidation = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Investigation = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Medicine = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Nature = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Perception = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Performance = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Persuasion = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
				SleightOfHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Stealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
				StrengthSavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Survival = table.Column<string>(type: "nvarchar(max)", nullable: false),
				WisdomSavingThrow = table.Column<string>(type: "nvarchar(max)", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Characters", x => x.CharacterId);
				_ = table.ForeignKey(
					name: "FK_Characters_AspNetUsers_UserId",
					column: x => x.UserId,
					principalTable: "AspNetUsers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateIndex(
			name: "IX_AspNetRoleClaims_RoleId",
			table: "AspNetRoleClaims",
			column: "RoleId");

		_ = migrationBuilder.CreateIndex(
			name: "RoleNameIndex",
			table: "AspNetRoles",
			column: "NormalizedName",
			unique: true,
			filter: "[NormalizedName] IS NOT NULL");

		_ = migrationBuilder.CreateIndex(
			name: "IX_AspNetUserClaims_UserId",
			table: "AspNetUserClaims",
			column: "UserId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_AspNetUserLogins_UserId",
			table: "AspNetUserLogins",
			column: "UserId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_AspNetUserRoles_RoleId",
			table: "AspNetUserRoles",
			column: "RoleId");

		_ = migrationBuilder.CreateIndex(
			name: "EmailIndex",
			table: "AspNetUsers",
			column: "NormalizedEmail");

		_ = migrationBuilder.CreateIndex(
			name: "UserNameIndex",
			table: "AspNetUsers",
			column: "NormalizedUserName",
			unique: true,
			filter: "[NormalizedUserName] IS NOT NULL");

		_ = migrationBuilder.CreateIndex(
			name: "IX_Characters_UserId",
			table: "Characters",
			column: "UserId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "AspNetRoleClaims");

		_ = migrationBuilder.DropTable(
			name: "AspNetUserClaims");

		_ = migrationBuilder.DropTable(
			name: "AspNetUserLogins");

		_ = migrationBuilder.DropTable(
			name: "AspNetUserRoles");

		_ = migrationBuilder.DropTable(
			name: "AspNetUserTokens");

		_ = migrationBuilder.DropTable(
			name: "Characters");

		_ = migrationBuilder.DropTable(
			name: "AspNetRoles");

		_ = migrationBuilder.DropTable(
			name: "AspNetUsers");
	}
}
