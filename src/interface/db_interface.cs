namespace PasswordManager.Interface;
public class DbInterface
{
    public long Id { get; set; }
    public string? Username { get; set; } = "N/D";
    public string? Email { get; set; } = "N/D";
    public string URL { get; set; } = "N/D";    
    public string Password { get; set; } = "N/D";   
    public byte[] Salt { get; set; } = {};
    public byte[] Hash { get; set; } = {};

}