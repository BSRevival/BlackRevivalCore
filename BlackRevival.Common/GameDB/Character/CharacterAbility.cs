using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;
using BlackSurvival.Model.Spectator;

namespace BlackSurvival.Model
{
    public class CharacterAbility
    {
        public bool isDead
        {
            get
            {
                return this.health <= 0f;
            }
        }
        
        public void UpdateAbility(UpdateInfoSet info)
        {
            if (info == null)
            {
                return;
            }
            this.health = info.currenHp;
            this.maxHealth = info.maxHp;
            this.stamina = info.currenSt;
            this.maxStamina = info.maxSt;
            this.level = info.level;
        }
        
        [JsonPropertyName("tmh")]
        public float maxHealth;
        
        [JsonPropertyName("hea")]
        public float health;
        
        [JsonPropertyName("sta")]
        public float stamina;
        
        [JsonPropertyName("mht")]
        public float inherentMaxHealth;
        
        [JsonPropertyName("tms")]
        public float maxStamina;
        
        [JsonPropertyName("msm")]
        public float inherentMaxStamina;
        
        [JsonPropertyName("off")]
        public float offence;
        
        [JsonPropertyName("def")]
        public float defence;
        
        [JsonPropertyName("lvl")]
        public int level;
        
        [JsonPropertyName("exp")]
        public float exp;
        
        [JsonPropertyName("hst")]
        public readonly HealthStatus healthStatus;
        
        public bool isAlreadyUsed;
    }
}
