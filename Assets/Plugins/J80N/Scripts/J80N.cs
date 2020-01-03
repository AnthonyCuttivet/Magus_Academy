using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.IO;
using LitJson;

namespace J80N {
    public class Translator{

        public static string JsonToString;
        public static JsonData J80NData;

        private static void InstanciateTranslator(){
            JsonToString = Resources.Load<TextAsset>("J80N").ToString();
            J80NData = JsonMapper.ToObject(JsonToString);
        }

        public static string Translate(string codedIdentifier){
            if(JsonToString == null){
                InstanciateTranslator();
            }
            if(GetValue(codedIdentifier) == "NULL"){
                Debug.LogError("An error occured, dialogue name seems incorrect.");
                return "NULL";
            }else{
                return GetValue(codedIdentifier);
            }

        }

        public static string GetValue(string identifier){
            JsonData data = J80NData;
            string value = "NULL";
            string[] iKeys = (identifier.Split('.'));
            foreach(var key in iKeys){
                data = data[key];
                if(data.IsString){
                    value = GetDataToString(data);
                }
            }
            return value;
        }


        public static string GetDataToString(JsonData data){
            if(data.ToString().Contains("<var=")){
                return SetVar(data.ToString());
            }else{
                return data.ToString();
            }
        }

        public static string SetVar(string line){
            if(line.Contains("<var=" + GetVarName(line) + "/>")){
                return line.Replace("<var=" + GetVarName(line) + "/>", GetVarValue(GetVarName(line)));
            }else{
                Debug.LogError("No <var=/> tag found in line, please check : " + line);
                return null;
            } 
        }

        public static string GetVarName(string line){
            int pFrom = line.IndexOf("<var=") + "<var=".Length;
            int pTo = line.LastIndexOf("/>");

            return line.Substring(pFrom, pTo - pFrom);
        }

        public static string GetVarValue(string varName){
            //return typeof(DialogueVars).GetProperty(varName).GetValue(null).ToString();
            return "";
        }


    }

}

