public enum SkillActivateType
{
	None = 0,
	Passive = 1,
	Field = 2,
	Combat = 3,
	Potential = 4
}

public enum SkillActiveNotiType
{
	None = 0,
	Activated = 1,
	DeActivated = 2,
	Activated_UseUI = 3
}
public enum SkillActiveTarget
{
	NONE = 0,
	CHARACTER = 1,
	MONSTER = 2,
	ALL = 3
}
public enum SkillColor
{
	NONE = 0,
	WHITE = 1,
	GREEN = 2,
	RED = 3,
	BLUE = 4
}
public enum SkillLogNotiType
{
	None = 0,
	Cast = 1,
	Cast_Effect = 2,
	BloodSucking = 3,
	Defence = 4,
	DefenceOnlyMe = 5,
	Both = 6,
	StackAndDuration = 7,
	StackAndCooltime = 8,
	UseItem = 9,
	Standalone_Effect = 10,
	No_Damage_Cast_Effect = 11
}
public enum SkillType
{
	NONE = 0,
	PASSIVE = 1,
	FIELD = 2,
	COMBAT = 3,
	EFFECT = 4
}

public enum SkillHolder
{
	NONE = 0,
	CHARACTER = 1,
	ITEM = 2,
	POTENTIAL = 3
}
