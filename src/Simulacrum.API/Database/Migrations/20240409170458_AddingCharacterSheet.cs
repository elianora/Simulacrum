using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simulacrum.API.Database.Migrations;

/// <inheritdoc />
public partial class AddingCharacterSheet : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.AddColumn<int>(
			name: "ArmorClass",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "AttacksAndSpellcasting",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "Bonds",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "CopperPieces",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "CurrentHitPoints",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "DeathSaves",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: false,
			defaultValue: "");

		_ = migrationBuilder.AddColumn<int>(
			name: "ElectrumPieces",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "Equipment",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "FeaturesAndTraits",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "Flaws",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "GoldPieces",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "HitDice",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "HitDiceTotal",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "HitPointMaximum",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "Ideals",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "Initiative",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "OtherProficienciesAndLanguages",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<string>(
			name: "PersonalityTraits",
			table: "Characters",
			type: "nvarchar(max)",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "PlatinumPieces",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "SilverPieces",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "Speed",
			table: "Characters",
			type: "int",
			nullable: true);

		_ = migrationBuilder.AddColumn<int>(
			name: "TemporaryHitPoints",
			table: "Characters",
			type: "int",
			nullable: true);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropColumn(
			name: "ArmorClass",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "AttacksAndSpellcasting",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Bonds",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "CopperPieces",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "CurrentHitPoints",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "DeathSaves",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "ElectrumPieces",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Equipment",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "FeaturesAndTraits",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Flaws",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "GoldPieces",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "HitDice",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "HitDiceTotal",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "HitPointMaximum",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Ideals",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Initiative",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "OtherProficienciesAndLanguages",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "PersonalityTraits",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "PlatinumPieces",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "SilverPieces",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "Speed",
			table: "Characters");

		_ = migrationBuilder.DropColumn(
			name: "TemporaryHitPoints",
			table: "Characters");
	}
}
