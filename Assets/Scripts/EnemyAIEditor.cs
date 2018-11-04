/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAI))]
[CanEditMultipleObjects]
public class EnemyAIEditor : Editor {
    SerializedProperty initialState;
    SerializedProperty patrolType;
    SerializedProperty isFacingRight;
    SerializedProperty patrolOffset;
    SerializedProperty patrolStandTime;
    SerializedProperty speed;
    SerializedProperty patrolRange;
    SerializedProperty chaseRange;
    SerializedProperty guardRange;

    public bool showSettings = false;

    private void OnEnable()
    {
        initialState = serializedObject.FindProperty("initialState");
        patrolType = serializedObject.FindProperty("patrolType");
        isFacingRight = serializedObject.FindProperty("isFacingRight");
        patrolOffset = serializedObject.FindProperty("patrolOffset");
        patrolStandTime = serializedObject.FindProperty("patrolStandTime");
        speed = serializedObject.FindProperty("speed");
        patrolRange = serializedObject.FindProperty("patrolRange");
        chaseRange = serializedObject.FindProperty("chaseRange");
        guardRange = serializedObject.FindProperty("guardRange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(initialState);
        
        // if initial state is patrol
        if (initialState.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(patrolType);
        }

        EditorGUILayout.PropertyField(isFacingRight);

        showSettings = EditorGUILayout.Foldout(showSettings, "Settings");

        if (showSettings)
        {
            EditorGUILayout.PropertyField(patrolOffset);
            EditorGUILayout.PropertyField(patrolStandTime);
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.PropertyField(patrolRange);
            EditorGUILayout.PropertyField(chaseRange);
            EditorGUILayout.PropertyField(guardRange);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
*/