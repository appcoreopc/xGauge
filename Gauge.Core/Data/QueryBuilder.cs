using System.Text;
using System.Text.RegularExpressions;

namespace Gauge.Core.Data
{
    public class QueryBuilder
    {
        private const string SELECT_STATEMENT = "SELECT ";
        private const string FROM_STATEMENT = " FROM ";
        private const string WHERE_STATEMENT = " WHERE ";
        
        private const string UPDATE_STATEMENT = "UPDATE ";
        private const string DELETE_STATEMENT = "DELETE ";

        private const string SET_STATEMENT = " SET ";

        public static string BuildQuery(string table, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            StringBuilder builder = new StringBuilder(SELECT_STATEMENT);
            builder.Append(string.Join(",", projection));
            builder.Append(FROM_STATEMENT + table);
            builder.Append(WHERE_STATEMENT);

            var pText = BuildSelection(selection, selectionArgs);
            builder.Append(pText);
            return builder.ToString();
        }

        public static string BuildUpdate(string table, string values, string selection)
        {
            StringBuilder builder = new StringBuilder(UPDATE_STATEMENT);
            builder.Append(table);
            builder.Append(SET_STATEMENT);
            builder.Append(values);
            builder.Append(WHERE_STATEMENT);
            builder.Append(selection);
            return builder.ToString();
        }

        public static string BuildDelete(string table, string selection)
        {
            StringBuilder builder = new StringBuilder(DELETE_STATEMENT);
            builder.Append(FROM_STATEMENT);
            builder.Append(table);
            builder.Append(WHERE_STATEMENT);
            builder.Append(selection);
            return builder.ToString();
        }

        public static string BuildSelection(string selection, string[] selectionArgs)
        {
            var regex = new Regex(Regex.Escape("?"));
            string pText = selection;

            for (int i = 0; i < selectionArgs.Length; i++)
            {
                pText = regex.Replace(pText, selectionArgs[i], 1);
            }
            return pText;
        }
    }
}
