# !Важно!
Для корректной работы необходимо запускать игру только с "Boot" сцены <br />

# Архитектура
Архитектура проекта построена на сервисах и глобальной FSM с использованием _Zenject_ в качестве DI<br /> 
Для написания логики инвентаря был выбран паттер MVC

# SaveLoad
Файл сохранения лежит по пути _/Assets/Save/Progress.json_ <br /> Сохранение происходит в _OnApplicationQuit()_ методе <br /> Загрузка/создание файла сохранения происходит в _LoadProgressState_ <br />Скрипт сохранения висит на _Main Camera_ в _Main_ сцене

# StaticData
Конфигурационные файлы лежат по пути _Assets/Resources/StaticData/Inventory_ <br />


# P.S.
Так же реализован драг-н-дроп 
