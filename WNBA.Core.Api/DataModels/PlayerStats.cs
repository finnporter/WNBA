using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.DataModels;

public class PlayerStats : EntityBaseClass
{
    public Guid TeamPlayerSeasonId { get; set; }
    public bool IsTotal { get; set; }
    public float? GamesPlayed { get; set; }
    public float? GamesStarted { get; set; }
    public float Minutes { get; set; }
    public float FieldGoalsMade { get; set; }
    public float FieldGoalsAttempts { get; set; }
    public float FieldGoalsPercent { get; set; }
    public float TwoPointsMade { get; set; }
    public float TwoPointsAttempts { get; set; }
    public float TwoPointsPercent { get; set; }
    public float ThreePointsMade { get; set; }
    public float ThreePointsAttempts { get; set; }
    public float ThreePointsPercent { get; set; }
    public float BlockedAttempts { get; set; }
    public float FreeThrowsMade { get; set; }
    public float FreeThrowsAttempts { get; set; }
    public float FreeTrhowsPercent { get; set; }
    public float? OffensiveRebounds { get; set; } //Sportsradar uses different naming for average stats and total stats.
    public float? OffRebounds { get; set; }
    public float? DefensiveRebounds { get; set; } //Sportsradar uses different naming for average stats and total stats.
    public float? DefRebounds { get; set; }
    public float Rebounds { get; set; }
    public float Assists { get; set; }
    public float Turnovers { get; set; }
    public float AssistsTurnoverRatio { get; set; }
    public float Steals { get; set; }
    public float Blocks { get; set; }
    public float PersonalFouls { get; set; }
    public float TechnicalFouls { get; set; }
    public float Points { get; set; }
    public float FlagrantFouls { get; set; }
    public float Ejections { get; set; }
    public float Foulouts { get; set; }
    public float TrueShootingAttempts { get; set; }
    public float TrueShootingPercent { get; set; }
    public float Efficiency { get; set; }
    public float PointsOffTurnovers { get; set; }
    public float PointsInPaint { get; set; }
    public double PointsInPaintMade { get; set; }
    public double PointsInPaintAttempts { get; set; }
    public double PointsInPaintPercent { get; set; }
    public double EffeciveFGPercent { get; set; }
    public float DoubleDoubles { get; set; }
    public float TripleDoubles { get; set; }
    public float FoulsDrawn { get; set; }
    public float OffensiveFouls { get; set; }
    public float FastBreakPoints { get; set; }
    public float FastBreakAttempts { get; set; }
    public float FastBreakMade { get; set; }
    public float FastBreakPercent { get; set; }
    public float CoachEjections { get; set; }
    public float SecondChancePercent { get; set; }
    public float SecondChancePoints { get; set; }
    public float SecondChanceAttempts { get; set; }
    public float SecondChanceMade { get; set; }
    public float Minus { get; set; }
    public float Plus { get; set; }
    public float CoachTechsFouls { get; set; }

    public virtual TeamPlayerSeason TeamPlayerSeason { get; set; }

    public static PlayerStats ToModel(PlayerSeasonStatsDto dto, Guid teamPlayerSeasonId, bool isTotal)
    {
        return new PlayerStats()
        {
            Id = Guid.NewGuid(), //this will most likely not be used as a PK
            TeamPlayerSeasonId = teamPlayerSeasonId, //should be used as a PK
            IsTotal =isTotal, //as opposed to average stats
            GamesPlayed = dto.GamesPlayed,
            GamesStarted = dto.GamesStarted,
            Minutes = dto.Minutes,
            FieldGoalsAttempts = dto.FieldGoalsAttempts,
            FieldGoalsMade = dto.FieldGoalsMade,
            FieldGoalsPercent = dto.FieldGoalsPercent,
            ThreePointsAttempts = dto.ThreePointsAttempts,
            ThreePointsMade = dto.ThreePointsMade,
            ThreePointsPercent = dto.ThreePointsPercent,
            TwoPointsAttempts = dto.TwoPointsAttempts,
            TwoPointsMade = dto.TwoPointsMade,
            TwoPointsPercent = dto.TwoPointsPercent,
            BlockedAttempts = dto.BlockedAttempts,  
            FreeThrowsAttempts = dto.FreeThrowsAttempts,
            FreeThrowsMade = dto.FreeThrowsMade,
            FreeTrhowsPercent = dto.FreeTrhowsPercent,
            OffensiveRebounds = dto.OffensiveRebounds,
            OffRebounds = dto.OffRebounds,
            DefensiveRebounds = dto.DefensiveRebounds,
            DefRebounds = dto.DefRebounds,
            Rebounds = dto.Rebounds,
            Assists = dto.Assists,
            Turnovers = dto.Turnovers,
            AssistsTurnoverRatio = dto.AssistsTurnoverRatio,
            Steals = dto.Steals,
            Blocks = dto.Blocks,
            PersonalFouls = dto.PersonalFouls,
            TechnicalFouls = dto.TechnicalFouls,
            Points = dto.Points,
            FlagrantFouls = dto.FlagrantFouls,
            Ejections = dto.Ejections,
            Foulouts = dto.Foulouts,
            TrueShootingAttempts = dto.TrueShootingAttempts,
            TrueShootingPercent = dto.TrueShootingPercent,
            Efficiency = dto.Efficiency,
            PointsOffTurnovers = dto.PointsOffTurnovers,
            PointsInPaint = dto.PointsInPaint,
            PointsInPaintAttempts = dto.PointsInPaintAttempts,
            PointsInPaintMade = dto.PointsInPaintMade,
            PointsInPaintPercent = dto.PointsInPaintPercent,
            EffeciveFGPercent = dto.EffeciveFGPercent,
            DoubleDoubles = dto.DoubleDoubles,
            TripleDoubles = dto.TripleDoubles,
            FoulsDrawn = dto.FoulsDrawn,
            OffensiveFouls = dto.OffensiveFouls,
            FastBreakAttempts = dto.FastBreakAttempts,
            FastBreakMade = dto.FastBreakMade,
            FastBreakPercent = dto.FastBreakPercent,
            FastBreakPoints = dto.FastBreakPoints,
            CoachEjections = dto.CoachEjections,
            SecondChanceAttempts = dto.SecondChanceAttempts,
            SecondChanceMade = dto.SecondChanceMade,
            SecondChancePercent = dto.SecondChancePercent,
            SecondChancePoints = dto.SecondChancePoints,
            Minus = dto.Minus,
            Plus = dto.Plus,
            CoachTechsFouls = dto.CoachTechsFouls
        };
    }
}
