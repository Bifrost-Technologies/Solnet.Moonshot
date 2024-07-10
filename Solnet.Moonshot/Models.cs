using Solnet.Wallet;

namespace Solnet.Moonshot
{
   
    public class BuyAccounts
    {
        public PublicKey Sender { get; set; }

        public PublicKey SenderTokenAccount { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey Mint { get; set; }


    }

    public class SellAccounts
    {
        public PublicKey Sender { get; set; }

        public PublicKey SenderTokenAccount { get; set; }

        public PublicKey CurveAccount { get; set; }

        public PublicKey CurveTokenAccount { get; set; }

        public PublicKey Mint { get; set; }


    }

 
}
