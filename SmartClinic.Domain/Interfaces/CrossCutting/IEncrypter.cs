namespace SmartClinic.Domain.Interfaces.CrossCutting
{
    public interface IEncrypter
    {
        string Encrypt(string value);
    }
}