# Solnet.Moonshot
Solnet.Moonshot is a C# client implementation of the Moonshot on-chain program.

# Quick start example:
```
using Solnet.Rpc;
using Solnet.Wallet;
using PublicKey = Solnet.Wallet.PublicKey;
using Solnet.Moonshot;


var rpc = ClientFactory.GetClient(Cluster.MainNet);

MoonshotClient moonshotClient = new MoonshotClient(rpc);

Account botAccount = Account.FromSecretKey("SECRET_KEY_HERE");

PublicKey tokenAddress = new PublicKey("TOKEN_ADDRESS_HERE");

TradeOrder tradeOrder = new TradeOrder()
{
    Amount = 8860000000000,
    CollateralAmount = 5000000,
    SlippageBps = 100

};
string response = await moonshotClient.SendBuyAsync(botAccount, tokenAddress, tradeOrder);
Console.WriteLine(response);    
Console.ReadKey();


```
