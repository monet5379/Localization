using UnityEngine;
using System.Collections;
using LitJson;

public class DropObjectItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Type1;
	public string Currency1;
	public int SpawnCount1;
	public int TotalValue1;
	public float Probability1;
	public string Type2;
	public string Currency2;
	public int SpawnCount2;
	public int TotalValue2;
	public float Probability2;
	public string Type3;
	public string Currency3;
	public int SpawnCount3;
	public int TotalValue3;
	public float Probability3;
	public string Type4;
	public string Currency4;
	public int SpawnCount4;
	public int TotalValue4;
	public float Probability4;
	public string Type5;
	public string Currency5;
	public int SpawnCount5;
	public int TotalValue5;
	public float Probability5;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Type1 = data["Type1"].ToString();
		Currency1 = data["Currency1"].ToString();
		SpawnCount1 = int.Parse(data["SpawnCount1"].ToString());
		TotalValue1 = int.Parse(data["TotalValue1"].ToString());
		Probability1 = float.Parse(data["Probability1"].ToString());
		Type2 = data["Type2"].ToString();
		Currency2 = data["Currency2"].ToString();
		SpawnCount2 = int.Parse(data["SpawnCount2"].ToString());
		TotalValue2 = int.Parse(data["TotalValue2"].ToString());
		Probability2 = float.Parse(data["Probability2"].ToString());
		Type3 = data["Type3"].ToString();
		Currency3 = data["Currency3"].ToString();
		SpawnCount3 = int.Parse(data["SpawnCount3"].ToString());
		TotalValue3 = int.Parse(data["TotalValue3"].ToString());
		Probability3 = float.Parse(data["Probability3"].ToString());
		Type4 = data["Type4"].ToString();
		Currency4 = data["Currency4"].ToString();
		SpawnCount4 = int.Parse(data["SpawnCount4"].ToString());
		TotalValue4 = int.Parse(data["TotalValue4"].ToString());
		Probability4 = float.Parse(data["Probability4"].ToString());
		Type5 = data["Type5"].ToString();
		Currency5 = data["Currency5"].ToString();
		SpawnCount5 = int.Parse(data["SpawnCount5"].ToString());
		TotalValue5 = int.Parse(data["TotalValue5"].ToString());
		Probability5 = float.Parse(data["Probability5"].ToString());

    }

	public DropObjectItem () {
	
	}
}
