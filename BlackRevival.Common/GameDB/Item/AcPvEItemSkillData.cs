using BlackRevival.Common.Model.Labyrinth;

namespace BlackRevival.Common.GameDB.Item;

public class AcPvEItemSkillData
{

        public AcPvEItemSkillData()
        {
        }

        public AcPvEItemSkillData(AcPvEGameData.PvEFieldItemSkillData data)
        {
            if (data == null)
            {
                return;
            }
            this.offenceAdd = data.offenceAdd;
            this.cumulativeDamage = data.cumulativeDamage;
        }

        public string GetOffenceAddToString()
        {
            if (this.offenceAdd <= 0)
            {
                return string.Empty;
            }
            return string.Format("([54CA58]+{0}[-])", this.offenceAdd);
        }

        public void Clear()
        {
            if (this.isPermanentEffect)
            {
                return;
            }
            this.offenceAdd = 0;
            this.cumulativeDamage = 0f;
            this.useCardCount = 0;
            this.elapsedTurnCount = 0;
        }

        public bool isPermanentEffect;

        public int offenceAdd;

        public float cumulativeDamage;

        public int useCardCount;

        public int elapsedTurnCount;
}