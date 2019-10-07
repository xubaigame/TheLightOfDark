using UnityEditor;
public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BulidAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

}
