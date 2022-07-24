using System;

namespace mySQLConnectio
{
    //Enum of the column in BDD
    public enum DataUpdateType
    {
        USERNAME ,
        PASSWORD ,
        EMAIL    ,
        LOCATION ,
        RATE,
        FIRSTNAME,
        TELEPHONE,
        DEFAULT
        
    }

    public static class DataUpdateTypeExtensions
    {
        //String of the name of column
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
                case DataUpdateType.LOCATION:
                    return "iplocation";
                case DataUpdateType.RATE:
                    return "rate";
                case DataUpdateType.FIRSTNAME:
                    return "namefirstname";
                case DataUpdateType.TELEPHONE:
                    return "telephone";
                default:
                    return null;
            }
        }

        //Link beetwen RowType and DataUpdateType
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