using BlackRevival.Common.Model;
using BlackRevival.Common.GameDB.Tutorial;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class TutorialDB
{

    public TutorialDB() {
        lstUserTutorial = new List<UserTutorial>();
        _lstReward = new List<TutorialTransmit>();
    }
    public TutorialDB(Model data) {
        lstUserTutorial = new List<UserTutorial>();
        _lstReward = data.tutorial;
    }
	public void Set_UserTutorial(Tutorial_List tutorial_List)
	{
		if (tutorial_List == null)
		{
			Log.Error("Tutorial_List is null.");
			return;
		}
		this.lstUserTutorial = tutorial_List.userTutorialList;
	}
	public UserTutorial Find_UserTutorial(int tutorialNum)
	{
		List<UserTutorial> lstUserTutorial = this.lstUserTutorial;
		if (lstUserTutorial == null)
		{
			return null;
		}
		return lstUserTutorial.Find((UserTutorial item) => item.tutorialNum.Equals(tutorialNum));
	}

	public TutorialTransmit Find_TutorialReward(int tutorialNum)
	{
		List<TutorialTransmit> lstReward = this._lstReward;
		if (lstReward == null)
		{
			return null;
		}
		return lstReward.Find((TutorialTransmit item) => item.tutorialNum.Equals(tutorialNum));
	}

	public bool IsClearTutorial(TutorialCode type)
	{
		if (type == TutorialCode.None)
		{
			return false;
		}
		UserTutorial userTutorial = this.Find_UserTutorial((int)type);
		return userTutorial != null && userTutorial.cleared;
	}
	public List<UserTutorial> lstUserTutorial { get; private set; }
	public List<TutorialTransmit> _lstReward { get; private set; }

	public class Tutorial_List
	{
		public Tutorial_List()
		{
		}

		public List<UserTutorial> userTutorialList;
	}

	public class Model
	{
        public List<TutorialTransmit> tutorial { get; set; }

	}
}
