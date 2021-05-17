using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private PlayerMovement player;
    private GameManager manager;

    [SetUp]
    public void Setup()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("manager");
        manager = obj.GetComponent<GameManager>();
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        player = gameGameObject.GetComponent<PlayerMovement>();
        player.target = manager.target;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(player.gameObject);
        Object.DestroyImmediate(manager.gameObject);
    }

    [UnityTest]
    public IEnumerator CheckForPlayerPaused()
    {
        player.transform.position = manager.target[1].position;
        yield return null;
        Assert.False(player.pausedMovement);
    }

}
