using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_cyberpunk_challenge_3.malware;
using dotnet_cyberpunk_challenge_3.malware.lib._lib;

namespace dotnet_cyberpunk_challenge_3
{
    public static class Handler
    {
        public static async Task StartTheChallenges(){
            /*
                OBJECTIVE: We've learned that Militech has just stolen a number of files from
                Arasaka and while that's great we also want our hands on those files. We can't
                break into Militech YET. 
                
                First we need you to adapt the Kuang malware we used on Arasaka to also be able
                to attack Militech without losing any capability to attack Arasaka either. The
                trick is to make the Kuang malware generic enough that can we spin up an attack
                process for both of them at a moment's notice.

                Couple concepts you'll need to remember from your recent adventures:
                - Async/await and how the `Task` datatype works
                - Generics
                - Abstraction (hiding all the super complicated stuff, like we're doing in the path
                 `lib/_lib/`)
                - Remember we're talking with an actual API and getting data back. Feel free to
                explore "under the hood" in the functions in _lib/

                Good luck!
            */
            await challenge1();
            await challenge2();
            await challenge3();
        }

        // TODO: Next it maks sense to go swap out ArasakaServerConnection for a generic 
        // ServerConnection object that we can use and pass in either Arasaka or Militech to determine
        // which it will be. We already have the MilitechMessage classes in `_HttpResponseModels.cs`
        /*
            1. Genericize the ArasakaServerConnection to be ServerConnection<T>
            2. Genericize the KuangMalwareFamily so it's not using any of the Arasaka stuff
            
        */

        public static async Task challenge1() {
            // FIXME: Mentor note
            // Need to genericize the Server Connection
            ArasakaKuangPrimusMalware arasakaIceBreaker = new ArasakaKuangPrimusMalware();
            await arasakaIceBreaker.Initialize();

            MilitechKuangPrimusMalware militechIceBreaker = new MilitechKuangPrimusMalware();
            await militechIceBreaker.Initialize();
        }

        public static async Task challenge2() {
            // FIXME: Mentor note
            // Need to adapt the existing ArasakaKuangPrimusMalware and MilitechKuangPrimusMalware to use
            // the generic ServerConnection

            // TODO: We need to go investigate the existing KuangGradeElevenMalware and start
            // swapping functions/properties so the wording is generic, i.e. remove any mention
            // of Arasaka

            ArasakaKuangPrimusMalware arasakaIceBreaker = new ArasakaKuangPrimusMalware();
            await arasakaIceBreaker.Initialize();
            List<ArasakaMessageProcessList> arasakaProcessList = await arasakaIceBreaker.GetArasakaProcessList();
            IEnumerable<string> arasakaMemoryMapping = await arasakaIceBreaker.GetProcessMemoryMapping();

            MilitechKuangPrimusMalware militechIceBreaker = new MilitechKuangPrimusMalware();
            await militechIceBreaker.Initialize();
            List<MilitechICEProcessList> militechProcessLists = await militechIceBreaker.GetMilitechProcessList();
            IEnumerable<string> militechMemoryMapping = await militechIceBreaker.GetProcessMemoryMapping();
        }

        public static async Task challenge3() {
            // FIXME: Mentor note
            // Need to create a new class, simply the KuangPrimusMalware.cs, which is genericized
            // from the existing Arasaka and Militech variants.
        }
    }
}