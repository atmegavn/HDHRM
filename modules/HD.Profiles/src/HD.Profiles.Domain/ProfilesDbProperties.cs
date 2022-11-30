namespace HD.Profiles;

public static class ProfilesDbProperties
{
    public static string DbTablePrefix { get; set; } = "Profiles";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Profiles";
}
