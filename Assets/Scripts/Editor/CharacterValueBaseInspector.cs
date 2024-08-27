using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//TODO refactor to UI Toolkit
[CustomEditor(typeof(CharacterValueBase), editorForChildClasses: true)]
public class CharacterValueBaseInspector : Editor
{
    private CharacterValueBase targetObj;
    private void OnEnable()
    {
        targetObj = (CharacterValueBase)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            GUI.enabled = false;
            EditorGUILayout.TextField("BaseValue", targetObj.Value.BaseValue.ToString());
            EditorGUILayout.TextField("CurrentValue", targetObj.Value.CurrentValue.ToString());

            if (targetObj.Value.ValueCalculationInfo != null)
            {
                EditorGUILayout.BeginVertical("Box");
                foreach (ModifierInfo stepInfo in targetObj.Value.ValueCalculationInfo)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.TextField(stepInfo.Name.GetLocalizedString());
                    EditorGUILayout.TextField(stepInfo.ValueChange.ToString());
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
        }

        GUI.enabled = true;
    }
}
