using UnityEngine;
using System.Collections;
using LitJson;

public class RiskLevelItem : DataItem  {
	public int TID;
	public override int Identity(){ return TID; }
	public float TimeToNextLevel;
	public int AppearEliteMinLevel;
	public int AppearEliteMaxLevel;

    public override void Setup(JsonData data) {
		base.Setup(data);
		TID = int.Parse(data["TID"].ToString());
		TimeToNextLevel = float.Parse(data["TimeToNextLevel"].ToString());
		AppearEliteMinLevel = int.Parse(data["AppearEliteMinLevel"].ToString());
		AppearEliteMaxLevel = int.Parse(data["AppearEliteMaxLevel"].ToString());

    }

	public RiskLevelItem () {
	
	}
}
