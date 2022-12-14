namespace Supercell.Magic.Servers.Battle.Logic.Mode.Listener
{
    using Supercell.Magic.Logic.Avatar;
    using Supercell.Magic.Logic.Avatar.Change;
    using Supercell.Magic.Logic.Data;
    
    using Supercell.Magic.Servers.Core.Network.Message.Session.Change;

    using Supercell.Magic.Servers.Battle.Logic.Mode;

    using Supercell.Magic.Titan.Math;
    using Supercell.Magic.Titan.Util;

    public class AvatarChangeListener : LogicAvatarChangeListener
    {
        private readonly GameMode m_gameMode;
        private readonly LogicClientAvatar m_playerAvatar;
        private readonly LogicArrayList<AvatarChange> m_avatarChanges;
        
        public AvatarChangeListener(GameMode gameMode, LogicClientAvatar playerAvatar)
        {
            this.m_gameMode = gameMode;
            this.m_playerAvatar = playerAvatar;
            this.m_avatarChanges = new LogicArrayList<AvatarChange>(16);
        }

        public LogicArrayList<AvatarChange> RemoveAvatarChanges()
        {
            LogicArrayList<AvatarChange> arrayList = new LogicArrayList<AvatarChange>();
            arrayList.AddAll(this.m_avatarChanges);
            this.m_avatarChanges.Clear();
            return arrayList;
        }

        public override void FreeDiamondsAdded(int count, int mode)
        {
            this.m_avatarChanges.Add(new DiamondAvatarChange
            {
                Count = count
            });
        }

        public override void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
        {
            this.m_avatarChanges.Add(new DiamondAvatarChange
            {
                Count = -count
            });
        }

        public override void CommodityCountChanged(int commodityType, LogicData data, int count)
        {
            this.m_avatarChanges.Add(new CommodityCountAvatarChange
            {
                Type = commodityType,
                Data = data,
                Count = count
            });
        }

        public override void WarPreferenceChanged(int preference)
        {
            this.m_avatarChanges.Add(new WarPreferenceAvatarChange
            {
                Preference = preference
            });
        }

        public override void ExpPointsGained(int count)
        {
            this.m_avatarChanges.Add(new ExpPointsAvatarChange
            {
                Points = count
            });
        }

        public override void ExpLevelGained(int count)
        {
            this.m_avatarChanges.Add(new ExpLevelAvatarChange
            {
                Points = count
            });
        }

        public override void AllianceJoined(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, LogicAvatarAllianceRole allianceRole)
        {
            this.m_avatarChanges.Add(new AllianceJoinedAvatarChange
            {
                AllianceId = allianceId,
                AllianceName = allianceName,
                AllianceBadgeId = allianceBadgeId,
                AllianceExpLevel = allianceExpLevel,
                AllianceRole = allianceRole
            });
        }

        public override void AllianceLeft()
        {
            this.m_avatarChanges.Add(new AllianceLeftAvatarChange());
        }

        public override void AllianceLevelChanged(int expLevel)
        {
            this.m_avatarChanges.Add(new AllianceLevelAvatarChange
            {
                Level = expLevel
            });
        }

        public override void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
        {
            this.m_avatarChanges.Add(new AllianceUnitAddedAvatarChange
            {
                Data = data,
                UpgradeLevel = upgLevel
            });
        }

        public override void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
        {
            this.m_avatarChanges.Add(new AllianceUnitRemovedAvatarChange
            {
                Data = data,
                UpgradeLevel = upgLevel
            });
        }

        public override void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
        {
            this.m_avatarChanges.Add(new AllianceUnitCountAvatarChange
            {
                Data = data,
                UpgradeLevel = upgLevel,
                Count = count
            });
        }

        public override void SetAllianceCastleLevel(int count)
        {
           this.m_avatarChanges.Add(new AllianceCastleLevelAvatarChange
           {
               Level = count
           });
        }

        public override void SetTownHallLevel(int count)
        {
            this.m_avatarChanges.Add(new TownHallLevelAvatarChange
            {
                Level = count
            });
        }

        public override void SetVillage2TownHallLevel(int count)
        {
            this.m_avatarChanges.Add(new TownHallV2LevelAvatarChange
            {
                Level = count
            });
        }

        public override void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
        {
            this.m_avatarChanges.Add(new LegendSeasonScoreAvatarChange
            {
                Entry = villageType == 0
                    ? this.m_playerAvatar.GetLegendSeasonEntry()
                    : this.m_playerAvatar.GetLegendSeasonEntryVillage2()
            });
        }

        public override void ScoreChanged(LogicLong allianceId, int scoreGain, int minScoreGain, bool attacker, LogicLeagueData leagueData, LogicLeagueData prevLeagueData, int destructionPercentage)
        {
            this.m_avatarChanges.Add(new ScoreAvatarChange
            {
                Attacker = attacker,
                LeagueData = leagueData,
                PrevLeagueData = prevLeagueData,
                ScoreGain = scoreGain
            });
        }
        
        public override void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
        {
            this.m_avatarChanges.Add(new DuelScoreAvatarChange
            {
                Attacker = attacker,
                DuelScoreGain = duelScoreGain,
                ResultType = resultType
            });
        }

        public override void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
        {
            this.m_avatarChanges.Add(new LeagueAvatarChange
            {
                LeagueInstanceId = leagueInstanceId,
                LeagueType = leagueType
            });
        }

        public override void AttackShieldReduceCounterChanged(int count)
        {
            this.m_avatarChanges.Add(new AttackShieldReduceCounterAvatarChange
            {
                Count = count
            });
        }

        public override void DefenseVillageGuardCounterChanged(int count)
        {
            this.m_avatarChanges.Add(new DefenseVillageGuardCounterAvatarChange
            {
                Count = count
            });
        }

        public override void REDPackageStateChanged(int value)
        {
            this.m_avatarChanges.Add(new REDPackageStateAvatarChange
            {
                State = value
            });
        }

        public void NameChanged(string name, int nameChangeState)
        {
            this.m_avatarChanges.Add(new NameAvatarChange
            {
                Name = name,
                NameChangeState = nameChangeState
            });
        }
    }
}