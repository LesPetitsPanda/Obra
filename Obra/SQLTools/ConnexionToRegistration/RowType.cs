namespace mySQLConnectio
{
    public enum RowType
    {
        ID = 0,
        USERNAME = 1,
        PASSWORD = 2,
        EMAIL = 3,
        LOCATION = 4,
        RATE = 5,

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
                case RowType.LOCATION: return 4;
                case RowType.RATE: return 5;
                default: return -1;
            }
        }
    }
}