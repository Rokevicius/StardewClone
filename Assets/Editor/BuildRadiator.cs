using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Rendering;

public class BuildRadiator
{
    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        string path = GetProjectFolderPath() + "/Builds";
        var filename = GetProjectName(); // do this so I can grab the project folder name
        BuildPlayer(BuildTargetGroup.Android, filename, path + "/");
    }

    [MenuItem("Build/Build iOS")]
    public static void BuildiOS()
    {
        string path = GetProjectFolderPath() + "/Builds";
        var filename = GetProjectName(); // do this so I can grab the project folder name
        BuildPlayer(BuildTargetGroup.iOS, filename, path + "/");
    }

    [MenuItem("Build/Build Android and iOS")]
    public static void BuildBoth()
    {
        BuildAndroid();
        BuildiOS();
    }

    static void BuildPlayer(BuildTargetGroup buildTargetGroup, string filename, string path)
    {
        string fileExtension = "";
        string modifier = "";
        BuildTarget buildTarget;
        ScriptingImplementation[] androidBackend = { ScriptingImplementation.Mono2x, ScriptingImplementation.IL2CPP };
        GraphicsDeviceType[] gfxAPIs = PlayerSettings.GetGraphicsAPIs(BuildTarget.Android);
        ManagedStrippingLevel[] mlvl = { ManagedStrippingLevel.Low, ManagedStrippingLevel.Medium, ManagedStrippingLevel.High };

        switch (buildTargetGroup)
        {
            default:
            case BuildTargetGroup.Android:
                buildTarget = BuildTarget.Android;
                modifier = "_Android";
                fileExtension = ".apk";
                break;
            case BuildTargetGroup.iOS:
                buildTarget = BuildTarget.iOS;
                modifier = "_iOS";
                fileExtension = ".xcode";
                break;
        }

        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTargetGroup, buildTarget);

        string buildPath = path + filename + modifier + "/";
        string playerPath = buildPath + filename + modifier + fileExtension;


        if (buildTargetGroup == BuildTargetGroup.Android)
        {
            foreach (ScriptingImplementation bk in androidBackend)
            {
                foreach (GraphicsDeviceType gfx in gfxAPIs)
                {
                    PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { gfx });
                    PlayerSettings.SetScriptingBackend(buildTargetGroup, bk);
                    EditorUserBuildSettings.SwitchActiveBuildTarget(buildTargetGroup, buildTarget);
                    playerPath = buildPath + filename + "_" + bk.ToString() + "_" + gfx.ToString() + fileExtension;
                    BuildPipeline.BuildPlayer(GetScenePaths(), playerPath, buildTarget, BuildOptions.None);
                }
            }
            PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { GraphicsDeviceType.OpenGLES3, GraphicsDeviceType.Vulkan }); //Set back APIs 
        }
        else if (buildTargetGroup == BuildTargetGroup.iOS)
        {
            foreach (ManagedStrippingLevel lvl in mlvl)
            {
                PlayerSettings.SetManagedStrippingLevel(buildTargetGroup, lvl);
                playerPath = buildPath + filename + "_" + lvl.ToString() + fileExtension;
                BuildPipeline.BuildPlayer(GetScenePaths(), playerPath, buildTarget, BuildOptions.None);
            }
        }
    }

    static string[] GetScenePaths()
    {
        string[] scenes = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }
        return scenes;
    }

    static string GetProjectName()
    {
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }

    static string GetProjectFolderPath()
    {
        string s = Path.GetFullPath(".");
        return s;
    }
}