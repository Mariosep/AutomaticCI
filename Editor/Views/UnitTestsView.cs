using UnityEditor;
using UnityEngine.UIElements;

public class UnitTestsView : View
{
    public new class UxmlFactory : UxmlFactory<UnitTestsView, UxmlTraits> {}
    
    private readonly string visualTreeAssetPath = "Packages/com.mariosep.automatic-ci/Editor/UXML/UnitTests.uxml";
    
    public UnitTestsView()
    {
        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(visualTreeAssetPath);
        visualTreeAsset.CloneTree(this);
    }
}