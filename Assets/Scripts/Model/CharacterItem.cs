using UnityEngine;
using System.Collections;
using LitJson;

public class CharacterItem : DataItem  {
	public int TID;
	public override int Identity(){ return TID; }
	public int Index;
	public string Type;
	public string Name;
	public int HP;
	public int MP;
	public int EXP;
	public float CriticalDamage;
	public float CriticalRate;
	public int DashCount;
	public float MoveSpeed;
	public float MoveSpeedInAir;
	public float JumpMaxHeight;
	public string DropObjectName;
	public string TargetType;
	public string TargetMask;
	public int SortingOrder;
	public bool IsFlying;
	public bool IsFallingOnDie;
	public float FallingDelayTime;
	public bool UseDefence;
	public string[] BlockRiskTrait_;
	public string[] Weapon_;
	public string[] SpawnBuff_;
	public string[] RemoveBattleReadyBuff_;

    public override void Setup(JsonData data) {
		base.Setup(data);
		TID = int.Parse(data["TID"].ToString());
		Index = int.Parse(data["Index"].ToString());
		Type = data["Type"].ToString();
		Name = data["Name"].ToString();
		HP = int.Parse(data["HP"].ToString());
		MP = int.Parse(data["MP"].ToString());
		EXP = int.Parse(data["EXP"].ToString());
		CriticalDamage = float.Parse(data["CriticalDamage"].ToString());
		CriticalRate = float.Parse(data["CriticalRate"].ToString());
		DashCount = int.Parse(data["DashCount"].ToString());
		MoveSpeed = float.Parse(data["MoveSpeed"].ToString());
		MoveSpeedInAir = float.Parse(data["MoveSpeedInAir"].ToString());
		JumpMaxHeight = float.Parse(data["JumpMaxHeight"].ToString());
		DropObjectName = data["DropObjectName"].ToString();
		TargetType = data["TargetType"].ToString();
		TargetMask = data["TargetMask"].ToString();
		SortingOrder = int.Parse(data["SortingOrder"].ToString());
		IsFlying = data["IsFlying"].ToString() != "0";
		IsFallingOnDie = data["IsFallingOnDie"].ToString() != "0";
		FallingDelayTime = float.Parse(data["FallingDelayTime"].ToString());
		UseDefence = data["UseDefence"].ToString() != "0";
		string BlockRiskTrait__str = data["BlockRiskTrait_"].ToString();
		if(BlockRiskTrait__str.Length > 0) { 
		 BlockRiskTrait_ = data["BlockRiskTrait_"].ToString().Split (',');
		} else {
BlockRiskTrait_ = new string[0];}
		string Weapon__str = data["Weapon_"].ToString();
		if(Weapon__str.Length > 0) { 
		 Weapon_ = data["Weapon_"].ToString().Split (',');
		} else {
Weapon_ = new string[0];}
		string SpawnBuff__str = data["SpawnBuff_"].ToString();
		if(SpawnBuff__str.Length > 0) { 
		 SpawnBuff_ = data["SpawnBuff_"].ToString().Split (',');
		} else {
SpawnBuff_ = new string[0];}
		string RemoveBattleReadyBuff__str = data["RemoveBattleReadyBuff_"].ToString();
		if(RemoveBattleReadyBuff__str.Length > 0) { 
		 RemoveBattleReadyBuff_ = data["RemoveBattleReadyBuff_"].ToString().Split (',');
		} else {
RemoveBattleReadyBuff_ = new string[0];}

    }

	public CharacterItem () {
	
	}
}
