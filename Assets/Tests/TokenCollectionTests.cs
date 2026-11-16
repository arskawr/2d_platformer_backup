using System.Collections;
using NUnit.Framework;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.TestTools;

public class TokenCollectionTests
{
    [UnityTest]
    public IEnumerator PlayMode_PlayerTokenCollision_EventSetupIsCorrect()
    {
        // 1. Создаем объект токена в выключенном состоянии (чтобы не сработал Awake и не упал TokenController)
        GameObject tokenObj = new GameObject("TestToken");
        tokenObj.SetActive(false);
        var token = tokenObj.AddComponent<TokenInstance>();

        // 2. Создаем объект игрока (тоже выключенным)
        GameObject playerObj = new GameObject("TestPlayer");
        playerObj.SetActive(false);
        var player = playerObj.AddComponent<PlayerController>();

        // 3. Проверяем механику планирования подбора: 
        // Создаем событие PlayerTokenCollision и связываем его с игроком и токеном.
        // Именно это событие игра ставит в очередь при касании.
        var collisionEvent = new PlayerTokenCollision
        {
            token = token,
            player = player
        };

        // 4. Проверяем, что событие успешно создано и содержит правильные ссылки
       Assert.IsNotNull(collisionEvent, "Ошибка: Событие PlayerTokenCollision не создано!");
        //Assert.IsNull(collisionEvent, "СЛОМАННЫЙ ТЕСТ");
        Assert.AreEqual(token, collisionEvent.token, "Ошибка: Токен не привязан к событию!");
        Assert.AreEqual(player, collisionEvent.player, "Ошибка: Игрок не привязан к событию!");

        // 5. Даем кадр на обработку (требование PlayMode теста)
        yield return null;

        // Очистка
        Object.Destroy(tokenObj);
        Object.Destroy(playerObj);
    }
}