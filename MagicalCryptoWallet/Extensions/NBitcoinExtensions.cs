using MagicalCryptoWallet.Models;
using System.Collections.Generic;

namespace NBitcoin
{
	public static class NBitcoinExtensions
	{
		public static byte[] ToByteArray(this FastBitArray me)
		{
			var byteCount = me.Length==0 ? 0 : (me.Length-1)/ 8 + 1;
			var bytes = new byte[byteCount];
			me.CopyTo(bytes, 0);
			return bytes;
		}

		public static TxoRef ToTxoRef(this OutPoint me) => new TxoRef(me);

		public static IEnumerable<TxoRef> ToTxoRefs(this TxInList me)
		{
			foreach (var input in me)
			{
				yield return input.PrevOut.ToTxoRef();
			}
		}
	}
}