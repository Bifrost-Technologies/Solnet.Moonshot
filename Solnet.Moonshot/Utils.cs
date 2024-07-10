using Solnet.Moonshot.Accounts;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Moonshot.Utils
{
    public static class PDALookup
    {
        /// <summary>
        /// Find the Metadata PDA from the mint address
        /// </summary>
        /// <param name="mintAddress"></param>
        /// <returns></returns>
        public static PublicKey FindCurvePDA(PublicKey mintAddress)
        {
            PublicKey.TryFindProgramAddress(new List<byte[]>()
            {
                Encoding.UTF8.GetBytes("token"),
            
                mintAddress
            },
            MoonshotProgram.programId,
            out PublicKey curveAccount,
            out _);

            return curveAccount;
        }
    }
}
