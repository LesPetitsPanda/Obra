using System;

namespace mySQLConnectio
{
    public enum DataUpdateType
    {
        USERNAME ,
        PASSWORD ,
        EMAIL    ,
        DEFAULT
        
    }

    public static class DataUpdateTypeExtensions
    {
        public static String GetString(this DataUpdateType meUpdateType)
        {
            switch (meUpdateType)
            {
                case DataUpdateType.USERNAME:
                    return "username";
                case DataUpdateType.PASSWORD:
                    return "password";
                case DataUpdateType.EMAIL:
                    return "email";
                default:
                    return null;
            }
        }

        public static DataUpdateType GetDataUpdateType(RowType rowType)
        {
            switch (rowType)
            {
                case RowType.EMAIL:
                    return DataUpdateType.EMAIL;
                case RowType.PASSWORD:
                    return DataUpdateType.PASSWORD;
                case RowType.USERNAME:
                    return DataUpdateType.USERNAME;
            }

            return DataUpdateType.DEFAULT;
        }
    }
}