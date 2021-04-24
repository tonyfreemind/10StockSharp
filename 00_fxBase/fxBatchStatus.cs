using System;
using System.Collections.Generic;
using System.Text;

namespace fx.Base
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Candle states.
	/// </summary>
	[System.Runtime.Serialization.DataContract]
	[Serializable]
	public enum fxBatchStatus : byte
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
