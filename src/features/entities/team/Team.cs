public static class Team
{
	public static string GetEnemy()
	{
		return "enemy";
	}

	public static string GetAlly()
	{
		return "ally";
	}
	public static string GetNeutral()
	{
		return "neutral";
	}
}

public enum Allegiance
{
	ALLY,
	ENEMY,
	NEUTRAL
}
