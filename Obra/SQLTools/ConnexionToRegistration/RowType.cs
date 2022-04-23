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
        JOB = 8,
        CODE = 6

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
                case RowType.PROFESSIONAL: return 5;
                case RowType.RATE |RowType.CODE: return 6;    
                case RowType.JOB: return 8;
                default: return -1;
            }
        }
    }
}