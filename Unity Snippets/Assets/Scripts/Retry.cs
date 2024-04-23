using System;

public class Retry
{
    public static bool UntilTrue(int retries, Func<bool> operation)
    {
        for (var retry = 0; retry < retries; retry++)
        {
            if (operation())
            {
                return true;
            }
        }
        return false;
    }
}