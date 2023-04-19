using NUnit.Framework;

public class EditorModeTests
{
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public void Test2()
    {
        Assert.True(2 + 2 == 4);
    }

    [Test]
    public void Test3()
    {
        Assert.True(5 * 3 == 15);
    }
}
