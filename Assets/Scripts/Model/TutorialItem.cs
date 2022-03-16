using UnityEngine;
using System.Collections;
using LitJson;

public class TutorialItem : DataItem  {
	public int TID;
	public override int Identity(){ return TID; }
	public string Name;
	public string NameKr;
	public bool PerCharacter;
	public bool IsPrologue;

    public override void Setup(JsonData data) {
		base.Setup(data);
		TID = int.Parse(data["TID"].ToString());
		Name = data["Name"].ToString();
		NameKr = data["NameKr"].ToString();
		PerCharacter = data["PerCharacter"].ToString() != "0";
		IsPrologue = data["IsPrologue"].ToString() != "0";

    }

	public TutorialItem () {
	
	}
}
