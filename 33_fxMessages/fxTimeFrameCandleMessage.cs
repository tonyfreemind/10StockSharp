using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Ecng.Common;
using Ecng.Serialization;
using fx.Localization;
using StockSharp.Localization;
using StockSharp.Messages;

namespace fx.Messages
{	
    /// <summary>
    /// The message contains information about the time-frame candle.
    /// </summary>
    [System.Runtime.Serialization.DataContract]
	[Serializable]
	[DisplayNameLoc( fxLocalizedStrings.FreemindCandleKey )]
	public class fxTimeFrameCandleMessage : TimeFrameCandleMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TimeFrameCandleMessage"/>.
		/// </summary>
		public fxTimeFrameCandleMessage() : this( MessageTypes.CandleTimeFrame )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeFrameCandleMessage"/>.
		/// </summary>
		/// <param name="type">Message type.</param>
		protected fxTimeFrameCandleMessage( MessageTypes type ) : base( type )
		{
		}

		
		/// <summary>
		/// Batch Status
		/// </summary>
		[DataMember]

		public BatchStatus BatchStatus
		{
			get;
			set;
		}

		/// <summary>
		/// Create a copy of <see cref="TimeFrameCandleMessage"/>.
		/// </summary>
		/// <returns>Copy.</returns>
		public override Message Clone()
		{
			var newClone = new fxTimeFrameCandleMessage
			{
				TimeFrame = TimeFrame
			};

			var copy = ( fxTimeFrameCandleMessage ) CopyTo( newClone );
			copy.BatchStatus = this.BatchStatus;

			return copy;
		}

		#region TONY 06


		/// <summary>
		/// Turn into Readable text for the TimeSpan
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ToReadable( TimeSpan input )
		{
			if ( input == TimeSpan.FromDays( 30 ) )
			{
				return "Monthly";
			}
			else if ( input == TimeSpan.FromDays( 7 ) )
			{
				return "Weekly";
			}
			else if ( input == TimeSpan.FromDays( 1 ) )
			{
				return "Daily";
			}
			else if ( input == TimeSpan.FromHours( 8 ) )
			{
				return "08 Hrs";
			}
			else if ( input == TimeSpan.FromHours( 6 ) )
			{
				return "06 Hrs";
			}
			else if ( input == TimeSpan.FromHours( 4 ) )
			{
				return "04 Hrs";
			}
			else if ( input == TimeSpan.FromHours( 3 ) )
			{
				return "03 Hrs";
			}
			else if ( input == TimeSpan.FromHours( 2 ) )
			{
				return "02 Hrs";
			}
			else if ( input == TimeSpan.FromHours( 1 ) )
			{
				return "01 Hrs";
			}
			else if ( input == TimeSpan.FromMinutes( 60 ) )
			{
				return "60 Min";
			}
			else if ( input == TimeSpan.FromMinutes( 30 ) )
			{
				return "30 Min";
			}
			else if ( input == TimeSpan.FromMinutes( 15 ) )
			{
				return "15 Min";
			}
			else if ( input == TimeSpan.FromMinutes( 5 ) )
			{
				return "05 Min";
			}
			else if ( input == TimeSpan.FromMinutes( 1 ) )
			{
				return "01 Min";
			}
			else if ( input == TimeSpan.FromTicks( 1 ) )
			{
				return "Tick";
			}

			return ( "No supported" );
		}

		/// <summary>
		/// FXCM is my main trading platform and get its closing time
		/// </summary>
		/// <param name="date"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		public static DateTime GetFxcmBarCloseTime( DateTime date, TimeSpan period )
		{
			DateTime output = date + period;

			if ( period == TimeSpan.FromDays( 30 ) )
			{
				var newMonth = date.AddDays(1);
				output = new DateTime( newMonth.Year,
								   newMonth.Month,
								   DateTime.DaysInMonth( newMonth.Year, newMonth.Month ), newMonth.Hour, newMonth.Minute, newMonth.Second );
			}
			else if ( period == TimeSpan.FromDays( 7 ) )
			{
				int num_days = System.DayOfWeek.Friday - date.DayOfWeek;
				if ( num_days < 0 ) num_days += 7;

				output = date.AddDays( num_days );

			}
			else if ( period == TimeSpan.FromDays( 1 ) )
			{
				return ( date + period );
			}

			return output;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			var period = (TimeSpan)Arg;
			var closeTime = GetFxcmBarCloseTime(OpenTime.UtcDateTime, period);
			var periodString = ToReadable(period);

			var str = $"{Type},Sec={SecurityId},A={periodString}, C={closeTime:HH:mm:ss yyyy/MM/dd},O={OpenTime: HH:mm:ss.fff yyyy/MM/dd},O={OpenPrice},H={HighPrice},L={LowPrice},C={ClosePrice},V={TotalVolume},S={State},TransId={OriginalTransactionId}";

			if ( SeqNum != default )
				str += $",SQ={SeqNum}";

			return str;
		}

		#endregion
	}
}