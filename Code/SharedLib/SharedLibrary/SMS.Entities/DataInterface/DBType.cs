namespace SMS.Entities.DataInterface
{
    public enum DBType
    {
        None,
        Full,
        MobileCache
    }

    public enum OperationErrorCode
    {
        None,
        RemoteServerUnavailable,
        ConnectionFailure,
        InvalidOperation,
        LogonFailure,
        NoDataFound
    }
}
