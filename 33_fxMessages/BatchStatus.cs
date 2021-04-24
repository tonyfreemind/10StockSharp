using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Ecng.Common;
using Ecng.Serialization;

using StockSharp.Localization;

namespace fx.Messages
{	
	/// <summary>
	/// Candle states.
	/// </summary>
	[System.Runtime.Serialization.DataContract]
	[Serializable]
	public enum BatchStatus : byte
	{
		/// <summary>
		/// Single Message
		/// </summary>
		[EnumMember]
		FromStorage,

		/// <summary>
		/// Message Batching Begin
		/// </summary>
		[EnumMember]
		BeginBatch,

		/// <summary>
		/// Still Batching
		/// </summary>
		[EnumMember]
		Batching,

		/// <summary>
		/// End of current Message Batch
		/// </summary>
		[EnumMember]
		EndBatch,

		/// <summary>
		/// End of current Message Batch
		/// </summary>
		[EnumMember]
		Latest,
	}
}