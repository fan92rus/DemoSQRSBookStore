namespace App.Models.Filters
{
    public interface IFilter<T>
    {
        public bool Check(T value);

    }
}