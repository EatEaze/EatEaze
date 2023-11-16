namespace EatEaze.Responce
{
    public class Responce<T> where T : class
    {
        public Responce(T data)
        {
            Data = data;
        }

        public T? Data { get; }

        public string Description { get; set; }
    }
}
