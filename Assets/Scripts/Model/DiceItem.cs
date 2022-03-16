using UnityEngine;
using System.Collections;
using LitJson;

public class DiceItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Buff_;
	public int MaxLevel1;
	public string Debuff;
	public int MaxLevel2;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Buff_ = data["Buff_"].ToString();
		MaxLevel1 = int.Parse(data["MaxLevel1"].ToString());
		Debuff = data["Debuff"].ToString();
		MaxLevel2 = int.Parse(data["MaxLevel2"].ToString());

    }

	public DiceItem () {
	
	}
}
