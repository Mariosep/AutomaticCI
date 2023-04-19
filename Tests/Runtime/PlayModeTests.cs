using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTests
{
    [UnityTest]
    public IEnumerator WhenRigidbodyAddedToAnObjectThenItFalls()
    {
        // Arrange
        float initialHeight = 0f;
        
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        initialHeight = cube.transform.position.y;

        // Act
        cube.AddComponent<Rigidbody>();
        
        yield return new WaitForSeconds(0.1f);

        // Assert
        float currentHeight = cube.transform.position.y;
        
        Assert.True(currentHeight < initialHeight, "The current height is not less than the initial height.");
    }
}
