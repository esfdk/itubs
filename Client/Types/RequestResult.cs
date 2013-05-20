namespace Client.Types
{
    public enum RequestResult
    {
        Success = 0, WrongUserNameOrPassword = 1, InvalidInput = 2, CommunicationFailure = 3, AccessDenied = 4, Error = 5
    }
}