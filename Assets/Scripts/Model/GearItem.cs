using UnityEngine;
using System.Collections;
using LitJson;

public class GearItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string NameKorean;
	public string Grade;
	public string[] Passive_;
	public string[] Buff_;
	public int MaxLevel;
	public int ActiveCount;
	public float ActiveCooldown;
	public string Currency;
	public int Price;
	public bool IsBlock;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		NameKorean = data["NameKorean"].ToString();
		Grade = data["Grade"].ToString();
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
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		ActiveCount = int.Parse(data["ActiveCount"].ToString());
		ActiveCooldown = float.Parse(data["ActiveCooldown"].ToString());
		Currency = data["Currency"].ToString();
		Price = int.Parse(data["Price"].ToString());
		IsBlock = data["IsBlock"].ToString() != "0";

    }

	public GearItem () {
	
	}
}
