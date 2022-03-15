using System.IO;
using UnityEditor;
using UnityEngine;

//using LitJson;

public class ExcelDeserializer
{
    public int FieldNameLine;
    public int FieldTypeLine;
    public int FieldValueLine;

    public string IgnoreSymbol = string.Empty;
    public string ModelPath = Application.dataPath + "/Editor/Excel4Unity/DataItem.txt";

    public bool GenerateCS(ExcelTable table)
    {
        string moudle = File.ReadAllText(ModelPath);
        string properties = "";
        string parse = "";
        int tableColumn = 0;

        string propName;
        string propType;

        try
        {
            for (int j = 1; j <= table.NumberOfColumns; j++)
            {
                tableColumn = j;
                propName = table.GetValue(FieldNameLine, j).ToString();
                propType = table.GetValue(FieldTypeLine, j).ToString().ToLower();

                if (false == string.IsNullOrEmpty(IgnoreSymbol))
                {
                    if (propName.StartsWith(IgnoreSymbol))
                    {
                        continue;
                    }
                }

                if (string.IsNullOrEmpty(propName))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(propType))
                {
                    continue;
                }

                if (properties.Length == 0)
                {
                    properties += string.Format("\tpublic {0} {1};\n", propType, propName);

                    if (propType.Equals("string"))
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
                    properties += string.Format("\tpublic {0} {1};\n", propType, propName);
                }

                if (propType == "string")
                {
                    parse += string.Format("\t\t{0} = data[\"{1}\"].ToString();\n", propName, propName);
                }
                else if (propType == "bool")
                {
                    parse += string.Format("\t\t{0} = data[\"{1}\"].ToString() != \"0\";\n", propName, propName);
                }
                else if (propType == "int" || propType == "float" || propType == "double")
                {
                    parse += string.Format("\t\t{0} = {1}.Parse(data[\"{2}\"].ToString());\n", propName, propType, propName);
                }
                else if (propType == "string[]")
                {
                    string subType = propType.Replace("[]", "");
                    parse += string.Format("\t\tstring {0}_str = data[\"{1}\"].ToString();\n", propName, propName);
                    parse += "\t\tif(" + propName + "_str.Length > 0) { \n";
                    parse += string.Format("\t\t {0} = data[\"{1}\"].ToString().Split (';');\n", propName, propName);
                    string elseStr = string.Format("{0} = new {1}[0];", propName, subType);
                    parse += "\t\t} else {" + elseStr + "}\n";
                }
                else if (propType == "int[]" || propType == "float[]" || propType == "double[]")
                {
                    string subType = propType.Replace("[]", "");
                    parse += string.Format("\t\tstring {0}_str = data[\"{1}\"].ToString();\n", propName, propName);
                    parse += "\t\tif(" + propName + "_str.Length > 0) { \n";
                    parse += string.Format("\t\tstring[] {0}_data = data[\"{1}\"].ToString().Split (';');\n", propName, propName);
                    parse += string.Format("\t\t{0} = new {1}[{2}_data.Length];\n", propName, subType, propName);
                    parse += "\t\tfor (int i = 0; i < " + propName + "_data.Length; i++) { " + propName + "[i] = " + subType + ".Parse (" + propName + "_data [i]);}\n";
                    string elseStr = string.Format("{0} = new {1}[0];", propName, subType);
                    parse += "\t\t} else {" + elseStr + "}\n";
                }
                else
                {
                    Debug.LogError("generate .cs failed! " + propType + " not a valid type" + " " + "table:" + table.TableName);
                    return false;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            Debug.LogError("generate .cs failed: [" + table.TableName + "]!");
            return false;
        }

        moudle = moudle.Replace("{0}", table.TableName + "Item");
        moudle = moudle.Replace("{1}", properties);
        moudle = moudle.Replace("{2}", table.TableName + "Item");
        moudle = moudle.Replace("{3}", parse);

        string directoryPath = string.Concat(Application.dataPath, "/Scripts/Model/");
        string fileName = string.Concat(table.TableName, "Item.cs");
        string filePath = string.Concat(directoryPath, fileName);

        string fileContent = string.Empty;
        if (File.Exists(filePath))
        {
            fileContent = File.ReadAllText(filePath);
        }

        string directoryName = Path.GetDirectoryName(filePath);
        if (false == Directory.Exists(directoryName))
        {
            Debug.LogFormat("Create Directory: {0}", directoryPath);

            Directory.CreateDirectory(directoryName);
        }

        if (fileContent != moudle)
        {
            Debug.LogFormat("Change File. {0}", fileName);

            File.WriteAllText(filePath, moudle);
        }

        AssetDatabase.Refresh();

        return true;
    }
}