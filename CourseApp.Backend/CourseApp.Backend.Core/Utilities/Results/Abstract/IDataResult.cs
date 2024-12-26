namespace CourseApp.Backend.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T? Data { get; }
    }
}