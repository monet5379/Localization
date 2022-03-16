using UnityEngine;
using System.Collections;
using LitJson;

public class StatItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public bool IsDefaultStat;
	public float DefaultValue;
	public bool UseRange;
	public float MinValue;
	public float MaxValue;
	public string StatMod;
	public string Form;
	public string[] ApplyAttackMethod_;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		IsDefaultStat = data["IsDefaultStat"].ToString() != "0";
		DefaultValue = float.Parse(data["DefaultValue"].ToString());
		UseRange = data["UseRange"].ToString() != "0";
		MinValue = float.Parse(data["MinValue"].ToString());
		MaxValue = float.Parse(data["MaxValue"].ToString());
		StatMod = data["StatMod"].ToString();
		Form = data["Form"].ToString();
		string ApplyAttackMethod__str = data["ApplyAttackMethod_"].ToString();
		if(ApplyAttackMethod__str.Length > 0) { 
		 ApplyAttackMethod_ = data["ApplyAttackMethod_"].ToString().Split (',');
		} else {
ApplyAttackMethod_ = new string[0];}

    }

	public StatItem () {
	
	}
}
