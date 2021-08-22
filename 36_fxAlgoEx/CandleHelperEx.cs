using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StockSharp.Algo.Candles
{
    /// <summary>
    /// 
    /// </summary>
    public static class CandleHelperEx
    {
		#region Tony 02

		/// <summary>
		/// Tony: Get last day of the month
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static DateTime GetLastDayOfMonth( this DateTime dateTime )
		{
			return new DateTime( dateTime.Year, dateTime.Month, DateTime.DaysInMonth( dateTime.Year, dateTime.Month ), dateTime.Hour, dateTime.Minute, dateTime.Second, DateTimeKind.Utc );
		}
		/// <summary>
		/// Tony: Since FXCM store the daily, weekly, month bar begin time from the previous days's close 
		/// </summary>
		/// <param name="anyDate"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		public static DateTime GetFxcmBarOpenTime( DateTime anyDate, TimeSpan period )
		{
			DateTime output = anyDate;

			if ( period == TimeSpan.FromDays( 30 ) )
			{
				// last day of previous month
				var firstDayCurrentMonth = new DateTime(anyDate.Year, anyDate.Month, 1, anyDate.Hour, anyDate.Minute, anyDate.Second, DateTimeKind.Utc);
				output = firstDayCurrentMonth.AddDays( -1 );
			}
			else if ( period == TimeSpan.FromDays( 7 ) )
			{
				int diff = (7 + (anyDate.DayOfWeek - DayOfWeek.Saturday)) % 7;
				output = anyDate.AddDays( -1 * diff ).Date;
			}
			else if ( period == TimeSpan.FromDays( 1 ) )
			{
				return anyDate.AddDays( -1 );
			}

			return output;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="barOpenTime"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		public static DateTime GetFxcmBarCloseTimeByOpen( DateTime barOpenTime, TimeSpan period )
		{
			DateTime output = barOpenTime;

			if ( period == TimeSpan.FromDays( 30 ) )
			{
				var sameMonth = output.AddDays(1);
				output = new DateTime( sameMonth.Year, sameMonth.Month, DateTime.DaysInMonth( sameMonth.Year, sameMonth.Month ), sameMonth.Hour, sameMonth.Minute, sameMonth.Second, DateTimeKind.Utc );
			}
			else if ( period == TimeSpan.FromDays( 7 ) )
			{
				int num_days = System.DayOfWeek.Friday - barOpenTime.DayOfWeek;
				if ( num_days < 0 ) num_days += 7;

				output = barOpenTime.AddDays( num_days );
			}
			else if ( period == TimeSpan.FromDays( 1 ) )
			{
				return ( barOpenTime + period );
			}
			else
			{
				output = barOpenTime + period;
			}

			return output;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="barCloseTime"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		public static DateTime GetFxcmBarCloseTime( DateTime barCloseTime, TimeSpan period )
		{
			DateTime output = barCloseTime;

			if ( period == TimeSpan.FromDays( 30 ) )
			{
				var sameMonth = barCloseTime;
				output = new DateTime( sameMonth.Year, sameMonth.Month, DateTime.DaysInMonth( sameMonth.Year, sameMonth.Month ), sameMonth.Hour, sameMonth.Minute, sameMonth.Second, DateTimeKind.Utc );
			}
			else if ( period == TimeSpan.FromDays( 7 ) )
			{
				//int num_days = System.DayOfWeek.Friday - barCloseTime.DayOfWeek;
				//if ( num_days < 0 ) num_days += 7;

				output = LastWorkingDayOfWeek( barCloseTime );
			}
			else if ( period == TimeSpan.FromDays( 1 ) )
			{
				return ( barCloseTime );
			}
			else
			{
				output = barCloseTime;
			}

			return output;
		}

		/// <summary>
		/// Get the first Day of the Week
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime FirstDayOfWeek( DateTime date )
		{
			DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
			int offset = fdow - date.DayOfWeek;
			DateTime fdowDate = date.AddDays(offset);
			return fdowDate;
		}


		/// <summary>
		/// Return the last working day of the week. Normally it is the Friday of the week.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime LastWorkingDayOfWeek( DateTime date )
		{
			DateTime ldowDate = FirstDayOfWeek(date).AddDays(5);
			return ldowDate;
		}
		#endregion


	}
}
