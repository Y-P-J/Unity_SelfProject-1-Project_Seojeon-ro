using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class StartSceneEditor : MonoBehaviour
{
    static StartSceneEditor()
    {
        var _pathOfFirstScene = EditorBuildSettings.scenes[0].path;
        var _sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(_pathOfFirstScene);
        EditorSceneManager.playModeStartScene = _sceneAsset;
    }
}
