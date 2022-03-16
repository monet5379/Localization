using UnityEngine;
using System.Collections;
using LitJson;

public class WeaponPassiveItem : DataItem
{
	public int TID;
	public override int Identity() { return TID; }
	public int Index;
	public string Name;
	public string WeaponName;
	public string[] Passive_;
	public string[] Buff_;
	public string CurrencyName;
	public int MaxLevel;
	public int Price;

	public override void Setup(JsonData data)
	{
		base.Setup(data);
		TID = int.Parse(data["TID"].ToString());
		Index = int.Parse(data["Index"].ToString());
		Name = data["Name"].ToString();
		WeaponName = data["WeaponName"].ToString();
		string Passive__str = data["Passive_"].ToString();
		if (Passive__str.Length > 0)
		{
			Passive_ = data["Passive_"].ToString().Split(',');
		}
		else
		{
			Passive_ = new string[0];
		}
		string Buff__str = data["Buff_"].ToString();
		if (Buff__str.Length > 0)
		{
			Buff_ = data["Buff_"].ToString().Split(',');
		}
		else
		{
			Buff_ = new string[0];
		}
		CurrencyName = data["CurrencyName"].ToString();
		MaxLevel = int.Parse(data["MaxLevel"].ToString());
		Price = int.Parse(data["Price"].ToString());

	}

	public WeaponPassiveItem()
	{

	}
}
