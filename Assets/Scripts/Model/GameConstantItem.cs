using UnityEngine;
using System.Collections;
using LitJson;

public class GameConstantItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public float Value;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Value = float.Parse(data["Value"].ToString());

    }

	public GameConstantItem () {
	
	}
}
