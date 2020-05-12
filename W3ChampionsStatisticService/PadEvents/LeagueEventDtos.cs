﻿using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using W3ChampionsStatisticService.CommonValueObjects;
using W3ChampionsStatisticService.PlayerProfiles;

namespace W3ChampionsStatisticService.PadEvents
{
    [BsonIgnoreExtraElements]
    public class LeagueConstellationChangedEvent
    {
        public int id { get; set; }
        public int season { get; set; }
        public GateWay gateway { get; set; }
        public GameMode gameMode { get; set; }
        public LeagueRaw[] leagues { get; set; }
    }

    [BsonIgnoreExtraElements]
    [BsonNoId]
    public class LeagueRaw
    {
        public int division;

        [BsonElement("id")]
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int maxParticipantCount { get; set; }
    }

    [BsonIgnoreExtraElements]
    [BsonNoId]
    public class RankingChangedEvent
    {
        [BsonElement("_id")]
        public int id { get; set; }
        public int season { get; set; }
        public GateWay gateway { get; set; }
        public int league { get; set; }
        public GameMode gameMode { get; set; }
        public RankRaw[] ranks { get; set; }
        public bool wasSyncedJustNow { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class RankRaw
    {
        public List<string> battleTags { get; set; }
        public double rp { get; set; }
    }
}