using LitJson;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Excel4UnityEditor : Editor
{
    private const string kOutputDirectory = "/Resources/Data/";

    [MenuItem("Excel4Unity/Test/ReadWrite")]
    private static void ReadWrite()
    {
        Excel xls = new Excel();
        ExcelTable table = new ExcelTable();
        table.TableName = "test";
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
        ExcelTable table = new ExcelTable();
        table.TableName = "test";
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
        ExcelDeserializer ed = new ExcelDeserializer();
        ed.FieldNameLine = 1;
        ed.FieldTypeLine = 2;
        ed.FieldValueLine = 3;
        ed.IgnoreSymbol = "#";
        ed.ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt";
        ed.GenerateCS(xls.Tables[0]);
    }

    [MenuItem(@"Excel4Unity/Test/Excel2JSON")]
    private static void Excel2JSON()
    {
        Object[] selectedObject = Selection.objects;
        
        for (int i = 0; i < selectedObject.Length; i++)
        {
            string path = AssetDatabase.GetAssetPath(selectedObject[i]);
            if (path.EndsWith(".xlsx"))
            {
                Excel4UnityEditor.ParseFile(path);
            }
            else
            {
                EditorUtility.DisplayDialog("Error", string.Format("지원하지 않는 형식입니다. {0}", path), "Ok");
                return;
            }
        }
        AssetDatabase.Refresh();
    }

    public static string ParseFile(string path, bool createCS = true, bool isMac = false)
    {
        if (false == path.EndsWith("xlsx"))
        {
            return null;
        }

        string tableName = "";
        string currentPropName = "";
        int tableRow = 0;
        int tableColumn = 0;
        string tableValue = "";
        Excel excel = null;

        StringBuilder stringBuilder = new StringBuilder();
        excel = ExcelHelper.LoadExcel(path);

        try
        {
            JsonWriter writer = new JsonWriter(stringBuilder);
            writer.WriteObjectStart();
            foreach (ExcelTable table in excel.Tables)
            {
                tableName = table.TableName;
                bool language = tableName.ToLower().Contains("language");
                if (table.TableName.StartsWith("#"))
                {
                    continue;
                }
                if (createCS)
                {
                    ExcelDeserializer ed = new ExcelDeserializer();
                    ed.FieldNameLine = 1;
                    ed.FieldTypeLine = 2;
                    ed.FieldValueLine = 3;
                    ed.IgnoreSymbol = "#";

                    ed.ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt";

                    ed.GenerateCS(table);
                }

                writer.WritePropertyName(table.TableName);
                writer.WriteArrayStart();

                for (int i = 4; i <= table.NumberOfRows; i++)
                {
                    tableRow = i;
                    string idStr = table.GetValue(i, 1).ToString();
                    if (idStr.Length <= 0)
                    {
                        //						UnityEngine.Debug.LogError ("ID error:" + tableName + "  (第" + i + "行)");
                        break;
                    }
                    writer.WriteObjectStart();

                    for (int j = 1; j <= table.NumberOfColumns; j++)
                    {
                        tableColumn = j;
                        string propName = table.GetValue(1, j).ToString();
                        string propType = table.GetValue(3, j).ToString();
                        propName = propName.Replace("*", "");
                        currentPropName = propName;

                        if (propName.StartsWith("#"))
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(propName) || string.IsNullOrEmpty(propType))
                        {
                            continue;
                        }
                        writer.WritePropertyName(propName);
                        tableValue = table.GetValue(i, j).ToString();
                        if (propType.Equals("int"))
                        {
                            int value = tableValue.Length > 0 ? int.Parse(tableValue) : 0;
                            writer.Write(value);
                        }
                        else if (propType.Equals("bool"))
                        {
                            int value = tableValue.Length > 0 ? int.Parse(tableValue) : 0;
                            writer.Write(value);
                        }
                        else if (propType.Equals("float"))
                        {
                            float value = tableValue.Length > 0 ? float.Parse(tableValue) : 0;
                            writer.Write(value);
                        }
                        else
                        {
                            string ss = table.GetValue(i, j).ToString();
                            if (language && ss.Contains(" "))
                            {
                                ss = ss.Replace(" ", "\u00A0");
                            }
                            writer.Write(ss);
                        }
                    }
                    writer.WriteObjectEnd();
                }
                writer.WriteArrayEnd();
            }
            writer.WriteObjectEnd();

            string outputDir = Application.dataPath + kOutputDirectory;
            string outputPath = outputDir + Path.GetFileNameWithoutExtension(path) + ".txt";
            if (false == Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            string str = string.Empty;
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                UTF8Encoding encoding = new UTF8Encoding();
                str = encoding.GetString(bytes);
            }
            string content = stringBuilder.ToString();
            if (str != content)
            {
                File.WriteAllText(outputPath, content);
            }
            Debug.Log("convert success! path = " + path);

            return stringBuilder.ToString();
        }
        catch (System.Exception exception)
        {
            if (excel == null)
            {
                Debug.LogErrorFormat("엑셀 파일을 여는데 실패했습니다. {0}", exception.StackTrace);
            }
            else
            {
                stringBuilder.Clear();

                stringBuilder.AppendFormat("테이블 이름: {0},", tableName);
                stringBuilder.AppendFormat("변수 이름: {0},", currentPropName);
                stringBuilder.AppendFormat("테이블 위치: ({0}, {1})", tableRow, tableColumn);
                stringBuilder.AppendFormat("변수 값: {0}", tableValue);

                EditorUtility.DisplayDialog("error!", stringBuilder.ToString(), "ok");
                Debug.LogError(exception);
                Debug.LogError(exception.StackTrace);
                Debug.LogError(stringBuilder.ToString());
            }
            return null;
        }
    }

    public static void ErrorLogParseFile()
    {
    }
}