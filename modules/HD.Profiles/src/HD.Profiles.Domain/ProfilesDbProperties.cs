namespace HD.Profiles;

public static class ProfilesDbProperties
{
    public static string DbTablePrefix { get; set; } = null;

    public static string DbSchema { get; set; } = "Hrm";

    public const string ConnectionStringName = "Profiles";
}
