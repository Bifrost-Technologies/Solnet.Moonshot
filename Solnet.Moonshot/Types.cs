using Solnet.Programs.Utilities;
using Solnet.Wallet;

namespace Solnet.Moonshot
{
    public partial class TradeOrder
    {
        public ulong Amount { get; set; }

        public ulong CollateralAmount { get; set; }

        public ulong SlippageBps { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(Amount, offset);
            offset += 8;
            _data.WriteU64(CollateralAmount, offset);
            offset += 8;
            _data.WriteU64(SlippageBps, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TradeOrder result)
        {
            int offset = initialOffset;
            result = new TradeOrder();
            result.Amount = _data.GetU64(offset);
            offset += 8;
            result.CollateralAmount = _data.GetU64(offset);
            offset += 8;
            result.SlippageBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public enum Currency : byte
    {
        Sol
    }

    public enum CurveType : byte
    {
        LinearV1
    }
}
