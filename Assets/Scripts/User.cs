public static class User
{
    private static string userName;
   

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
}