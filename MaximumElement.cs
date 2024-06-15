namespace Delegates_Events
{
    /// <summary>
    /// Функция возврата максимального элемента коллекции
    /// </summary>
    public static class MaxElement
    {
        interface IFloatValue
        {
            float Value { get; }
        }

        class FloatValue(float value) : IFloatValue
        {
            public float Value { get; } = value;
        }

        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            T? maxElement = null;
            float maxValue = float.MinValue;

            foreach(T element in collection)
            {
                float value = convertToNumber(element);

                if(value > maxValue)
                {
                    maxElement = element;
                    maxValue = value;
                }
            }

            return maxElement;
        }

        private static float GetParameter<T>(T param) where T : class => param switch
        {
            IFloatValue value => value.Value,

            float convertToFloat => convertToFloat,
            _ => throw new ArgumentException("Не удается преобразовать тип")
        };

        public static string Run()
        {
            List<IFloatValue> list = new()
            {
                new FloatValue(1f),
                new FloatValue(7.45f),
                new FloatValue(-23f)
            };

            float maxElement = list.GetMax<IFloatValue>(GetParameter).Value;

            string console = "Задача 'Максимальное число'\n\r";
            console += "На вход даны числа 1, 7.45, -23";
            console += $"Максимальное число: {maxElement}\n\r\n\r";

            return console;

            //Console.WriteLine("Задача 'Максимальное число'\n\r");
            //Console.WriteLine("На вход даны числа 1, 7.45, -23");
            //Console.WriteLine($"Максимальное число: {maxElement}\n\r\n\r");
        }
    }
}
