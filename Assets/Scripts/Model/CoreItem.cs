using UnityEngine;
using System.Collections;
using LitJson;

public class CoreItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Type;
	public string CoreAttackMethod;
	public int Priority;
	public string[] Passive_;
	public string[] Buff_;
	public string[] ReleasePassive_;
	public int MaxLevel;
	public float ActiveCooldown;
	public string[] LinkedCore_;
	public string[] Incompatible_;
	public string EnhanceConditionCore;
	public string[] EnhancedCore_;
	public string[] ConditionCore_;
	public int ConditionCoreCount;
	public string ConditionBuff;
	public string CustomGrade;
	public string BuyingCurrency;
	public int BuyingPrice;
	public bool IsBarrier;
	public bool IsBlock;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Type = data["Type"].ToString();
		CoreAttackMethod = data["CoreAttackMethod"].ToString();
		Priority = int.Parse(data["Priority"].ToString());
		string Passive__str = data["Passive_"].ToString();
		if(Passive__str.Length > 0) { 
		 Passive_ = data["Passive_"].ToString().Split (',');
		} else {
Passive_ = new string[0];}
		string Buff__str = data["Buff_"].ToString();
		if(Buff__str.Length > 0) { 
		 Buff_ = data["Buff_"].ToString().Split (',');
		} else {
Buff_ = new string[0];}
		string ReleasePassive__str = data["ReleasePassive_"].ToString();
		if(ReleasePassive__str.Length > 0) { 
		 ReleasePassive_ = data["ReleasePassive_"].ToString().Split (',');
		} else {
ReleasePassive_ = new string[0];}
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		ActiveCooldown = float.Parse(data["ActiveCooldown"].ToString());
		string LinkedCore__str = data["LinkedCore_"].ToString();
		if(LinkedCore__str.Length > 0) { 
		 LinkedCore_ = data["LinkedCore_"].ToString().Split (',');
		} else {
LinkedCore_ = new string[0];}
		string Incompatible__str = data["Incompatible_"].ToString();
		if(Incompatible__str.Length > 0) { 
		 Incompatible_ = data["Incompatible_"].ToString().Split (',');
		} else {
Incompatible_ = new string[0];}
		EnhanceConditionCore = data["EnhanceConditionCore"].ToString();
		string EnhancedCore__str = data["EnhancedCore_"].ToString();
		if(EnhancedCore__str.Length > 0) { 
		 EnhancedCore_ = data["EnhancedCore_"].ToString().Split (',');
		} else {
EnhancedCore_ = new string[0];}
		string ConditionCore__str = data["ConditionCore_"].ToString();
		if(ConditionCore__str.Length > 0) { 
		 ConditionCore_ = data["ConditionCore_"].ToString().Split (',');
		} else {
ConditionCore_ = new string[0];}
		ConditionCoreCount = int.Parse(data["ConditionCoreCount"].ToString());
		ConditionBuff = data["ConditionBuff"].ToString();
		CustomGrade = data["CustomGrade"].ToString();
		BuyingCurrency = data["BuyingCurrency"].ToString();
		BuyingPrice = int.Parse(data["BuyingPrice"].ToString());
		IsBarrier = data["IsBarrier"].ToString() != "0";
		IsBlock = data["IsBlock"].ToString() != "0";

    }

	public CoreItem () {
	
	}
}
