using LitJson;

public class ProjectileItem : DataItem
{
    public int TID;

    public override int Identity()
    { return TID; }

    public string Name;

    public string Type;

    public string Hitmark;

    public string AnotherHitmark;

    public string ReturnHitmark;

    public string DamageMask;

    public string EraseMask;

    public string CollisionMask;

    public string CollisionTag;

    public string[] IgnoreCollisionTag_;

    public int CollisionCount;

    public bool GroundCheck;

    public bool GroundCheckOnSpawn;

    public float GroundCheckDistance;

    public bool UseOwnerPointForGroundCheck;

    public bool ForceReturn;

    public bool IsAttackOnSpawn;

    public bool IsAttackOnHit;

    public bool IsThrough;

    public int ThroughMaxCount;

    public bool IsFirstChain;

    public bool IsAnotherChain;

    public string RegisterTargetType;

    public int ChainCount;

    public bool DeactivePhysicsOnDestroy;

    public bool DeactivePhysicsOnDespawn;

    public bool IsIgnoreParrying;

    public float Speed;

    public float[] AddSpeed_;

    public float Acceleration;

    public float DelayTime;

    public float LifeTime;

    public float AddLifeTime;

    public float Distance;

    public float ArrivalDistance;

    public string TimeResult;

    public string DistanceResult;

    public string ArrivalResult;

    public string DamageResult;

    public string EraseResult;

    public string CollisionResult;

    public string InAirResult;

    public string LandingResult;

    public string AttackResult;

    public bool IsLinkedToOwner;

    public string DetectType;

    public bool IgnoreDetectSelf;

    public float DetectAngle;

    public string DetectAreaType;

    public float[] DetectAreaOffset_;

    public float[] DetectBoxSize_;

    public float DetectDistance;

    public float DetectMinDistance;

    public string[] DetectCharacter_;

    public string DetectPriority;

    public string LaunchType;

    public int Times;

    public int[] AddTimes_;

    public float Interval;

    public int CountAtTime;

    public int[] AddCountAtTime_;

    public string SpawnOffset;

    public float BoxWidth;

    public float BoxHeight;

    public string PointAlignments;

    public float PointsInterval;

    public string RaycastDirection;

    public float RaycastDistance;

    public float Angle;

    public float MaxAngle;

    public float SymmetryAngle;

    public float AngleInterval;

    public int AngleIntervalCount;

    public string AngleApplication;

    public string MotionType;

    public string MotionType2;

    public float GravityRate;

    public float RigidForceX;

    public float RigidMaxForceX;

    public float RigidForceY;

    public float RigidMaxForceY;

    public float RotateMinSpeed;

    public float RotateMaxSpeed;

    public string HomingTarget;

    public string HomingDirection;

    public string PrefabName;

    public string SpawnVFX;

