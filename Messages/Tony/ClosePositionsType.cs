using System;
using System.Collections.Generic;
using System.Text;

namespace StockSharp.Messages
{
	/// <summary>
	/// Tony 05: close the Positions of the following types
	/// </summary>
	public enum ClosePositionsType
	{
		/// <summary>
		/// Close All Positions
		/// </summary>
		All = 0,
		/// <summary>
		/// Close All Lossing Positions
		/// </summary>
		Lossing = 1,
		/// <summary>
		/// Close All Winning Positions
		/// </summary>
		Winning = 2,
		/// <summary>
		/// Close All Long
		/// </summary>
		Long = 3,
		/// <summary>
		/// Close All Short
		/// </summary>
		Short = 4,
		/// <summary>
		/// Close All Hedge for Long Positions
		/// </summary>
		LongHedge = 5,
		/// <summary>
		/// Close All Hedge for Short Positions
		/// </summary>
		ShortHedge = 6,
		/// <summary>
		/// Close All Winning Hedge for Positions
		/// </summary>
		WinningHedge = 7,
		/// <summary>
		/// Close All Lossing Hedge for Positions
		/// </summary>
		LossingHedge = 8,
		/// <summary>
		/// Close All Hedge for Positions
		/// </summary>
		AllHedge = 9
	}
}
