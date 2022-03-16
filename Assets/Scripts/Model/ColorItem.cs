using UnityEngine;
using System.Collections;
using LitJson;

public class ColorItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Type;
	public string Times;
	public int Priority;
	public float Duration;
	public float Interval;
	public float RestTime;
	public string Hex;
	public float Alpha;
	public float Intensity;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Type = data["Type"].ToString();
		Times = data["Times"].ToString();
		Priority = int.Parse(data["Priority"].ToString());
		Duration = float.Parse(data["Duration"].ToString());
		Interval = float.Parse(data["Interval"].ToString());
		RestTime = float.Parse(data["RestTime"].ToString());
		Hex = data["Hex"].ToString();
		Alpha = float.Parse(data["Alpha"].ToString());
		Intensity = float.Parse(data["Intensity"].ToString());

    }

	public ColorItem () {
	
	}
}
