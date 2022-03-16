using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelDeserializer
{
    public int FieldNameLine;

    public int FieldTypeLine;

    public int FieldDescLine;

    public int FieldValueLine;

    public string IgnoreSymbol = string.Empty;

    public string ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt";

    public bool GenerateCS(ExcelTable table)
    {
        string moudle = File.ReadAllText(ModelPath);

        string properties = "";
        string parse = "";
        int tableColumn = 0;
        try
        {
            for (int j = 1; j <= table.NumberOfColumns; j++)
            {
                tableColumn = j;

                string propName = table.GetValue(FieldNameLine, j).ToString();

                string propType = table.GetValue(FieldTypeLine, j).ToString().ToLower();

                if (false == string.IsNullOrEmpty(IgnoreSymbol) && propName.StartsWith(IgnoreSymbol))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(propName) || string.IsNullOrEmpty(propType))
                {
                    continue;
                }

                if (properties.Length == 0)
                {
                    if (propType.Equals("enum"))
                    {
                        properties += string.Format("\tpublic string {0};\n", propName);
                    }
                    else if (propType.Equals("enum[]"))
                    {
                        properties += string.Format("\tpublic string[] {0};\n", propName);
                    }
                    else
                    {
                        properties += string.Format("\tpublic {0} {1};\n", propType, propName);
                    }

                    if (propType.Equals("string"))
                    {
                        properties += "\tpublic override string StringIdentity(){ return " + propName + "; }\n";
                    }
                    else if (propType.Equals("enum"))
                    {
                        properties += "\tpublic override string StringIdentity(){ return " + propName + "; }\n";
                    }
                    else
                    {
                        properties += "\tpublic override int Identity(){ return " + propName + "; }\n";
                    }
                }
                else
                {
                    if (propType.Equals("enum"))
                    {
                        properties += string.Format("\tpublic string {0};\n", propName);
                    }
                    else if (propType.Equals("enum[]"))
                    {
                        properties += string.Format("\tpublic string[] {0};\n", propName);
                    }
                    else
                    {
                        properties += string.Format("\tpublic {0} {1};\n", propType, propName);
                    }
                }

                if (propType == "bool")
                {
                    parse += string.Format("\t\t{0} = data[\"{1}\"].ToString() != \"0\";\n", propName, propName);
                }
                else if (propType == "int" || propType == "float" || propType == "double")
                {
                    parse += string.Format("\t\t{0} = {1}.Parse(data[\"{2}\"].ToString());\n", propName, propType, propName);
                }
                else if (propType == "string")
                {
                    parse += string.Format("\t\t{0} = data[\"{1}\"].ToString();\n", propName, propName);
                }
                else if (propType == "enum")
                {
                    parse += string.Format("\t\t{0} = data[\"{1}\"].ToString();\n", propName, propName);
                }
                else if (propType == "string[]")
                {
                    string subType = propType.Replace("[]", "");

                    parse += string.Format("\t\tstring {0}_str = data[\"{1}\"].ToString();\n", propName, propName);

                    parse += "\t\tif(" + propName + "_str.Length > 0) { \n";

                    parse += string.Format("\t\t {0} = data[\"{1}\"].ToString().Split (',');\n", propName, propName);

                    string elseStr = string.Format("{0} = new {1}[0];", propName, subType);

                    parse += "\t\t} else {\n" + elseStr + "}\n";
                }
                else if (propType == "enum[]")
                {
                    string subType = "string"; // propType.Replace("[]", "");

                    parse += string.Format("\t\tstring {0}_str = data[\"{1}\"].ToString();\n", propName, propName);

                    parse += "\t\tif(" + propName + "_str.Length > 0) { \n";

                    parse += string.Format("\t\t {0} = data[\"{1}\"].ToString().Split (',');\n", propName, propName);

                    string elseStr = string.Format("{0} = new {1}[0];", propName, subType);

                    parse += "\t\t} else {\n" + elseStr + "}\n";
                }
                else if (propType == "int[]" || propType == "float[]" || propType == "double[]")
                {
                    string subType = propType.Replace("[]", "");
                    parse += string.Format("\t\tstring {0}_str = data[\"{1}\"].ToString();\n", propName, propName);
                    parse += "\t\tif(" + propName + "_str.Length > 0) { \n";
                    parse += string.Format("\t\tstring[] {0}_data = data[\"{1}\"].ToString().Split (',');\n", propName, propName);
                    parse += string.Format("\t\t{0} = new {1}[{2}_data.Length];\n", propName, subType, propName);
                    parse += "\t\tfor (int i = 0; i < " + propName + "_data.Length; i++) \n{\n" + propName + "[i] = " + subType + ".Parse (" + propName + "_data [i]);}\n";
                    string elseStr = string.Format("{0} = new {1}[0];", propName, subType);
                    parse += "\t\t} else {\n" + elseStr + "}\n";
                }
                else
                {
                    Debug.LogErrorFormat("변환에 실패했습니다. 유효한 타입이 아닙니다. PropType:{0}, TableName:{1} ", propType, table.TableName);

                    return false;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            Debug.LogError("generate .cs failed: " + table.TableName + "!" + " " + "table:" + table.TableName);
            return false;
        }
        moudle = moudle.Replace("{0}", table.TableName + "Item");
        moudle = moudle.Replace("{1}", properties);
        moudle = moudle.Replace("{2}", table.TableName + "Item");
        moudle = moudle.Replace("{3}", parse);

        string path = string.Format("{0}/Scripts/Model/{1}Item.cs", Application.dataPath, table.TableName);
        string str = string.Empty;

        if (File.Exists(path))
        {
            str = File.ReadAllText(path);
        }

        string directory = Path.GetDirectoryName(path);
        if (false == Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (str != moudle)
        {
            Debug.LogFormat("{0} 테이블을 클래스로 변환하였습니다.", table.TableName);
            File.WriteAllText(path, moudle);
        }

        AssetDatabase.Refresh();

        return true;
    }
}