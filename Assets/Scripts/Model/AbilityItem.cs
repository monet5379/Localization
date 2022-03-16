using UnityEngine;
using System.Collections;
using LitJson;

public class AbilityItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public bool UseForceJump;
	public bool UseForceJumpAttack;
	public string[] ForceJumpFVString;
	public bool UseDiveAttack;
	public string DiveStartFV;
	public string DiveAttackFV;
	public string[] DiveAttackBuffString;
	public int DiveManaCost;
	public string DiveVFX;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		UseForceJump = data["UseForceJump"].ToString() != "0";
		UseForceJumpAttack = data["UseForceJumpAttack"].ToString() != "0";
		string ForceJumpFVString_str = data["ForceJumpFVString"].ToString();
		if(ForceJumpFVString_str.Length > 0) { 
		 ForceJumpFVString = data["ForceJumpFVString"].ToString().Split (',');
		} else {
ForceJumpFVString = new string[0];}
		UseDiveAttack = data["UseDiveAttack"].ToString() != "0";
		DiveStartFV = data["DiveStartFV"].ToString();
		DiveAttackFV = data["DiveAttackFV"].ToString();
		string DiveAttackBuffString_str = data["DiveAttackBuffString"].ToString();
		if(DiveAttackBuffString_str.Length > 0) { 
		 DiveAttackBuffString = data["DiveAttackBuffString"].ToString().Split (',');
		} else {
DiveAttackBuffString = new string[0];}
		DiveManaCost = int.Parse(data["DiveManaCost"].ToString());
		DiveVFX = data["DiveVFX"].ToString();

    }

	public AbilityItem () {
	
	}
}
