using UnityEngine;
using System.Collections;
using LitJson;

public class DiceStringItem : DataItem  {
	public string ID;
	public override string StringIdentity(){ return ID; }
	public string Korean;
	public string English;
	public string ChineseSimplified;
	public string ChineseTraditional;
	public string Japanese;
	public string Russian;
	public string German;
	public int Arguments;

    public override void Setup(JsonData data) {
		base.Setup(data);
		ID = data["ID"].ToString();
		Korean = data["Korean"].ToString();
		English = data["English"].ToString();
		ChineseSimplified = data["ChineseSimplified"].ToString();
		ChineseTraditional = data["ChineseTraditional"].ToString();
		Japanese = data["Japanese"].ToString();
		Russian = data["Russian"].ToString();
		German = data["German"].ToString();
		Arguments = int.Parse(data["Arguments"].ToString());

    }

	public DiceStringItem () {
	
	}
}
