# Inventory
 Постановка задачи

Логика (Model + Controllers)
1. Реализовать инвентарь, в котором можно хранить определенную дату.
2. Инвентарь должен представлять с собой контейнер.
3. В контейнере по умолчанию пусто.
4. Дата представляет собой набор следующих свойств (название предмета string type,
состояние предмета float type (0,1), изображение предмета (Sprite type)), размер
объекта в рамках инвентаря (Vector2 type).
5. Все что заносится в инвентарь или убирается из него пользователем, должно
сохраняться между сессиями (PlayerPrefs или Json File)
6. Инвентарь представляет собой сетку 10 x 10. У каждого слота сетки есть статус
"Занято" или "Свободно". В случае если пользователь пытается положить в
инвентарь предмет в занятую ячейку - операция по занесению отменяется. Если
ячейка свободна - операция успешна.
7. Реализовать различные примеры предметов для инвентаря с разной размерностью
(3x1, 2x2, 1x1, 5x2)

View отображение
1. Должно быть два визуальных контейнера на экране. Первый представляет собой
инвентарь, второй - условно список предметов которые можно в нем разместить.
Второй контейнер справа при каждом запуске хранит набор разных предметов
(рандомно)
2. Пользователь должен перетаскивать предметы левой кнопкой мыши. Если с Drag
проблемы - допускается упрощенный вариант в котором надо просто нажать на
предмет, чтобы он автоматически распределился в инвентарь.
3. Если нажать на предмет в инвентаре - он уйдет назад, в правый контейнер.
