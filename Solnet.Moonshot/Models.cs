using Solnet.Wallet;

namespace Solnet.Moonshot
{
    public class TokenMintAccounts
    {
        public PublicKey Sender { get; set; }

        public PublicKey BackendAuthority { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey Mint { get; set; }

        public PublicKey MintMetadata { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey ConfigAccount { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey AssociatedTokenProgram { get; set; }

        public PublicKey MplTokenMetadata { get; set; }

        public PublicKey SystemProgram { get; set; }
    }

    public class BuyAccounts
    {
        public PublicKey Sender { get; set; }

        public PublicKey SenderTokenAccount { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey DexFee { get; set; }

        public PublicKey HelioFee { get; set; }

        public PublicKey Mint { get; set; }

        public PublicKey ConfigAccount { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey AssociatedTokenProgram { get; set; }

        public PublicKey SystemProgram { get; set; }
    }

    public class SellAccounts
    {
        public PublicKey Sender { get; set; }

        public PublicKey SenderTokenAccount { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey DexFee { get; set; }

        public PublicKey HelioFee { get; set; }

        public PublicKey Mint { get; set; }

        public PublicKey ConfigAccount { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey AssociatedTokenProgram { get; set; }

        public PublicKey SystemProgram { get; set; }
    }

    public class MigrateFundsAccounts
    {
        public PublicKey BackendAuthority { get; set; }

        public PublicKey MigrationAuthority { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey MigrationAuthorityTokenAccount { get; set; }

        public PublicKey Mint { get; set; }

        public PublicKey ConfigAccount { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey TokenProgram { get; set; }

        public PublicKey AssociatedTokenProgram { get; set; }
    }

    public class ConfigInitAccounts
    {
        public PublicKey ConfigAuthority { get; set; }

        public PublicKey ConfigAccount { get; set; }

        public PublicKey SystemProgram { get; set; }
    }

    public class ConfigUpdateAccounts
    {
        public PublicKey ConfigAuthority { get; set; }

        public PublicKey ConfigAccount { get; set; }
    }
}
