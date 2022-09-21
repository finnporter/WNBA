using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.DataModels;

public class PlayerStats : EntityBaseClass
{
    public Guid TeamPlayerSeasonId { get; set; }
    public bool IsTotal { get; set; }
    public int? GamesPlayed { get; set; }
    public int? GamesStarted { get; set; }
    public int Minutes { get; set; }
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempts { get; set; }
    public int FieldGoalsPercent { get; set; }
    public int TwoPointsMade { get; set; }
    public int TwoPointsAttempts { get; set; }
    public int TwoPointsPercent { get; set; }
    public int ThreePointsMade { get; set; }
    public int ThreePointsAttempts { get; set; }
    public int ThreePointsPercent { get; set; }
    public int BlockedAttempts { get; set; }
    public int FreeThrowsMade { get; set; }
    public int FreeThrowsAttempts { get; set; }
    public int FreeTrhowsPercent { get; set; }
    public int? OffensiveRebounds { get; set; }
    public int? OffRebounds { get; set; }
    public int? DefensiveRebounds { get; set; }
    public int? DefRebounds { get; set; }
    public int Rebounds { get; set; }
    public int Assists { get; set; }
    public int Turnovers { get; set; }
    public float AssistsTurnoverRatio { get; set; }
    public int Steals { get; set; }
    public int Blocks { get; set; }
    public int PersonalFouls { get; set; }
    public int TechnicalFouls { get; set; }
    public int Points { get; set; }
    public int FlagrantFouls { get; set; }
    public int Ejections { get; set; }
    public int Foulouts { get; set; }
    public float TrueShootingAttempts { get; set; }
    public float TrueShootingPercent { get; set; }
    public int Efficiency { get; set; }
    public int PointsOffTurnovers { get; set; }
    public int PointsInPaint { get; set; }
    public double PointsInPaintMade { get; set; }
    public double PointsInPaintAttempts { get; set; }
    public double PointsInPaintPercent { get; set; }
    public double EffeciveFGPercent { get; set; }
    public int DoubleDoubles { get; set; }
    public int TripleDoubles { get; set; }
    public int FoulsDrawn { get; set; }
    public int OffensiveFouls { get; set; }
    public int FastBreakPoints { get; set; }
    public int FastBreakAttempts { get; set; }
    public int FastBreakMade { get; set; }
    public int FastBreakPercent { get; set; }
    public int CoachEjections { get; set; }
    public int SecondChancePercent { get; set; }
    public int SecondChancePoints { get; set; }
    public int SecondChanceAttributes { get; set; }
    public int SecondChanceMade { get; set; }
    public int Minus { get; set; }
    public int Plus { get; set; }
    public int CoachTechsFouls { get; set; }

    public virtual TeamPlayerSeason TeamPlayerSeason { get; set; }

    public static PlayerStats ToModel(PlayerSeasonStatsDto dto, Guid teamPlayerSeasonId, bool isTotal)
    {
        return new PlayerStats()
        {
            Id = dto.Id,
            TeamPlayerSeasonId = teamPlayerSeasonId,
            IsTotal =isTotal
        };
    }
}
