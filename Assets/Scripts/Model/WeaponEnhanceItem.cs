using LitJson;

public class WeaponEnhanceItem : DataItem
{
    public int TID;

    public override int Identity()
    { return TID; }

    public int Index;

    public int Level;

    public string Name;

    public string WeaponName;

    public string AttackMethod;

    public string[] Passive_;

    public string[] RemovePassive_;

    public string[] Buff_;

    public string BuyingCurrency;

    public int BuyingPrice;

    public bool IsBlock;

    public string[] Incompatible_;

    public override void Setup(JsonData data)
    {
        base.Setup(data);
        TID = int.Parse(data["TID"].ToString());
        Index = int.Parse(data["Index"].ToString());
        Level = int.Parse(data["Level"].ToString());
        Name = data["Name"].ToString();
        WeaponName = data["WeaponName"].ToString();
        AttackMethod = data["AttackMethod"].ToString();
        string Passive__str = data["Passive_"].ToString();
        if (Passive__str.Length > 0)
        {
            Passive_ = data["Passive_"].ToString().Split(',');
        }
        else
        {
            Passive_ = new string[0];
        }
        string RemovePassive__str = data["RemovePassive_"].ToString();
        if (RemovePassive__str.Length > 0)
        {
            RemovePassive_ = data["RemovePassive_"].ToString().Split(',');
        }
        else
        {
            RemovePassive_ = new string[0];
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
        BuyingCurrency = data["BuyingCurrency"].ToString();
        BuyingPrice = int.Parse(data["BuyingPrice"].ToString());
        IsBlock = data["IsBlock"].ToString() != "0";
        string Incompatible__str = data["Incompatible_"].ToString();
        if (Incompatible__str.Length > 0)
        {
            Incompatible_ = data["Incompatible_"].ToString().Split(',');
        }
        else
        {
            Incompatible_ = new string[0];
        }
    }

    public WeaponEnhanceItem()
    {
    }
}