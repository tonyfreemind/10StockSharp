namespace fx.Messages
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Runtime.Serialization;

	using Ecng.Common;

	using StockSharp.Localization;
    using StockSharp.Messages;
    using DataType = StockSharp.Messages.DataType;



    /// <summary>
    /// The message containing the level1 market data.
    /// </summary>
    [DataContract]
	[Serializable]
	[DisplayNameLoc( LocalizedStrings.Level1Key )]
	[DescriptionLoc( LocalizedStrings.Level1MarketDataKey )]
	public class fxLevel1ChangeMessage : BaseChangeMessage<fxLevel1ChangeMessage, Level1Fields>, ISecurityIdMessage, ISeqNumMessage
	{
		/// <inheritdoc />
		[DataMember]
		[DisplayNameLoc( LocalizedStrings.SecurityKey )]
		[DescriptionLoc( LocalizedStrings.SecurityIdKey, true )]
		
		public SecurityId SecurityId { get; set; }

		/// <inheritdoc />
		[DataMember]
		public long SeqNum { get; set; }


		/* -------------------------------------------------------------------------------------------------------------------------------------------
		* 
		*  Tony 11: IsReloadFromServer
		* 
		* ------------------------------------------------------------------------------------------------------------------------------------------- */

		/// <inheritdoc />

		[DataMember]
		public bool IsReloadFromServer
		{
			get;
			set;
		}

		/// <inheritdoc />
		public override DataType DataType => DataType.Level1;

		/// <summary>
		/// Initializes a new instance of the <see cref="fxLevel1ChangeMessage"/>.
		/// </summary>
		public fxLevel1ChangeMessage() : base( MessageTypes.Level1Change )
		{
		}

		/// <inheritdoc />
		public override void CopyTo( fxLevel1ChangeMessage destination )
		{
			base.CopyTo( destination );

			destination.SecurityId = SecurityId;
			destination.SeqNum = SeqNum;

			/* -------------------------------------------------------------------------------------------------------------------------------------------
			* 
			*  Tony 11: IsReloadFromServer
			* 
			* ------------------------------------------------------------------------------------------------------------------------------------------- */

			destination.IsReloadFromServer = IsReloadFromServer;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			var str = base.ToString() + $",Sec={SecurityId},Changes={Changes.Select(c => c.ToString()).JoinComma()}";

			if ( SeqNum != default )
				str += $",SQ={SeqNum}";

			return str;
		}
	}
}