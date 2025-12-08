using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Helpers
{
    internal class ValidatioHelper
    {
        #region String Validation

        /// <summary>
        /// Check if string is null, empty, or whitespace
        /// </summary>
        /// <param name="value">String to validate</param>
        /// <returns>True if null/empty/whitespace, false otherwise</returns>
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Validate string length is within specified range
        /// </summary>
        /// <param name="value">String to validate</param>
        /// <param name="minLength">Minimum allowed length</param>
        /// <param name="maxLength">Maximum allowed length</param>
        /// <returns>True if length is valid, false otherwise</returns>
        public static bool IsValidLength(string value, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            int length = value.Trim().Length;
            return length >= minLength && length <= maxLength;
        }

        /// <summary>
        /// Check if string contains only letters and spaces
        /// </summary>
        /// <param name="value">String to validate</param>
        /// <returns>True if alphabetic, false otherwise</returns>
        public static bool IsAlphabetic(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value, @"^[a-zA-Z\s]+$");
        }

        /// <summary>
        /// Check if string contains only alphanumeric characters (letters, numbers, and spaces)
        /// </summary>
        /// <param name="value">String to validate</param>
        /// <returns>True if alphanumeric, false otherwise</returns>
        public static bool IsAlphanumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$");
        }

        /// <summary>
        /// Check if string contains only alphanumeric characters and hyphens
        /// </summary>
        /// <param name="value">String to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        public static bool IsAlphanumericWithHyphens(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value, @"^[a-zA-Z0-9\s\-]+$");
        }

        #endregion

        #region Email Validation

        /// <summary>
        /// Validate email format using regex pattern
        /// </summary>
        /// <param name="email">Email address to validate</param>
        /// <returns>True if valid email format, false otherwise</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Standard email regex pattern
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email.Trim(), pattern);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Phone Validation

        /// <summary>
        /// Validate phone number format (flexible - accepts various formats)
        /// Accepts formats like: (123) 456-7890, 123-456-7890, 1234567890, +1-123-456-7890
        /// </summary>
        /// <param name="phone">Phone number to validate</param>
        /// <returns>True if valid phone format, false otherwise</returns>
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Remove common formatting characters
            string cleanPhone = Regex.Replace(phone, @"[\s\-\(\)\.\+]+", "");

            // Check if it contains only digits and is between 10-15 characters
            return Regex.IsMatch(cleanPhone, @"^\d{10,15}$");
        }

        /// <summary>
        /// Format phone number to standard format (XXX) XXX-XXXX
        /// </summary>
        /// <param name="phone">Phone number to format</param>
        /// <returns>Formatted phone number or original if invalid</returns>
        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return phone;

            // Remove all non-digit characters
            string cleanPhone = Regex.Replace(phone, @"[^\d]", "");

            // Format as (XXX) XXX-XXXX for 10-digit numbers
            if (cleanPhone.Length == 10)
            {
                return $"({cleanPhone.Substring(0, 3)}) {cleanPhone.Substring(3, 3)}-{cleanPhone.Substring(6, 4)}";
            }

            return phone; // Return original if not 10 digits
        }

        #endregion

        #region Numeric Validation

        /// <summary>
        /// Check if decimal value is within specified range
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="min">Minimum allowed value</param>
        /// <param name="max">Maximum allowed value</param>
        /// <returns>True if within range, false otherwise</returns>
        public static bool IsInRange(decimal value, decimal min, decimal max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Check if integer value is within specified range
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="min">Minimum allowed value</param>
        /// <param name="max">Maximum allowed value</param>
        /// <returns>True if within range, false otherwise</returns>
        public static bool IsInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Check if decimal value is positive (greater than zero)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if positive, false otherwise</returns>
        public static bool IsPositive(decimal value)
        {
            return value > 0;
        }

        /// <summary>
        /// Check if integer value is positive (greater than zero)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if positive, false otherwise</returns>
        public static bool IsPositive(int value)
        {
            return value > 0;
        }

        /// <summary>
        /// Check if decimal value is non-negative (zero or greater)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if non-negative, false otherwise</returns>
        public static bool IsNonNegative(decimal value)
        {
            return value >= 0;
        }

        /// <summary>
        /// Check if integer value is non-negative (zero or greater)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if non-negative, false otherwise</returns>
        public static bool IsNonNegative(int value)
        {
            return value >= 0;
        }

        #endregion

        #region Date Validation

        /// <summary>
        /// Check if date is not in the past (today or future)
        /// </summary>
        /// <param name="date">Date to validate</param>
        /// <returns>True if not in past, false otherwise</returns>
        public static bool IsNotPastDate(DateTime date)
        {
            return date.Date >= DateTime.Today;
        }

        /// <summary>
        /// Check if date is within valid range
        /// </summary>
        /// <param name="date">Date to validate</param>
        /// <param name="minDate">Minimum allowed date</param>
        /// <param name="maxDate">Maximum allowed date</param>
        /// <returns>True if within range, false otherwise</returns>
        public static bool IsDateInRange(DateTime date, DateTime minDate, DateTime maxDate)
        {
            return date >= minDate && date <= maxDate;
        }

        /// <summary>
        /// Check if end date is after or equal to start date
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>True if end date is valid, false otherwise</returns>
        public static bool IsEndDateValid(DateTime startDate, DateTime endDate)
        {
            return endDate.Date >= startDate.Date;
        }

        /// <summary>
        /// Calculate number of days between two dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Number of days (always positive)</returns>
        public static int GetDaysBetween(DateTime startDate, DateTime endDate)
        {
            return Math.Abs((endDate.Date - startDate.Date).Days);
        }

        /// <summary>
        /// Check if date is today
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>True if date is today, false otherwise</returns>
        public static bool IsToday(DateTime date)
        {
            return date.Date == DateTime.Today;
        }

        /// <summary>
        /// Check if date is in the future
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>True if date is in future, false otherwise</returns>
        public static bool IsFutureDate(DateTime date)
        {
            return date.Date > DateTime.Today;
        }

        /// <summary>
        /// Check if date is in the past
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>True if date is in past, false otherwise</returns>
        public static bool IsPastDate(DateTime date)
        {
            return date.Date < DateTime.Today;
        }

        #endregion

        #region License Number Validation

        /// <summary>
        /// Validate driver's license format (alphanumeric with optional hyphens, 5-20 characters)
        /// </summary>
        /// <param name="licenseNumber">License number to validate</param>
        /// <returns>True if valid format, false otherwise</returns>
        public static bool IsValidLicenseNumber(string licenseNumber)
        {
            if (string.IsNullOrWhiteSpace(licenseNumber))
                return false;

            // Allow alphanumeric characters and hyphens, 5-20 characters total
            return Regex.IsMatch(licenseNumber.Trim(), @"^[a-zA-Z0-9\-]{5,20}$");
        }

        #endregion

        #region Year Validation

        /// <summary>
        /// Validate car year (must be between 1900 and next year)
        /// </summary>
        /// <param name="year">Year to validate</param>
        /// <returns>True if valid car year, false otherwise</returns>
        public static bool IsValidCarYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            int minYear = 1900;
            int maxYear = currentYear + 1; // Allow next year models

            return year >= minYear && year <= maxYear;
        }

        /// <summary>
        /// Get the current year
        /// </summary>
        /// <returns>Current year as integer</returns>
        public static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }

        #endregion

        #region Input Parsing Helpers

        /// <summary>
        /// Safely parse string to integer
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <param name="result">Parsed integer (0 if parsing fails)</param>
        /// <returns>True if parsing successful, false otherwise</returns>
        public static bool TryParseInt(string value, out int result)
        {
            return int.TryParse(value, out result);
        }

        /// <summary>
        /// Safely parse string to decimal
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <param name="result">Parsed decimal (0 if parsing fails)</param>
        /// <returns>True if parsing successful, false otherwise</returns>
        public static bool TryParseDecimal(string value, out decimal result)
        {
            return decimal.TryParse(value, out result);
        }

        /// <summary>
        /// Safely parse string to DateTime
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <param name="result">Parsed DateTime (DateTime.MinValue if parsing fails)</param>
        /// <returns>True if parsing successful, false otherwise</returns>
        public static bool TryParseDateTime(string value, out DateTime result)
        {
            return DateTime.TryParse(value, out result);
        }

        #endregion

        #region Rental-Specific Validation

        /// <summary>
        /// Check if rental duration is within acceptable limits
        /// </summary>
        /// <param name="startDate">Rental start date</param>
        /// <param name="endDate">Rental end date</param>
        /// <param name="maxDays">Maximum allowed rental days (default 90)</param>
        /// <returns>True if duration is valid, false otherwise</returns>
        public static bool IsValidRentalDuration(DateTime startDate, DateTime endDate, int maxDays = 90)
        {
            int days = GetDaysBetween(startDate, endDate);
            return days >= 1 && days <= maxDays;
        }

        /// <summary>
        /// Calculate rental cost based on daily rate and date range
        /// </summary>
        /// <param name="startDate">Rental start date</param>
        /// <param name="endDate">Rental end date</param>
        /// <param name="dailyRate">Daily rental rate</param>
        /// <returns>Total rental cost</returns>
        public static decimal CalculateRentalCost(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            int days = GetDaysBetween(startDate, endDate);
            if (days < 1) days = 1; // Minimum 1 day charge

            return days * dailyRate;
        }

        #endregion

        #region Comparison Helpers

        /// <summary>
        /// Compare two strings ignoring case
        /// </summary>
        /// <param name="value1">First string</param>
        /// <param name="value2">Second string</param>
        /// <returns>True if strings are equal (case-insensitive), false otherwise</returns>
        public static bool AreEqualIgnoreCase(string value1, string value2)
        {
            if (value1 == null && value2 == null)
                return true;

            if (value1 == null || value2 == null)
                return false;

            return string.Equals(value1.Trim(), value2.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region Format Helpers

        /// <summary>
        /// Format currency value to string with 2 decimal places
        /// </summary>
        /// <param name="amount">Amount to format</param>
        /// <returns>Formatted currency string</returns>
        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2"); // e.g., $45.00
        }

        /// <summary>
        /// Format date to short date string (MM/dd/yyyy)
        /// </summary>
        /// <param name="date">Date to format</param>
        /// <returns>Formatted date string</returns>
        public static string FormatDate(DateTime date)
        {
            return date.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Format date to long date string (e.g., Monday, January 1, 2024)
        /// </summary>
        /// <param name="date">Date to format</param>
        /// <returns>Formatted date string</returns>
        public static string FormatDateLong(DateTime date)
        {
            return date.ToString("dddd, MMMM d, yyyy");
        }

        #endregion

        #region Sanitization

        /// <summary>
        /// Trim and clean string input
        /// </summary>
        /// <param name="value">String to clean</param>
        /// <returns>Cleaned string or empty string if null</returns>
        public static string SanitizeString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // Trim whitespace and remove multiple consecutive spaces
            return Regex.Replace(value.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Remove all non-digit characters from string
        /// </summary>
        /// <param name="value">String to clean</param>
        /// <returns>String containing only digits</returns>
        public static string GetDigitsOnly(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return Regex.Replace(value, @"[^\d]", "");
        }

        #endregion
    }

}

