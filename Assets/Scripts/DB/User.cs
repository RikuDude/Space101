public static class User
{
    private static string userName;
    private static string bestScore = "0";
    private static string score = "0";
    private static bool newUser;
    private static int difficulty = 0;

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

    public static string Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
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

    public static int Difficulty
    {
        get
        {
            return difficulty;
        }

        set
        {
            difficulty = value;
        }
    }

    public static void SetUserData(string username, bool newuser, string bestScore = "0", string score = "0")
    {
        UserName = username;
        NewUser = newuser;
        BestScore = bestScore;
        Score = score;
    }

    public static string GetUserDataMessage()
    {
        if (NewUser)
        {
            return string.Format("Welcome to Space 101 {0}  ", UserName);
        }
        else
        {

            return string.Format("Welcome back {0}  ", UserName, BestScore, Score);
        }

    }
}