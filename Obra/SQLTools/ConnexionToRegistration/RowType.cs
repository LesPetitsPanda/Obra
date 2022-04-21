namespace mySQLConnectio
{
    public enum RowType
    {
        ID = 0,
        USERNAME = 1,
        PASSWORD = 2,
        EMAIL = 3,
        LOCATION = 4,
        PROFESSIONAL = 5,
        RATE = 6,
        JOB = 8

    }
    public class RowTypeUtils
    {
        public static int RowTypeInt(RowType row)
        {
            switch (row)
            {
                case RowType.ID: return 0;
                case RowType.USERNAME: return 1;
                case RowType.PASSWORD: return 2;
                case RowType.EMAIL: return 3;
                default: return -1;
            }
        }
    }
}