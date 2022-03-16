using UnityEngine;
using System.Collections;
using LitJson;

public class CharacterTraitItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Character;
	public int Step;
	public string Type;
	public string[] Passive_;
	public string[] Buff_;
	public int UnlockCharacterLevel;
	public int MaxLevel;
	public string Currency;
	public int Price;
	public int AddPrice;
	public bool IsBlock;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Character = data["Character"].ToString();
		Step = int.Parse(data["Step"].ToString());
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
		UnlockCharacterLevel = int.Parse(data["UnlockCharacterLevel"].ToString());
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		Currency = data["Currency"].ToString();
		Price = int.Parse(data["Price"].ToString());
		AddPrice = int.Parse(data["AddPrice"].ToString());
		IsBlock = data["IsBlock"].ToString() != "0";

    }

	public CharacterTraitItem () {
	
	}
}
