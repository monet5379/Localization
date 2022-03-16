using UnityEngine;
using System.Collections;
using LitJson;

public class WeaponItem : DataItem  {
	public int TID;
	public override int Identity(){ return TID; }
	public int CharacterTID;
	public int Index;
	public string Name;
	public int MaxAmmo;
	public int SkillManaCost;
	public int SubWeaponManaCost;
	public int AttackMaxOrder;
	public string[] Passive_;
	public string[] Buff_;
	public string[] WeaponPassive_;
	public string[] WeaponEnhance_;
	public string[] AirAttack_;
	public string[] ChangedAirAttack_;
	public string[] Attack_;
	public string[] ChangedAttack_;
	public float StartCharge;
	public float MinCharge;
	public float MaxCharge;
	public bool AutoCharged;
	public bool ChargeMaxFloatyText;
	public string ChargingBuff;
	public string ChargeMaxBuff;
	public string ChargeAttack;
	public string ChargeSwapAttack;
	public string ChargeMinAttack;
	public string ChargeMaxAttack;
	public string ChangeChargeAttack;
	public string[] ChangeChargeMinAttack_;
	public string[] ChangeChargeMaxAttack_;
	public string[] Skill_;
	public string[] ChangedSkill_;
	public string[] SubWeapon_;
	public string[] ChangedSubWeapon_;
	public string Dash;
	public string[] DashAttack_;
	public string[] ChangedDashAttack_;
	public string[] ForceJumpAttack_;
	public string[] DiveAttack_;
	public string[] ParryingAttack_;
	public string[] DyingAttack_;
	public string[] ChangedDyingAttack_;

