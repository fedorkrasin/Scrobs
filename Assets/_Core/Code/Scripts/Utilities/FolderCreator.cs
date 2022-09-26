using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class FolderCreator : EditorWindow
{
    private const string RootFolder = "Assets/_Core";

    [MenuItem("Assets/Create Default Folders")]
    private static void SetUpFolders()
    {
        var window = CreateInstance<FolderCreator>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 200, 200);
        window.ShowPopup();
    }

    private static void CreateAllFolders()
    {
        CreateRootFolder();

        var folders = new List<string>
        {
            "Art",
            "Audio",
            "Code",
            "Docs",
            "Level"
        };

        var artFolders = new List<string>
        {
            "Animations",
            "Materials",
            "Models",
            "Sprites",
            "Textures",
            "VFX"
        };
        
        var audioFolders = new List<string>
        {
            "Music",
            "Sound"
        };
        
        var codeFolders = new List<string>
        {
            "ScriptableObjects",
            "Scripts",
            "Shaders"
        };
        
        var levelFolders = new List<string>
        {
            "Prefabs",
            "Scenes",
            "UI"
        };
        
        var uiFolders = new List<string>
        {
            "Elements",
            "Screens",
            "Fonts"
        };

        CreateFolders(folders);
        CreateFolders(artFolders, "/Art");
        CreateFolders(audioFolders, "/Audio");
        CreateFolders(codeFolders, "/Code");
        CreateFolders(levelFolders, "/Level");
        CreateFolders(uiFolders, "/Level/UI");
        
        AssetDatabase.Refresh();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Create Folders");
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate", GUILayout.Width(200), GUILayout.Height(40)))
        {
            CreateAllFolders();
            Close();
        }
        
        GUILayout.Space(20);
        if (GUILayout.Button("Close Window", GUILayout.Width(200), GUILayout.Height(40)))
        {
            Close();
        }
    }

    private static void CreateRootFolder()
    {
        if (!Directory.Exists(RootFolder))
        {
            Directory.CreateDirectory(RootFolder);
        }
    }

    private static void CreateFolders(List<string> folders, string path)
    {
        foreach (var folder in folders.Where(folder => !Directory.Exists(RootFolder + folder)))
        {
            Directory.CreateDirectory(RootFolder + path + "/" + folder);
        }
    }
    
    private static void CreateFolders(List<string> folders)
    {
        foreach (var folder in folders.Where(folder => !Directory.Exists(RootFolder + folder)))
        {
            Directory.CreateDirectory(RootFolder + "/" + folder);
        }
    }
}
