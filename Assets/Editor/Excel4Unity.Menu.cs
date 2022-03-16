using UnityEditor;

public partial class Excel4Unity : Editor
{
    protected static string[] kDataFileNames =
    {
        "/Ability.xlsx",
        "/AttackableArea.xlsx",
        "/Buff.xlsx",
        "/Character.xlsx",
        "/CharacterTrait.xlsx",
        "/Color.xlsx",
        "/Core.xlsx",
        "/Drone.xlsx",
        "/DropObject.xlsx",
        "/ForceVelocity.xlsx",
        "/Gacha.xlsx",
        "/GameConstant.xlsx",
        "/Gear.xlsx",
        "/Passive.xlsx",
        "/Projectile.xlsx",
        "/RiskLevel.xlsx",
        "/Stack.xlsx",
        "/Stat.xlsx",
        "/StringData.xlsx",
        "/Tutorial.xlsx",
        "/Weapon.xlsx",
        "/WeaponEnhance.xlsx",
        "/WeaponPassive.xlsx",
    };

    [MenuItem("ExcelData/개별 엑셀 데이터를 가져오기")]
    public static void AbilityExcel2JSON()
    {
        ParseExcel("/WeaponEnhance.xlsx");
        ParseExcel("/WeaponPassive.xlsx");

        EditorUtility.DisplayDialog("Successed!", "Parse file.", "OK");
    }

    [MenuItem("ExcelData/모든 엑셀 데이터를 가져오기")]
    public static void AllExcel2JSON()
    {
        for (int i = 0; i < kDataFileNames.Length; i++)
        {
            ParseExcel(kDataFileNames[i]);
        }

        EditorUtility.DisplayDialog("Successed!", "Parse all file.", "OK");
    }

    /*

    [MenuItem("Excel4Unity/Test/ReadWrite")]
    private static void ReadWrite()
    {
        Excel xls = new Excel();
        ExcelTable table = new ExcelTable
        {
            TableName = "test"
        };
        string outputPath = Application.dataPath + "/Test/Test2.xlsx";
        xls.Tables.Add(table);
        xls.Tables[0].SetValue(1, 1, "1");
        xls.Tables[0].SetValue(1, 2, "2");
        xls.Tables[0].SetValue(2, 1, "3");
        xls.Tables[0].SetValue(2, 2, "4");
        xls.ShowLog();
        ExcelHelper.SaveExcel(xls, outputPath);
    }

    [MenuItem("Excel4Unity/Test/Read")]
    private static void Read()
    {
        string path = Application.dataPath + "/Test/Test3.xlsx";
        Excel xls = ExcelHelper.LoadExcel(path);
        xls.ShowLog();
    }

    [MenuItem("Excel4Unity/Test/Write")]
    private static void Write()
    {
        Excel xls = new Excel();
        ExcelTable table = new ExcelTable
        {
            TableName = "test"
        };
        string outputPath = Application.dataPath + "/Test/Test2.xlsx";
        xls.Tables.Add(table);
        xls.Tables[0].SetValue(1, 1, Random.Range(1000, 100000).ToString());
        xls.ShowLog();
        ExcelHelper.SaveExcel(xls, outputPath);
    }

    [MenuItem("Excel4Unity/Test/GenerateModel")]
    private static void GenerateModel()
    {
        string path = Application.dataPath + "/Test/Test4.xlsx";
        Excel xls = ExcelHelper.LoadExcel(path);
        ExcelDeserializer ed = new ExcelDeserializer
        {
            FieldNameLine = 1,
            FieldTypeLine = 2,
            FieldDescLine = 3,
            FieldValueLine = 4,
            IgnoreSymbol = "#",
            ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt"
        };
        ed.GenerateCS(xls.Tables[0]);
    }

    [MenuItem(@"Excel4Unity/Test/Excel2JSON")]
    private static void Excel2JSON()
    {
        Object[] selectedObjects = Selection.objects;
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            string excelPath = AssetDatabase.GetAssetPath(selectedObjects[i]);

            if (excelPath.EndsWith(".xlsx"))
            {
                Excel4Unity.ParseFile(excelPath);
            }
            else
            {
                EditorUtility.DisplayDialog("提示", "暂不支持的文件格式" + excelPath, "ok");

                return;
            }
        }
        AssetDatabase.Refresh();
    }

    */
}