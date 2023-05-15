using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace DATN_NguyenThiThuHuong.Commons
{
    public static class FileBase
    {
        #region Method
        /// <summary>
        /// Xử lý dữ liệu lưu vô MemoryStream
        /// </summary>
        /// <param name="table">Bảng chứa dữ liệu xuất</param>
        /// <param name="filter">Bộ lọc</param>
        /// <param name="url">Link file template</param>
        /// <param name="memory">MemoryStream xuất ra</param>
        /// <returns>Chuỗi nếu lỗi</returns>
        public static string PrintfDataTable(DataTable table, Dictionary<string, string> filter, string url, out MemoryStream memory)
        {
            memory = new MemoryStream();
            try
            {
                string msg = DowLoadFileFromUrl(url, out MemoryStream fi);
                if (msg.Length > 0) return msg;
                if (fi.Length == 0) return "File template không tồn tại";

                using (var pack = new ExcelPackage(fi))
                {
                    var worksheet = pack.Workbook.Worksheets[table.TableName];

                    // Lấy vị trí hiển thị dữ liệu
                    int col = pack.Workbook.Names["Start"].Start.Column;
                    int row = pack.Workbook.Names["Start"].Start.Row;

                    worksheet.Cells[row, col].LoadFromDataTable(table, false);

                    //Style 
                    worksheet.Cells[row, col, row + table.Rows.Count - 1, col + table.Columns.Count - 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, col, row + table.Rows.Count - 1, col + table.Columns.Count - 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, col, row + table.Rows.Count - 1, col + table.Columns.Count - 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, col, row + table.Rows.Count - 1, col + table.Columns.Count - 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    pack.SaveAs(memory);
                    memory.Position = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

            return "";
        }

        /// <summary>
        /// Convert link thành MemoryStream
        /// </summary>
        /// <param name="url">Link muốn chuyển</param>
        /// <param name="memoryStream">MemoryStream</param>
        /// <returns>Chuỗi lỗi nếu có</returns>
        public static string DowLoadFileFromUrl(string url, out MemoryStream memoryStream)
        {
            memoryStream = null;
            try
            {
                using (var client = new WebClient())
                {
                    var content = client.DownloadData(url);
                    memoryStream = new MemoryStream(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            return "";
        }

        /// <summary>
        /// Xuất file sang table
        /// </summary>
        /// <param name="fileStream">fileStream</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTableFromExcelFileWithHeader(Stream fileStream)
        {
            var dt = GetDataTableFromXlsx(fileStream);

            DataTable dataTable = new DataTable();
            object[] itemArray = dt.Rows[0].ItemArray;
            foreach (object obj in itemArray)
            {
                dataTable.Columns.Add(obj.ToString());
            }

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                dataTable.Rows.Add(dt.Rows[j].ItemArray);
            }

            dt = dataTable;
            return dt;
        }

        /// <summary>
        /// Xuất file sang table dựa vào dòng đầu tiên của file 
        /// </summary>
        /// <param name="fileStream">fileStream</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTableFromXlsx(Stream fileStream)
        {
            DataTable dt = new DataTable();
            int i = 1;
            int j = 1;
            try
            {
                using ExcelPackage excelPackage = new ExcelPackage(fileStream);
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.First();
                int valueOrDefault = (excelWorksheet?.Dimension?.End?.Column).GetValueOrDefault();
                if (valueOrDefault < 1)
                {
                    return dt;
                }

                dt = new DataTable();
                for (j = 1; j <= valueOrDefault; j++)
                {
                    dt.Columns.Add($"Column {j}");
                }

                for (; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    ExcelRange excelRange = excelWorksheet.Cells[i, 1, i, excelWorksheet.Dimension.End.Column];
                    DataRow dataRow = dt.Rows.Add();
                    foreach (ExcelRangeBase item in excelRange)
                    {
                        j = 1;
                        string format = item.Style.Numberformat.Format;
                        object value = item.Value;
                        dataRow[item.Start.Column - 1] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }
        #endregion
    }
}
