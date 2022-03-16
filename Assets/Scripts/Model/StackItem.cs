using UnityEngine;
using System.Collections;
using LitJson;

public class StackItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string CoreType;
	public bool IsStatusEffect;
	public bool UseSave;
	public float Duration;
	public float Interval;
	public float Cooldown;
	public int ActivateCount;
	public int RemoveCount;
	public int MaxCount;
	public string MaxResult;
	public string Buff;
	public int BuffStackCount;
	public bool UseBuffLevelToStack;
	public string AttackHitmark;
	public int AttackStackCount;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		CoreType = data["CoreType"].ToString();
		IsStatusEffect = data["IsStatusEffect"].ToString() != "0";
		UseSave = data["UseSave"].ToString() != "0";
		Duration = float.Parse(data["Duration"].ToString());
		Interval = float.Parse(data["Interval"].ToString());
		Cooldown = float.Parse(data["Cooldown"].ToString());
		ActivateCount = int.Parse(data["ActivateCount"].ToString());
		RemoveCount = int.Parse(data["RemoveCount"].ToString());
		MaxCount = int.Parse(data["MaxCount"].ToString());
		MaxResult = data["MaxResult"].ToString();
		Buff = data["Buff"].ToString();
		BuffStackCount = int.Parse(data["BuffStackCount"].ToString());
		UseBuffLevelToStack = data["UseBuffLevelToStack"].ToString() != "0";
		AttackHitmark = data["AttackHitmark"].ToString();
		AttackStackCount = int.Parse(data["AttackStackCount"].ToString());

    }

	public StackItem () {
	
	}
}
