namespace CalculatingShiftNumberBasedOnWorkingHours
{
    internal class Program
    {
        static void Main(string[] args)
        {
			DateTime[] samples = [ new DateTime (2024, 01, 30, 2, 0, 0),
							new DateTime (2024, 01, 30, 8, 0, 0),
							new DateTime (2024, 01, 30, 17, 0, 0),
							new DateTime (2024, 01, 30, 22, 0, 0) ];
			foreach (var sample in samples)
			{
				Console.WriteLine(sample.ToLongDateString());
				Console.WriteLine("\t" + sample.ToLongTimeString());
				var resSample = GetInterval(sample);
				Console.WriteLine($"Смена {resSample.number}:\r\n\tс {resSample.start} до {resSample.end}");
				PrintLine(60, '-');
			}
			Console.ReadKey();
        }

		/// <summary>
		/// <para>Method…</para>
		/// <para>Получает номер смены и временной интервал в зависимости от текущего времени.</para>
		/// </summary>
		/// <param name="current">Текущее время для определения смены.</param>
		/// <returns>Кортеж, содержащий номер смены, время начала и время конца смены.</returns>
		static (int number, DateTime start, DateTime end) GetInterval(DateTime current)
		{
			var morning = new TimeSpan(8, 0, 0); // Начало утренней смены
			var evening = new TimeSpan(16, 0, 0); // Начало вечерней смены
			var night = new TimeSpan(22, 0, 0); // Начало ночной смены

			return current.TimeOfDay switch
			{
				var t when t < morning => ( // Если текущее время меньше 8:00
					3, // Номер смены (3 - ночная)
					current.Date.AddDays(-1).Add(night), // Начало ночной смены: вчерашний день, 22:00
					current.Date.Add(morning) // Конец ночной смены: сегодня, 8:00
				),
				var t when t < evening => ( // Если текущее время между 8:00 и 16:00
					1, // Номер смены (1 - утренняя)
					current.Date.Add(morning), // Начало утренней смены: сегодня, 8:00
					current.Date.Add(evening) // Конец утренней смены: сегодня, 16:00
				),
				var t when t < night => ( // Если текущее время между 16:00 и 22:00
					2, // Номер смены (2 - вечерняя)
					current.Date.Add(evening), // Начало вечерней смены: сегодня, 16:00
					current.Date.Add(night) // Конец вечерней смены: сегодня, 22:00
				),
				_ => ( // Если текущее время 22:00 или позже
					3, // Номер смены (3 - ночная)
					current.Date.Add(night), // Начало ночной смены: сегодня, 22:00
					current.Date.AddDays(1).Add(morning) // Конец ночной смены: завтра, 8:00
				)
			};
		}

		/// <summary>
		/// <para>Method…</para>
		/// <para>Выводит строку, состоящую из указанного количества заданных символов.</para>
		/// </summary>
		/// <param name="symbolCount">Количество символов в строке.</param>
		/// <param name="symbol">Символ, который будет использоваться для заполнения строки.</param>
		static void PrintLine(int symbolCount, char symbol)
		{
			for (int i = 0; i < symbolCount; i++)
			{
				Console.Write(symbol);
			}
			Console.WriteLine();
		}
	}
}
