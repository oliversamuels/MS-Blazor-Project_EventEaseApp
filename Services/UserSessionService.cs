using System;

namespace EventEaseApp;

public class UserSessionService
{
    public string? UserName { get; private set; }
    public string? UserEmail { get; private set; }
    public DateTime SessionStartTime { get; private set; }

    public void StartSession(string userName, string userEmail)
    {
        if (!IsSessionActive())
        {
            UserName = userName;
            UserEmail = userEmail;
            SessionStartTime = DateTime.Now;
        }
    }

    public void EndSession()
    {
        UserName = null;
        UserEmail = null;
        SessionStartTime = DateTime.MinValue;
    }

    public bool IsSessionActive()
    {
        return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserEmail);
    }
}
