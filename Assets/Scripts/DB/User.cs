public static class User
{
    private static string userName;
    private static string bestScore;
    private static string totalPoints;
    private static bool newUser;

    public static string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public static string BestScore
    {
        get
        {
            return bestScore;
        }

        set
        {
            bestScore = value;
        }
    }

    public static string TotalPoints
    {
        get
        {
            return totalPoints;
        }

        set
        {
            totalPoints = value;
        }
    }

    public static bool NewUser
    {
        get
        {
            return newUser;
        }

        set
        {
            newUser = value;
        }
    }

    public static void SetUserData(string username,bool newuser, string bestScore = "0", string totalPoints = "0")
    {
        UserName = username;
        NewUser = newuser;
        BestScore = bestScore;
        TotalPoints = totalPoints;
    }

    public static string GetUserDataMessage()
    {
        if (NewUser)
        {
            return string.Format("Welcome to Space 101 {0}  ", UserName);
        }
        else
        {
            return string.Format("Welcome back {0}  ", UserName, BestScore, TotalPoints);
        }
        
    }
}