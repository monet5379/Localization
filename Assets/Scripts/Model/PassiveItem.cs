using UnityEngine;
using System.Collections;
using LitJson;

public class PassiveItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string NameString;
	public string OwnerType;
	public string Weapon;
	public string Gear;
	public string CoreType;
	public bool IsLevelup;
	public string[] TriggerCondition_;
	public string TriggerTargetLayer;
	public string TriggerAttackerLayer;
	public string[] TriggerTargetCharacter_;
	public string[] TriggerAttackerCharacter_;
	public string TriggerCurrency;
	public string[] TriggerAttackMethod_;
	public string TriggerTime;
	public int TriggerAttackOrder;
	public int TriggetDamageIndex;
	public int TriggerIgnoreDamageIndex;
	public string TriggerDamageType;
	public string[] IgnoreDamageType_;
	public string Condition;
	public string Comparison;
	public float ConditionValue;
	public float ConditionAddValue;
	public bool UseReverseExecute;
	public int AllowedLevelConditionValue;
	public string[] ConditionPassive_;
	public int ConditionPassiveMinCount;
	public string[] ConditionHitmark_;
	public string[] ConditionOwnerBuff_;
	public string[] ConditionTargetBuff_;
	public string ConditionTargetFV;
	public string ConditionOwnerStack;
	public string ConditionTargetStack;
	public string ConditionIgnoreTargetStack;
	public int ConditionStackCount;
	public bool UseLevelByStackedTargets;
	public bool UseLevelByStackCount;
	public bool IsConditionMaxStack;
	public float OffsetX;
	public float OffsetY;
	public bool UseOnce;
	public bool UseCharge;
	public bool UseChargedOnActivated;
	public bool UseChargeOnActivated;
	public bool UseExecuteOnActivated;
	public bool AutoChargeOnCharged;
	public bool AutoExecuteOnCharged;
	public bool UseChargeText;
	public float FirstChargeTime;
	public float ChargeTime;
	public float AddChargeTime;
	public int ChargeMaxCount;
	public string ChargeFX;
	public string[] CharacterAttack_;
	public string[] ChangedAnimation_;
	public string[] ChangeHitmark1_;
	public string[] ChangeHitmark2_;
	public string[] ChangeHitmark3_;
	public string AppliedOwnerStack;
	public string AppliedTargetStack;
	public string RemoveTargetStack;
	public int StackCount;
	public string[] AppliedOwnerBuff_;
	public string[] AppliedAttackerBuff_;
	public string[] AppliedTargetBuff_;
	public string[] ReleaseOwnerBuff_;
	public string[] ReleaseTargetBuff_;
	public string AppliedOwnerBlink;
	public string AppliedAnimation;
	public string AppliedAttackMethod;
	public string AttackEntityType;
	public string TargetType;
	public string AppliedHitmarkName;
	public bool TargetVitalOffset;
	public string AppliedOwnerFV;
	public string AppliedTargetFV;
	public string DropObjectType;
	public string DropCurrency;
	public int DropObjectCount;
	public int DropObjectAddCount;
	public int DropObjectValue;
	public int DropObjectAddValue;
	public string ChargingBuff;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		NameString = data["NameString"].ToString();
		OwnerType = data["OwnerType"].ToString();
		Weapon = data["Weapon"].ToString();
		Gear = data["Gear"].ToString();
		CoreType = data["CoreType"].ToString();
		IsLevelup = data["IsLevelup"].ToString() != "0";
		string TriggerCondition__str = data["TriggerCondition_"].ToString();
		if(TriggerCondition__str.Length > 0) { 
		 TriggerCondition_ = data["TriggerCondition_"].ToString().Split (',');
		} else {
TriggerCondition_ = new string[0];}
		TriggerTargetLayer = data["TriggerTargetLayer"].ToString();
		TriggerAttackerLayer = data["TriggerAttackerLayer"].ToString();
		string TriggerTargetCharacter__str = data["TriggerTargetCharacter_"].ToString();
		if(TriggerTargetCharacter__str.Length > 0) { 
		 TriggerTargetCharacter_ = data["TriggerTargetCharacter_"].ToString().Split (',');
		} else {
TriggerTargetCharacter_ = new string[0];}
		string TriggerAttackerCharacter__str = data["TriggerAttackerCharacter_"].ToString();
		if(TriggerAttackerCharacter__str.Length > 0) { 
		 TriggerAttackerCharacter_ = data["TriggerAttackerCharacter_"].ToString().Split (',');
		} else {
TriggerAttackerCharacter_ = new string[0];}
		TriggerCurrency = data["TriggerCurrency"].ToString();
		string TriggerAttackMethod__str = data["TriggerAttackMethod_"].ToString();
		if(TriggerAttackMethod__str.Length > 0) { 
		 TriggerAttackMethod_ = data["TriggerAttackMethod_"].ToString().Split (',');
		} else {
TriggerAttackMethod_ = new string[0];}
		TriggerTime = data["TriggerTime"].ToString();
		TriggerAttackOrder = int.Parse(data["TriggerAttackOrder"].ToString());
		TriggetDamageIndex = int.Parse(data["TriggetDamageIndex"].ToString());
		TriggerIgnoreDamageIndex = int.Parse(data["TriggerIgnoreDamageIndex"].ToString());
		TriggerDamageType = data["TriggerDamageType"].ToString();
		string IgnoreDamageType__str = data["IgnoreDamageType_"].ToString();
		if(IgnoreDamageType__str.Length > 0) { 
		 IgnoreDamageType_ = data["IgnoreDamageType_"].ToString().Split (',');
		} else {
IgnoreDamageType_ = new string[0];}
		Condition = data["Condition"].ToString();
		Comparison = data["Comparison"].ToString();
		ConditionValue = float.Parse(data["ConditionValue"].ToString());
		ConditionAddValue = float.Parse(data["ConditionAddValue"].ToString());
		UseReverseExecute = data["UseReverseExecute"].ToString() != "0";
		AllowedLevelConditionValue = int.Parse(data["AllowedLevelConditionValue"].ToString());
		string ConditionPassive__str = data["ConditionPassive_"].ToString();
		if(ConditionPassive__str.Length > 0) { 
		 ConditionPassive_ = data["ConditionPassive_"].ToString().Split (',');
		} else {
ConditionPassive_ = new string[0];}
		ConditionPassiveMinCount = int.Parse(data["ConditionPassiveMinCount"].ToString());
		string ConditionHitmark__str = data["ConditionHitmark_"].ToString();
		if(ConditionHitmark__str.Length > 0) { 
		 ConditionHitmark_ = data["ConditionHitmark_"].ToString().Split (',');
		} else {
ConditionHitmark_ = new string[0];}
		string ConditionOwnerBuff__str = data["ConditionOwnerBuff_"].ToString();
		if(ConditionOwnerBuff__str.Length > 0) { 
		 ConditionOwnerBuff_ = data["ConditionOwnerBuff_"].ToString().Split (',');
		} else {
ConditionOwnerBuff_ = new string[0];}
		string ConditionTargetBuff__str = data["ConditionTargetBuff_"].ToString();
		if(ConditionTargetBuff__str.Length > 0) { 
		 ConditionTargetBuff_ = data["ConditionTargetBuff_"].ToString().Split (',');
		} else {
ConditionTargetBuff_ = new string[0];}
		ConditionTargetFV = data["ConditionTargetFV"].ToString();
		ConditionOwnerStack = data["ConditionOwnerStack"].ToString();
		ConditionTargetStack = data["ConditionTargetStack"].ToString();
		ConditionIgnoreTargetStack = data["ConditionIgnoreTargetStack"].ToString();
		ConditionStackCount = int.Parse(data["ConditionStackCount"].ToString());
		UseLevelByStackedTargets = data["UseLevelByStackedTargets"].ToString() != "0";
		UseLevelByStackCount = data["UseLevelByStackCount"].ToString() != "0";
		IsConditionMaxStack = data["IsConditionMaxStack"].ToString() != "0";
		OffsetX = float.Parse(data["OffsetX"].ToString());
		OffsetY = float.Parse(data["OffsetY"].ToString());
		UseOnce = data["UseOnce"].ToString() != "0";
		UseCharge = data["UseCharge"].ToString() != "0";
		UseChargedOnActivated = data["UseChargedOnActivated"].ToString() != "0";
		UseChargeOnActivated = data["UseChargeOnActivated"].ToString() != "0";
		UseExecuteOnActivated = data["UseExecuteOnActivated"].ToString() != "0";
		AutoChargeOnCharged = data["AutoChargeOnCharged"].ToString() != "0";
		AutoExecuteOnCharged = data["AutoExecuteOnCharged"].ToString() != "0";
		UseChargeText = data["UseChargeText"].ToString() != "0";
		FirstChargeTime = float.Parse(data["FirstChargeTime"].ToString());
		ChargeTime = float.Parse(data["ChargeTime"].ToString());
		AddChargeTime = float.Parse(data["AddChargeTime"].ToString());
		ChargeMaxCount = int.Parse(data["ChargeMaxCount"].ToString());
		ChargeFX = data["ChargeFX"].ToString();
		string CharacterAttack__str = data["CharacterAttack_"].ToString();
		if(CharacterAttack__str.Length > 0) { 
		 CharacterAttack_ = data["CharacterAttack_"].ToString().Split (',');
		} else {
CharacterAttack_ = new string[0];}
		string ChangedAnimation__str = data["ChangedAnimation_"].ToString();
		if(ChangedAnimation__str.Length > 0) { 
		 ChangedAnimation_ = data["ChangedAnimation_"].ToString().Split (',');
		} else {
ChangedAnimation_ = new string[0];}
		string ChangeHitmark1__str = data["ChangeHitmark1_"].ToString();
		if(ChangeHitmark1__str.Length > 0) { 
		 ChangeHitmark1_ = data["ChangeHitmark1_"].ToString().Split (',');
		} else {
ChangeHitmark1_ = new string[0];}
		string ChangeHitmark2__str = data["ChangeHitmark2_"].ToString();
		if(ChangeHitmark2__str.Length > 0) { 
		 ChangeHitmark2_ = data["ChangeHitmark2_"].ToString().Split (',');
		} else {
ChangeHitmark2_ = new string[0];}
		string ChangeHitmark3__str = data["ChangeHitmark3_"].ToString();
		if(ChangeHitmark3__str.Length > 0) { 
		 ChangeHitmark3_ = data["ChangeHitmark3_"].ToString().Split (',');
		} else {
ChangeHitmark3_ = new string[0];}
		AppliedOwnerStack = data["AppliedOwnerStack"].ToString();
		AppliedTargetStack = data["AppliedTargetStack"].ToString();
		RemoveTargetStack = data["RemoveTargetStack"].ToString();
		StackCount = int.Parse(data["StackCount"].ToString());
		string AppliedOwnerBuff__str = data["AppliedOwnerBuff_"].ToString();
		if(AppliedOwnerBuff__str.Length > 0) { 
		 AppliedOwnerBuff_ = data["AppliedOwnerBuff_"].ToString().Split (',');
		} else {
AppliedOwnerBuff_ = new string[0];}
		string AppliedAttackerBuff__str = data["AppliedAttackerBuff_"].ToString();
		if(AppliedAttackerBuff__str.Length > 0) { 
		 AppliedAttackerBuff_ = data["AppliedAttackerBuff_"].ToString().Split (',');
		} else {
AppliedAttackerBuff_ = new string[0];}
		string AppliedTargetBuff__str = data["AppliedTargetBuff_"].ToString();
		if(AppliedTargetBuff__str.Length > 0) { 
		 AppliedTargetBuff_ = data["AppliedTargetBuff_"].ToString().Split (',');
		} else {
AppliedTargetBuff_ = new string[0];}
		string ReleaseOwnerBuff__str = data["ReleaseOwnerBuff_"].ToString();
		if(ReleaseOwnerBuff__str.Length > 0) { 
		 ReleaseOwnerBuff_ = data["ReleaseOwnerBuff_"].ToString().Split (',');
		} else {
ReleaseOwnerBuff_ = new string[0];}
		string ReleaseTargetBuff__str = data["ReleaseTargetBuff_"].ToString();
		if(ReleaseTargetBuff__str.Length > 0) { 
		 ReleaseTargetBuff_ = data["ReleaseTargetBuff_"].ToString().Split (',');
		} else {
ReleaseTargetBuff_ = new string[0];}
		AppliedOwnerBlink = data["AppliedOwnerBlink"].ToString();
		AppliedAnimation = data["AppliedAnimation"].ToString();
		AppliedAttackMethod = data["AppliedAttackMethod"].ToString();
		AttackEntityType = data["AttackEntityType"].ToString();
		TargetType = data["TargetType"].ToString();
		AppliedHitmarkName = data["AppliedHitmarkName"].ToString();
		TargetVitalOffset = data["TargetVitalOffset"].ToString() != "0";
		AppliedOwnerFV = data["AppliedOwnerFV"].ToString();
		AppliedTargetFV = data["AppliedTargetFV"].ToString();
		DropObjectType = data["DropObjectType"].ToString();
		DropCurrency = data["DropCurrency"].ToString();
		DropObjectCount = int.Parse(data["DropObjectCount"].ToString());
		DropObjectAddCount = int.Parse(data["DropObjectAddCount"].ToString());
		DropObjectValue = int.Parse(data["DropObjectValue"].ToString());
		DropObjectAddValue = int.Parse(data["DropObjectAddValue"].ToString());
		ChargingBuff = data["ChargingBuff"].ToString();

    }

	public PassiveItem () {
	
	}
}
