using UnityEngine;
using System.Collections;
using LitJson;

public class DroneItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Grade;
	public string Passive;
	public string Buff;
	public int MaxLevel;
	public string Currency;
	public int Price;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Grade = data["Grade"].ToString();
		Passive = data["Passive"].ToString();
		Buff = data["Buff"].ToString();
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		Currency = data["Currency"].ToString();
		Price = int.Parse(data["Price"].ToString());

    }

	public DroneItem () {
	
	}
}
