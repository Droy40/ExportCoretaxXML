using Export.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Export.Repository
{
    public class RetailInvoiceRepository
    {
        public static List<RetailInvoice> GetAllRetailInvoice(DateTime? startDate, DateTime? endDate)
        {
            List<RetailInvoice> retailInvoice = new List<RetailInvoice>();

            string query = @"SELECT " +
                                "trxCode trxCode," +
                                "BuyerName BuyerName," +
                                "BuyerIdOpt BuyerIdOpt," +
                                "BuyerIdNumber BuyerIdNumber," +
                                "GoodServiceOpt GoodServiceOpt," +
                                "SerialNo SerialNo," +
                                "TransactionDate TransactionDate," +
                                "TaxBaseSellingPrice TaxBaseSellingPrice," +
                                "OtherTaxBaseSellingPrice OtherTaxBaseSellingPrice," +
                                "VAT VAT," +
                                "STLG STLG " +
                            "FROM retail_invoice " +
                            "WHERE (@StartDate IS NULL OR date(TransactionDate) >= @StartDate) AND (@EndDate IS NULL OR date(TransactionDate) <= @EndDate) " +
                            "ORDER BY TransactionDate DESC;";
            using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.Instance.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate?.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", endDate?.ToString("yyyy-MM-dd"));
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retailInvoice.Add(new RetailInvoice
                            {
                                TrxCode = reader["trxCode"].ToString(),
                                BuyerName = reader["BuyerName"].ToString(),
                                BuyerIdOpt = reader["BuyerIdOpt"].ToString(),
                                BuyerIdNumber = reader["BuyerIdNumber"].ToString(),
                                GoodServiceOpt = reader["GoodServiceOpt"].ToString(),
                                SerialNo = reader["SerialNo"].ToString(),
                                TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString()),
                                TaxBaseSellingPrice = decimal.Parse(reader["TaxBaseSellingPrice"].ToString()),
                                OtherTaxBaseSellingPrice = decimal.Parse(reader["OtherTaxBaseSellingPrice"].ToString()),
                                VAT = decimal.Parse(reader["VAT"].ToString()),
                                STLG = decimal.Parse(reader["STLG"].ToString())
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return retailInvoice;
        }
        public static List<RetailInvoice> GetRetailInvoice(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate)
        {
            List<RetailInvoice> retailInvoice = new List<RetailInvoice>();

            string query = @"SELECT " +
                                "trxCode trxCode," +
                                "BuyerName BuyerName," +
                                "BuyerIdOpt BuyerIdOpt," +
                                "BuyerIdNumber BuyerIdNumber," +
                                "GoodServiceOpt GoodServiceOpt," +
                                "SerialNo SerialNo," +
                                "TransactionDate TransactionDate," +
                                "TaxBaseSellingPrice TaxBaseSellingPrice," +
                                "OtherTaxBaseSellingPrice OtherTaxBaseSellingPrice," +
                                "VAT VAT," +
                                "STLG STLG " +
                            "FROM retail_invoice " +
                            "WHERE (@StartDate IS NULL OR date(TransactionDate) >= @StartDate) AND (@EndDate IS NULL OR date(TransactionDate) <= @EndDate) " +
                            "ORDER BY TransactionDate DESC " +
                            "LIMIT @PageSize OFFSET @Offset;";
            using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.Instance.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.AddWithValue("@StartDate", startDate?.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", endDate?.ToString("yyyy-MM-dd"));
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retailInvoice.Add(new RetailInvoice
                            {
                                TrxCode = reader["trxCode"].ToString(),
                                BuyerName = reader["BuyerName"].ToString(),
                                BuyerIdOpt = reader["BuyerIdOpt"].ToString(),
                                BuyerIdNumber = reader["BuyerIdNumber"].ToString(),
                                GoodServiceOpt = reader["GoodServiceOpt"].ToString(),
                                SerialNo = reader["SerialNo"].ToString(),
                                TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString()),
                                TaxBaseSellingPrice = decimal.Parse(reader["TaxBaseSellingPrice"].ToString()),
                                OtherTaxBaseSellingPrice = decimal.Parse(reader["OtherTaxBaseSellingPrice"].ToString()),
                                VAT = decimal.Parse(reader["VAT"].ToString()),
                                STLG = decimal.Parse(reader["STLG"].ToString())
                            });
                        }                    
                    }                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return retailInvoice;
        }
        public static int GetTotalRecords(DateTime? startDate, DateTime? endDate)
        {
            string query = @"SELECT " +
                                "COUNT(*)" +
                            "FROM retail_invoice " +
                            "WHERE (@StartDate IS NULL OR date(TransactionDate) >= @StartDate) AND (@EndDate IS NULL OR date(TransactionDate) <= @EndDate)";
            using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.Instance.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate?.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", endDate?.ToString("yyyy-MM-dd"));

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
