using System;
using System.Collections.Generic;

namespace Scraffold
{
    public partial class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }
        public int? Class { get; set; }
        public int? Race { get; set; }
        public int? Gender { get; set; }
        public int? Level { get; set; }
        public int? AchievementPoints { get; set; }
        public string Thumbnail { get; set; }
        public long? Spec { get; set; }
        public string Guild { get; set; }
        public string GuildRealm { get; set; }
        public string LastModified { get; set; }
        public string Rank { get; set; }
    }
}
