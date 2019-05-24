using UnityEngine;
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System.IO;
#endif
/// <summary>
/// インスペクターからResources/BGM内のaudioclipをpopupで選択できる拡張
/// stringのフィールにattribute SelectBGMをつけて使用する
/// /// </summary>
class SelectBGMAttribute : PropertyAttribute { }
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SelectBGMAttribute))]

public class SelectionBGM : PropertyDrawer
{
    List<string> list;
    List<string> AllBgmName
    {
        get
        {

            List<string> BGMNames = new List<string>();
            //Resources/BGMからSceneのPathを読み込む  

            foreach (var s in Resources.LoadAll("BGM"))
            {
                string n = s.ToString();
                BGMNames.Add(n.Replace(" (UnityEngine.AudioClip)", ""));
            }
            return BGMNames;
        }
        //[Resources/BGM]フォルダからBGMを探す

    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        if(list==null)list= AllBgmName;
        if (list != AllBgmName) list = AllBgmName;


        var selectedIndex = list.FindIndex(item => item.Equals(property.stringValue));
        if (selectedIndex == -1)
        {
            selectedIndex = list.FindIndex(item => item.Equals(list[0]));
        }

        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, list.ToArray());

        property.stringValue = list[selectedIndex];
    }

}

#endif



