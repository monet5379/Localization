using UnityEngine;
using System.Collections;
using LitJson;

public class GachaItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public float Normal;
	public float Rare;
	public float Epic;
	public float Legendary;
	public float Hero;
	public float Risk;
	public float Active;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Normal = float.Parse(data["Normal"].ToString());
		Rare = float.Parse(data["Rare"].ToString());
		Epic = float.Parse(data["Epic"].ToString());
		Legendary = float.Parse(data["Legendary"].ToString());
		Hero = float.Parse(data["Hero"].ToString());
		Risk = float.Parse(data["Risk"].ToString());
		Active = float.Parse(data["Active"].ToString());

    }

	public GachaItem () {
	
	}
}
