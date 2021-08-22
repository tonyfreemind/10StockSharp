using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using IOPath = System.IO.Path;

using MoreLinq;

using Ecng.Collections;
using Ecng.Common;
using Ecng.Serialization;
using Ecng.ComponentModel;

using StockSharp.BusinessEntities;
using StockSharp.Messages;
using StockSharp.Localization;
using StockSharp.Logging;

namespace StockSharp.Algo.Storages
{
	/// <summary>
	/// 
	/// </summary>
    public static class AlgoGeneralHelper
    {
		/// <summary>
		/// Get the Creation time of the file storing the databars. If the file is too old, that means, the databars are not downloaded recently. We can delete it
		/// if the databars are not continuous.
		/// </summary>
		/// <param name="drive"></param>
		/// <param name="securityId"></param>
		/// <param name="dataType"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime GetFileCreationTime( this IMarketDataDrive drive, SecurityId securityId, DataType dataType, DateTime date )
		{
			var path = GetPath( drive, securityId, dataType, date.ChangeKind(DateTimeKind.Utc), true);

			if ( File.Exists( path ) )
			{
				return ( File.GetCreationTime( path ) );
			}

			return DateTime.MinValue;
		}

		/// <summary>
		/// Get the path for the databars of a certain date.
		/// </summary>
		/// <param name="drive"></param>
		/// <param name="dataType"></param>
		/// <param name="date"></param>
		/// <param name="isLoad"></param>
		/// <returns></returns>
		public static string GetPath( IMarketDataDrive drive, SecurityId securityId, DataType dataType, DateTime date, bool isLoad )
		{
			var secPath = GetSecurityPath( securityId );
			var drivePath = IOPath.Combine( drive.Path, secPath );

			var fileName = dataType.DataTypeToFileName();
			fileName += ".bin";

			var dataPath = IOPath.Combine( drivePath, date.ToString( "yyyy_MM_dd" ) );

			var fullPath = IOPath.Combine( dataPath, fileName);
			
			return fullPath;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataType"></param>
		/// <param name="format"></param>
		/// <param name="throwIfUnknown"></param>
		/// <returns></returns>
		public static string GetFileName( DataType dataType, StorageFormats? format = null, bool throwIfUnknown = true )
		{
			var fileName = dataType.DataTypeToFileName();

			if ( fileName == null )
			{
				if ( throwIfUnknown )
					throw new NotSupportedException( LocalizedStrings.Str2872Params.Put( dataType.ToString() ) );

				return null;
			}

			if ( fileName.Contains( "fx" ) )
            {

            }

			fileName = fileName.Replace( "fx", "" );

			if ( format != null )
				fileName += GetExtension( format.Value );

			return fileName;
		}

		/// <summary>
		/// To get the file extension for the format.
		/// </summary>
		/// <param name="format">Format.</param>
		/// <returns>The extension.</returns>
		public static string GetExtension( StorageFormats format )
		{
			switch ( format )
			{
				case StorageFormats.Binary:
					return ".bin";
				case StorageFormats.Csv:
					return ".csv";
				default:
					throw new ArgumentOutOfRangeException( nameof( format ), format, LocalizedStrings.Str1219 );
			}
		}

		public static string GetSecurityPath( SecurityId securityId )
		{
			var id = securityId == default ? TraderHelper.AllSecurity.Id : securityId.ToStringId();

			var folderName = id.SecurityIdToFolderName();

			return IOPath.Combine( folderName.Substring( 0, 1 ), folderName );
		}

		//public static string DataTypeToFileName( this DataType dataType )
		//{
		//	if ( dataType is null )
		//		throw new ArgumentNullException( nameof( dataType ) );

		//	if ( dataType.MessageType.IsCandleMessage() )
		//	{
		//		if ( _fileNames.TryGetValue( DataType.Create( dataType.MessageType, null ), out var fileName ) )
		//			return $"candles_{fileName}_{dataType.DataTypeArgToString()}";

		//		return null;
		//	}
		//	else
		//	{
		//		return _fileNames.TryGetValue( dataType );
		//	}
		//}
	}
}
