using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class PlayerTests
{
    private const string MainScenePath = "Assets/Scenes/SampleScene.unity";

    [Test]
    public void EditMode_PlayerTag_IsCorrect()
    {
        var scene = EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
        Assert.IsTrue(scene.IsValid(), "Ошибка: не удалось открыть сцену!");

        GameObject player = GameObject.Find("Player");
        Assert.IsNotNull(player, "Ошибка: на сцене не найден объект 'Player'!");
        Assert.AreEqual("Player", player.tag, "Ошибка: У объекта игрока сброшен тег!");

        Assert.IsNotNull(player.GetComponent<PlayerController>(), "Ошибка: нет PlayerController!");
        Assert.IsNotNull(player.GetComponent<Health>(), "Ошибка: нет Health!");
    }
}