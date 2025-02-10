<a id="anchor"></a>
# Calculating-the-shift-number-based-on-the-working-hours
## Методики для определения номера рабочей смены сотрудников…
https://github.com/user-attachments/assets/6f78abf7-93c7-42b3-825c-0a095b95b3ad
> :point_right: Требуется разработать систему расчёта номера рабочей смены, основываясь на текущем времени суток. Продолжительность каждой смены составляет 12 часов, и они начинаются в 8:00, 16:00 и 22:00. После окончания предыдущей смены в это же время начинается следующая.</br>
  :world_map: Для корректного сбора статистических данных необходимо определить начальную точку отсчёта в зависимости от типа смены. Для утренней смены (8:00) сбор данных начинается в 8:00 текущего дня и продолжается до 22:00 того же дня. Для дневной смены (16:00) сбор данных начинается в 16:00 текущего дня и заканчивается в 8:00 следующего дня. Для вечерней смены (22:00) сбор данных начинается в 22:00 текущего дня и продолжается до 8:00 следующего дня.</br>
  :traffic_light: Однако возникает проблема: статистические данные собираются каждые 5 минут, и необходимо корректно определить начальную точку отсчёта. Например, если текущее время 1:05 ночи, то сбор данных должен начаться с 22:00 предыдущего дня. Если текущее время 9:55 утра, то сбор данных должен начаться с 8:00 этого дня.</br>
  :eye_speech_bubble: Ручное указание интервалов времени для каждой смены не является приемлемым решением. Требуется разработать автоматизированный механизм расчёта начальной точки отсчёта времени на основе текущего времени и типа смены.</br>
<a href="https://github.com/DeNaN20250203" target="_blank"><img src="GitHubDeJra.png" alt="Image" width="300" /></a>
[Верх](#anchor)
