using UnityEngine;
using System.Collections;
using LitJson;

public class BuffItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Type;
	public bool IsStatusEffect;
	public bool IsCrowdControl;
	public bool IsDeleteOnResurrection;
	public int MaxLevel;
	public bool IsInheritLevel;
	public string Application;
	public float Probability;
	public string Time;
	public float DelayTime;
	public float Duration;
	public float LevelDuration;
	public float Interval;
	public string StatName1;
	public float DefaultValue1;
	public float LevelValue1;
	public float GradeValue1;
	public string StatName2;
	public float DefaultValue2;
	public float LevelValue2;
	public float GradeValue2;
	public string StatName3;
	public float DefaultValue3;
	public float LevelValue3;
	public float GradeValue3;
	public bool UseStack;
	public string StackName;
	public string Core;
	public string[] ImmuneBuff_;
	public string[] ImmuneFV_;
	public string[] ImmuneHitmark_;
	public string ReleaseAddBuff;
	public string ReleaseRemoveBuff;
	public string Incompatible;
	public int Priority;
	public string ActivateHitmark;
	public string DeactivateHitmark;
	public string ApplySFX;
	public string DeactiveSFX;
	public string CharacterVFX;
	public string EnchantCoreVFX;
	public string ActivateVFX;
	public string ApplyVFX;
	public string DeactiveVFX;
	public string RendererColor;
	public bool UseFloatyText;
	public bool UseReleaseFloatyText;
	public bool UseArea;
	public string TargetCharacterInArea;
	public float AreaRadius;
	public string AppliedBuffInArea;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Type = data["Type"].ToString();
		IsStatusEffect = data["IsStatusEffect"].ToString() != "0";
		IsCrowdControl = data["IsCrowdControl"].ToString() != "0";
		IsDeleteOnResurrection = data["IsDeleteOnResurrection"].ToString() != "0";
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		IsInheritLevel = data["IsInheritLevel"].ToString() != "0";
		Application = data["Application"].ToString();
		Probability = float.Parse(data["Probability"].ToString());
		Time = data["Time"].ToString();
		DelayTime = float.Parse(data["DelayTime"].ToString());
		Duration = float.Parse(data["Duration"].ToString());
		LevelDuration = float.Parse(data["LevelDuration"].ToString());
		Interval = float.Parse(data["Interval"].ToString());
		StatName1 = data["StatName1"].ToString();
		DefaultValue1 = float.Parse(data["DefaultValue1"].ToString());
		LevelValue1 = float.Parse(data["LevelValue1"].ToString());
		GradeValue1 = float.Parse(data["GradeValue1"].ToString());
		StatName2 = data["StatName2"].ToString();
		DefaultValue2 = float.Parse(data["DefaultValue2"].ToString());
		LevelValue2 = float.Parse(data["LevelValue2"].ToString());
		GradeValue2 = float.Parse(data["GradeValue2"].ToString());
		StatName3 = data["StatName3"].ToString();
		DefaultValue3 = float.Parse(data["DefaultValue3"].ToString());
		LevelValue3 = float.Parse(data["LevelValue3"].ToString());
		GradeValue3 = float.Parse(data["GradeValue3"].ToString());
		UseStack = data["UseStack"].ToString() != "0";
		StackName = data["StackName"].ToString();
		Core = data["Core"].ToString();
		string ImmuneBuff__str = data["ImmuneBuff_"].ToString();
		if(ImmuneBuff__str.Length > 0) { 
		 ImmuneBuff_ = data["ImmuneBuff_"].ToString().Split (',');
		} else {
ImmuneBuff_ = new string[0];}
		string ImmuneFV__str = data["ImmuneFV_"].ToString();
		if(ImmuneFV__str.Length > 0) { 
		 ImmuneFV_ = data["ImmuneFV_"].ToString().Split (',');
		} else {
ImmuneFV_ = new string[0];}
		string ImmuneHitmark__str = data["ImmuneHitmark_"].ToString();
		if(ImmuneHitmark__str.Length > 0) { 
		 ImmuneHitmark_ = data["ImmuneHitmark_"].ToString().Split (',');
		} else {
ImmuneHitmark_ = new string[0];}
		ReleaseAddBuff = data["ReleaseAddBuff"].ToString();
		ReleaseRemoveBuff = data["ReleaseRemoveBuff"].ToString();
		Incompatible = data["Incompatible"].ToString();
		Priority = int.Parse(data["Priority"].ToString());
		ActivateHitmark = data["ActivateHitmark"].ToString();
		DeactivateHitmark = data["DeactivateHitmark"].ToString();
		ApplySFX = data["ApplySFX"].ToString();
		DeactiveSFX = data["DeactiveSFX"].ToString();
		CharacterVFX = data["CharacterVFX"].ToString();
		EnchantCoreVFX = data["EnchantCoreVFX"].ToString();
		ActivateVFX = data["ActivateVFX"].ToString();
		ApplyVFX = data["ApplyVFX"].ToString();
		DeactiveVFX = data["DeactiveVFX"].ToString();
		RendererColor = data["RendererColor"].ToString();
		UseFloatyText = data["UseFloatyText"].ToString() != "0";
		UseReleaseFloatyText = data["UseReleaseFloatyText"].ToString() != "0";
		UseArea = data["UseArea"].ToString() != "0";
		TargetCharacterInArea = data["TargetCharacterInArea"].ToString();
		AreaRadius = float.Parse(data["AreaRadius"].ToString());
		AppliedBuffInArea = data["AppliedBuffInArea"].ToString();

    }

	public BuffItem () {
	
	}
}
