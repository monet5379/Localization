using LitJson;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JsonDataManager
{
    public enum _Sheet
    {
        Ability,

        Buff,

        Character,

        CharacterTrait,

        Color,

        Core,

        Drone,

        DroneWeapon,

        DropObject,

        ForceVelocity,

        Gacha,

        GameConstant,

        Gear,

        Passive,

        Projectile,

        RiskLevel,

        RiskTrait,

        Stack,

        Stat,

        Tutorial,

        Weapon,

        WeaponEnhance,

        WeaponPassive,

        //

        CharacterString,

        CoreString,

        DiceString,

        GearString,

        MapObjectString,

        MonsterString,

        LoadingString,

        StageString,

        StateString,

        StatString,

        String,

        TalkString,

        WarningString,

        WeaponString,

        DroneString,
    }

    private static Dictionary<string, AbilityItem> abilitySheetData = new Dictionary<string, AbilityItem>();

    private static Dictionary<int, BuffItem> buffSheetData = new Dictionary<int, BuffItem>();

    private static Dictionary<int, CharacterItem> characterSheetData = new Dictionary<int, CharacterItem>();

    private static Dictionary<int, CharacterTraitItem> characterTraitSheetData = new Dictionary<int, CharacterTraitItem>();

    private static Dictionary<int, ColorItem> colorSheetData = new Dictionary<int, ColorItem>();

    private static Dictionary<int, CoreItem> coreSheetData = new Dictionary<int, CoreItem>();

    private static Dictionary<int, DroneItem> droneSheetData = new Dictionary<int, DroneItem>();

    private static Dictionary<int, DroneWeaponItem> droneWeaponSheetData = new Dictionary<int, DroneWeaponItem>();

    private static Dictionary<int, DropObjectItem> dropObjectSheetData = new Dictionary<int, DropObjectItem>();

    private static Dictionary<int, ForceVelocityItem> FVSheetData = new Dictionary<int, ForceVelocityItem>();

    private static Dictionary<int, GachaItem> gachaSheetData = new Dictionary<int, GachaItem>();

    private static Dictionary<int, GameConstantItem> gameConstantSheetData = new Dictionary<int, GameConstantItem>();

    private static Dictionary<int, GearItem> gearSheetData = new Dictionary<int, GearItem>();

    private static Dictionary<int, PassiveItem> passiveSheetData = new Dictionary<int, PassiveItem>();

    private static Dictionary<int, ProjectileItem> projectileSheetData = new Dictionary<int, ProjectileItem>();

    private static Dictionary<int, RiskLevelItem> riskLevelSheetData = new Dictionary<int, RiskLevelItem>();

    private static Dictionary<int, RiskTraitItem> riskTraitSheetData = new Dictionary<int, RiskTraitItem>();

    private static Dictionary<int, StackItem> stackSheetData = new Dictionary<int, StackItem>();

    private static Dictionary<int, StatItem> statSheetData = new Dictionary<int, StatItem>();

    private static Dictionary<string, StringItem> stringSheetData = new Dictionary<string, StringItem>();

    private static Dictionary<int, TalkStringItem> talkStringSheetData = new Dictionary<int, TalkStringItem>();

    private static Dictionary<int, TutorialItem> tutorialSheetData = new Dictionary<int, TutorialItem>();

    private static Dictionary<int, WeaponEnhanceItem> weaponEnhanceSheetData = new Dictionary<int, WeaponEnhanceItem>();

    private static Dictionary<int, WeaponPassiveItem> weaponPassiveSheetData = new Dictionary<int, WeaponPassiveItem>();

    private static Dictionary<int, WeaponItem> weaponSheetData = new Dictionary<int, WeaponItem>();

    [MenuItem("JsonData/Json 데이터 불러오기")]
    public static void LoadJsonData()
    {
        JsonDataManager.Load();
    }

    public static void Load()
    {
        _Sheet[] sheets = (_Sheet[])Enum.GetValues(typeof(_Sheet));

        for (int i = 0; i < sheets.Length; i++)
        {
            string fileNameWithExtention = string.Format("{0}.json", sheets[i].ToString());

            string path = PathManager.Lookup(fileNameWithExtention);

            if (false == string.IsNullOrEmpty(path))
            {
                TextAsset textAsset = Resources.Load<TextAsset>(path);

                if (null != textAsset)
                {
                    ParseJsonData(sheets[i], textAsset.text);
                }
            }
        }
    }

    public static void ParseJsonData(_Sheet sheet, string text)
    {
        JsonData jsonData = JsonMapper.ToObject(text)[0];

        switch (sheet)
        {
            case _Sheet.Ability:
                {
                    ParseAbilityJsonData(jsonData);
                }
                break;

            case _Sheet.Buff:
                {
                    ParseBuffJsonData(jsonData);
                }
                break;

            case _Sheet.Character:
                {
                    ParseCharacterJsonData(jsonData);
                }
                break;

            case _Sheet.CharacterTrait:
                {
                    ParseCharacterTraitJsonData(jsonData);
                }
                break;

            case _Sheet.Color:
                {
                    ParseColorJsonData(jsonData);
                }
                break;

            case _Sheet.Core:
                {
                    ParseCoreJsonData(jsonData);
                }
                break;

            case _Sheet.Drone:
                {
                    ParseDroneJsonData(jsonData);
                }
                break;

            case _Sheet.DroneWeapon:
                {
                    ParseDroneWeaponJsonData(jsonData);
                }
                break;

            case _Sheet.DropObject:
                {
                    ParseDropObjectJsonData(jsonData);
                }
                break;

            case _Sheet.ForceVelocity:
                {
                    ParseForceVelocityJsonData(jsonData);
                }
                break;

            case _Sheet.Gacha:
                {
                    ParseGachaJsonData(jsonData);
                }
                break;

            case _Sheet.GameConstant:
                {
                    ParseGameConstantJsonData(jsonData);
                }
                break;

            case _Sheet.Gear:
                {
                    ParseGearJsonData(jsonData);
                }
                break;

            case _Sheet.Passive:
                {
                    ParsePassiveJsonData(jsonData);
                }
                break;

            case _Sheet.Projectile:
                {
                    ParseProjectileJsonData(jsonData);
                }
                break;

            case _Sheet.RiskLevel:
                {
                    ParseRiskLevelJsonData(jsonData);
                }
                break;

            case _Sheet.RiskTrait:
                {
                    ParseRiskTraitJsonData(jsonData);
                }
                break;

            case _Sheet.Stack:
                {
                    ParseStackJsonData(jsonData);
                }
                break;

            case _Sheet.Stat:
                {
                    ParseStatJsonData(jsonData);
                }
                break;

            case _Sheet.String:
            case _Sheet.CharacterString:
            case _Sheet.StatString:
            case _Sheet.CoreString:
            case _Sheet.DiceString:
            case _Sheet.MonsterString:
            case _Sheet.LoadingString:
            case _Sheet.WeaponString:
            case _Sheet.StateString:
            case _Sheet.StageString:
            case _Sheet.WarningString:
            case _Sheet.DroneString:
            case _Sheet.GearString:
            case _Sheet.MapObjectString:
                {
                    ParseStringJsonData(jsonData);
                }
                break;

            case _Sheet.TalkString:
                {
                    ParseTalkStringJsonData(jsonData);
                }
                break;

            case _Sheet.Tutorial:
                {
                    ParseTutorialJsonData(jsonData);
                }
                break;

            case _Sheet.Weapon:
                {
                    ParseWeaponJsonData(jsonData);
                }
                break;

            case _Sheet.WeaponPassive:
                {
                    ParseWeaponPassiveJsonData(jsonData);
                }
                break;

            case _Sheet.WeaponEnhance:
                {
                    ParseWeaponEnhanceJsonData(jsonData);
                }
                break;
        }

        Debug.LogFormat("Load 'JsonData'. Sheet: {0}", sheet);
    }

    private static void ParseAbilityJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            AbilityItem item = new AbilityItem();

            item.Setup(jsonData[i]);

            if (abilitySheetData.ContainsKey(item.StringIdentity()))
            {
                abilitySheetData.Add(item.StringIdentity(), item);
            }
        }
    }

    private static void ParseCharacterJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            CharacterItem item = new CharacterItem();

            item.Setup(jsonData[i]);

            if (characterSheetData.ContainsKey(item.Identity()))
            {
                characterSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseCharacterTraitJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            CharacterTraitItem item = new CharacterTraitItem();

            item.Setup(jsonData[i]);

            if (characterTraitSheetData.ContainsKey(item.Identity()))
            {
                characterTraitSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseRiskTraitJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            RiskTraitItem item = new RiskTraitItem();

            item.Setup(jsonData[i]);

            if (riskTraitSheetData.ContainsKey(item.Identity()))
            {
                riskTraitSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseDropObjectJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            DropObjectItem item = new DropObjectItem();

            item.Setup(jsonData[i]);

            if (dropObjectSheetData.ContainsKey(item.Identity()))
            {
                dropObjectSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseWeaponJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            WeaponItem item = new WeaponItem();

            item.Setup(jsonData[i]);

            if (weaponSheetData.ContainsKey(item.Identity()))
            {
                weaponSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseForceVelocityJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            ForceVelocityItem item = new ForceVelocityItem();

            item.Setup(jsonData[i]);

            if (FVSheetData.ContainsKey(item.Identity()))
            {
                FVSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseWeaponPassiveJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            WeaponPassiveItem item = new WeaponPassiveItem();

            item.Setup(jsonData[i]);

            if (weaponPassiveSheetData.ContainsKey(item.Identity()))
            {
                weaponPassiveSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseWeaponEnhanceJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            WeaponEnhanceItem item = new WeaponEnhanceItem();

            item.Setup(jsonData[i]);

            if (weaponEnhanceSheetData.ContainsKey(item.Identity()))
            {
                weaponEnhanceSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseProjectileJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            ProjectileItem item = new ProjectileItem();

            item.Setup(jsonData[i]);

            if (projectileSheetData.ContainsKey(item.Identity()))
            {
                projectileSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseStatJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            StatItem item = new StatItem();

            item.Setup(jsonData[i]);

            if (statSheetData.ContainsKey(item.Identity()))
            {
                statSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseTutorialJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            TutorialItem item = new TutorialItem();

            item.Setup(jsonData[i]);

            if (tutorialSheetData.ContainsKey(item.Identity()))
            {
                tutorialSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseStackJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            StackItem item = new StackItem();

            item.Setup(jsonData[i]);

            if (stackSheetData.ContainsKey(item.Identity()))
            {
                stackSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseCoreJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            CoreItem item = new CoreItem();

            item.Setup(jsonData[i]);

            if (coreSheetData.ContainsKey(item.Identity()))
            {
                coreSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParsePassiveJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            PassiveItem item = new PassiveItem();

            item.Setup(jsonData[i]);

            if (passiveSheetData.ContainsKey(item.Identity()))
            {
                passiveSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseBuffJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            BuffItem item = new BuffItem();

            item.Setup(jsonData[i]);

            if (buffSheetData.ContainsKey(item.Identity()))
            {
                buffSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseGearJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            GearItem item = new GearItem();

            item.Setup(jsonData[i]);

            if (gearSheetData.ContainsKey(item.Identity()))
            {
                gearSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseDroneJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            DroneItem item = new DroneItem();

            item.Setup(jsonData[i]);

            if (droneSheetData.ContainsKey(item.Identity()))
            {
                droneSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseDroneWeaponJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            DroneWeaponItem item = new DroneWeaponItem();

            item.Setup(jsonData[i]);

            if (droneWeaponSheetData.ContainsKey(item.Identity()))
            {
                droneWeaponSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseColorJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            ColorItem item = new ColorItem();

            item.Setup(jsonData[i]);

            if (colorSheetData.ContainsKey(item.Identity()))
            {
                colorSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseGachaJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            GachaItem item = new GachaItem();

            item.Setup(jsonData[i]);

            if (gachaSheetData.ContainsKey(item.Identity()))
            {
                gachaSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseRiskLevelJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            RiskLevelItem item = new RiskLevelItem();

            item.Setup(jsonData[i]);

            if (riskLevelSheetData.ContainsKey(item.Identity()))
            {
                riskLevelSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseStringJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            StringItem item = new StringItem();

            item.Setup(jsonData[i]);

            if (stringSheetData.ContainsKey(item.StringIdentity()))
            {
                stringSheetData.Add(item.StringIdentity(), item);
            }
        }
    }

    private static void ParseTalkStringJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            TalkStringItem item = new TalkStringItem();

            item.Setup(jsonData[i]);

            if (talkStringSheetData.ContainsKey(item.Identity()))
            {
                talkStringSheetData.Add(item.Identity(), item);
            }
        }
    }

    private static void ParseGameConstantJsonData(JsonData jsonData)
    {
        for (int i = 0; i < jsonData.Count; i++)
        {
            GameConstantItem item = new GameConstantItem();

            item.Setup(jsonData[i]);

            if (gameConstantSheetData.ContainsKey(item.Identity()))
            {
                gameConstantSheetData.Add(item.Identity(), item);
            }
        }
    }
}