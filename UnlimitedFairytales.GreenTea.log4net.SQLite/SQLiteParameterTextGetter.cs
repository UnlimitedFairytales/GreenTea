using System.Data.SQLite;
using UnlimitedFairytales.GreenTea.log4net.Data;

namespace UnlimitedFairytales.GreenTea.log4net.SQLite
{
    public class SQLiteParameterTextGetter : IParameterTextGetter
    {
        public string GetParameterText(object parameter)
        {
            SQLiteParameter casted = (SQLiteParameter)parameter;
            return $"{casted.ParameterName}={casted.Value}";
        }
    }
}
