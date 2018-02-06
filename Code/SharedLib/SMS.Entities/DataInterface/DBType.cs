namespace SMS.Entities.DataInterface
{
    public enum DBType
    {
        None,
        Server,
        MobileCache,
        Online
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
