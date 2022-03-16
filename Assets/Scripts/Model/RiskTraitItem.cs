using UnityEngine;
using System.Collections;
using LitJson;

public class RiskTraitItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Type;
	public string[] Passive_;
	public string[] Buff_;
	public string Character;
	public bool IsDefault;
	public bool IsBlock;
	public int MaxLevel;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Type = data["Type"].ToString();
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
		Character = data["Character"].ToString();
		IsDefault = data["IsDefault"].ToString() != "0";
		IsBlock = data["IsBlock"].ToString() != "0";
		MaxLevel = int.Parse(data["MaxLevel"].ToString());

    }

	public RiskTraitItem () {
	
	}
}
