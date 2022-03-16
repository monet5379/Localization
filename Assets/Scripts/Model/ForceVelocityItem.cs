using UnityEngine;
using System.Collections;
using LitJson;

public class ForceVelocityItem : DataItem  {
	public string Name;
	public override string StringIdentity(){ return Name; }
	public string Subject;
	public bool IsDamage;
	public bool IsPiercing;
	public int Priority;
	public float Delay;
	public float Duration;
	public string Application;
	public string[] Stat_;
	public string Buff;
	public string Trail;
	public string Direction;
	public float VelocityX;
	public float VelocityY;
	public bool UseGravity;
	public bool UseCustomGravity;
	public float Gravity;
	public bool UseAccelerationX;
	public bool UseAccelerationY;
	public float AccelerationX;
	public float AccelerationY;
	public bool UseForceFriction;
	public float Friction;
	public bool UseAirResist;
	public float AirResist;
	public float AirResistFlyingMonster;
	public bool StopXOnHitWall;
	public bool StopXOnHitGround;
	public bool StopYOnHitGround;
	public bool DirectionalFacing;
	public bool ReverseDirectionalFacing;
	public bool IgnorePlatform;
	public bool IgnoreCharacterInAir;

    public override void Setup(JsonData data) {
		base.Setup(data);
		Name = data["Name"].ToString();
		Subject = data["Subject"].ToString();
		IsDamage = data["IsDamage"].ToString() != "0";
		IsPiercing = data["IsPiercing"].ToString() != "0";
		Priority = int.Parse(data["Priority"].ToString());
		Delay = float.Parse(data["Delay"].ToString());
		Duration = float.Parse(data["Duration"].ToString());
		Application = data["Application"].ToString();
		string Stat__str = data["Stat_"].ToString();
		if(Stat__str.Length > 0) { 
		 Stat_ = data["Stat_"].ToString().Split (',');
		} else {
Stat_ = new string[0];}
		Buff = data["Buff"].ToString();
		Trail = data["Trail"].ToString();
		Direction = data["Direction"].ToString();
		VelocityX = float.Parse(data["VelocityX"].ToString());
		VelocityY = float.Parse(data["VelocityY"].ToString());
		UseGravity = data["UseGravity"].ToString() != "0";
		UseCustomGravity = data["UseCustomGravity"].ToString() != "0";
		Gravity = float.Parse(data["Gravity"].ToString());
		UseAccelerationX = data["UseAccelerationX"].ToString() != "0";
		UseAccelerationY = data["UseAccelerationY"].ToString() != "0";
		AccelerationX = float.Parse(data["AccelerationX"].ToString());
		AccelerationY = float.Parse(data["AccelerationY"].ToString());
		UseForceFriction = data["UseForceFriction"].ToString() != "0";
		Friction = float.Parse(data["Friction"].ToString());
		UseAirResist = data["UseAirResist"].ToString() != "0";
		AirResist = float.Parse(data["AirResist"].ToString());
		AirResistFlyingMonster = float.Parse(data["AirResistFlyingMonster"].ToString());
		StopXOnHitWall = data["StopXOnHitWall"].ToString() != "0";
		StopXOnHitGround = data["StopXOnHitGround"].ToString() != "0";
		StopYOnHitGround = data["StopYOnHitGround"].ToString() != "0";
		DirectionalFacing = data["DirectionalFacing"].ToString() != "0";
		ReverseDirectionalFacing = data["ReverseDirectionalFacing"].ToString() != "0";
		IgnorePlatform = data["IgnorePlatform"].ToString() != "0";
		IgnoreCharacterInAir = data["IgnoreCharacterInAir"].ToString() != "0";

    }

	public ForceVelocityItem () {
	
	}
}
