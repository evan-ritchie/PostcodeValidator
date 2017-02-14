using System.Text.RegularExpressions;

namespace PostcodeValidator
{
    public static class Utilities
    {

        static public bool IsValidPostCode(string postcode)
        {
            string strRegex = "(GIR\\s0AA)|((([A-PR-UWYZ][0-9][0-9]?)|(([A-PR-UWYZ][A-HK-Y][0-9](?<!(BR|FY|HA|HD|HG|HR|HS|HX|JE|LD|SM|SR|WC|WN|ZE)[0-9])[0-9])|([A-PR-UWYZ][A-HK-Y](?<!AB|LL|SO)[0-9])|(WC[0-9][A-Z])|(([A-PR-UWYZ][0-9][A-HJKPSTUW])|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY]))))\\s[0-9][ABD-HJLNP-UW-Z]{2})";


            return Regex.IsMatch(postcode, strRegex);

        }

    }
}
