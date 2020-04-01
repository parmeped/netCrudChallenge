using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Errors
{
    public class Errors
    {
        public static string ErrHigherBirthDate = "BirthDate can't be higher than today";
        public static string ErrGeneric = "An unexpected error happened";
        public static string ErrContactNotFound = "The contact was not found";
        public static string ErrWrongLocationParameter = "No contact was found or the Location parameter is wrong. The accepted ones are Company or City";
        public static string ErrNoPhonesFound = "No contact with the given phone was found";
        public static string ErrContactAlreadyExists = "There is already a contact with that email or username.";
    }
}
