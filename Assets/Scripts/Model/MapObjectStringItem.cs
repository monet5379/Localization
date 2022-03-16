using UnityEngine;
using System.Collections;
using LitJson;

public class MapObjectStringItem : DataItem  {
	public string ID;
	public override string StringIdentity(){ return ID; }
	public int Arguments;
	public string Korean;
	public string English;
	public string ChineseSimplified;
	public string ChineseTraditional;
	public string Japanese;
	public string Russian;
	public string German;

    public override void Setup(JsonData data) {
		base.Setup(data);
		ID = data["ID"].ToString();
		Arguments = int.Parse(data["Arguments"].ToString());
		Korean = data["Korean"].ToString();
		English = data["English"].ToString();
		ChineseSimplified = data["ChineseSimplified"].ToString();
		ChineseTraditional = data["ChineseTraditional"].ToString();
		Japanese = data["Japanese"].ToString();
		Russian = data["Russian"].ToString();
		German = data["German"].ToString();

    }

	public MapObjectStringItem () {
	
	}
}
