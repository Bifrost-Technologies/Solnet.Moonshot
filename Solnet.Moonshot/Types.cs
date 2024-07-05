using Solnet.Programs.Utilities;
using Solnet.Wallet;

namespace Solnet.Moonshot
{
    public partial class TokenMintParams
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Uri { get; set; }

        public byte Decimals { get; set; }

        public byte CollateralCurrency { get; set; }

        public ulong Amount { get; set; }

        public byte CurveType { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            offset += _data.WriteBorshString(Name, offset);
            offset += _data.WriteBorshString(Symbol, offset);
            offset += _data.WriteBorshString(Uri, offset);
            _data.WriteU8(Decimals, offset);
            offset += 1;
            _data.WriteU8(CollateralCurrency, offset);
            offset += 1;
            _data.WriteU64(Amount, offset);
            offset += 8;
            _data.WriteU8(CurveType, offset);
            offset += 1;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TokenMintParams result)
        {
            int offset = initialOffset;
            result = new TokenMintParams();
            offset += _data.GetBorshString(offset, out var resultName);
            result.Name = resultName;
            offset += _data.GetBorshString(offset, out var resultSymbol);
            result.Symbol = resultSymbol;
            offset += _data.GetBorshString(offset, out var resultUri);
            result.Uri = resultUri;
            result.Decimals = _data.GetU8(offset);
            offset += 1;
            result.CollateralCurrency = _data.GetU8(offset);
            offset += 1;
            result.Amount = _data.GetU64(offset);
            offset += 8;
            result.CurveType = _data.GetU8(offset);
            offset += 1;
            return offset - initialOffset;
        }
    }

    public partial class TradeParams
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

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TradeParams result)
        {
            int offset = initialOffset;
            result = new TradeParams();
            result.Amount = _data.GetU64(offset);
            offset += 8;
            result.CollateralAmount = _data.GetU64(offset);
            offset += 8;
            result.SlippageBps = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class ConfigParams
    {
        public PublicKey MigrationAuthority { get; set; }

        public PublicKey BackendAuthority { get; set; }

        public PublicKey ConfigAuthority { get; set; }

        public PublicKey HelioFee { get; set; }

        public PublicKey DexFee { get; set; }

        public ushort? FeeBps { get; set; }

        public byte? DexFeeShare { get; set; }

        public ulong? MigrationFee { get; set; }

        public ulong? MarketcapThreshold { get; set; }

        public byte? MarketcapCurrency { get; set; }

        public byte? MinSupportedDecimalPlaces { get; set; }

        public byte? MaxSupportedDecimalPlaces { get; set; }

        public ulong? MinSupportedTokenSupply { get; set; }

        public ulong? MaxSupportedTokenSupply { get; set; }

        public uint? CoefB { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            if (MigrationAuthority != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WritePubKey(MigrationAuthority, offset);
                offset += 32;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (BackendAuthority != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WritePubKey(BackendAuthority, offset);
                offset += 32;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (ConfigAuthority != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WritePubKey(ConfigAuthority, offset);
                offset += 32;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (HelioFee != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WritePubKey(HelioFee, offset);
                offset += 32;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (DexFee != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WritePubKey(DexFee, offset);
                offset += 32;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (FeeBps != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU16(FeeBps.Value, offset);
                offset += 2;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (DexFeeShare != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8(DexFeeShare.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MigrationFee != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(MigrationFee.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MarketcapThreshold != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(MarketcapThreshold.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MarketcapCurrency != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8(MarketcapCurrency.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MinSupportedDecimalPlaces != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8(MinSupportedDecimalPlaces.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MaxSupportedDecimalPlaces != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU8(MaxSupportedDecimalPlaces.Value, offset);
                offset += 1;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MinSupportedTokenSupply != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(MinSupportedTokenSupply.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (MaxSupportedTokenSupply != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU64(MaxSupportedTokenSupply.Value, offset);
                offset += 8;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (CoefB != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                _data.WriteU32(CoefB.Value, offset);
                offset += 4;
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ConfigParams result)
        {
            int offset = initialOffset;
            result = new ConfigParams();
            if (_data.GetBool(offset++))
            {
                result.MigrationAuthority = _data.GetPubKey(offset);
                offset += 32;
            }

            if (_data.GetBool(offset++))
            {
                result.BackendAuthority = _data.GetPubKey(offset);
                offset += 32;
            }

            if (_data.GetBool(offset++))
            {
                result.ConfigAuthority = _data.GetPubKey(offset);
                offset += 32;
            }

            if (_data.GetBool(offset++))
            {
                result.HelioFee = _data.GetPubKey(offset);
                offset += 32;
            }

            if (_data.GetBool(offset++))
            {
                result.DexFee = _data.GetPubKey(offset);
                offset += 32;
            }

            if (_data.GetBool(offset++))
            {
                result.FeeBps = _data.GetU16(offset);
                offset += 2;
            }

            if (_data.GetBool(offset++))
            {
                result.DexFeeShare = _data.GetU8(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.MigrationFee = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.MarketcapThreshold = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.MarketcapCurrency = _data.GetU8(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.MinSupportedDecimalPlaces = _data.GetU8(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.MaxSupportedDecimalPlaces = _data.GetU8(offset);
                offset += 1;
            }

            if (_data.GetBool(offset++))
            {
                result.MinSupportedTokenSupply = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.MaxSupportedTokenSupply = _data.GetU64(offset);
                offset += 8;
            }

            if (_data.GetBool(offset++))
            {
                result.CoefB = _data.GetU32(offset);
                offset += 4;
            }

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
