
![moonshot](https://github.com/user-attachments/assets/3aff7437-2e76-4444-b52f-ecf27b2c9bc4)

# Solnet.Moonshot
Solnet.Moonshot is a C# SDK & Client for the Moonshot on-chain program.

### Dependencies
- NET8
- Solnet.Rpc
- Solnet.Wallet
- Solnet.Programs

#### Search for the NET8 tag on nuget to find the latest versions of Solnet

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
