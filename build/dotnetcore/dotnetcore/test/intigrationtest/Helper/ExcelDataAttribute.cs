using System;
using System.Collections.Generic;
using System.Data;


using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;
using OfficeOpenXml;
using OfficeOpenXml.Table;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class ExcelDataAttribute : DataAttribute
{
    // private static readonly string connectionTemplate =
    //     "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";

    public ExcelDataAttribute(string fileName, string sheetName)
    {
        FileName = fileName;
        this.SheetName = sheetName;
        // QueryString = queryString;
    }

    public string FileName { get; private set; }

    public string SheetName { get; private set; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {

        if (testMethod == null)
            throw new ArgumentNullException("testMethod");

        ParameterInfo[] pars = testMethod.GetParameters();
        return DataSource(FileName);
    }

    private IEnumerable<object[]> DataSource(string fileName)
    {

        var fileInfo = new FileInfo(GetFullFilename(fileName));

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[SheetName];
            int rowCount = worksheet.Dimension.Rows;
            int ColCount = worksheet.Dimension.Columns;

            for (int row = 1; row <= rowCount; row++)
            {
                var result = new List<object>();
                for (int col = 1; col <= ColCount; col++)
                {
                    result.Add(worksheet.Cells[row, col].Value.ToString());

                }
                yield return result.ToArray();
            }
        }

    }

    private static string GetFullFilename(string filename)
    {
        string executable = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
        return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(executable), filename));
    }

    // private static object[] ConvertParameters(object[] values, Type[] parameterTypes)
    // {
    //     object[] result = new object[values.Length];

    //     for (int idx = 0; idx < values.Length; idx++)
    //         result[idx] = ConvertParameter(values[idx], idx >= parameterTypes.Length ? null : parameterTypes[idx]);

    //     return result;
    // }

    /// <summary>
    /// Converts a parameter to its destination parameter type, if necessary.
    /// </summary>
    /// <param name="parameter">The parameter value</param>
    /// <param name="parameterType">The destination parameter type (null if not known)</param>
    /// <returns>The converted parameter value</returns>
    // private static object ConvertParameter(object parameter, Type parameterType)
    // {
    //     if ((parameter is double || parameter is float) &&
    //         (parameterType == typeof(int) || parameterType == typeof(int?)))
    //     {
    //         int intValue;
    //         string floatValueAsString = parameter.ToString();

    //         if (Int32.TryParse(floatValueAsString, out intValue))
    //             return intValue;
    //     }

    //     return parameter;
    // }
}