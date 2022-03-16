using UnityEngine;
using System.Collections;
using LitJson;

public class TalkStringItem : DataItem  {
	public string TID;
	public override string StringIdentity(){ return TID; }
	public string Type;
	public int BubblePointIndex;
	public string Stage;
	public string TalkCharacter;
	public string Speaker;
	public string Player;
	public string Tutorial;
	public string CompleteTutorial;
	public int Affinity;
	public bool IsComplete;
	public int MaxParagraph;
	public int Paragraph;
	public int Index;
	public bool IsEnd;
	public string Korean;
	public string English;
	public string ChineseSimplified;
	public string ChineseTraditional;
	public string Japanese;
	public string Russian;
	public string German;

    public override void Setup(JsonData data) {
		base.Setup(data);
		TID = data["TID"].ToString();
		Type = data["Type"].ToString();
		BubblePointIndex = int.Parse(data["BubblePointIndex"].ToString());
		Stage = data["Stage"].ToString();
		TalkCharacter = data["TalkCharacter"].ToString();
		Speaker = data["Speaker"].ToString();
		Player = data["Player"].ToString();
		Tutorial = data["Tutorial"].ToString();
		CompleteTutorial = data["CompleteTutorial"].ToString();
		Affinity = int.Parse(data["Affinity"].ToString());
		IsComplete = data["IsComplete"].ToString() != "0";
		MaxParagraph = int.Parse(data["MaxParagraph"].ToString());
		Paragraph = int.Parse(data["Paragraph"].ToString());
		Index = int.Parse(data["Index"].ToString());
		IsEnd = data["IsEnd"].ToString() != "0";
		Korean = data["Korean"].ToString();
		English = data["English"].ToString();
		ChineseSimplified = data["ChineseSimplified"].ToString();
		ChineseTraditional = data["ChineseTraditional"].ToString();
		Japanese = data["Japanese"].ToString();
		Russian = data["Russian"].ToString();
		German = data["German"].ToString();

    }

	public TalkStringItem () {
	
	}
}
