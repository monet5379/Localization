using UnityEngine;
using System.Collections;
using LitJson;

public class DroneWeaponItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Grade;
	public string Currency;
	public int Price;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Grade = data["Grade"].ToString();
		Currency = data["Currency"].ToString();
		Price = int.Parse(data["Price"].ToString());

    }

	public DroneWeaponItem () {
	
	}
}
