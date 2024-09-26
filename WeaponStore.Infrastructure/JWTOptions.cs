namespace WeaponStore.Infrastructure;

public class JWTOptions
{
    public string SecretKey { get; set; }
    public int ExpitesHours { get; set; }
}