using BlackRevival.Common.Networking;
using Serilog;
namespace BlackRevival.GameServer;

	public class ResponseEntry<T> : IngameClient.IResponse where T : class
	{
		// Token: 0x06001AED RID: 6893 RVA: 0x0001490C File Offset: 0x00012B0C
		public long GetRid()
		{
			return this.ingameRequest.RequestId;
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x000C087C File Offset: 0x000BEA7C
		public void ExcuteCallback()
		{
			if (this.ingameRequest.State == IngameRequestStates.Error)
			{
				Log.Debug("[INgameClinet.ResponseEntry.ExcuteCallback] error / state = " + this.ingameRequest.State.ToString());
				this.responseCallback(this.ingameRequest, default(T));
				return;
			}
			if (!this.ingameRequest.State.IsDone())
			{
				Log.Error("[INgameClinet.ResponseEntry.ExcuteCallback] failed / not done / state = " + this.ingameRequest.State.ToString());
				this.responseCallback(this.ingameRequest, default(T));
				return;
			}
			T t = this.ingameRequest.Result<T>();
			if (t == null && typeof(T) == typeof(object))
			{
				t = (T)((object)new object());
			}
			if (this.responseCallback != null)
			{
				this.responseCallback(this.ingameRequest, t);
			}
		}

		// Token: 0x040012B4 RID: 4788
		public IngameRequest ingameRequest;

		// Token: 0x040012B5 RID: 4789
		public IngameClient.Response<T> responseCallback;
	}
	public class IngameClient
	{
		public delegate void Response<T>(IngameRequest req, T result = default(T)) where T : class;
		public interface IResponse
		{
			// Token: 0x06001AEB RID: 6891
			long GetRid();

			// Token: 0x06001AEC RID: 6892
			void ExcuteCallback();
		}
		public IngameClient(string ClientAddress, int ClientID, Guid guid)
        {
			clientAddress = ClientAddress;
			clientId = ClientID;
			GUID = guid;
		}

		public Guid GUID;
		public string clientAddress;
		public int clientId;

		//public void GameExit(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("gameExit", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A5A RID: 6746 RVA: 0x00013A89 File Offset: 0x00011C89
		//public void unknownTest(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("unknownError", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A5B RID: 6747 RVA: 0x00013AA3 File Offset: 0x00011CA3
		//public void JoinAI(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("requestAi", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A5C RID: 6748 RVA: 0x00013ABD File Offset: 0x00011CBD
		//public void StartRoom(string roomKey, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("startRoom", new object[] { "roomKey", roomKey }), callback, true);
		//}

		//// Token: 0x06001A5D RID: 6749 RVA: 0x00013AE4 File Offset: 0x00011CE4
		//public void StartMatching(string roomKey, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("StartMatching", new object[] { "roomKey", roomKey }), callback, true);
		//}

		//// Token: 0x06001A5E RID: 6750 RVA: 0x000BF538 File Offset: 0x000BD738
		//public void ReJoinRoom(long userNum, IngameClient.Response<MyInfoData> callback)
		//{
		//	this.send<MyInfoData>(this.req("reJoinRoom", new object[] { "userNum", userNum }), delegate (IngameRequest request, MyInfoData result)
		//	{
		//		if (result != null)
		//		{
		//			this.ReconnectTryCount = 0;
		//		}
		//		callback(request, result);
		//	}, true);
		//}

		//// Token: 0x06001A5F RID: 6751 RVA: 0x000BF590 File Offset: 0x000BD790
		//public void LeftRoom(IngameClient.Response<object> callback, bool isWaitRoom)
		//{
		//	this.state = IngameClientStates.Unconnected;
		//	if (isWaitRoom)
		//	{
		//		this.send<object>(this.req("leftRoom", new object[] { "waiting", 1 }), callback, true);
		//		return;
		//	}
		//	this.send<object>(this.req("leftRoom", new object[] { "waiting", 0 }), callback, true);
		//}

		//// Token: 0x06001A60 RID: 6752 RVA: 0x00013B0B File Offset: 0x00011D0B
		//public void UserBan(IngameClient.Response<object> callback, string nick)
		//{
		//	this.send<object>(this.req("userBan", new object[] { "banUserNick", nick }), callback, true);
		//}

		//// Token: 0x06001A61 RID: 6753 RVA: 0x000BF5FC File Offset: 0x000BD7FC
		//public void SendChatMessage(string message, ChatType chatType, int chatSubType, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("chat", new object[]
		//	{
		//		"message",
		//		message,
		//		"chatType",
		//		(int)chatType,
		//		"chatSubType",
		//		chatSubType
		//	}), callback, true);
		//}

		//// Token: 0x06001A62 RID: 6754 RVA: 0x00013B32 File Offset: 0x00011D32
		//public void EnterPassCode(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("enterPasscode", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A63 RID: 6755 RVA: 0x00013B4C File Offset: 0x00011D4C
		//public void UseFieldSkill(int fieldSkillId, IngameClient.Response<UseFieldSkillResult> callback)
		//{
		//	this.send<UseFieldSkillResult>(this.req("useFieldSkill", new object[] { "skillId", fieldSkillId }), callback, true);
		//}

		//// Token: 0x06001A64 RID: 6756 RVA: 0x00013B78 File Offset: 0x00011D78
		//public void UnEquip(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("unequip", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A65 RID: 6757 RVA: 0x00013B9F File Offset: 0x00011D9F
		//public void ChangeStartWeapon(AcE_WEAPON_TYPE weaponType, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("changeStartWeapon", new object[] { "weaponType", weaponType }), callback, true);
		//}

		//// Token: 0x06001A66 RID: 6758 RVA: 0x00013BCB File Offset: 0x00011DCB
		//public void ChangeStartItem(int itemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("changeStartItem", new object[] { "itemId", itemCode }), callback, true);
		//}

		//// Token: 0x06001A67 RID: 6759 RVA: 0x00013BF7 File Offset: 0x00011DF7
		//public void TakeFindItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("takeFieldItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A68 RID: 6760 RVA: 0x00013C1E File Offset: 0x00011E1E
		//public void TakeSupplyItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("takeSupplyItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A69 RID: 6761 RVA: 0x00013C45 File Offset: 0x00011E45
		//public void DumpFindItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("abandonFieldItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A6A RID: 6762 RVA: 0x00013C6C File Offset: 0x00011E6C
		//public void UploadTeamItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("uploadTeamItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A6B RID: 6763 RVA: 0x00013C93 File Offset: 0x00011E93
		//public void DownloadTeamItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("downloadTeamItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A6C RID: 6764 RVA: 0x00013CBA File Offset: 0x00011EBA
		//public void UseMyItem(string item, IngameClient.Response<UseInventoryItemResult> callback)
		//{
		//	this.send<UseInventoryItemResult>(this.req("useInventoryItem", new object[] { "fieldItemCode", item }), callback, true);
		//}

		//// Token: 0x06001A6D RID: 6765 RVA: 0x00013CE1 File Offset: 0x00011EE1
		//public void CheckHackStatus(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("checkHackingStatus", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A6E RID: 6766 RVA: 0x00013CFB File Offset: 0x00011EFB
		//public void DropMyItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("discardInventoryItem", new object[] { "fieldItemCode", fieldItemCode }), callback, false);
		//}

		//// Token: 0x06001A6F RID: 6767 RVA: 0x000BF654 File Offset: 0x000BD854
		//public void MakeNewItem(int materialItemCodeA, int materialItemCodeB, int targetItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("makeNewItem", new object[] { "materialItemCodeA", materialItemCodeA, "materialItemCodeB", materialItemCodeB, "targetItemCode", targetItemCode }), callback, true);
		//}

		//// Token: 0x06001A70 RID: 6768 RVA: 0x00013D22 File Offset: 0x00011F22
		//public void TakeEnemyItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("takeEnemyItem", new object[] { "fieldItemCode", fieldItemCode }), callback, true);
		//}

		//// Token: 0x06001A71 RID: 6769 RVA: 0x00013D49 File Offset: 0x00011F49
		//public void TakeMonsterItem(string fieldItemCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("takeMonsterItem", new object[] { "fieldItemCode", fieldItemCode }), callback, true);
		//}

		//// Token: 0x06001A72 RID: 6770 RVA: 0x00013D70 File Offset: 0x00011F70
		//public void AbandonDeadEnemy(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("abandonDeadEnemy", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A73 RID: 6771 RVA: 0x00013D8A File Offset: 0x00011F8A
		//public void AbandonDeadMonster(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("abandonDeadMonster", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A74 RID: 6772 RVA: 0x00013DA4 File Offset: 0x00011FA4
		//public void UnlockMap(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("unlockMap", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A75 RID: 6773 RVA: 0x00013DBE File Offset: 0x00011FBE
		//public void KillEnemy(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("killEnemy", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A76 RID: 6774 RVA: 0x00013DD8 File Offset: 0x00011FD8
		//public void CancelHackingProgress(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("cancelHacking", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A77 RID: 6775 RVA: 0x00013DF2 File Offset: 0x00011FF2
		//private AttackType WeaponTypeToAttackType(AcE_WEAPON_TYPE weaponType = AcE_WEAPON_TYPE.NONE)
		//{
		//	if (weaponType == AcE_WEAPON_TYPE.BLADE)
		//	{
		//		return AttackType.BLADE;
		//	}
		//	if (weaponType == AcE_WEAPON_TYPE.STAB)
		//	{
		//		return AttackType.STAB;
		//	}
		//	return AttackType.NONE;
		//}

		//// Token: 0x06001A78 RID: 6776 RVA: 0x000BF6B0 File Offset: 0x000BD8B0
		//public void Attack(long enemyUserNum, AcE_WEAPON_TYPE weaponType, IngameClient.Response<ActionResult> callback)
		//{
		//	AttackType attackType = this.WeaponTypeToAttackType(weaponType);
		//	this.send<ActionResult>(this.req("attackFieldCharacter", new object[]
		//	{
		//		"attackType",
		//		(int)attackType,
		//		"enemyUserNum",
		//		enemyUserNum
		//	}), callback, true);
		//}

		//// Token: 0x06001A79 RID: 6777 RVA: 0x000BF700 File Offset: 0x000BD900
		//public void Attack(string enemyUserNick, AcE_WEAPON_TYPE weaponType, int skillId, IngameClient.Response<ActionResult> callback)
		//{
		//	AttackType attackType;
		//	if (skillId == 0)
		//	{
		//		attackType = this.WeaponTypeToAttackType(weaponType);
		//	}
		//	else
		//	{
		//		attackType = AttackType.SPECIALTY;
		//	}
		//	this.send<ActionResult>(this.req("attackFieldCharacter", new object[]
		//	{
		//		"attackType",
		//		(int)attackType,
		//		"skillId",
		//		skillId,
		//		"enemyUserNick",
		//		enemyUserNick
		//	}), callback, true);
		//}

		//// Token: 0x06001A7A RID: 6778 RVA: 0x000BF768 File Offset: 0x000BD968
		//public void AttackMonster(AcE_WEAPON_TYPE weaponType, int skillId, int monster, IngameClient.Response<ActionResult> callback)
		//{
		//	AttackType attackType;
		//	if (skillId == 0)
		//	{
		//		attackType = this.WeaponTypeToAttackType(weaponType);
		//	}
		//	else
		//	{
		//		attackType = AttackType.SPECIALTY;
		//	}
		//	this.send<ActionResult>(this.req("attackMonster", new object[]
		//	{
		//		"attackType",
		//		(int)attackType,
		//		"skillId",
		//		skillId,
		//		"monster",
		//		monster
		//	}), callback, true);
		//}

		//// Token: 0x06001A7B RID: 6779 RVA: 0x00013E01 File Offset: 0x00012001
		//public void GetRestInfomation(IngameClient.Response<RestResult> callback)
		//{
		//	this.send<RestResult>(this.req("restInfo", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A7C RID: 6780 RVA: 0x00013E1B File Offset: 0x0001201B
		//public void StartRest(CastingType restTypeCode, IngameClient.Response<RestResult> callback)
		//{
		//	this.send<RestResult>(this.req("beginRest", new object[]
		//	{
		//		"restTypeCode",
		//		(int)restTypeCode
		//	}), callback, true);
		//}

		//// Token: 0x06001A7D RID: 6781 RVA: 0x00013E47 File Offset: 0x00012047
		//public void UseRadar(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("useRadar", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A7E RID: 6782 RVA: 0x00013E61 File Offset: 0x00012061
		//public void StartSearch(IngameClient.Response<SearchResult> callback)
		//{
		//	this.send<SearchResult>(this.req("search", Array.Empty<object>()), callback, false);
		//}

		//// Token: 0x06001A7F RID: 6783 RVA: 0x000BF7D4 File Offset: 0x000BD9D4
		//public void StartItemSearch(FieldItem fieldItem, IngameClient.Response<SearchResult> callback)
		//{
		//	this.send<SearchResult>(this.req("search", new object[] { "itemCode", fieldItem.item, "fieldItemCode", fieldItem.fieldItemCode }), callback, true);
		//}

		//// Token: 0x06001A80 RID: 6784 RVA: 0x00013E7B File Offset: 0x0001207B
		//public void EndRest(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("suspendRest", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A81 RID: 6785 RVA: 0x00013E95 File Offset: 0x00012095
		//public void PotentialDeactivate(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("potentialDeactivate", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A82 RID: 6786 RVA: 0x00013EAF File Offset: 0x000120AF
		//public void ChangeStance(CharacterStance stanceCode, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("changeStance", new object[]
		//	{
		//		"stanceCode",
		//		(int)stanceCode
		//	}), callback, true);
		//}

		//// Token: 0x06001A83 RID: 6787 RVA: 0x00013EDB File Offset: 0x000120DB
		//public void Reconnoiter(IngameClient.Response<ReconResult> callback)
		//{
		//	this.send<ReconResult>(this.req("reconnoiter", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A84 RID: 6788 RVA: 0x00013EF5 File Offset: 0x000120F5
		//public void ShowBattleStatus(IngameClient.Response<BattleStatusResult> callback)
		//{
		//	this.send<BattleStatusResult>(this.req("playerStatus", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A85 RID: 6789 RVA: 0x00013F0F File Offset: 0x0001210F
		//public void MoveMap(int fieldType, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("shiftField", new object[] { "typeCode", fieldType }), callback, true);
		//}

		//// Token: 0x06001A86 RID: 6790 RVA: 0x00013F3B File Offset: 0x0001213B
		//public void EverythingLocation(int varietyLocation, IngameClient.Response<EverythingLocation> callback)
		//{
		//	this.send<EverythingLocation>(this.req("everythingLocation", new object[] { "varietyLocation", varietyLocation }), callback, true);
		//}

		//// Token: 0x06001A87 RID: 6791 RVA: 0x00013F67 File Offset: 0x00012167
		//public void MuteChat(string userName, int type, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("silenceChat", new object[] { "enemyNick", userName, "silenceType", type }), callback, true);
		//}

		//// Token: 0x06001A88 RID: 6792 RVA: 0x00013F9F File Offset: 0x0001219F
		//public void TakeStartEquip(int startFlag, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("takeStartEquip", new object[] { "startFlag", startFlag }), callback, true);
		//}

		//// Token: 0x06001A89 RID: 6793 RVA: 0x000030B0 File Offset: 0x000012B0
		//public void FreeFieldItem(int itemCode, IngameClient.Response<ActionResult> callback)
		//{
		//}

		//// Token: 0x06001A8A RID: 6794 RVA: 0x000030B0 File Offset: 0x000012B0
		//public void MakeWound(IngameClient.Response<ActionResult> callback)
		//{
		//}

		//// Token: 0x06001A8B RID: 6795 RVA: 0x00013FCB File Offset: 0x000121CB
		//public void TargetingEnemy(string nickname, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("targetingEnemy", new object[] { "enemyNickname", nickname }), callback, true);
		//}

		//// Token: 0x06001A8C RID: 6796 RVA: 0x00013FF2 File Offset: 0x000121F2
		//public void FinishSkillDuration(int skillId, IngameClient.Response<FinishSkillDuration> callback)
		//{
		//	this.send<FinishSkillDuration>(this.req("finishSkillDuration", new object[] { "skillId", skillId }), callback, true);
		//}

		//// Token: 0x06001A8D RID: 6797 RVA: 0x0001401E File Offset: 0x0001221E
		//public void Ready(IngameClient.Response<ReadyResult> callback)
		//{
		//	this.send<ReadyResult>(this.req("ready2Move", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A8E RID: 6798 RVA: 0x00014038 File Offset: 0x00012238
		//public void AdminFamiliarity(AcE_WEAPON_TYPE weaponType, int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeFamiliarity", new object[] { "weaponType", weaponType, "incrPt", addPoint }), callback, true);
		//}

		//// Token: 0x06001A8F RID: 6799 RVA: 0x00014075 File Offset: 0x00012275
		//public void AdminLevel(int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlLevel", new object[] { "changePoint", addPoint }), callback, true);
		//}

		//// Token: 0x06001A90 RID: 6800 RVA: 0x000140A1 File Offset: 0x000122A1
		//public void AdminHp(int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlHealth", new object[] { "changePoint", addPoint }), callback, true);
		//}

		//// Token: 0x06001A91 RID: 6801 RVA: 0x000140CD File Offset: 0x000122CD
		//public void AdminExp(int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlExp", new object[] { "changePoint", addPoint }), callback, true);
		//}

		//// Token: 0x06001A92 RID: 6802 RVA: 0x000140F9 File Offset: 0x000122F9
		//public void AdminResetCoolTime(int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlCooltime", new object[] { "changePoint", addPoint }), callback, true);
		//}

		//// Token: 0x06001A93 RID: 6803 RVA: 0x00014125 File Offset: 0x00012325
		//public void AdminResetStatusEffectDuration(int addPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlStatusEffectDuration", new object[] { "changePoint", addPoint }), callback, true);
		//}

		//// Token: 0x06001A94 RID: 6804 RVA: 0x00014151 File Offset: 0x00012351
		//public void AdminStamina(int setPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlStamina", new object[] { "changePoint", setPoint }), callback, true);
		//}

		//// Token: 0x06001A95 RID: 6805 RVA: 0x0001417D File Offset: 0x0001237D
		//public void AdminHalfBrokenWeapon(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlBrokenWeapon", new object[] { "changeWeapon", 1 }), callback, true);
		//}

		//// Token: 0x06001A96 RID: 6806 RVA: 0x000141A9 File Offset: 0x000123A9
		//public void AdminRemoveHalfBrokenWeapon(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlBrokenWeapon", new object[] { "changeWeapon", 2 }), callback, true);
		//}

		//// Token: 0x06001A97 RID: 6807 RVA: 0x000141D5 File Offset: 0x000123D5
		//public void AdminBrokenWeapon(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlBrokenWeapon", new object[] { "changeWeapon", 3 }), callback, true);
		//}

		//// Token: 0x06001A98 RID: 6808 RVA: 0x00014201 File Offset: 0x00012401
		//public void AdminWeakenWeapon(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlBrokenWeapon", new object[] { "changeWeapon", 5 }), callback, true);
		//}

		//// Token: 0x06001A99 RID: 6809 RVA: 0x0001422D File Offset: 0x0001242D
		//public void AdminEnchantWeapon(IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlBrokenWeapon", new object[] { "changeWeapon", 4 }), callback, true);
		//}

		//// Token: 0x06001A9A RID: 6810 RVA: 0x00014259 File Offset: 0x00012459
		//public void AdminSkillStack(int setPoint, IngameClient.Response<ActionResult> callback)
		//{
		//	this.send<ActionResult>(this.req("freeControlSkillStack", new object[] { "changePoint", setPoint }), callback, true);
		//}

		//// Token: 0x06001A9B RID: 6811 RVA: 0x00014285 File Offset: 0x00012485
		//public void ReviveForPractice(IngameClient.Response<ReviveForPracticeResult> callback)
		//{
		//	this.send<ReviveForPracticeResult>(this.req("reviveForPractice", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001A9C RID: 6812 RVA: 0x0001429F File Offset: 0x0001249F
		//public void CreateRoom(string battleSeatKey, global::PlayMode playMode, IngameClient.Response<CreatePrivateRoomResult> callback)
		//{
		//	this.send<CreatePrivateRoomResult>(this.req("createRoom", new object[]
		//	{
		//		"battleSeatKey",
		//		battleSeatKey,
		//		"battleMode",
		//		(int)playMode
		//	}), callback, true);
		//}

		//// Token: 0x06001A9D RID: 6813 RVA: 0x000142D7 File Offset: 0x000124D7
		//public void CreateTutorialRoom(string battleSeatKey, global::PlayMode playMode, IngameClient.Response<CreatePrivateRoomResult> callback)
		//{
		//	this.send<CreatePrivateRoomResult>(this.req("createTutorialRoom", new object[]
		//	{
		//		"battleSeatKey",
		//		battleSeatKey,
		//		"battleMode",
		//		(int)playMode
		//	}), callback, true);
		//}

		//// Token: 0x06001A9E RID: 6814 RVA: 0x0001430F File Offset: 0x0001250F
		//public void JoinRoom(string roomKey, string battleSeatKey, IngameClient.Response<JoinPrivateRoomResult> callback)
		//{
		//	this.send<JoinPrivateRoomResult>(this.req("joinRoom", new object[] { "roomKey", roomKey, "battleSeatKey", battleSeatKey }), callback, true);
		//}

		//// Token: 0x06001A9F RID: 6815 RVA: 0x000BF824 File Offset: 0x000BDA24
		//public void JoinMatchedRoom(long userNum, string roomKey, string battleSeatKey, IngameClient.Response<JoinMatchedRoomResult> callback)
		//{
		//	this.send<JoinMatchedRoomResult>(this.req("joinMatchedRoom", new object[] { "userNum", userNum, "roomKey", roomKey, "battleSeatKey", battleSeatKey }), callback, true);
		//}

		//// Token: 0x06001AA0 RID: 6816 RVA: 0x00014342 File Offset: 0x00012542
		//public void ChangeTeam(TeamFormationInfo teamFormationInfo, IngameClient.Response<ChangeTeamResult> callback)
		//{
		//	this.send<ChangeTeamResult>(this.req("changeTeam", new object[] { "teamFormationInfo", teamFormationInfo }), callback, true);
		//}

		//// Token: 0x06001AA1 RID: 6817 RVA: 0x00014369 File Offset: 0x00012569
		//public void CreateReadyRoom(string battleSeatKey, BroadcastReadyRoom readyRoom, IngameClient.Response<CreateReadyRoomResult> callback)
		//{
		//	this.send<CreateReadyRoomResult>(this.req("createOpenRoom", new object[] { "battleSeatKey", battleSeatKey, "openRoomInfo", readyRoom }), callback, true);
		//}

		//// Token: 0x06001AA2 RID: 6818 RVA: 0x0001439C File Offset: 0x0001259C
		//public void JoinReadyRoom(string battleSeatKey, string roomKey, IngameClient.Response<JoinReadyRoomResult> callback)
		//{
		//	this.send<JoinReadyRoomResult>(this.req("joinOpenRoom", new object[] { "battleSeatKey", battleSeatKey, "roomKey", roomKey }), callback, true);
		//}

		//// Token: 0x06001AA3 RID: 6819 RVA: 0x000143CF File Offset: 0x000125CF
		//public void Runaway(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("runaway", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AA4 RID: 6820 RVA: 0x000143E9 File Offset: 0x000125E9
		//public void ReloadMatchingTeamCharacters(IngameClient.Response<ReloadTeamResult> callback)
		//{
		//	this.send<ReloadTeamResult>(this.req("reloadMatchingTeams", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AA5 RID: 6821 RVA: 0x000BF874 File Offset: 0x000BDA74
		//public void SendTeamAlert(TeamAlertType alertType, int option1, string option2, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("alertTeam", new object[]
		//	{
		//		"alertType",
		//		(int)alertType,
		//		"option1",
		//		option1,
		//		"option2",
		//		option2
		//	}), callback, true);
		//}

		//// Token: 0x06001AA6 RID: 6822 RVA: 0x00014403 File Offset: 0x00012603
		//public void ReviveTeam(int teamUserNumber, IngameClient.Response<ReviveTeamPlayerReusult> callback)
		//{
		//	this.send<ReviveTeamPlayerReusult>(this.req("reviveTeamPlayer", new object[] { "teamPlayerNumber", teamUserNumber }), callback, true);
		//}

		//// Token: 0x06001AA7 RID: 6823 RVA: 0x0001442F File Offset: 0x0001262F
		//public void ReviveTeamProgress(int teamUserNumber, int progress, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("reviveTeamPlayerProgress", new object[] { "teamPlayerNumber", teamUserNumber, "progress", progress }), callback, true);
		//}

		//// Token: 0x06001AA8 RID: 6824 RVA: 0x0001446C File Offset: 0x0001266C
		//public void UpdateTeamStatus(IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("updateTeamStatus", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AA9 RID: 6825 RVA: 0x000BF8CC File Offset: 0x000BDACC
		//public void ChangeEnterCharacter(int characterClass, int skinType, int grade, int potentialSkillId, bool isActiveLive2d, int perkMain, int perkFirst, int perkSecond, IngameClient.Response<ChangeEnterCharacter> callback)
		//{
		//	this.send<ChangeEnterCharacter>(this.req("changeCharacter", new object[]
		//	{
		//		"characterClass", characterClass, "skinType", skinType, "grade", grade, "potentialSkillId", potentialSkillId, "isActiveLive2d", isActiveLive2d,
		//		"perkMain", perkMain, "perkFirst", perkFirst, "perkSecond", perkSecond
		//	}), callback, true);
		//}

		//// Token: 0x06001AAA RID: 6826 RVA: 0x00014486 File Offset: 0x00012686
		//public void SelectRobotField(int fieldType, string itemCode, IngameClient.Response<SelectRobotFieldResult> callback)
		//{
		//	this.send<SelectRobotFieldResult>(this.req("selectRobotField", new object[] { "typeCode", fieldType, "itemCode", itemCode }), callback, true);
		//}

		//// Token: 0x06001AAB RID: 6827 RVA: 0x000144BE File Offset: 0x000126BE
		//public void CheckEvolutionCondition(int motherItemCode, int childItemCode, IngameClient.Response<EvolutionFieldItemResult> callback)
		//{
		//	this.send<EvolutionFieldItemResult>(this.req("checkEvolutionCondition", new object[] { "motherItemCode", motherItemCode, "childItemCode", childItemCode }), callback, true);
		//}

		//// Token: 0x06001AAC RID: 6828 RVA: 0x000144FB File Offset: 0x000126FB
		//public void EvolutionFiledItem(int motherItemCode, int childItemCode, IngameClient.Response<EvolutionFieldItemResult> callback)
		//{
		//	this.send<EvolutionFieldItemResult>(this.req("evolutionFieldItem", new object[] { "motherItemCode", motherItemCode, "childItemCode", childItemCode }), callback, true);
		//}

		//// Token: 0x06001AAD RID: 6829 RVA: 0x000BF988 File Offset: 0x000BDB88
		//public void SelectUseItemForSkill(int typeCode, int skillCode, string itemCode, IngameClient.Response<UseItemForSkillResult> callback)
		//{
		//	this.send<UseItemForSkillResult>(this.req("selectUseItemForSkill", new object[] { "typeCode", typeCode, "skillCode", skillCode, "itemCode", itemCode }), callback, true);
		//}

		//// Token: 0x06001AAE RID: 6830 RVA: 0x00014538 File Offset: 0x00012738
		//public void CheckTransmogItemList(IngameClient.Response<CheckTransmogItemListResult> callback)
		//{
		//	this.send<CheckTransmogItemListResult>(this.req("checkTransmogItemList", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AAF RID: 6831 RVA: 0x00014552 File Offset: 0x00012752
		//public void TransmogItem(int transmogTarget, IngameClient.Response<TransmogItemResult> callback)
		//{
		//	this.send<TransmogItemResult>(this.req("transmogItem", new object[] { "transTargetItemCode", transmogTarget }), callback, true);
		//}

		//// Token: 0x06001AB0 RID: 6832 RVA: 0x0001457E File Offset: 0x0001277E
		//public void RejoinSupply(IngameClient.Response<RejoinRequestSupplyResult> callback)
		//{
		//	this.send<RejoinRequestSupplyResult>(this.req("getInGameSupplies", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AB1 RID: 6833 RVA: 0x00014598 File Offset: 0x00012798
		//public void RequestSupply(int code, int step, IngameClient.Response<RequestSupplyResult> callback)
		//{
		//	this.send<RequestSupplyResult>(this.req("takeInGameSuppliesItem", new object[] { "inGameSuppliesCode", code, "step", step }), callback, true);
		//}

		//// Token: 0x06001AB2 RID: 6834 RVA: 0x000145D5 File Offset: 0x000127D5
		//public void SelectPaintItem(int itemId, IngameClient.Response<SelectPaintItemResult> callback)
		//{
		//	this.send<SelectPaintItemResult>(this.req("selectPaintItem", new object[] { "selectItemId", itemId }), callback, true);
		//}

		//// Token: 0x06001AB3 RID: 6835 RVA: 0x00014601 File Offset: 0x00012801
		//public void TeamReady(IngameClient.Response<ReadyResult> callback)
		//{
		//	this.send<ReadyResult>(this.req("ready2Start", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AB4 RID: 6836 RVA: 0x0001461B File Offset: 0x0001281B
		//public void TeamReadyStatus(IngameClient.Response<ReadyStatusResult> callback)
		//{
		//	this.send<ReadyStatusResult>(this.req("teamReadyStatus", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AB5 RID: 6837 RVA: 0x00014635 File Offset: 0x00012835
		//public void CheckNoMove(IngameClient.Response<CheckNoMoveResult> callback)
		//{
		//	this.send<CheckNoMoveResult>(this.req("checkNoMove", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AB6 RID: 6838 RVA: 0x0001464F File Offset: 0x0001284F
		//public void RequestObserverLog(IngameClient.Response<ObserverActionResult> callback)
		//{
		//	this.send<ObserverActionResult>(this.req("observerInfo", Array.Empty<object>()), callback, true);
		//}

		//// Token: 0x06001AB7 RID: 6839 RVA: 0x00014669 File Offset: 0x00012869
		//public void Ready2Find(long aiUserNum, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("ready2Find", new object[] { "userNum", aiUserNum }), callback, true);
		//}

		//// Token: 0x06001AB8 RID: 6840 RVA: 0x00014695 File Offset: 0x00012895
		//public void UseSiren(long aiUserNum, IngameClient.Response<object> callback)
		//{
		//	this.send<object>(this.req("useSiren", new object[] { "userNum", aiUserNum }), callback, true);
		//}

		//// Token: 0x06001AB9 RID: 6841 RVA: 0x000BF9E0 File Offset: 0x000BDBE0
		//public void SaveTutorialStep(int tutorialNum, int tutorialStep, IngameClient.Response<object> callback)
		//{
		//	if (tutorialNum - 201 <= 1)
		//	{
		//		this.send<object>(this.req("saveTutorialStep", new object[] { "tutorialNum", tutorialNum, "tutorialStep", tutorialStep }), callback, true);
		//		return;
		//	}
		//	AcLogger.LogError("Invalid tutorial code : {0}", new object[] { (AcE_TUTORIAL_CODE)tutorialNum });
		//}

		//// Token: 0x17000415 RID: 1045
		//// (get) Token: 0x06001ABA RID: 6842 RVA: 0x000146C1 File Offset: 0x000128C1
		//// (set) Token: 0x06001ABB RID: 6843 RVA: 0x000146C9 File Offset: 0x000128C9
		//public IngameClientStates State
		//{
		//	get
		//	{
		//		return this.state;
		//	}
		//	private set
		//	{
		//		this.state = value;
		//	}
		//}

		//// Token: 0x17000416 RID: 1046
		//// (get) Token: 0x06001ABC RID: 6844 RVA: 0x000146D2 File Offset: 0x000128D2
		//// (set) Token: 0x06001ABD RID: 6845 RVA: 0x000146DA File Offset: 0x000128DA
		//public Exception Exception { get; private set; }

		//// Token: 0x06001ABE RID: 6846 RVA: 0x000146E3 File Offset: 0x000128E3
		//public float getLatency()
		//{
		//	if (this.timeSync == null)
		//	{
		//		return 0f;
		//	}
		//	return (float)this.timeSync.delay / 1000f;
		//}

		//// Token: 0x17000417 RID: 1047
		//// (get) Token: 0x06001ABF RID: 6847 RVA: 0x00014705 File Offset: 0x00012905
		//// (set) Token: 0x06001AC0 RID: 6848 RVA: 0x0001470D File Offset: 0x0001290D
		//public bool IsReconnecting
		//{
		//	get
		//	{
		//		return this.isReconnecting;
		//	}
		//	set
		//	{
		//		this.isReconnecting = value;
		//	}
		//}

		//// Token: 0x06001AC1 RID: 6849 RVA: 0x000BFA50 File Offset: 0x000BDC50
		//public void EnableInternetCheck(bool enable)
		//{
		//	if (enable)
		//	{
		//		if (this.internetReachabilityCheck == null)
		//		{
		//			base.StartCoroutine(this.internetReachabilityCheck = this.InternetReachabilityCheck());
		//			return;
		//		}
		//	}
		//	else if (this.internetReachabilityCheck != null)
		//	{
		//		base.StopCoroutine(this.internetReachabilityCheck);
		//		if (MonoBehaviourInstance<IngameUIManager>.inst != null)
		//		{
		//			MonoBehaviourInstance<IngameUIManager>.inst.HideWifiQualityUI();
		//		}
		//		if (MonoBehaviourInstance<SpectatorUIManager>.inst != null)
		//		{
		//			MonoBehaviourInstance<SpectatorUIManager>.inst.HideWifiQualityUI();
		//		}
		//		this.internetReachabilityCheck = null;
		//	}
		//}

		//// Token: 0x06001AC2 RID: 6850 RVA: 0x00014716 File Offset: 0x00012916
		//public void Connect(string url, Action onConnect = null)
		//{
		//	this.Exception = null;
		//	this.RequestIdQueue = new Queue<long>();
		//	this.State = IngameClientStates.Connecting;
		//	base.StartCoroutine(this.WaitingConnect(url, onConnect));
		//}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x00014740 File Offset: 0x00012940

		// Token: 0x06001AC4 RID: 6852 RVA: 0x0001475D File Offset: 0x0001295D
		public IngameRequest Send(string method, params object[] param)
		{
			return this.Send(method, null, param);
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x00014768 File Offset: 0x00012968
		public IngameRequest Send<T>(string method, params object[] param)
		{
			return this.Send(method, typeof(T), param);
		}
	}