    public override void Setup(JsonData data) {
		base.Setup(data);
		TID = int.Parse(data["TID"].ToString());
		CharacterTID = int.Parse(data["CharacterTID"].ToString());
		Index = int.Parse(data["Index"].ToString());
		Name = data["Name"].ToString();
		MaxAmmo = int.Parse(data["MaxAmmo"].ToString());
		SkillManaCost = int.Parse(data["SkillManaCost"].ToString());
		SubWeaponManaCost = int.Parse(data["SubWeaponManaCost"].ToString());
		AttackMaxOrder = int.Parse(data["AttackMaxOrder"].ToString());
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
		string WeaponPassive__str = data["WeaponPassive_"].ToString();
		if(WeaponPassive__str.Length > 0) { 
		 WeaponPassive_ = data["WeaponPassive_"].ToString().Split (',');
		} else {
WeaponPassive_ = new string[0];}
		string WeaponEnhance__str = data["WeaponEnhance_"].ToString();
		if(WeaponEnhance__str.Length > 0) { 
		 WeaponEnhance_ = data["WeaponEnhance_"].ToString().Split (',');
		} else {
WeaponEnhance_ = new string[0];}
		string AirAttack__str = data["AirAttack_"].ToString();
		if(AirAttack__str.Length > 0) { 
		 AirAttack_ = data["AirAttack_"].ToString().Split (',');
		} else {
AirAttack_ = new string[0];}
		string ChangedAirAttack__str = data["ChangedAirAttack_"].ToString();
		if(ChangedAirAttack__str.Length > 0) { 
		 ChangedAirAttack_ = data["ChangedAirAttack_"].ToString().Split (',');
		} else {
ChangedAirAttack_ = new string[0];}
		string Attack__str = data["Attack_"].ToString();
		if(Attack__str.Length > 0) { 
		 Attack_ = data["Attack_"].ToString().Split (',');
		} else {
Attack_ = new string[0];}
		string ChangedAttack__str = data["ChangedAttack_"].ToString();
		if(ChangedAttack__str.Length > 0) { 
		 ChangedAttack_ = data["ChangedAttack_"].ToString().Split (',');
		} else {
ChangedAttack_ = new string[0];}
		StartCharge = float.Parse(data["StartCharge"].ToString());
		MinCharge = float.Parse(data["MinCharge"].ToString());
		MaxCharge = float.Parse(data["MaxCharge"].ToString());
		AutoCharged = data["AutoCharged"].ToString() != "0";
		ChargeMaxFloatyText = data["ChargeMaxFloatyText"].ToString() != "0";
		ChargingBuff = data["ChargingBuff"].ToString();
		ChargeMaxBuff = data["ChargeMaxBuff"].ToString();
		ChargeAttack = data["ChargeAttack"].ToString();
		ChargeSwapAttack = data["ChargeSwapAttack"].ToString();
		ChargeMinAttack = data["ChargeMinAttack"].ToString();
		ChargeMaxAttack = data["ChargeMaxAttack"].ToString();
		ChangeChargeAttack = data["ChangeChargeAttack"].ToString();
		string ChangeChargeMinAttack__str = data["ChangeChargeMinAttack_"].ToString();
		if(ChangeChargeMinAttack__str.Length > 0) { 
		 ChangeChargeMinAttack_ = data["ChangeChargeMinAttack_"].ToString().Split (',');
		} else {
ChangeChargeMinAttack_ = new string[0];}
		string ChangeChargeMaxAttack__str = data["ChangeChargeMaxAttack_"].ToString();
		if(ChangeChargeMaxAttack__str.Length > 0) { 
		 ChangeChargeMaxAttack_ = data["ChangeChargeMaxAttack_"].ToString().Split (',');
		} else {
ChangeChargeMaxAttack_ = new string[0];}
		string Skill__str = data["Skill_"].ToString();
		if(Skill__str.Length > 0) { 
		 Skill_ = data["Skill_"].ToString().Split (',');
		} else {
Skill_ = new string[0];}
		string ChangedSkill__str = data["ChangedSkill_"].ToString();
		if(ChangedSkill__str.Length > 0) { 
		 ChangedSkill_ = data["ChangedSkill_"].ToString().Split (',');
		} else {
ChangedSkill_ = new string[0];}
		string SubWeapon__str = data["SubWeapon_"].ToString();
		if(SubWeapon__str.Length > 0) { 
		 SubWeapon_ = data["SubWeapon_"].ToString().Split (',');
		} else {
SubWeapon_ = new string[0];}
		string ChangedSubWeapon__str = data["ChangedSubWeapon_"].ToString();
		if(ChangedSubWeapon__str.Length > 0) { 
		 ChangedSubWeapon_ = data["ChangedSubWeapon_"].ToString().Split (',');
		} else {
ChangedSubWeapon_ = new string[0];}
		Dash = data["Dash"].ToString();
		string DashAttack__str = data["DashAttack_"].ToString();
		if(DashAttack__str.Length > 0) { 
		 DashAttack_ = data["DashAttack_"].ToString().Split (',');
		} else {
DashAttack_ = new string[0];}
		string ChangedDashAttack__str = data["ChangedDashAttack_"].ToString();
		if(ChangedDashAttack__str.Length > 0) { 
		 ChangedDashAttack_ = data["ChangedDashAttack_"].ToString().Split (',');
		} else {
ChangedDashAttack_ = new string[0];}
		string ForceJumpAttack__str = data["ForceJumpAttack_"].ToString();
		if(ForceJumpAttack__str.Length > 0) { 
		 ForceJumpAttack_ = data["ForceJumpAttack_"].ToString().Split (',');
		} else {
ForceJumpAttack_ = new string[0];}
		string DiveAttack__str = data["DiveAttack_"].ToString();
		if(DiveAttack__str.Length > 0) { 
		 DiveAttack_ = data["DiveAttack_"].ToString().Split (',');
		} else {
DiveAttack_ = new string[0];}
		string ParryingAttack__str = data["ParryingAttack_"].ToString();
		if(ParryingAttack__str.Length > 0) { 
		 ParryingAttack_ = data["ParryingAttack_"].ToString().Split (',');
		} else {
ParryingAttack_ = new string[0];}
		string DyingAttack__str = data["DyingAttack_"].ToString();
		if(DyingAttack__str.Length > 0) { 
		 DyingAttack_ = data["DyingAttack_"].ToString().Split (',');
		} else {
DyingAttack_ = new string[0];}
		string ChangedDyingAttack__str = data["ChangedDyingAttack_"].ToString();
		if(ChangedDyingAttack__str.Length > 0) { 
		 ChangedDyingAttack_ = data["ChangedDyingAttack_"].ToString().Split (',');
		} else {
ChangedDyingAttack_ = new string[0];}

    }

	public WeaponItem () {
	
	}
}
