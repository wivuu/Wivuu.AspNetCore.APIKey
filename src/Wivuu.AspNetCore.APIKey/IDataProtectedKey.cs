namespace Wivuu.AspNetCore.APIKey;

public interface IDataProtectedKey
{
    /// <summary>
    /// Represent your API key as bytes
    /// </summary>
    byte[] ToTokenBytes();

    /// <summary>
    /// Deserialize your API key from bytes
    /// </summary>
    static abstract bool TryParseTokenBytes(byte[] tokenBytes, out IDataProtectedKey? key);
}