    public override void Setup(JsonData data)
    {
        base.Setup(data);
        TID = int.Parse(data["TID"].ToString());
        Name = data["Name"].ToString();
        Type = data["Type"].ToString();
        Hitmark = data["Hitmark"].ToString();
        AnotherHitmark = data["AnotherHitmark"].ToString();
        ReturnHitmark = data["ReturnHitmark"].ToString();
        DamageMask = data["DamageMask"].ToString();
        EraseMask = data["EraseMask"].ToString();
        CollisionMask = data["CollisionMask"].ToString();
        CollisionTag = data["CollisionTag"].ToString();
        string IgnoreCollisionTag__str = data["IgnoreCollisionTag_"].ToString();
        if (IgnoreCollisionTag__str.Length > 0)
        {
            IgnoreCollisionTag_ = data["IgnoreCollisionTag_"].ToString().Split(',');
        }
        else
        {
            IgnoreCollisionTag_ = new string[0];
        }
        CollisionCount = int.Parse(data["CollisionCount"].ToString());
        GroundCheck = data["GroundCheck"].ToString() != "0";
        GroundCheckOnSpawn = data["GroundCheckOnSpawn"].ToString() != "0";
        GroundCheckDistance = float.Parse(data["GroundCheckDistance"].ToString());
        UseOwnerPointForGroundCheck = data["UseOwnerPointForGroundCheck"].ToString() != "0";
        ForceReturn = data["ForceReturn"].ToString() != "0";
        IsAttackOnSpawn = data["IsAttackOnSpawn"].ToString() != "0";
        IsAttackOnHit = data["IsAttackOnHit"].ToString() != "0";
        IsThrough = data["IsThrough"].ToString() != "0";
        ThroughMaxCount = int.Parse(data["ThroughMaxCount"].ToString());
        IsFirstChain = data["IsFirstChain"].ToString() != "0";
        IsAnotherChain = data["IsAnotherChain"].ToString() != "0";
        RegisterTargetType = data["RegisterTargetType"].ToString();
        ChainCount = int.Parse(data["ChainCount"].ToString());
        DeactivePhysicsOnDestroy = data["DeactivePhysicsOnDestroy"].ToString() != "0";
        DeactivePhysicsOnDespawn = data["DeactivePhysicsOnDespawn"].ToString() != "0";
        IsIgnoreParrying = data["IsIgnoreParrying"].ToString() != "0";
        Speed = float.Parse(data["Speed"].ToString());
        string AddSpeed__str = data["AddSpeed_"].ToString();
        if (AddSpeed__str.Length > 0)
        {
            string[] AddSpeed__data = data["AddSpeed_"].ToString().Split(',');
            AddSpeed_ = new float[AddSpeed__data.Length];
            for (int i = 0; i < AddSpeed__data.Length; i++)
            {
                AddSpeed_[i] = float.Parse(AddSpeed__data[i]);
            }
        }
        else
        {
            AddSpeed_ = new float[0];
        }
        Acceleration = float.Parse(data["Acceleration"].ToString());
        DelayTime = float.Parse(data["DelayTime"].ToString());
        LifeTime = float.Parse(data["LifeTime"].ToString());
        AddLifeTime = float.Parse(data["AddLifeTime"].ToString());
        Distance = float.Parse(data["Distance"].ToString());
        ArrivalDistance = float.Parse(data["ArrivalDistance"].ToString());
        TimeResult = data["TimeResult"].ToString();
        DistanceResult = data["DistanceResult"].ToString();
        ArrivalResult = data["ArrivalResult"].ToString();
        DamageResult = data["DamageResult"].ToString();
        EraseResult = data["EraseResult"].ToString();
        CollisionResult = data["CollisionResult"].ToString();
        InAirResult = data["InAirResult"].ToString();
        LandingResult = data["LandingResult"].ToString();
        AttackResult = data["AttackResult"].ToString();
        IsLinkedToOwner = data["IsLinkedToOwner"].ToString() != "0";
        DetectType = data["DetectType"].ToString();
        IgnoreDetectSelf = data["IgnoreDetectSelf"].ToString() != "0";
        DetectAngle = float.Parse(data["DetectAngle"].ToString());
        DetectAreaType = data["DetectAreaType"].ToString();
        string DetectAreaOffset__str = data["DetectAreaOffset_"].ToString();
        if (DetectAreaOffset__str.Length > 0)
        {
            string[] DetectAreaOffset__data = data["DetectAreaOffset_"].ToString().Split(',');
            DetectAreaOffset_ = new float[DetectAreaOffset__data.Length];
            for (int i = 0; i < DetectAreaOffset__data.Length; i++)
            {
                DetectAreaOffset_[i] = float.Parse(DetectAreaOffset__data[i]);
            }
        }
        else
        {
            DetectAreaOffset_ = new float[0];
        }
        string DetectBoxSize__str = data["DetectBoxSize_"].ToString();
        if (DetectBoxSize__str.Length > 0)
        {
            string[] DetectBoxSize__data = data["DetectBoxSize_"].ToString().Split(',');
            DetectBoxSize_ = new float[DetectBoxSize__data.Length];
            for (int i = 0; i < DetectBoxSize__data.Length; i++)
            {
                DetectBoxSize_[i] = float.Parse(DetectBoxSize__data[i]);
            }
        }
        else
        {
            DetectBoxSize_ = new float[0];
        }
        DetectDistance = float.Parse(data["DetectDistance"].ToString());
        DetectMinDistance = float.Parse(data["DetectMinDistance"].ToString());
        string DetectCharacter__str = data["DetectCharacter_"].ToString();
        if (DetectCharacter__str.Length > 0)
        {
            DetectCharacter_ = data["DetectCharacter_"].ToString().Split(',');
        }
        else
        {
            DetectCharacter_ = new string[0];
        }
        DetectPriority = data["DetectPriority"].ToString();
        LaunchType = data["LaunchType"].ToString();
        Times = int.Parse(data["Times"].ToString());
        string AddTimes__str = data["AddTimes_"].ToString();
        if (AddTimes__str.Length > 0)
        {
            string[] AddTimes__data = data["AddTimes_"].ToString().Split(',');
            AddTimes_ = new int[AddTimes__data.Length];
            for (int i = 0; i < AddTimes__data.Length; i++)
            {
                AddTimes_[i] = int.Parse(AddTimes__data[i]);
            }
        }
        else
        {
            AddTimes_ = new int[0];
        }
        Interval = float.Parse(data["Interval"].ToString());
        CountAtTime = int.Parse(data["CountAtTime"].ToString());
        string AddCountAtTime__str = data["AddCountAtTime_"].ToString();
        if (AddCountAtTime__str.Length > 0)
        {
            string[] AddCountAtTime__data = data["AddCountAtTime_"].ToString().Split(',');
            AddCountAtTime_ = new int[AddCountAtTime__data.Length];
            for (int i = 0; i < AddCountAtTime__data.Length; i++)
            {
                AddCountAtTime_[i] = int.Parse(AddCountAtTime__data[i]);
            }
        }
        else
        {
            AddCountAtTime_ = new int[0];
        }
        SpawnOffset = data["SpawnOffset"].ToString();
        BoxWidth = float.Parse(data["BoxWidth"].ToString());
        BoxHeight = float.Parse(data["BoxHeight"].ToString());
        PointAlignments = data["PointAlignments"].ToString();
        PointsInterval = float.Parse(data["PointsInterval"].ToString());
        RaycastDirection = data["RaycastDirection"].ToString();
        RaycastDistance = float.Parse(data["RaycastDistance"].ToString());
        Angle = float.Parse(data["Angle"].ToString());
        MaxAngle = float.Parse(data["MaxAngle"].ToString());
        SymmetryAngle = float.Parse(data["SymmetryAngle"].ToString());
        AngleInterval = float.Parse(data["AngleInterval"].ToString());
        AngleIntervalCount = int.Parse(data["AngleIntervalCount"].ToString());
        AngleApplication = data["AngleApplication"].ToString();
        MotionType = data["MotionType"].ToString();
        MotionType2 = data["MotionType2"].ToString();
        GravityRate = float.Parse(data["GravityRate"].ToString());
        RigidForceX = float.Parse(data["RigidForceX"].ToString());
        RigidMaxForceX = float.Parse(data["RigidMaxForceX"].ToString());
        RigidForceY = float.Parse(data["RigidForceY"].ToString());
        RigidMaxForceY = float.Parse(data["RigidMaxForceY"].ToString());
        RotateMinSpeed = float.Parse(data["RotateMinSpeed"].ToString());
        RotateMaxSpeed = float.Parse(data["RotateMaxSpeed"].ToString());
        HomingTarget = data["HomingTarget"].ToString();
        HomingDirection = data["HomingDirection"].ToString();
        PrefabName = data["PrefabName"].ToString();
        SpawnVFX = data["SpawnVFX"].ToString();
    }

    public ProjectileItem()
    {
    }
}