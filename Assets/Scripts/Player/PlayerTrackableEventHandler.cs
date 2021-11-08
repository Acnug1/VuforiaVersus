using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackableEventHandler : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound() // переопределяем метод OnTrackingFound() в классе DefaultTrackableEventHandler и наследуемся от него 
    {
        base.OnTrackingFound(); // вызываем этот метод у базового класса DefaultTrackableEventHandler и дополняем его своими действиями
        Player player = GetComponentInChildren<Player>(); // находим компонент Player у дочерних объектов в карточке и записываем его в поле player
        if (player != null) // если компонент Player найден
            player.enabled = true; // включаем компонент нашего игрока, при трекинге (работаем с компонентом player, а не объектом игрока, чтобы работал метод GetComponentInChildren)
    }

    protected override void OnTrackingLost() // при потере трекинга
    {
        base.OnTrackingLost(); // вызываем метод у базового класса и дополняем его
        Player player = GetComponentInChildren<Player>(); // находим компонент Player у дочерних объектов в карточке и записываем его в поле player
        if (player != null) // если компонент Player найден
            player.enabled = false; // включаем компонент нашего игрока, при потере трекинга (события Unity в этом случае работать не будут, но будут работать методы внутри компонента Player)
    }
}
