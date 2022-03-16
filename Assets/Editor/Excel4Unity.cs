using LitJson;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public partial class Excel4Unity : Editor
{
    private static string outputDirectory = "/Resources/Data/";

    private static string outputPath;

    private static void ParseExcel(string excelName)
    {
        try
        {
            DirectoryInfo dataPath = Directory.GetParent(Application.dataPath);

            string filePath = string.Format("{0}/Sheet/{1}", dataPath.ToString(), excelName);

            ParseFile(filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    public static string ParseFile(string excelPath, bool createCS = true, bool isMac = false)
    {
        if (false == excelPath.EndsWith("xlsx"))
        {
            return null;
        }

        Excel excel = ExcelHelper.LoadExcel(excelPath);

        string jsonString = WriteJson(excel, createCS);
        string outputDir = Application.dataPath + outputDirectory;
        string outputPath = outputDir + Path.GetFileNameWithoutExtension(excelPath) + ".json";
        string excelContent = ReadExcel(excelPath);

        CreateDirectory(outputDir);

        if (excelContent != jsonString)
        {
            File.WriteAllText(outputPath, jsonString);
        }

        Debug.LogFormat("엑셀파일 변환에 성공하였습니다.  path: {0}", excelPath);

        return jsonString;
    }

    private static string WriteJson(Excel excel, bool createCS)
    {
        StringBuilder stringBuilder = new StringBuilder();
        JsonWriter writer = new JsonWriter(stringBuilder);

        int tableRow = 0;
        int tableColumn = 0;

        string tableName = string.Empty;
        string currentPropName = string.Empty;
        string currentPropType = string.Empty;
        string tableValue = string.Empty;
        bool language = false;

        try
        {
            writer.WriteObjectStart();

            foreach (ExcelTable excelTable in excel.Tables)
            {
                tableName = excelTable.TableName;

                language = tableName.ToLower().Contains("language");

                if (excelTable.TableName.StartsWith("#"))
                {
                    continue;
                }

                if (createCS)
                {
                    CreateClass(excelTable);
                }

                writer.WritePropertyName(excelTable.TableName);

                writer.WriteArrayStart();

                // row 0 : 키값
                // row 1 : 타입
                // row 2 : 설명
                for (int row = 4; row <= excelTable.NumberOfRows; row++)
                {
                    tableRow = row;

                    string idString = excelTable.GetValue(row, 1).ToString();
                    if (idString.Length <= 0)
                    {
                        break;
                    }

                    writer.WriteObjectStart();

                    for (int column = 1; column <= excelTable.NumberOfColumns; column++)
                    {
                        tableColumn = column;

                        string propName = excelTable.GetValue(1, column).ToString();
                        string propType = excelTable.GetValue(2, column).ToString();

                        propName = propName.Replace("*", "");
                        currentPropName = propName;
                        currentPropType = propType;

                        if (propName.StartsWith("#"))
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(propName) || string.IsNullOrEmpty(propType))
                        {
                            continue;
                        }

                        writer.WritePropertyName(propName);

                        tableValue = excelTable.GetValue(row, column).ToString();

                        ParseTableValue(propType, tableValue, ref writer);
                    }

                    writer.WriteObjectEnd();
                }

                writer.WriteArrayEnd();
            }

            writer.WriteObjectEnd();
        }
        catch (System.Exception exception)
        {
            if (excel == null)
            {
                string message = string.Format("엑셀파일을 여는 데 실패하였습니다.  stackTrace: {0}", exception.StackTrace);

                EditorUtility.DisplayDialog("ERROR!", message, "OK");
                Debug.LogError(message);
                Debug.LogError(exception.StackTrace);
            }
            else
            {
                stringBuilder.AppendLine("엑셀파일을 여는 데 실패하였습니다.");
                stringBuilder.AppendLine("테이블 이름: " + tableName);
                stringBuilder.AppendLine("변수명:" + currentPropName);
                stringBuilder.AppendLine("행" + tableRow);
                stringBuilder.AppendLine("열" + tableColumn);
                stringBuilder.AppendLine("값= " + tableValue);

                EditorUtility.DisplayDialog("ERROR!", stringBuilder.ToString(), "OK");
                Debug.LogError(stringBuilder.ToString());
                Debug.LogError(exception);
                Debug.LogError(exception.StackTrace);
            }

            return null;
        }

        return stringBuilder.ToString();
    }

    private static void ParseTableValue(string propType, string tableValue, ref JsonWriter writer)
    {
        switch (propType)
        {
            case "bool":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write(false);
                    }
                    else
                    {
                        writer.Write(bool.Parse(tableValue));
                    }
                }
                break;

            case "int":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write(0);
                    }
                    else
                    {
                        int value = tableValue.Length > 0 ? int.Parse(tableValue) : 0;
                        writer.Write(value);
                    }
                }
                break;

            case "int[]":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write("0");
                    }
                    else
                    {
                        writer.Write(tableValue);
                    }
                }
                break;

            case "float":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write(0f);
                    }
                    else
                    {
                        float value = float.Parse(tableValue);
                        writer.Write(value);
                    }
                }
                break;

            case "float[]":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write("0");
                    }
                    else
                    {
                        writer.Write(tableValue);
                    }
                }
                break;

            case "double":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write(0);
                    }
                    else
                    {
                        double value = tableValue.Length > 0 ? double.Parse(tableValue) : 0;
                        writer.Write(value);
                    }
                }
                break;

            case "enum":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write("None");
                    }
                    else if (tableValue.Equals(null))
                    {
                        writer.Write("None");
                    }
                    else
                    {
                        writer.Write(tableValue);
                    }
                }
                break;

            case "enum[]":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write("None");
                    }
                    else if (string.IsNullOrEmpty(tableValue))
                    {
                        writer.Write("None");
                    }
                    else
                    {
                        writer.Write(tableValue);
                    }
                }
                break;

            case "string":
            case "string[]":
                {
                    if (tableValue.Equals("-"))
                    {
                        writer.Write("");
                    }
                    else if (string.IsNullOrEmpty(tableValue))
                    {
                        writer.Write("");
                    }
                    else
                    {
                        writer.Write(tableValue);
                    }
                }
                break;

            default:
                {
                    if (tableValue.Contains(" "))
                    {
                        tableValue = tableValue.Replace(" ", "\u00A0");
                    }

                    writer.Write(tableValue);
                }

                break;
        }
    }

    private static void CreateClass(ExcelTable excelTable)
    {
        ExcelDeserializer excelDeserializer = new ExcelDeserializer
        {
            FieldNameLine = 1,
            FieldTypeLine = 2,
            FieldDescLine = 3,
            FieldValueLine = 4,
            IgnoreSymbol = "#",
            ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt"
        };

        excelDeserializer.GenerateCS(excelTable);
    }

    private static string ReadExcel(string excelPath)
    {
        if (File.Exists(excelPath))
        {
            byte[] bytes = File.ReadAllBytes(excelPath);

            UTF8Encoding encoding = new UTF8Encoding();

            return encoding.GetString(bytes);
        }

        return string.Empty;
    }

    private static void CreateDirectory(string outputDir)
    {
        if (false == Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
    }
}