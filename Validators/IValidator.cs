namespace Validators;

public interface IValidator<T>
{
    List<string> Errors { get; }

    string GetErrors();
    void Validate(T value);
}