using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAI))]
[CanEditMultipleObjects]
public class EnemyAIEditor : Editor {
    SerializedProperty levelStats;
    SerializedProperty initialState;
    SerializedProperty patrolType;
    SerializedProperty isFacingRight;
    SerializedProperty isJuggernaut;
    SerializedProperty patrolOffset;
    SerializedProperty patrolStandTime;
    SerializedProperty speed;
    SerializedProperty patrolRange;
    SerializedProperty chaseRange;
    SerializedProperty guardRange;
    SerializedProperty detectedSound;

    public bool showSettings = false;

    private void OnEnable()
    {
        levelStats = serializedObject.FindProperty("levelStats");
        initialState = serializedObject.FindProperty("initialState");
        patrolType = serializedObject.FindProperty("patrolType");
        isFacingRight = serializedObject.FindProperty("isFacingRight");
        isJuggernaut = serializedObject.FindProperty("isJuggernaut");
        patrolOffset = serializedObject.FindProperty("patrolOffset");
        patrolStandTime = serializedObject.FindProperty("patrolStandTime");
        speed = serializedObject.FindProperty("speed");
        patrolRange = serializedObject.FindProperty("patrolRange");
        chaseRange = serializedObject.FindProperty("chaseRange");
        guardRange = serializedObject.FindProperty("guardRange");
        detectedSound = serializedObject.FindProperty("detectedSound");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(levelStats);
        EditorGUILayout.PropertyField(initialState);
        
        // if initial state is patrol
        if (initialState.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(patrolType);
        }

        EditorGUILayout.PropertyField(isFacingRight);
        EditorGUILayout.PropertyField(isJuggernaut);

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

        EditorGUILayout.PropertyField(detectedSound);

        serializedObject.ApplyModifiedProperties();
    }
}
