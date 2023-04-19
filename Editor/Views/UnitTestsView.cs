<<<<<<< HEAD
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
=======
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
>>>>>>> a29aa12a619fa8f7546a181f86b8ffd0b0132bd8
}