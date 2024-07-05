# Solnet.Moonshot
Solnet.Moonshot is a C# client implementation of the Moonshot on-chain program. 



### Available public instructions:

Buy 

Sell

### Private instructions that require backend authority or migration authority from Dexscreener:

Mint

MigrateFunds

Config

# Quick start example:
```
using Solnet.Rpc;
using Solnet.Wallet;
using PublicKey = Solnet.Wallet.PublicKey;
using Solnet.Moonshot;

var rpc = ClientFactory.GetClient(Cluster.MainNet);

Account botAccount = Account.FromSecretKey("PRIVATE_KEY_HERE");

MoonshotClient moonshotClient = new MoonshotClient(rpc);
//Everything required in the instruction keys can be found in an existing buy/sell transaction. Buy or sell through dexscreener then copy the data from the TX on solscan to fill in the object properties for a specific moonshot
BuyAccounts buyAccounts = new BuyAccounts()
{
    Sender = new PublicKey("CHANGE_TO_YOUR_WALLET_ADDRESS"),
    SenderTokenAccount = new PublicKey("CHANGE_TO_YOUR_ASSOCIATED_TOKEN_ADDRESS"),
    CurveAccount = new PublicKey("CHANGE_TO_CURVE_ACCOUNT_ADDRESS"),
    CurveTokenAccount = new PublicKey("CHANGE_TO_CURVE_TOKEN_ACCOUNT_ADDRESS"),
    DexFee = new PublicKey("CHANGE_TO_DEX_FEE_ADDRESS"),
    HelioFee = new PublicKey("CHANGE_TO_HELIO_FEE_ADDRESS"),
    Mint = new PublicKey("CHANGE_TO_TOKEN_ADDRESS"),
    ConfigAccount = new PublicKey("CHANGE_TO_TOKEN_CONFIG_ADDRESS"),
    TokenProgram = new PublicKey("TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA"),
    AssociatedTokenProgram = new PublicKey("ATokenGPvbdGVxr1b2hvZbsiqW5xWH25efTNsLJA8knL"),
    SystemProgram = new PublicKey("11111111111111111111111111111111")

};
ulong token_amount = 10000;
ulong SOL_AMOUNT_AS_LAMPORTS = 5000000; //0.005 sol

TradeParams tParams = new TradeParams()
{
    Amount = token_amount * (ulong)1000000000,
    CollateralAmount = SOL_AMOUNT_AS_LAMPORTS,
    SlippageBps = 100

};

 
string signedTX = moonshotClient.SendBuyAsync(buyAccounts, tParams, botAccount.PublicKey, botAccount).Result;
var response = await rpc.SendTransactionAsync(Convert.FromBase64String(signedTX));

Console.WriteLine(response.Result);

```
