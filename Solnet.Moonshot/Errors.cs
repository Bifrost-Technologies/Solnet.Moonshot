namespace Solnet.Moonshot
{
    public enum TokenLaunchpadErrorKind : uint
    {
        InsufficientBalance = 6000U,
        InvalidAmount = 6001U,
        InvalidSlippage = 6002U,
        SlippageOverflow = 6003U,
        ThresholdReached = 6004U,
        InvalidTokenAccount = 6005U,
        InvalidCurveAccount = 6006U,
        InvalidFeeAccount = 6007U,
        CurveLimit = 6008U,
        InvalidCurveType = 6009U,
        InvalidCurrency = 6010U,
        Arithmetics = 6011U,
        ThresholdNotHit = 6012U,
        InvalidAuthority = 6013U,
        TradeAmountTooLow = 6014U,
        ConfigFieldMissing = 6015U,
        DifferentCurrencies = 6016U,
        BasisPointTooHigh = 6017U,
        FeeShareTooHigh = 6018U,
        TokenDecimalsOutOfRange = 6019U,
        TokenNameTooLong = 6020U,
        TokenSymbolTooLong = 6021U,
        TokenURITooLong = 6022U,
        IncorrectDecimalPlacesBounds = 6023U,
        IncorrectTokenSupplyBounds = 6024U,
        TotalSupplyOutOfBounds = 6025U,
        FinalCollateralTooLow = 6026U,
        CoefficientZero = 6027U,
        MarketCapThresholdTooLow = 6028U,
        CoefBOutofBounds = 6029U,
        General = 6030U
    }
}
