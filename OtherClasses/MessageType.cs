using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class MessageTypes
{
    public enum MessageType
    {
        SuccessMessage = 1,
        ErrorMessage = 2,
        WarningMessage = 3,
        InfoMessage = 4,
        PromptMessage = 5,
        InputMessage = 6
    }
}