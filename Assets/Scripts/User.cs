public static class User
{
    private static string userName;
    private static string bestScore;
    private static string totalPoints;

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


    public static void SetUserData(string username, string bestScore = "0", string totalPoints = "0")
    {
        UserName = username;
        BestScore = bestScore;
        TotalPoints = totalPoints;
    }

    public static string GetUserDataMessage(bool newPlayer)
    {
        if (newPlayer)
        {
            return string.Format("Welcome to Space 101 {0} ", UserName, BestScore, TotalPoints);
        }
        else
        {
            return string.Format("Welcome back {0} \n your Best Score is {1} and your Total Points are {2}", UserName, BestScore, TotalPoints);
        }
        
    }
}